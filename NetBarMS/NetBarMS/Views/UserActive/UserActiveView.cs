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
                   

                    //如果是临时会员提醒是否添加会员
                    StructMember member = result.pack.Content.ScEmkUserInfo.Member;
                    //if(member.Membertype == IdTools.TEM_MEMBER_ID)
                    //{
                    //    RemindIsOpenMember();
                    //}
                }));
            }
            else
            {
               // AddCardInfo();
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
            UserScanCodeView view = new UserScanCodeView(this.card, 50, PRECHARGE_TYPE.NOT_MEMBER);
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
