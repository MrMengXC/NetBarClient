using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Views.NetUserManage;
using NetBarMS.Codes.Tools;

namespace NetBarMS.Views.HomePage
{
    /// <summary>
    /// 提示扫描身份证
    /// </summary>
    public partial class ReminderScanView : RootUserControlView
    {
        public ReminderScanView()
        {
            InitializeComponent();
            this.titleLabel.Text = "会员办理";
        }

        //确定点击
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //关闭点击
            this.FindForm().Close();

            //进入开卡界面
            OpenMemberView open = new OpenMemberView(this.textEdit1.Text);
            ToolsManage.ShowForm(open, false);
        }

        //取消点击
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //关闭点击
            this.FindForm().Close();

        }
    }
}
