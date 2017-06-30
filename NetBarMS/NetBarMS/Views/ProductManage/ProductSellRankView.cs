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

namespace NetBarMS.Views.ProductManage
{
    public partial class ProductSellRankView : RootUserControlView
    {
        enum TitleList
        {
            None = 0,

            Type,               //类别
            ChildType,          //子类别
            ProductName,        //商品名称
            SellNumber,         //销售量
            SellNumRank,        //销售量排行
            SellMoney,          //销售额
            SellMoneyRank,       //销售额排行
        }


   

        public ProductSellRankView()
        {
            InitializeComponent();
            this.titleLabel.Text = "销售排行";
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductSellRank, out this.mainDataTable);
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            this.gridControl1.DataSource = this.mainDataTable;
        }
        #region 获取销售记录
        //获取销售记录
        private void GetSellRecordList()
        {
          
           //ProductNetOperation.GetSellRankList

        }
        //获取销售记录结果回调
        private void GetSellRankListResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_GOODS_SALES_TOP)
            {
                NetMessageManage.Manage().RemoveResultBlock(GetSellRankListResult);
                System.Console.WriteLine("GetSellRankListResult:" + result.pack);
            }
        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
           

        }
        //添加新行
        private void AddNewRow(StructSale sale)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
        


        }
        #endregion

    }
}
