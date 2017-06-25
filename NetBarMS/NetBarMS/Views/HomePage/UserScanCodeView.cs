using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.HomePage
{
    /// <summary>
    /// 用户充值页面
    /// </summary>
    public partial class UserScanCodeView : RootUserControlView
    {
        public UserScanCodeView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户充值";
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {

        }
    }
}
