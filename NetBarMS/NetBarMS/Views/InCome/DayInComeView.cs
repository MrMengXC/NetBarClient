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
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools;


namespace NetBarMS.Views.InCome
{
    public partial class DayInComeView : RootUserControlView
    {

        private string start, end;
        private IList<StructEarn> earns;
       

        public DayInComeView()
        {
            InitializeComponent();
            //this.titleLabel.Text = "日营收管理";
            
            InitUI();
        }

        #region 初始化UI
        private void InitUI()
        {
            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;

            this.chartControl1.RuntimeHitTesting = true;

         

            DateTime date = DateTime.Now.AddDays(-1);
            start = date.ToString("yyyy-MM-dd") + " 00:00:00";
            end = date.ToString("yyyy-MM-dd") + " 23:59:59";
            GetDayIncomeDetail();
        }
        #endregion

        #region 获取营收详情
        //获取日营收详情
        private void GetDayIncomeDetail()
        {
            IncomeNetOperation.GetIncomeDetail(GetIncomeDetailResult, start, end,IncomeType.DAY_INCOME);
        }
        //获取日收入的结果回调
        private void GetIncomeDetailResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_EARNING_DAY)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(GetIncomeDetailResult);
            System.Console.WriteLine("GetIncomeDetailResult:" + result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                this.earns = result.pack.Content.ScEarning.EarnsList;
                this.Invoke(new UIHandleBlock(delegate {
                    if (this.earns != null && this.earns.Count > 0)
                    {
                        IncomeDetail();
                        IncomeRate(earns[0]);
                        WxRate(earns[0]);
                        ZfbRate(earns[0]);
                        AreaRate(earns[0].AreaTotalList);
                    }
                }));

            }
        }
        #endregion

        #region 进行数据展示
        //营收详情
        private void IncomeDetail()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("time", typeof(string));
            dt.Columns.Add("money", typeof(int));

            Series lineseries = this.chartControl1.Series[0];
            lineseries.ArgumentDataMember = "time";
            lineseries.ValueDataMembers[0] = "money";
            lineseries.DataSource = dt;
            
            for (int i = 1; i <= this.earns.Count; i++)
            {

                StructEarn earn = this.earns[i - 1];
                dt.Rows.Add(i + "", earn.CashCharge + earn.CashSale + earn.TenpaySale + earn.TenpayCharge + earn.AlipaySale + earn.AlipayCharge);
            }
            this.chartControl1.MouseClick += chartControl_MouseClick;
        }
        //条形图点击事件
        private void chartControl_MouseClick(object sender, MouseEventArgs e)
        {
            ChartHitInfo hitInfo = this.chartControl1.CalcHitInfo(e.Location);
            //MessageBox.Show("hhhh");

            if (hitInfo.SeriesPoint != null)
            {
                StructEarn earn = this.earns[this.chartControl1.Series[0].Points.IndexOf(hitInfo.SeriesPoint)];
                IncomeRate(earn);
                WxRate(earn);
                ZfbRate(earn);
                AreaRate(earn.AreaTotalList);

            }
        }
        //营收占比
        private void IncomeRate(StructEarn earn)
        {
            //当日营业收入占比

            Series pieseries = this.chartControl2.Series[0];
            pieseries.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;  // 设置鼠标悬浮显示toolTip  
            pieseries.Points.Clear();

            SeriesPoint p1 = new SeriesPoint("现金", earn.CashCharge + earn.CashSale);
            SeriesPoint p2 = new SeriesPoint("微信", earn.TenpayCharge + earn.TenpaySale);
            SeriesPoint p3 = new SeriesPoint("支付宝", earn.AlipayCharge + earn.AlipaySale);
           
            p1.Color = Color.Blue;
            p2.Color = Color.Orange;
            p3.Color = Color.Gray;
            pieseries.Points.Add(p1);
            pieseries.Points.Add(p2);
            pieseries.Points.Add(p3);

        }

        //微信支付占比
        private void WxRate(StructEarn earn)
        {
            //微信收入占比
            Series wxPieSeries = this.chartControl3.Series[0];
            wxPieSeries.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;  // 设置鼠标悬浮显示toolTip  
            wxPieSeries.Points.Clear();

            SeriesPoint p1 = new SeriesPoint("充值", earn.TenpayCharge);
            SeriesPoint p2 = new SeriesPoint("购物", earn.TenpaySale);
            p1.Color = Color.Blue;
            p2.Color = Color.Orange;
            wxPieSeries.Points.Add(p1);
            wxPieSeries.Points.Add(p2);

        }
        //支付宝支付占比
        private void ZfbRate(StructEarn earn)
        {
            //支付宝收入占比
            Series zfbPieSeries = this.chartControl4.Series[0];
            zfbPieSeries.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;  // 设置鼠标悬浮显示toolTip  
            zfbPieSeries.Points.Clear();

            SeriesPoint p1 = new SeriesPoint("充值", earn.AlipayCharge);
            SeriesPoint p2 = new SeriesPoint("购物", earn.AlipaySale);
            p1.Color = Color.Blue;
            p2.Color = Color.Orange;
            zfbPieSeries.Points.Add(p1);
            zfbPieSeries.Points.Add(p2);
        }
        //区域收入占比
        private void AreaRate(IList<StructAreaTotal> areas)
        {
            //支付宝收入占比
            Series areaPieSeries = this.chartControl5.Series[0];
            areaPieSeries.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;  // 设置鼠标悬浮显示toolTip  
            areaPieSeries.Points.Clear();
            foreach(StructAreaTotal area in areas)
            {
                SeriesPoint p = new SeriesPoint(area.Areaname, area.Amount);
                areaPieSeries.Points.Add(p);
            }          
        }
        #endregion

        #region 功能按钮
        //导出营收详情
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            IncomeDetail detail = new InCome.IncomeDetail(IncomeType.DAY_INCOME, this.earns.ToList<StructEarn>(),0,0);
            ToolsManage.ShowForm(detail, false);
        }

        //关闭选择菜单
        private void ComboBoxEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

            DateTime date = this.dateNavigator1.SelectionStart;
            start = date.ToString("yyyy-MM-dd") + " 00:00:00";
            end = date.ToString("yyyy-MM-dd") + " 23:59:59";
            GetDayIncomeDetail();
        }
        #endregion

    }
}
