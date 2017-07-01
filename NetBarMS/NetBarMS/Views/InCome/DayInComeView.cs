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

        //初始化UI
        private void InitUI()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("time", typeof(string));
            dt.Columns.Add("money", typeof(int));

            Series lineseries = this.chartControl1.Series[0];
            lineseries.ArgumentDataMember = "time";
            lineseries.ValueDataMembers[0] = "money";
            lineseries.DataSource = dt;
            for (int i = 1; i <= 24; i++)
            {
                dt.Rows.Add(i+"", i*20);
            }

            //当日营业收入占比
            DataTable table = new DataTable("Table1");
            table.Columns.Add("PayMode", typeof(String));
            table.Columns.Add("Value", typeof(Int32));
            table.Rows.Add("现金",14.89);
            table.Rows.Add("微信支付", 9.59696);
            table.Rows.Add("支付宝", 8.511965);


            Series pieseries = this.chartControl2.Series[0];
            pieseries.ValueDataMembers[0] = "Value";
            pieseries.ArgumentDataMember = "PayMode";
            pieseries.DataSource = table;
            pieseries.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;  // 设置鼠标悬浮显示toolTip  

            //微信收入占比
            DataTable wxTable = new DataTable("WX");
            wxTable.Columns.Add("PayMode", typeof(String));
            wxTable.Columns.Add("Value", typeof(float));
            wxTable.Rows.Add("充值", 14.89);
            wxTable.Rows.Add("购物", 9.59696);


            Series wxPieSeries = this.chartControl3.Series[0];
            wxPieSeries.ValueDataMembers[0] = "Value";
            wxPieSeries.ArgumentDataMember = "PayMode";
            wxPieSeries.DataSource = wxTable;
            wxPieSeries.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;  // 设置鼠标悬浮显示toolTip  

            //支付宝收入占比
            DataTable zfbTable = new DataTable("zfb");
            zfbTable.Columns.Add("PayMode", typeof(String));
            zfbTable.Columns.Add("Value", typeof(float));
            zfbTable.Rows.Add("充值", 14.89);
            zfbTable.Rows.Add("购物", 9.59696);
            

            Series zfbPieSeries = this.chartControl4.Series[0];
            //zfbPieSeries.ValueDataMembers[0] = "Value";
            //zfbPieSeries.ArgumentDataMember = "PayMode";
            //zfbPieSeries.DataSource = zfbTable;
            zfbPieSeries.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;  // 设置鼠标悬浮显示toolTip  

            SeriesPoint p1 = new SeriesPoint("充值", 12.9);
            SeriesPoint p2 = new SeriesPoint("购物", 12.9);
            p1.Color = Color.Blue;
            p2.Color = Color.Orange;
            zfbPieSeries.Points.Add(p1);
            zfbPieSeries.Points.Add(p2);

        }
    }
}
