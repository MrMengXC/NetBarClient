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
    public partial class IncomeManageView : RootUserControlView
    {
        public IncomeManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "营收管理";
        }
    }
}
