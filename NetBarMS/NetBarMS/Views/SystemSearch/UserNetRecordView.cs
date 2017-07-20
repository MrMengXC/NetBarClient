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
using NetBarMS.Codes.Tools.Manage;
using System.Reflection;

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

        private List<StructRealTime> computers;
        private IList<StructEmbarkation> records;
        public UserNetRecordView()
        {
            InitializeComponent();
            InitUI();

        }
        
        #region 初始化UI
        private void InitUI()
        {


            ToolsManage.SetGridView(this.gridView1, GridControlType.UserNetRecord, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;

            //获取设备编号
            this.comboBoxEdit1.Properties.Items.Add("无");
            HomePageMessageManage.GetComputers(out this.computers);
            foreach(StructRealTime com in this.computers)
            {
                this.comboBoxEdit1.Properties.Items.Add(com.Computer);
            }

            GetUserNetRecord(false);

        }
        #endregion

        #region 会员上网记录查询/条件过滤查询
        //会员上网记录查询
        private void GetUserNetRecord(bool isFilter)
        {
            if(isFilter)
            {
                this.pageView1.InitPageViewData();
            }

            StructPage.Builder page = new StructPage.Builder()
            {
                Pagesize = pageView1.PageSize,
                Pagebegin = pageView1.PageBegin,
                Fieldname = 0,
                Order = 0,
            };

            string name = "";
            if(!this.searchButtonEdit.Text.Equals(this.searchButtonEdit.Properties.NullText))
            {
                name = this.searchButtonEdit.Text;
            }

            int comId = -1;
            if(this.comboBoxEdit1.SelectedIndex > 0)
            {
                comId = this.computers[this.comboBoxEdit1.SelectedIndex - 1].Computerid;
            }
            RecordNetOperation.GetUserNetRecord(GetUserNetRecordResult, page.Build(),this.startTime, this.endTime, name,-1,comId);

        }
        //上网记录查询结果回调
        private void GetUserNetRecordResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_QUERY_EMBARKATION)
            {
                return;
            }

            System.Console.WriteLine("GetUserNetRecordResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(GetUserNetRecordResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {
                    this.pageView1.RefreshPageView(result.pack.Content.ScQueryEmk.Pagecount);
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
            row[TitleList.MemberType.ToString()] = SysManage.GetMemberTypeName(emk.Usertype);
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
            if(!this.startTime.Equals("") && !this.endTime.Equals(""))
            {
                this.popupContainerEdit1.Text = string.Format("{0}-{1}", this.startTime, this.endTime);
            }
            GetUserNetRecord(true);
        }

        //日期选择触发
        private void DateNavigator_Click(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }

      
        private void SearchButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetUserNetRecord(true);
        }



        #endregion

        #region 选择电脑设备
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUserNetRecord(true);

        }
        #endregion
        //进行页数通知
        private void PageView_PageChanged(int current)
        {
            GetUserNetRecord(false);
        }

    }
}
