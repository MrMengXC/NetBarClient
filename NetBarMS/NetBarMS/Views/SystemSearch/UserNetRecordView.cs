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
   
    public partial class UserNetRecordView : RootUserControlView
    {
        #region Title　ENUM
        enum TitleList
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

        public UserNetRecordView(Int32 tem)
        {
            InitializeComponent();
            this.titleLabel.Text = "上网记录查询";
            mid = tem;
            InitUI();
            MemberNetRecord();

        }
        public UserNetRecordView()
        {
            InitializeComponent();
            this.titleLabel.Text = "上网记录查询";
            InitUI();
            //MemberNetRecord();


        }
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.UserNetRecord, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;
        }

        #region 会员上网记录查询/条件过滤查询
        //会员上网记录查询
        private void MemberNetRecord()
        {

            StructPage.Builder page = new StructPage.Builder()
            {
                Pagesize = 15,
                Pagebegin = 0,
                Fieldname = 0,
                Order = 0,
            };
            MemberNetOperation.MemberNetRecord(MemberNetRecordResult, this.mid, page.Build());

        }
        //会员上网记录过滤查询
        private void MemberNetFilterRecord()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagesize = 15,
                Pagebegin = 0,
                Fieldname = 0,
                Order = 0,
            };
           // MemberNetOperation.MemberConsumeRecordFilter()


        }
        //会员上网记录查询结果回调
        private void MemberNetRecordResult(ResultModel result)
        {

            
            if(result.pack.Cmd != Cmd.CMD_EMK_RECORD)
            {
                return;
            }

            System.Console.WriteLine("MemberNetRecordResult:" + result.pack);
            NetMessageManage.Manage().RemoveResultBlock(MemberNetRecordResult);
            if (result.pack.Content.MessageType == 1)
            {
                 this.Invoke(new UIHandleBlock(delegate {
                    UpdateGridControl(result.pack.Content.ScEmkRecord.EmkinfoList);
                }));
            }

        }
        #endregion

        #region 更新GridControl 数据
        //更新GridControl列表数据
        private void UpdateGridControl(IList<StructEmbarkation> list)
        {
            foreach (StructEmbarkation realTime in list)
            {
                AddGridControlNewRow(realTime);
            }
        }
        //添加新行
        private void AddGridControlNewRow(StructEmbarkation consum)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IdNumber.ToString()] = consum.Cardnumber;
            row[TitleList.Name.ToString()] = consum.Username;
            row[TitleList.MemberType.ToString()] = consum.Usertype;
            row[TitleList.StartTime.ToString()] = consum.Starttime;
            row[TitleList.EndTime.ToString()] = consum.Stoptime;
            row[TitleList.Area.ToString()] = consum.Area;
            row[TitleList.UseTime.ToString()] = consum.Usedtime;
            row[TitleList.UseMoney.ToString()] = consum.Money;
            row[TitleList.Mac.ToString()] = consum.Mac;
            row[TitleList.Ip.ToString()] = consum.Ip;
        }
        #endregion


        #region 过滤条件搜索/日期/关键字
        //关闭日期选择菜单
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            MemberNetFilterRecord();
        }

        //日期选择触发
        private void DateNavigator_Click(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }
        private void SearchButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MemberNetFilterRecord();
        }

        #endregion
    }
}
