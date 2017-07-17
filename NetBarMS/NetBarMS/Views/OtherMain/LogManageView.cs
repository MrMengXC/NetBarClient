using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Tools.NetOperation;

namespace NetBarMS.Views
{
    public partial class LogManageView : RootUserControlView
    {
        private enum TitleList
        {
            None,
            Check = 0,                          //勾选
            OperationPerson,                    //操作人
            OperationExplain,                   //操作说明
            OperationIp,                        //操作Ip地址
            OperationTime,                      //操作时间
            OperationStatus,                    //操作状态
        }

        private string startTime = "", endTime = "";
        private DateTime lastDate = DateTime.MinValue;
        private int pagebegin = 0, pageSize = 15;
        private IList<StructLog> logs;
        private List<StructAccount> staffs;

        public LogManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "日志管理";

            InitUI();
        }

        #region 初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.LogManage, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;

            //获取员工
            this.staffs = SysManage.Staffs;
            foreach (StructAccount staff in this.staffs)
            {
                this.comboBoxEdit1.Properties.Items.Add(staff.Nickname);
            }
            GetLogList();
        }
        #endregion

        #region 获取日志数据
        //获取日志数据列表
        private void GetLogList()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pagebegin,
                Pagesize = this.pageSize,
                Fieldname = 0,
                Order = 0
            };
            string staff = "";
            if(this.comboBoxEdit1.SelectedIndex >= 0)
            {
                staff = this.staffs[this.comboBoxEdit1.SelectedIndex].Nickname;
            }
            string keyword = this.buttonEdit1.Text;
            OtherMainNetOperation.GetLogList(GetLogListResult,page.Build(), startTime, endTime, staff, keyword);

        }
        //获取日志数据列表结果回调
        private void GetLogListResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_LOG)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetLogListResult);
         //   System.Console.WriteLine("GetLogListResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {
                    this.logs = result.pack.Content.ScLog.LogsList;
                    RefreshGridControl();
                }));
            }
            else
            {
                System.Console.WriteLine("GetLogListResult:" + result.pack);
            }

        }
        #endregion

        #region 刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            foreach (StructLog log in this.logs)
            {
                AddNewRow(log);
            }
        }

        //获取新行
        private void AddNewRow(StructLog log)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.OperationPerson.ToString()] = log.Operator;
            row[TitleList.OperationExplain.ToString()] = log.Operation;
            row[TitleList.OperationIp.ToString()] = log.Ip;
            row[TitleList.OperationTime.ToString()] = log.Addtime;
            row[TitleList.OperationStatus.ToString()] = log.Status;
        }
        #endregion

        #region 日期选择
        //日期选择触发
        private void DateNavigator_EditValueChanged(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator1, lastDate, out this.startTime, out this.endTime);
        }
        #endregion

        #region 关闭日期
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (!this.startTime.Equals("") && !this.endTime.Equals(""))
            {
                this.popupContainerEdit1.Text = string.Format("{0}-{1}", this.startTime, this.endTime);
            }
            GetLogList();
        }
        #endregion

        #region 条件筛选
        //进行搜索点击
        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetLogList();
        }
        //选择操作人点击
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLogList();
        }
        #endregion
    }
}
