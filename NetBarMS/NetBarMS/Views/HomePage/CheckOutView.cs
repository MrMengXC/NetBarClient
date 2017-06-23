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
    public partial class CheckOutView : RootUserControlView
    {
        public CheckOutView()
        {
            InitializeComponent();
            this.titleLabel.Text = "全部结帐";
        }
    }
}
