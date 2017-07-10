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
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Controls;
using NetBarMS.Codes.Model;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using NetBarMS.Codes.Tools.NetOperation;

namespace NetBarMS.Views.SystemSearch

{
    public partial class ChangeShiftsRecordView : RootUserControlView
    {
        private DataTable giveTable;
        private DataTable receiveTable;

        enum TitleList
        {
            None,
            GiveShift = 1,               //交班人
            WorkTime,                   //上班时间
            GiveTime,                          //交班时间
            WorkRechargeMoney,                     //当班期间充值金额
            WorkSellMoney,                          //当班期间商品销售金额
            WorkBackMoney,                          //当班期间撤销的金额
            ConnectShift,                      //接班人
            ConnectTime,                        //接班时间
            NumCorrect,                         //商品剩余数量是否正确
            Remark,                             //备注

        }

        private IList<StructShift> records;
        private DateTime lastDate = DateTime.MinValue;
        private string startTime = "", endTime = "";

        public ChangeShiftsRecordView()
        {
            InitializeComponent();
            this.titleLabel.Text = "交接班记录";
            InitUI();
        }
        #region 初始化UI
        private void InitUI()
        {
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;

            ToolsManage.SetGridView(this.gridView1, GridControlType.GiveShiftsRecord, out this.giveTable);
            this.gridControl1.DataSource = this.giveTable;
            ToolsManage.SetGridView(this.gridView2, GridControlType.ReceiveShiftsRecord, out this.receiveTable);
            this.gridControl2.DataSource = this.receiveTable;
            // RepositoryItemHyperLinkEdit

            GetStaffShiftsRecord();


        }
        #endregion
        #region 获取员工交班记录
        private void GetStaffShiftsRecord()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = 0,
                Pagesize = 15,
                Order = 1,
                Fieldname = 0,
            };
            System.Console.WriteLine("start"+startTime + "\nend:"+endTime);
            StaffNetOperation.GetStaffShiftsRecordList(GetStaffShiftsRecordListResult, page.Build(), startTime,endTime);
        }
        //获取员工交班记录列表
        private void GetStaffShiftsRecordListResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_SHIFT_FIND)
            {
                return;
            }
            
            NetMessageManage.Manage().RemoveResultBlock(GetStaffShiftsRecordListResult);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate
                {
                    records = result.pack.Content.ScShiftFind.ShiftsList;
                    RefreshGridControl();

                }));
            }
            else
            {
                System.Console.WriteLine("GetStaffShiftsRecordListResult:" + result.pack);
            }


        }
        #endregion

        #region 刷新GridControl
        private void RefreshGridControl()
        {
            this.giveTable.Rows.Clear();
            this.receiveTable.Rows.Clear();
            foreach(StructShift shift in records)
            {
                AddNewRow(shift);
            }
        }

        //添加新行
        private void AddNewRow(StructShift shift)
        {
            DataRow give = this.giveTable.NewRow();
            this.giveTable.Rows.Add(give);
            DataRow receive = this.receiveTable.NewRow();
            this.receiveTable.Rows.Add(receive);
         
            give[TitleList.GiveShift.ToString()] = shift.DeliveredBy;
            give[TitleList.WorkTime.ToString()] = shift.Starttime;
            give[TitleList.GiveTime.ToString()] = shift.Stoptime;
            give[TitleList.WorkRechargeMoney.ToString()] = shift.ChargeAmount;
            give[TitleList.WorkSellMoney.ToString()] = shift.SaleAmount;
            give[TitleList.WorkBackMoney.ToString()] = shift.RefundAmount;

            receive[TitleList.ConnectShift.ToString()] = shift.ReceivedBy;
            receive[TitleList.ConnectTime.ToString()] = shift.Stoptime;
            receive[TitleList.NumCorrect.ToString()] = shift.Ischeck == 1?"是":"否";
            receive[TitleList.Remark.ToString()] = shift.Remark;
       


        }
        #endregion

        #region 日期选择
        //日期选择触发
        private void DateNavigator_Click(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }


        #endregion

        #region 关闭日期选择菜单
        private void ComboBoxEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {

            GetStaffShiftsRecord();
        }
        #endregion

        #region 添加行标的代码
        ////初始化UI
        //private void InitUI()
        //{
        //    this.band1.Caption = "交班人";
        //    this.band2.Caption = "接班人";
        //    //RepositoryItemHyperLinkEdit
        //    band1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //    band2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //    //this.bandedGridView1.OptionsView.ShowGroupPanel = false;
        //    SetBandGridView(GridControlType.ChangeShiftsRecord, out this.mainDataTable, null, null);

        //    this.gridControl1.DataSource = this.mainDataTable;

        //    DataRow row = this.mainDataTable.NewRow();
        //    this.mainDataTable.Rows.Add(row);

        //}
        //private void SetBandGridView(
        //    GridControlType type,
        //    out DataTable table
        //    , ButtonPressedEventHandler buttonclik,
        //    DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler titleHandler)
        //{

        //    string[] titles1 = {TitleList.GiveShift.ToString(),
        //        TitleList.WorkTime.ToString(),
        //        TitleList.GiveTime.ToString(),
        //        TitleList.WorkRechargeMoney.ToString(),
        //        TitleList.WorkSellMoney.ToString(),
        //    TitleList.WorkBackMoney.ToString() };



        //    GridControlModel model = XMLDataManage.GetGridControlModel(type.ToString());
        //    table = new DataTable();

        //    int i = 0;
        //    foreach (ColumnModel columnModel in model.columns)
        //    {

        //        string fieldname = "column_" + i;
        //        if (columnModel.field != "None")
        //        {
        //            fieldname = columnModel.field;
        //        }

        //        DataColumn dc = new DataColumn(fieldname);
        //        table.Columns.Add(dc);

        //        BandedGridColumn column = new BandedGridColumn();
        //        column.FieldName = fieldname;
        //        column.Caption = columnModel.name;
        //        column.Visible = true;

        //        column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //        column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //        column.OptionsColumn.AllowEdit = false;
        //        if(titles1.Contains(fieldname))
        //        {
        //            this.band1.Columns.Add(column);
        //        }
        //        else
        //        {
        //            this.band2.Columns.Add(column);
        //        }
        //        //switch (columnModel.type)
        //        //{
        //        //    #region 添加复选框
        //        //    case ColumnType.C_Check:        //添加复选框
        //        //        RepositoryItemCheckEdit check = new RepositoryItemCheckEdit();
        //        //        check.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
        //        //        column.ColumnEdit = check;
        //        //        column.OptionsColumn.AllowEdit = true;
        //        //        dc.DataType = typeof(bool);
        //        //        break;
        //        //    #endregion

        //        //    #region 添加按钮
        //        //    case ColumnType.C_Button:        //添加按钮
        //        //        RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
        //        //        buttonEdit.Buttons.Clear();
        //        //        column.OptionsColumn.AllowEdit = true;
        //        //        buttonEdit.ButtonsStyle = BorderStyles.Simple;
        //        //        buttonEdit.AutoHeight = false;
        //        //        dc.DataType = typeof(object);
        //        //        buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;

        //        //        if (buttonclik != null)
        //        //        {
        //        //            buttonEdit.ButtonClick += buttonclik;
        //        //        }
        //        //        int num = 0;
        //        //        foreach (string name in columnModel.buttonNames)
        //        //        {

        //        //            EditorButton button = new EditorButton();
        //        //            button.Kind = ButtonPredefines.Glyph;
        //        //            button.Caption = name;
        //        //            button.Visible = true;
        //        //            button.Tag = fieldname + "_" + num;
        //        //            buttonEdit.Buttons.Add(button);

        //        //            button.Appearance.Options.UseBackColor = true;
        //        //            button.Appearance.BackColor = Color.Red;
        //        //            button.Appearance.BackColor2 = Color.Red;

        //        //            button.Width = 50;
        //        //            num++;
        //        //        }
        //        //        column.ColumnEdit = buttonEdit;
        //        //        break;
        //        //    #endregion
        //        //    default:
        //        //        //column.SortMode = ColumnSortMode.Custom;
        //        //        break;
        //        //}
        //        column.Width = 100;
        //        i++;

        //    }
        //   // gridView.OptionsSelection.MultiSelect = true;
        //    //gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
        //    gridView.RowHeight = 25;




        //}
        #endregion
    }
}
