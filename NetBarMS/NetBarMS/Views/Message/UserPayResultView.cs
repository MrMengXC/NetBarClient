using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.Message
{
    /// <summary>
    /// 用户充值结果充值
    /// </summary>
    public partial class UserPayResultView : RootUserControlView
    {
        public UserPayResultView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户充值";
        }
    }
}
