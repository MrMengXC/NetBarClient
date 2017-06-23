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
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Views.SystemSearch
{
    public partial class ProductIndentDetailView : RootUserControlView
    {
        private enum TitleList {
            None = 0,
            Type,
            Name,
            Price,
            Num,
            Money,

        }


        private StructOrder order;
        public ProductIndentDetailView(StructOrder tem)
        {
            InitializeComponent();
            this.titleLabel.Text = "订单详情";
            InitUI();
            if(tem != null)
            {
                RefreshUI();
            }
        }
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductIndentDetail, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
        }
        //刷新UI
        private void RefreshUI()
        {
            this.label1.Text += ""+this.order.Orderid;
            this.label2.Text += this.order.Addtime;
            this.label3.Text += ""+this.order.Money;
        }
        #region 获取订单详情
        //Get Order Info
        private void GetProductIndentDetail()
        {
            ProductNetOperation.GetProdcutIndentDetail(GetProdcutIndentDetailResult);
        }
        //获取订单详情结果回调
        private void GetProdcutIndentDetailResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_GOODS_ORDER_DETAIL)
            {
                NetMessageManage.Manager().RemoveResultBlock(GetProdcutIndentDetailResult);
                System.Console.WriteLine("GetProdcutIndentDetailResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate {

                    RefreshGridControl();

                }));


            }
        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {

        }

        //添加新行
        private void AddNewRow()
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
        }
        #endregion
    }
}
