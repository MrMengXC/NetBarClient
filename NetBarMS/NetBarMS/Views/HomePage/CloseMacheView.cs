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
    public partial class CloseMacheView : RootUserControlView
    {
        public CloseMacheView()
        {
            InitializeComponent();
            this.titleLabel.Text = "关闭闲机";
        }

        //确定关闭闲着的机子
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.IDLEOFF, null);
        }
        //关闭闲机的结果回调
        private void ManagerCommandOperationResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_COMMAND)
            {
                return;
            }
            System.Console.WriteLine("ManagerCommandOperationResult:"+result.pack);
            NetMessageManage.Manage().RemoveResultBlock(ManagerCommandOperationResult);

            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate
                {
                    MessageBox.Show("发送成功");
                    this.CloseFormClick();

                }));
            }
        }
        //取消
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.CloseFormClick();
        }
    }
}
