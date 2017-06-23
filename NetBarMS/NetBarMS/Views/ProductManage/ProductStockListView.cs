﻿using System;
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

namespace NetBarMS.Views.ProductManage
{
    public partial class ProductStoreList : RootUserControlView
    {

        enum TitleList
        {
            None,

            Number = 0,             //序号
            ProductName,            //商品名称
            Type,                   //类别
            ChildType,              //子类别
            UnitPrice,              //单价
            StockNum,               //库存数量
            StockInventory,         //库存盘点
            Remarks,                //备注
        }
        private Int32 pageBegin = 0;
        private Int32 pageSize = 15;
        private IList<StructStock> products;

        public ProductStoreList()
        {
            InitializeComponent();
            titleLabel.Text = "库存清单";
            InitUI();
        }

        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductStockList, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;

            GetStoreList();

        }
        #region 获取库存清单
        //获取库存清单
        private void GetStoreList()
        {

            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pageBegin,
                Pagesize = this.pageSize,
                Fieldname = 0,
                Order = 0,
            };
            ProductNetOperation.GetStoreList(GetStoreListResult, page.Build());

        }
        //获取库存清单结果回调
        private void GetStoreListResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_GOODS_STOCK)
            {
                NetMessageManage.Manager().RemoveResultBlock(GetStoreListResult);
                System.Console.WriteLine("GetStoreListResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate
                {
                    products = result.pack.Content.ScGoodsStock.GoodsList;
                    RefreshGridControl();
                }));
            }
        }
        #endregion

        #region 刷新GridControl

        //刷新GridControl
        private void RefreshGridControl()
        {
            foreach(StructStock stock in this.products)
            {
                AddNewRow(stock);
            }
        }
        //添加新行
        private void AddNewRow(StructStock product)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);         
            row[TitleList.Number.ToString()] = this.mainDataTable.Rows.Count + "";
            row[TitleList.ProductName.ToString()] = product.Goodsname;
            row[TitleList.Type.ToString()] = SysManage.Manage().GetProductTypeName(product.Category);
            row[TitleList.StockNum.ToString()] = product.Num;
            row[TitleList.UnitPrice.ToString()] = product.Price;

        }

        #endregion

    }
}
