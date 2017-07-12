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

namespace NetBarMS.Views.NetUserManage
{
   
    public partial class MemberNetRecordView : RootUserControlView
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

        private Int32 mid;
        private DateTime lastDate = DateTime.MinValue;
        private string startTime = "", endTime = "";
        IList<StructEmbarkation> records;

        public MemberNetRecordView(Int32 tem)
        {
            InitializeComponent();
            this.titleLabel.Text = "上网记录查询";
            mid = tem;
            InitUI();

        }
        //初始化UI
        private void InitUI()
        {
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;

            ToolsManage.SetGridView(this.gridView1, GridControlType.UserNetRecord, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            GetMemberNetRecord(false);
        }
      
        #region 会员上网记录查询
        //会员上网记录查询
        private void GetMemberNetRecord(bool isFilter)
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
            RecordNetOperation.GetUserNetRecord(MemberNetRecordResult, page.Build(), this.startTime, this.endTime, "",mid,-1);


        }
       
        //会员上网记录查询结果回调
        private void MemberNetRecordResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_QUERY_EMBARKATION)
            {
                return;
            }
            System.Console.WriteLine("MemberNetRecordResult:" + result.pack);
            NetMessageManage.Manage().RemoveResultBlock(MemberNetRecordResult);
            if (result.pack.Content.MessageType == 1)
            {
                ToolsManage.Invoke(this, new UIHandleBlock(delegate
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
            foreach (StructEmbarkation realTime in this.records)
            {
                AddGridControlNewRow(realTime);
            }
        }
        //添加新行
        private void AddGridControlNewRow(StructEmbarkation emb)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IdNumber.ToString()] = emb.Cardnumber;
            row[TitleList.Name.ToString()] = emb.Username;
            row[TitleList.MemberType.ToString()] = emb.Usertype;
            row[TitleList.StartTime.ToString()] = emb.Starttime;
            row[TitleList.EndTime.ToString()] = emb.Stoptime;
            row[TitleList.Area.ToString()] = emb.Area;
            row[TitleList.UseTime.ToString()] = emb.Usedtime;
            row[TitleList.UseMoney.ToString()] = emb.Money;
            row[TitleList.Mac.ToString()] = emb.Mac;
            row[TitleList.Ip.ToString()] = emb.Ip;
        }
        #endregion


        #region 过滤条件搜索/日期/关键字
        //关闭日期选择菜单
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            GetMemberNetRecord(true);
        }

        //日期选择触发
        private void DateNavigator_Click(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }
        #endregion

        //
        private void PageView_PageChanged(int current)
        {
            GetMemberNetRecord(false);
        }

    }
}
