using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace NetBarMS.Views.InCome
{
    public partial class DayInComeView : RootUserControlView
    {
        public DayInComeView()
        {
            InitializeComponent();
            this.titleLabel.Text = "日营收管理";
            InitUI();
        }

        private void InitUI()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("time", typeof(string));
            dt.Columns.Add("money", typeof(int));

            Series series = this.chartControl1.Series[0];
            series.ArgumentDataMember = "time";
            series.ValueDataMembers[0] = "money";
            series.DataSource = dt;
            for (int i = 1; i <= 24; i++)
            {
                dt.Rows.Add(i+"", i*20);
            }

        }
    }
}
