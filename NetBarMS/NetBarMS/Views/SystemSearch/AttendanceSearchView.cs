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

        private string start;
        private List<AreaTypeModel> areas;
        private IList<int> ratedatas;

        public AttendanceSearchView()
        {
            InitializeComponent();
            this.titleLabel.Text = "上座率查询";
            InitUI();
        }

        #region 初始化UI
        private void InitUI()
        {


            this.mainDataTable = new DataTable();
            this.mainDataTable.Columns.Add("time", typeof(string));
            this.mainDataTable.Columns.Add("rate", typeof(int));

            Series lineseries = this.chartControl1.Series[0];
            lineseries.ArgumentDataMember = "time";
            lineseries.ValueDataMembers[0] = "rate";
            lineseries.DataSource = this.mainDataTable;


            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;

            this.comboBoxEdit1.Properties.Items.Add("无");
            this.areas = SysManage.Areas;
            foreach (AreaTypeModel model in this.areas)
            {
                this.comboBoxEdit1.Properties.Items.Add(model.areaName);
            }

            DateTime date = DateTime.Now.AddDays(-1);
            start = date.ToString("yyyy-MM-dd");
            this.popupContainerEdit1.Text = start;
            GetAttendanceSearch();
        }
        #endregion

        #region 获取上座率
        private void GetAttendanceSearch()
        {
            int areaId = -1;
            if(this.comboBoxEdit1.SelectedIndex > 0)
            {
                areaId = this.areas[this.comboBoxEdit1.SelectedIndex-1].areaId;
            }
            RecordNetOperation.GetAttendanceSearch(GetAttendanceSearchResult, areaId, start);
        }
        //获取上座率结果回调
        private void GetAttendanceSearchResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_QUERY_OCCUPANCY)
            {
                return;
            }
            System.Console.WriteLine("GetAttendanceSearchResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(GetAttendanceSearchResult);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {

                    ratedatas = result.pack.Content.ScQueryOccup.OccupsList;

                    ShowAttendance();

                }));

            }
        }
        #endregion

        #region 显示占座率条形图
        private void ShowAttendance()
        {
            this.mainDataTable.Clear();

            for (int i = 1; i <= this.ratedatas.Count; i++)
            {
                string time = string.Format("{0:D2}", i)+":00";
                this.mainDataTable.Rows.Add(time, this.ratedatas[i-1]);
            }


        }
        #endregion

        #region 关闭日期菜单
        private void ComboBoxEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

            DateTime date = this.dateNavigator1.SelectionStart;
            start = date.ToString("yyyy-MM-dd");
            this.popupContainerEdit1.Text = start;
            GetAttendanceSearch();
        }
        #endregion

        #region 筛选区域
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAttendanceSearch();
        }
        #endregion
    }
}
