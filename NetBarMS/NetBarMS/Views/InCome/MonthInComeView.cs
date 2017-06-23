using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.InCome
{
    public partial class MonthInComeView : RootUserControlView
    {
        public MonthInComeView()
        {
            InitializeComponent();
            this.titleLabel.Text = "月营收管理";
        }
    }
}
