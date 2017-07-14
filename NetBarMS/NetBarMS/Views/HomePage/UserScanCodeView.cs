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

namespace NetBarMS.Views.HomePage
{
    /// <summary>
    /// 用户充值页面
    /// </summary>
    public partial class UserScanCodeView : RootUserControlView
    {

        private string cardNum = "";        //身份证号
        private int recharge;               //充值的金额
        PRECHARGE_TYPE prechargeType;           //充值类型（是否办理会员）
        private FLOW_STATUS flowstatus = FLOW_STATUS.NONE_STATUS;     //流程状态判断返回的状态

        #region 初始化方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="card">身份证号</param>
        /// <param name="money">充值金额</param>
        /// <param name="offical">是否办理会员</param>
        public UserScanCodeView(string card,int money, PRECHARGE_TYPE offical)
        {
            InitUI(card, money, FLOW_STATUS.NORMAL_STATUS,offical);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="card">身份证号</param>
        /// <param name="money">充值金额</param>
        /// <param name="status">流程状态</param>
        /// <param name="offical">是否办理会员</param>
        public UserScanCodeView(string card, int money,FLOW_STATUS status, PRECHARGE_TYPE offical)
        {
            InitUI(card,money,status,offical);
        }
        //初始化UI
        private void InitUI(string card, int money, FLOW_STATUS status, PRECHARGE_TYPE offical)
        {
            InitializeComponent();
            this.titleLabel.Text = "用户充值";
            this.cardNum = card;
            this.recharge = money;
            this.prechargeType = offical;

            this.flowstatus = status;

            //如果进入充值。进入充值入口
            if(status == FLOW_STATUS.NORMAL_STATUS)
            {
                BeginRecharge();

            }
            else
            {
                GetRechargeCode();
                //获取充值结果
                //HomePageNetOperation.GetRecharge(GetRechargeResult);
            }



        }

        #endregion
        //获取二维码
        private void GetRechargeCode()
        {
            HomePageNetOperation.GetRechargeCode(GetRechargeCodeResult, cardNum, recharge, 0, (int)this.prechargeType);
        }
        private void BeginRecharge()
        {
            MemberNetOperation.BeiginRecharge(BeginRechargeResult, this.cardNum);
        }
        private void BeginRechargeResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_EMK_RECHARGE)
            {
                return;
            }
            System.Console.WriteLine("BeginRechargeResult:"+result.pack);
            NetMessageManage.RemoveResultBlock(BeginRechargeResult);

            FLOW_ERROR error = FLOW_ERROR.OTHER;
            Enum.TryParse<FLOW_ERROR>(result.pack.Content.ErrorTip.Key, out error);

            if (result.pack.Content.MessageType == 1 || error == FLOW_ERROR.NEED_RECHARGE)
            {
                GetRechargeCode();
            }
            else
            {
              
                switch (error)
                {
                    case FLOW_ERROR.NEED_ADD_CARD:
                        AddCardInfo();
                        break;
                    default:
                        break;
                }
            }
        }
        #region 添加身份证信息（添加临时会员）
        private void AddCardInfo()
        {
            string cardNum = this.cardNum;
            StructCard.Builder structcard = new StructCard.Builder()
            {
                Name = "xx22",
                Gender = 1,
                Nation = "2112",
                Number = cardNum,
                Birthday = "2012-09-01",
                Address = "海南省",
                Organization = "海南",
                HeadUrl = "#dasdasd#",
                Vld = "",
            };

            MemberNetOperation.AddCardInfo(AddCardInfoResult, structcard.Build());

        }
        //添加身份证信息回调
        private void AddCardInfoResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_EMK_ADD_CARDINFO)
            {
                return;
            }
            System.Console.WriteLine("AddCardInfoResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(AddCardInfoResult);
            if (result.pack.Content.MessageType == 1)
            {
                BeginRecharge();
            }
        }
        #endregion

        #region 获取充值二维码和充值结果的回调
        //获取充值二维码
        private void GetRechargeCodeResult(ResultModel result)
        {

            if(result.pack.Cmd != Cmd.CMD_PRECHARGE)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetRechargeCodeResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    try
                    {
                        System.Console.WriteLine("GetRechargeCodeResult:" + result.pack);
                        string wxCode = result.pack.Content.ScPreCharge.Qrcode;
                        string url = IdTools.IMG_HEADER + wxCode;
                        //TODO:服务器没开引起崩溃
                        Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream();
                        this.pictureEdit1.Image = Image.FromStream(stream);

                        //TODO:暂时显示充值成功
                        //充值成功，显示充值成功的界面9
                        CloseFormHandle handle = new CloseFormHandle(delegate {
                            if (this.flowstatus == FLOW_STATUS.ACTIVE_STATUS)
                            {
                                ActiveFlowManage.ActiveFlow().MemberPaySuccess();
                            }
                            this.CloseFormClick();
                        });
                        UserPayResultView view = new UserPayResultView();
                        ToolsManage.ShowForm(view, false, handle);

                    }
                    catch (System.ArgumentException exc)
                    {
                        System.Console.WriteLine("exc:"+exc.ToString());

                    }
            


                }));
            }

        }
        //获取充值结果
        private void GetRechargeResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_PREBUY)
            {
                return;
            }
            System.Console.WriteLine("GetRechargeResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(GetRechargeResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate 
                {
                    //充值成功，显示充值成功的界面9
                    CloseFormHandle handle = new CloseFormHandle(delegate {                      
                        if(this.flowstatus == FLOW_STATUS.ACTIVE_STATUS)
                        {
                            ActiveFlowManage.ActiveFlow().MemberPaySuccess();
                        }
                        this.FindForm().Close();
                    });
                    UserPayResultView view = new UserPayResultView();
                    ToolsManage.ShowForm(view,false,handle);
                }));
            }
        }
        #endregion
    }
}
