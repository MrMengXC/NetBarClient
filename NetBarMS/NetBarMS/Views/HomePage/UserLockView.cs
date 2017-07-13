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

namespace NetBarMS.Views.HomePage
{
    public partial class UserLockView : RootFormView
    {
        public string card;
        public UserLockView(string tem)
        {
            InitializeComponent();
            this.titleLabel.Text = "用户锁定";
            card = tem;
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {
            this.label3.Text += card;
        }
        #region 进行锁定
        //进行锁定
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<string> pars = new List<string>() { card,this.textBox1.Text};
            HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.LOCK, pars);
        }

        //锁定结果回调
        private void ManagerCommandOperationResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_COMMAND)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(ManagerCommandOperationResult);
            System.Console.WriteLine("ManagerCommandOperationResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    MessageBox.Show("锁定用户" + card + "成功");
                    this.CloseFormClick();
                }));
               
            }
        }
        #endregion
    }
}
