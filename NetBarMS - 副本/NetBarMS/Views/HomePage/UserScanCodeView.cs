using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools;
using System.IO;
using NetBarMS.Codes.Tools.FlowManage;
using NetBarMS.Views.Message;
using System.Net;
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS.Views.HomePage
{
    /// <summary>
    /// 用户充值页面(直接充值、办理会员时充值。激活金额不足充值)
    /// </summary>
    public partial class UserScanCodeView : RootFormView
    {

        private StructCard rechargeCard;       //需要充值的身份证信息
        private FLOW_STATUS flowstatus = FLOW_STATUS.NONE_STATUS;     //流程状态判断返回的状态
        private PRECHARGE_TYPE prechargeType;           //充值类型（是否办理会员）
        private int recharge;               //充值的金额

        #region 初始化方法
        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="card">身份证信息</param>
        /// <param name="money">充值金额</param>
        /// <param name="offical">是否办理会员</param>
        public UserScanCodeView(StructCard card,int money, PRECHARGE_TYPE offical)
        {
            InitUI(card, money, FLOW_STATUS.NORMAL_STATUS,offical);
        }
        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="card">身份证号</param>
        /// <param name="money">充值金额</param>
        /// <param name="status">流程状态</param>
        /// <param name="offical">是否办理会员</param>
        public UserScanCodeView(StructCard card, int money,FLOW_STATUS status, PRECHARGE_TYPE offical)
        {
            InitUI(card,money,status,offical);
        }
        //初始化UI
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="card">身份证信息</param>
        /// <param name="money">充值金额</param>
        /// <param name="status">流程</param>
        /// <param name="offical">是否办理会员</param>
        private void InitUI(StructCard card, int money, FLOW_STATUS status, PRECHARGE_TYPE offical)
        {
            InitializeComponent();
            this.titleLabel.Text = "用户充值";
            this.recharge = money;
            this.prechargeType = offical;
            this.rechargeCard = new StructCard.Builder(card).Build();
            this.flowstatus = status;

            //如果进入充值。进入充值入口
            if(status == FLOW_STATUS.NORMAL_STATUS){BeginRecharge();}
            //直接获取二维码
            else {GetRechargeCode();}


        }

        #endregion

        #region 充值入口
        //开始充值的入口
        private void BeginRecharge()
        {
            MemberNetOperation.BeiginRecharge(BeginRechargeResult, this.rechargeCard.Number);
        }
        //充值入口回调
        private void BeginRechargeResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_EMK_RECHARGE)
            {
                return;
            }
            System.Console.WriteLine("BeginRechargeResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(BeginRechargeResult);

            //充值成功关闭窗口
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {
                    this.CloseFormClick();
                }));
            }
            else
            {

                FLOW_ERROR error = FLOW_ERROR.OTHER;
                Enum.TryParse<FLOW_ERROR>(result.pack.Content.ErrorTip.Key, out error);
                switch (error)
                {
                    //需要添加身份证信息
                    case FLOW_ERROR.NEED_ADD_CARD:
                        AddCardInfo();
                        break;
                    //用户锁定
                    case FLOW_ERROR.USER_LOCK:
                        {
                            this.Invoke(new RefreshUIHandle(delegate
                            {
                                MessageBox.Show("该用户已经被锁");
                                this.CloseFormClick();
                            }));
                           
                        }
                        break;
                        //需要充值，获取二维码
                    case FLOW_ERROR.NEED_RECHARGE:
                        {
                            GetRechargeCode();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region 获取充值二维码和充值结果的回调
        private void GetRechargeCode()
        {
            HomePageNetOperation.GetRechargeCode(GetRechargeCodeResult, this.rechargeCard.Number, recharge, 0, (int)this.prechargeType);
        }
       
        //获取充值二维码几个回调
        private void GetRechargeCodeResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_PRECHARGE)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetRechargeCodeResult);
            //System.Console.WriteLine("GetRechargeCodeResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                //获取充值结果
                this.Invoke(new RefreshUIHandle(delegate {
                    //获取充值结果
                    NetMessageManage.AddResultBlock(GetRechargeResult);
                    string wxCode = result.pack.Content.ScPreCharge.Qrcode;
                    try
                    {
                        using (Stream stream = WebRequest.Create(wxCode).GetResponse().GetResponseStream())
                        {
                            this.pictureEdit1.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("图片链接出错");
                    }

                }));
            }
            else
            {
                //获取充值结果
                this.Invoke(new RefreshUIHandle(delegate {
                    MessageBox.Show("获取二维码失败");
                    this.CloseFormClick();
                }));
            }

        }
        //获取充值结果回调
        private void GetRechargeResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_TOCHARGE)
            {
                return;
            }
            System.Console.WriteLine("GetRechargeResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(GetRechargeResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {

                    SCToCharge charge = result.pack.Content.CsToCharge;
                    string msg = string.Format("充值成功！\n本次充值{0}元，赠送{1}元，赠送{2}积分", charge.Recharge, charge.Bonus, charge.Integal);
                    MessageBox.Show(msg);

                    //正常充值流程继续调入口
                    if (this.flowstatus == FLOW_STATUS.NORMAL_STATUS)
                    {
                        BeginRecharge();
                    }
                    //其他则进行关闭
                    else
                    {
                        if (this.flowstatus == FLOW_STATUS.ACTIVE_STATUS)
                        {
                            ActiveFlowManage.ActiveFlow().MemberPaySuccess();
                        }
                        this.CloseFormClick();
                    }

                }));
            }
            else
            {
                this.Invoke(new RefreshUIHandle(delegate
                {

                    MessageBox.Show("充值失败");
                    //if (this.flowstatus == FLOW_STATUS.ACTIVE_STATUS)
                    //{
                    //    ActiveFlowManage.ActiveFlow().MemberPaySuccess();
                    //}
                    this.CloseFormClick();
                }));
            }
        }
        #endregion

        #region 添加身份证信息（添加临时会员）
        private void AddCardInfo()
        {
            MemberNetOperation.AddCardInfo(AddCardInfoResult, rechargeCard);
        }
        //添加身份证信息回调
        private void AddCardInfoResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_EMK_ADD_CARDINFO)
            {
                return;
            }
            //System.Console.WriteLine("AddCardInfoResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(AddCardInfoResult);
            if (result.pack.Content.MessageType == 1)
            {
                BeginRecharge();
            }
        }
        #endregion

       



    }
}
