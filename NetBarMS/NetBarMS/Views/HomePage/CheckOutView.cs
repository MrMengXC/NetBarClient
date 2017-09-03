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
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS.Views.HomePage
{
    public partial class CheckOutView : RootFormView
    {
        public CheckOutView()
        {
            InitializeComponent();
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
                this.Invoke(new RefreshUIHandle(delegate
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

        private void ControlPaint(object sender, PaintEventArgs e)
        {
            BorderManage.DrawBorder(e.Graphics, this.simpleButton2.ClientRectangle, BORDER_TYPE.BUTTON_BORDER);
        }
    }
}
