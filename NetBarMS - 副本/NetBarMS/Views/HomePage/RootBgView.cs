using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Views.OtherMain;

namespace NetBarMS.Views.HomePage
{
    public partial class RootBgView : UserControl
    {
        public RootBgView()
        {
            InitializeComponent();
            InitUI();
        }
        #region 初始化UI
        private void InitUI()
        {
            ManagerLoginView login = new ManagerLoginView();
            this.Controls.Add(login);
            login.Dock = DockStyle.Fill;

        }
        #endregion
        //关闭程序
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.FindForm().WindowState = FormWindowState.Minimized;
        }
    }
}
