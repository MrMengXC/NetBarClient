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
    public partial class YearInComeView : RootUserControlView
    {
        public YearInComeView()
        {
            InitializeComponent();
            this.titleLabel.Text = "年营收统计";
        }
    }
}
