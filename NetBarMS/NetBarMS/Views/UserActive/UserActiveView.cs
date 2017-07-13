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
using NetBarMS.Codes.Tools.FlowManage;
using NetBarMS.Views.HomePage;
using NetBarMS.Views.NetUserManage;

namespace NetBarMS.Views.UserUseCp
{

    public partial class UserActiveView : RootUserControlView
    {
        private string card;
        public UserActiveView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户上机";
            card = ToolsManage.RandomCard;
            InitUI();
        }

        #region 初始化UI
        private void InitUI()
        {
            label1.Text += card;
            this.simpleButton1.Enabled = false;
            this.simpleButton2.Enabled = false;
            this.simpleButton3.Enabled = false;

            //判断会员信息。是否是会员。是的话进行
            MemberNetOperation.MemberInfo(MemberInfoResult, card);

        }
        //查询会员信息结果反馈
        private void MemberInfoResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_EMK_USERINFO)
            {
                return;
            }
            System.Console.WriteLine("MemberInfoResult" + result.pack);
            NetMessageManage.RemoveResultBlock(MemberInfoResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    //将按钮回复可以点击
                    this.simpleButton1.Enabled = true;
                    this.simpleButton2.Enabled = true;
                    this.simpleButton3.Enabled = true;

                    //如果是临时会员提醒是否添加会员
                    StructMember member = result.pack.Content.ScEmkUserInfo.Member;
                    if(member.Membertype == IdTools.TEM_MEMBER_ID)
                    {
                        RemindIsOpenMember();
                    }
                }));
            }
            else
            {
                AddCardInfo();
            }
        }
        #endregion

        #region 添加身份证信息（添加临时会员）
        private void AddCardInfo()
        {
            string cardNum = this.card;
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
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    //将按钮回复可以点击
                    this.simpleButton1.Enabled = true;
                    this.simpleButton2.Enabled = true;
                    this.simpleButton3.Enabled = true;

                    //提醒是否开通会员
                    RemindIsOpenMember();

                }));
            }

        }
        #endregion

        #region 提醒是否开通会员
        private void RemindIsOpenMember()
        {
            if(MessageBox.Show("询问用户是否开通会员！","提醒", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                OpenMemberView view = new OpenMemberView(FLOW_STATUS.ACTIVE_STATUS, this.card);
                ToolsManage.ShowForm(view, false);
            }
        }
        #endregion

        #region 激活
        //激活
        private void simpleButton1_Click(object sender, EventArgs e)
        {
             ActiveFlowManage.ActiveFlow().CardCheckIn(this.card);
        }
        #endregion
        
        #region 充值
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            UserScanCodeView view = new UserScanCodeView(this.card, 50, (int)PRECHARGE_TYPE.NOT_MEMBER);
            ToolsManage.ShowForm(view, false);
        }
        #endregion

        #region 下机
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            HomePageNetOperation.CardCheckOut(CardCheckOutResult, this.card);  
        }
        private void CardCheckOutResult(ResultModel result)
        {

            if(result.pack.Cmd != Cmd.CMD_EMK_CHECKOUT)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(CardCheckOutResult);
            System.Console.WriteLine("CardCheckOutResult:" + result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock (delegate {
                    this.CloseFormClick();
                    UserCloseCpView view = new UserCloseCpView();
                    ToolsManage.ShowForm(view, false);
                    
                }));
            }

        }
        #endregion
    }
}
