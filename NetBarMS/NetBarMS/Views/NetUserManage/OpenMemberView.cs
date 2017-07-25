#define PRODUCT
#region using
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
using DevExpress.XtraEditors.Controls;
using NetBarMS.Views.ResultManage;
using NetBarMS.Forms;
using NetBarMS.Views.HomePage;
using NetBarMS.Codes.Tools.FlowManage;
using NetBarMS.Codes.Model;
using NetBarMS.Codes.Tools.Manage;
using System.IO;
#endregion

namespace NetBarMS.Views.NetUserManage
{
    public partial class OpenMemberView : RootUserControlView
    {
        private enum TitleList{
            None = 0,
            Type,
            PayMoney,
            GiveMoney,
        }
       
        private List<MemberTypeModel> memberTypes;       //会员类别数组
        private int memberIndex = -1;                   //当前会员类别索引
        private FLOW_STATUS flowstatus = FLOW_STATUS.NONE_STATUS;                 //判断返回的状态
        private char[] sp = { '：', ':' };
        private StructCard openCard;            //需要开通会员的身份证信息

        #region 初始化方法
       /// <summary>
       /// 声明开通会员（激活时进入。不监听读卡）
       /// </summary>
       /// <param name="status"></param>
       /// <param name="card"></param>
        public OpenMemberView(FLOW_STATUS status, StructCard card)
        {
            InitializeComponent();
            this.flowstatus = status;
            InitUI(card);
        }
        /// <summary>
        /// 直接进入开通会员界面
        /// </summary>
        /// <param name="card">若card为null自动生成card</param>
        public OpenMemberView(StructCard card)
        {
            InitializeComponent();
            if(card == null)
            {
                StructCard.Builder newcard = new StructCard.Builder()
                {
                    Name = "xx22",
                    Gender = 1,
                    Nation = "2112",
                    Number = ToolsManage.RandomCard,
                    Birthday = "2012-09-01",
                    Address = "海南省",
                    Organization = "海南",
                    Head = "#dasdasd#",
                    Vld = "",
                };
                Bitmap b = Imgs.test;
                string inputString = ToolsManage.BitmapToDataSring(b);
                newcard.Head = inputString;
                InitUI(newcard.Build());

            }
            else
            {
                InitUI(card);
                IdCardReaderManage.ReadCard(ReadCardResult, null, null);
            }
            
        }
        #endregion

#if PRODUCT
        #region 关闭重写
        protected override void RootUserControlView_Disposed(object sender, EventArgs e)
        {
            IdCardReaderManage.OffCardReader(ReadCardResult, null, null);
            base.RootUserControlView_Disposed(sender, e);
        }
        #endregion
#endif

#region 初始化UI
        private void InitUI(StructCard card)
        {
            this.openCard = new StructCard.Builder(card).Build();

            //初始化Label
            char[] sp = { ':', '：' };
            this.nameLabel.Text = string.Format("{0}：{1}", this.nameLabel.Text.Split(sp)[0], this.openCard.Name);
            this.genderLabel.Text = string.Format("{0}：{1}", this.genderLabel.Text.Split(sp)[0], this.openCard.Gender);
            this.nationLabel.Text = string.Format("{0}：{1}", this.nationLabel.Text.Split(sp)[0], this.openCard.Nation);
            this.cardTypeLabel.Text = string.Format("{0}：{1}", this.cardTypeLabel.Text.Split(sp)[0], "身份证");
            this.cardNumLabel.Text = string.Format("{0}：{1}", this.cardNumLabel.Text.Split(sp)[0], this.openCard.Number);
            this.addressLabel.Text = string.Format("{0}：{1}", this.addressLabel.Text.Split(sp)[0], this.openCard.Address);
            this.organLabel.Text = string.Format("{0}：{1}", this.organLabel.Text.Split(sp)[0], this.openCard.Organization);
            this.countryLabel.Text = string.Format("{0}：{1}", this.countryLabel.Text.Split(sp)[0], "中国");
            this.birthdayLabel.Text = string.Format("{0}：{1}", this.birthdayLabel.Text.Split(sp)[0], this.openCard.Birthday);
            this.cardValidityLabel.Text = string.Format("{0}：{1}", this.cardValidityLabel.Text.Split(sp)[0], this.openCard.Vld);
            MemoryStream ms = new MemoryStream(System.Convert.FromBase64String(this.openCard.Head));
            this.pictureEdit1.Image = Image.FromStream(ms);


            if(this.mainDataTable == null)
            {
                //先接受数据
                this.memberTypes = SysManage.MemberTypes;
                //初始化GridControl
                ToolsManage.SetGridView(this.gridView1, GridControlType.OpenMember, out this.mainDataTable);
                this.gridControl1.DataSource = this.mainDataTable;
                RefreshGridControl();
            }
            //隐藏按钮可点击
            this.simpleButton1.Enabled = false;
            this.simpleButton2.Enabled = false;
            this.moneyTextEdit.Text = "";

            //开通会员入口
            OpenMember();
        }

        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            foreach (MemberTypeModel model in this.memberTypes)
            {
                DataRow row = this.mainDataTable.NewRow();
                this.mainDataTable.Rows.Add(row);
                row[TitleList.Type.ToString()] = model.typeName;
                row[TitleList.PayMoney.ToString()] = model.payMoney;
            }
        }
#endregion

#region 添加身份证信息。（临时会员）
        private void AddCardInfo()
        {
            MemberNetOperation.AddCardInfo(AddCardInfoResult, this.openCard);
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
                OpenMember();
            }

        }
#endregion

#region 开通会员入口-进行充值
        private void OpenMember()
        {
            MemberNetOperation.OpenMember(OpenMemberResult, this.openCard.Number);
        }

        //开通会员入口回调
        private void OpenMemberResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_EMK_APPLY_MEMBER)
            {
                return;
            }

            System.Console.WriteLine("OpenMemberResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(OpenMemberResult);
            FLOW_ERROR error = FLOW_ERROR.OTHER;
            Enum.TryParse<FLOW_ERROR>(result.pack.Content.ErrorTip.Key, out error);

            //办理完成
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate ()
                {
                    //将按钮回复可以点击
                    this.simpleButton1.Enabled = false;
                    this.simpleButton2.Enabled = true;
                }));
            }
            else
            {
                switch (error)
                {
                    //需要添加身份证信息
                    case FLOW_ERROR.NEED_ADD_CARD:
                        AddCardInfo();
                        break;
                        //被锁
                    case FLOW_ERROR.USER_LOCK:
                        MessageBox.Show("该用户已经被锁");
                        break;
                        //需要充值
                    case FLOW_ERROR.NEED_RECHARGE:
                        {
                            this.Invoke(new RefreshUIHandle(delegate ()
                            {
                                //将按钮回复可以点击
                                this.simpleButton1.Enabled = true;
                            }));
                        }
                        break;
                        //已经是会员
                    case FLOW_ERROR.IS_MEMBER:
                        {
                            this.Invoke(new RefreshUIHandle(delegate ()
                            {
                                //将按钮回复可以点击
                                this.simpleButton1.Enabled = false;
                                this.simpleButton2.Enabled = true;
                            }));
                        }
                        break;
                    default:
                        break;
                }
            }

        }
#endregion

#region 添加会员以及回调方法
        //保存(更新会员)
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //CloseFormHandle closeHandle = new CloseFormHandle(delegate
            //{
            //    this.CloseFormClick();   
            //    //如果流程属于激活流程
            //    if(this.flowstatus == FLOW_STATUS.ACTIVE_STATUS)
            //    {
            //        ActiveFlowManage.ActiveFlow().MemberRegistSuccess();
            //    }
            //});
            //显示提示
            OpenMemberResultView view = new OpenMemberResultView();
            ToolsManage.ShowForm(view, false);
        }
#endregion

#region 控件的操作
        //金额的输入
        private void moneyTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //通过输入的金额判断类新
            try
            {
                int money = int.Parse(this.moneyTextEdit.Text);
                int need = 0;

                memberIndex = -1;

                foreach(MemberTypeModel model in this.memberTypes)
                {
                    int tem = int.Parse(model.payMoney);

                    if (money >= tem && tem > need && model.typeId != IdTools.TEM_MEMBER_ID)
                    {
                        memberIndex = this.memberTypes.IndexOf(model);
                        need = tem;
                        //System.Console("");
                    }
                }
               
            }
            catch (Exception exp)
            {
                memberIndex = -1;
            }

            if (memberIndex == -1)
            {
                this.memberTypeTextEdit.Text = null;
            }
            else
            {
                this.memberTypeTextEdit.Text = memberTypes[memberIndex].typeName;
            }
        }
#endregion

#region 进行充值
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //关闭后再获取入口
            CloseFormHandle close = new CloseFormHandle(delegate () {
                OpenMember();
            });

            int money = int.Parse(this.moneyTextEdit.Text);
            UserScanCodeView view = new UserScanCodeView(this.openCard, money,FLOW_STATUS.MEMBER_STATUS, PRECHARGE_TYPE.OPEN_MEMBER);
            ToolsManage.ShowForm(view, false,close);
        }
#endregion

#region 读取身份证结果回调
        private void ReadCardResult(StructCard readCard, bool isSuccess)
        {
            if (readCard != null && isSuccess)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new RefreshUIHandle(delegate {
                        InitUI(readCard);
                    }));
                }
                else { InitUI(readCard); }
                   
            }
        }
#endregion
    }
}
