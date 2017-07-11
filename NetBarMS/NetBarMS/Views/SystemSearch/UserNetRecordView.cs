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

namespace NetBarMS.Views.SystemSearch
{
    public partial class UserNetRecordView : RootUserControlView
    {
        #region Title　ENUM
        private enum TitleList
        {
            None,
            IdNumber,               //身份证号
            Name,                   //姓名
            MemberType,             //会员类型
            StartTime,              //上机时间
            EndTime,              //下机时间
            Area,                   //所在区域
            UseTime,                //用时
            UseMoney,               //金额
            Mac,                    //mac地址
            Ip,                     //ip地址

        }
        #endregion

        private DateTime lastDate = DateTime.MinValue;
        private string startTime = "", endTime = "";
        private int pageBegin = 0, pageSize = 15;
        private IList<StructEmbarkation> records;
        public UserNetRecordView()
        {
            InitializeComponent();
            this.titleLabel.Text = "上网记录查询";
            InitUI();

        }
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.UserNetRecord, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;
            GetUserNetRecord();

        }

        #region 会员上网记录查询/条件过滤查询
        //会员上网记录查询
        private void GetUserNetRecord()
        {

            StructPage.Builder page = new StructPage.Builder()
            {
                Pagesize = this.pageSize,
                Pagebegin = this.pageBegin,
                Fieldname = 0,
                Order = 0,
            };

            string name = "";
            if(!this.searchButtonEdit.Text.Equals(this.searchButtonEdit.Properties.NullText))
            {
                name = this.searchButtonEdit.Text;
            }
            RecordNetOperation.GetUserNetRecord(GetUserNetRecordResult, page.Build(),this.startTime, this.endTime, name);

        }
        //上网记录查询结果回调
        private void GetUserNetRecordResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_QUERY_EMBARKATION)
            {
                return;
            }

            System.Console.WriteLine("GetUserNetRecordResult:" + result.pack);
            NetMessageManage.Manage().RemoveResultBlock(GetUserNetRecordResult);
            if (result.pack.Content.MessageType == 1)
            {
                ToolsManage.Invoke(this,new UIHandleBlock(delegate
                {
                    this.records = result.pack.Content.ScQueryEmk.EmksList;

                    RefreshGridControl();
                }));
            }

        }
        
        #endregion

        #region 更新GridControl 数据
        //更新GridControl列表数据
        private void RefreshGridControl()
        {
            this.mainDataTable.Rows.Clear();
            foreach (StructEmbarkation emk in this.records)
            {
                AddNewRow(emk);
            }
        }
        //添加新行
        private void AddNewRow(StructEmbarkation emk)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IdNumber.ToString()] = emk.Cardnumber;
            row[TitleList.Name.ToString()] = emk.Username;
            row[TitleList.MemberType.ToString()] = emk.Usertype;
            row[TitleList.StartTime.ToString()] = emk.Starttime;
            row[TitleList.EndTime.ToString()] = emk.Stoptime;
            row[TitleList.Area.ToString()] = emk.Area;
            row[TitleList.UseTime.ToString()] = emk.Usedtime;
            row[TitleList.UseMoney.ToString()] = emk.Money;
            row[TitleList.Mac.ToString()] = emk.Mac;
            row[TitleList.Ip.ToString()] = emk.Ip;
        }
        #endregion


        #region 过滤条件搜索/日期/关键字
        //关闭日期选择菜单
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            GetUserNetRecord();
        }

        //日期选择触发
        private void DateNavigator_Click(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }
        private void SearchButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetUserNetRecord();
        }

        #endregion
    }
}
