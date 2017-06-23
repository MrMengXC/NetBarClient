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
    public partial class CloseMacheView : RootUserControlView
    {
        public CloseMacheView()
        {
            InitializeComponent();
            this.titleLabel.Text = "关闭闲机";
        }
    }
}
