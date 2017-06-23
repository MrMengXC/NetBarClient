using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.OtherMain
{
    public partial class DataReportView : RootUserControlView
    {
        public DataReportView()
        {
            InitializeComponent();
            this.titleLabel.Text = "数据报告";
        }
    }
}
