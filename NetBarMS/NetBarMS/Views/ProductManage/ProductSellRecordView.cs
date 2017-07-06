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
using DevExpress.XtraScheduler;
using NetBarMS.Codes.Tools.NetOperation;
namespace NetBarMS.Views.ProductManage
{
    public partial class ProductSellRecordView : RootUserControlView
    {
        private enum TitleList
        {
            None,
            IndentNumber = 0,        //订单号
            IdNumber,               //身份证号
            Name,                   //姓名
            Area,                   //位置
            ProductName,            //商品名称
            Num,                    //数量
            IndentMoney,            //消费金额
            IndentTime,             //下单时间
            PayChannel,             //付款渠道
        }


        private string startTime = "", endTime = "";
        private DateTime lastDate = DateTime.MinValue;

        private Int32 productId;
        private int pagebegin = 0, pageSize = 15;
        private IList<StructSale> sales;

        public ProductSellRecordView(Int32 id)
        {
            InitializeComponent();
            this.titleLabel.Text = "商品销售记录查询";
            productId = id;

            InitUI();
        }
        
         //初始化UI
        private void InitUI()
        {

            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductSellRecord, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;

            GetSellRecordList();
        }

        #region 获取销售记录
        //获取销售记录
        private void GetSellRecordList()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = pagebegin,
                Pagesize = pageSize,
                Fieldname = 0,
                Order = 0,
            };
            ProductNetOperation.GetSellRecordList(GetSellRecordListResult, page.Build(),this.productId,startTime,endTime);

        }
        //获取销售记录结果回调
        private void GetSellRecordListResult(ResultModel result)
        {
            if(result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_GOODS_SALES)
            {
                NetMessageManage.Manage().RemoveResultBlock(GetSellRecordListResult);
                System.Console.WriteLine("GetSellRecordListResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate{
                    sales = result.pack.Content.ScSalesRecord.SalesList;
                    RefreshGridControl();
                }));


            }
        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            foreach(StructSale sale in this.sales)
            {
                AddNewRow(sale);
            }

        }
        //添加新行
        private void AddNewRow(StructSale sale)
        {
              DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IndentNumber.ToString()] = sale.Orderid;
            row[TitleList.Name.ToString()] = sale.Username;
            row[TitleList.IdNumber.ToString()] = sale.Cardnumber;
            row[TitleList.Area.ToString()] = sale.Areaname;
            row[TitleList.ProductName.ToString()] = sale.Goodsname;
            row[TitleList.Num.ToString()] = sale.Num;
            row[TitleList.IndentMoney.ToString()] = sale.Money;
            row[TitleList.IndentTime.ToString()] = sale.Addtime;
            row[TitleList.PayChannel.ToString()] = sale.Paymode;


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
            //进行查询
           //System.Console.WriteLine("start:"+startTime +"end:"+endTime);
           this.mainDataTable.Clear();
           GetSellRecordList();
        }
        #endregion

    }
}
