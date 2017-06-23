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
    public partial class AreaIncomeView : RootUserControlView
    {
        public AreaIncomeView()
        {
            InitializeComponent();
            this.titleLabel.Text = "区域营收管理";
        }
    }
}
