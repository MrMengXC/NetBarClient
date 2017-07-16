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
using DevExpress.XtraEditors.Controls;


namespace NetBarMS.Views.NetUserManage
{
   
    public partial class MemberConsumeRecordView : RootUserControlView
    {
        #region Title ENUM
        private enum TitleList
        {
            None,

            IndentNumber = 0,        //订单号
            IdNumber,               //身份证号
            Name,                   //姓名
            Area,                   //位置
            Use,                    //手用途
            Money,                  //消费金额
            Time,                   //时间
            PayChannel,             //付款渠道


        }
        #endregion
        private Int32 mid;
        private DateTime lastDate = DateTime.MinValue;
        private string startTime = "", endTime = "";
        private IList<StructTrade> records;
        public MemberConsumeRecordView(int temmid)
        {
            InitializeComponent();
            this.titleLabel.Text = "会员消费记录查询";
            this.mid = temmid;
            InitUI();
        }

       
        #region 初始化UI
        //初始化UI数据    
        private void InitUI()
        {
          
            foreach(string use in Enum.GetNames(typeof(CONSUMEUSE)))
            {
                this.useComboBoxEdit.Properties.Items.Add(use);
            }
            foreach (string pay in Enum.GetNames(typeof(PAYCHANNEL)))
            {
                this.payChannelComboBoxEdit.Properties.Items.Add(pay);
            }
            // 设置 comboBox的文本值不能被编辑
            this.useComboBoxEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.payChannelComboBoxEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;


            ToolsManage.SetGridView(this.gridView1, GridControlType.UserConsumeRecord, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;

            GetMemberConsumeRecord(false);


        }
        #endregion

        #region 会员消费记录查询/过滤
        //会员消费记录查询
        private void GetMemberConsumeRecord(bool isFilter)
        {
            if(isFilter)
            {
                this.pageView1.InitPageViewData();
            }

            CONSUMEUSE consume = CONSUMEUSE.无;
            Enum.TryParse<CONSUMEUSE>(this.useComboBoxEdit.Text, out consume);

            PAYCHANNEL paychannel = PAYCHANNEL.无;
            Enum.TryParse<PAYCHANNEL>(this.payChannelComboBoxEdit.Text, out paychannel);

            StructPage.Builder page = new StructPage.Builder()
            {
                Pagesize = pageView1.PageSize,
                Pagebegin = pageView1.PageBegin,
                Fieldname = 0,
                Order = 0,
            };
            RecordNetOperation.GetUserConsumeRecord(MemberConsumeRecordResult, page.Build(), this.startTime, this.endTime, (int)consume, (int)paychannel,mid);



        }


        //会员消费记录查询结果
        private void MemberConsumeRecordResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_QUERY_CONSUM)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(MemberConsumeRecordResult);
            System.Console.WriteLine("MemberConsumeRecordResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {
                    this.pageView1.RefreshPageView(result.pack.Content.ScQueryTrade.Pagecount);
                    records = result.pack.Content.ScQueryTrade.TradesList;
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
            foreach(StructTrade consum in this.records)
            {
                AddGridNewRow(consum);
            }
        }
        //添加新行
        private void AddGridNewRow(StructTrade consum)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IndentNumber.ToString()] = consum.Tradeid;
            row[TitleList.Name.ToString()] = consum.Username;
            row[TitleList.IdNumber.ToString()] = consum.Cardnumber;

            row[TitleList.Area.ToString()] = SysManage.GetAreaName(consum.Area.ToString());
            row[TitleList.Use.ToString()] = Enum.GetName(typeof(CONSUMEUSE), consum.Tradetype);
            row[TitleList.Money.ToString()] = consum.Amount;
            row[TitleList.Time.ToString()] = consum.Addtime;
            row[TitleList.PayChannel.ToString()] = Enum.GetName(typeof(PAYCHANNEL), consum.Paymode); ;


        }
        #endregion

        #region 过滤条件搜索/日期/用途/付款渠道
        //关闭日期选择菜单
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            GetMemberConsumeRecord(true);
        }

        //日期选择触发
        private void DateNavigator_EditValueChanged(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }

        //用途搜索
        private void useComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMemberConsumeRecord(true);

        }
        //支付渠道搜索
        private void payChannelComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMemberConsumeRecord(true);
        }
        #endregion

        #region 翻页
        private void PageView_PageChanged(int current)
        {
            GetMemberConsumeRecord(false);
        }
        #endregion

    }
}
