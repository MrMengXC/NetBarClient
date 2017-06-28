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
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Views.UserUseCp
{



    public partial class UserActiveView : RootUserControlView
    {

        public UserActiveView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户上机";
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {
        }

        #region 激活
        //激活
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if(this.textEdit1.Text.Equals(""))
            {
                return;

            }
            ActiveFlowManage.ActiveFlow().CardCheckIn(this.textEdit1.Text);
        }
        #endregion

        #region 充值
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this.textEdit1.Text.Equals(""))
            {
                return;
            }
            UserScanCodeView view = new UserScanCodeView(this.textEdit1.Text, 50, (int)PRECHARGE_TYPE.NOT_MEMBER);
            ToolsManage.ShowForm(view, false);
        }
        #endregion

        #region 下机
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (this.textEdit1.Text.Equals(""))
            {
                return;
            }
            HomePageNetOperation.CardCheckOut(CardCheckOutResult, this.textEdit1.Text);  



        }
        private void CardCheckOutResult(ResultModel result)
        {

            if(result.pack.Cmd != Cmd.CMD_EMK_CHECKOUT)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(CardCheckOutResult);
            System.Console.WriteLine("CardCheckOutResult:" + result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock (delegate {
                    this.FindForm().Close();
                    UserCloseCpView view = new UserCloseCpView();
                    ToolsManage.ShowForm(view, false);
                    
                }));
            }

        }
        #endregion
    }
}
