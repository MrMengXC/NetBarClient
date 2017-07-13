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
    public partial class CheckOutView : RootUserControlView
    {
        public CheckOutView()
        {
            InitializeComponent();
            this.titleLabel.Text = "全部结帐";
        }

        #region 确定
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.CHECKOUT, null);
        }
        //全部结帐的结果回调
        private void ManagerCommandOperationResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_COMMAND)
            {
                return;
            }
            System.Console.WriteLine("ManagerCommandOperationResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(ManagerCommandOperationResult);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate
                {
                    MessageBox.Show("发送成功");
                    this.CloseFormClick();

                }));
            }
        }
        #endregion

        #region 取消
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.CloseFormClick();
        }
        #endregion
    }
}
