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
using DevExpress.XtraEditors.Controls;
using NetBarMS.Codes.Tools.NetOperation;

namespace NetBarMS.Views.HomePage
{
    public partial class PayedProductIndentView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,
            Name,           //订单用户
            Area,           //位置
            Money,          //订单金额
            Time,           //下单时间
            Detail,         //订单详情
        }
        private int pageBegin = 0, pageSize = 15;
        private IList<StructOrder> orders;
        public PayedProductIndentView()
        {
            InitializeComponent();
            this.titleLabel.Text = "已付款商品订单管理";
            InitUI();
        }
        #region 初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.PayedProductIndent, out this.mainDataTable,ButtonColumn_ButtonClick);
            this.gridControl1.DataSource = this.mainDataTable;
            GetProductIndentList();
        }
        #endregion

        #region 获取销售记录
        //获取销售记录
        private void GetProductIndentList()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = pageBegin,
                Pagesize = pageSize,
                Fieldname = 0,
                Order = 0,
            };

            string keyWords = this.buttonEdit1.Text;

            //1提交 2付款完成 3订单处理完成（发货完成）
            //"1提交","2完成","3撤销"
            ProductNetOperation.GetProdcutIndentList(GetProdcutIndentListResult, page.Build(), 1,"","","","", keyWords);
        }
        //获取已付款商品订单列表
        private void GetProdcutIndentListResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_GOODS_ORDER)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetProdcutIndentListResult);
            System.Console.WriteLine("GetProdcutIndentListResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    this.orders = result.pack.Content.ScOrderList.OrdersList;
                    RefreshGridControl();
                }));
            }

        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Rows.Clear();
            foreach (StructOrder order in this.orders)
            {
                AddNewRow(order);
            }

        }
        //添加新行
        private void AddNewRow(StructOrder order)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.Name.ToString()] = order.Username;
            row[TitleList.Area.ToString()] = order.Areaname;
            row[TitleList.Money.ToString()] = order.Money;
            row[TitleList.Time.ToString()] = order.Addtime;
        }
        #endregion

        #region 按钮列的点击事件(点击查看)
        public void ButtonColumn_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            StructOrder order = orders[rowhandle];

            CloseFormHandle close = new CloseFormHandle(delegate () {
                GetProductIndentList();
            });
            PayedProductIndentDetailView detail = new PayedProductIndentDetailView(order);
            ToolsManage.ShowForm(detail, false, close);
        }
        #endregion

        #region 搜索按钮点击事件
        //搜索按钮
        public void SearchButton_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            GetProductIndentList();
        }
        #endregion
    }
}
