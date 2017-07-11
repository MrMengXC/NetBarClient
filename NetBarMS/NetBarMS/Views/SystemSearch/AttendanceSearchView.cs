using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Model;
using DevExpress.XtraCharts;

namespace NetBarMS.Views.SystemSearch
{
    public partial class AttendanceSearchView : RootUserControlView
    {

        private string start, end;
        private List<AreaTypeModel> areas;
        private IList<int> ratedatas;

        public AttendanceSearchView()
        {
            InitializeComponent();
            this.titleLabel.Text = "上座率查询";
            InitUI();
        }

        //初始化UI
        private void InitUI()
        {
            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;

            this.comboBoxEdit1.Properties.Items.Add("无");
            SysManage.Manage().GetAreasList(out this.areas);
            foreach(AreaTypeModel model in this.areas)
            {
                this.comboBoxEdit1.Properties.Items.Add(model.areaName);
            }

            DateTime date = DateTime.Now.AddDays(-1);
            start = date.ToString("yyyy-MM-dd") + " 00:00:00";
            end = date.ToString("yyyy-MM-dd") + " 23:59:59";
        }

        //获取上座率
        private void GetAttendanceSearch()
        {
            int areaId = -1;
            if(this.comboBoxEdit1.SelectedIndex > 0)
            {
                areaId = this.areas[this.comboBoxEdit1.SelectedIndex].areaId;
            }
            RecordNetOperation.GetAttendanceSearch(GetAttendanceSearchResult, areaId, "");
        }
        //获取上座率结果回调
        private void GetAttendanceSearchResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_QUERY_OCCUPANCY)
            {
                return;
            }
            System.Console.WriteLine("GetAttendanceSearchResult:" + result.pack);
            NetMessageManage.Manage().RemoveResultBlock(GetAttendanceSearchResult);
            if(result.pack.Content.MessageType == 1)
            {


            }
        }
        //显示占座率条形图

        private void ShowAttendance()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("time", typeof(string));
            dt.Columns.Add("money", typeof(int));

            Series lineseries = this.chartControl1.Series[0];
            lineseries.ArgumentDataMember = "time";
            lineseries.ValueDataMembers[0] = "money";
            lineseries.DataSource = dt;

            //for (int i = 1; i <= this.earns.Count; i++)
            //{
            //    StructEarn earn = this.earns[i - 1];
            //    dt.Rows.Add(i + "", earn.CashCharge + earn.CashSale + earn.TenpaySale + earn.TenpayCharge + earn.AlipaySale + earn.AlipayCharge);
            //}


        }
        #region 关闭日期菜单s
        private void ComboBoxEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

            DateTime date = this.dateNavigator1.SelectionStart;
            start = date.ToString("yyyy-MM-dd") + " 00:00:00";
            end = date.ToString("yyyy-MM-dd") + " 23:59:59";
        }
        #endregion
    }
}
