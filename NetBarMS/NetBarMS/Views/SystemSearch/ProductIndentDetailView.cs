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

namespace NetBarMS.Views.SystemSearch
{
    public partial class ProductIndentDetailView : RootFormView
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
        private IList<StructOrderDetail> details;
        public ProductIndentDetailView(StructOrder tem)
        {
            InitializeComponent();
            this.order = tem;
            InitUI();
            if(tem != null)
            {
                RefreshUI();
            }
        }
        #region 赋值UI
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductIndentDetail, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            GetProductIndentDetail();
        }
        //刷新UI
        private void RefreshUI()
        {
            this.label1.Text += ""+this.order.Orderid;
            this.label2.Text += this.order.Addtime;
            this.label3.Text += ""+this.order.Money;
        }
        #endregion

        #region 获取订单详情
        //Get Order Info
        private void GetProductIndentDetail()
        {
            ProductNetOperation.GetProdcutIndentDetail(GetProdcutIndentDetailResult,this.order.Orderid);
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
                NetMessageManage.RemoveResultBlock(GetProdcutIndentDetailResult);
                System.Console.WriteLine("GetProdcutIndentDetailResult:" + result.pack);
                this.Invoke(new RefreshUIHandle(delegate {
                    this.details = result.pack.Content.ScOrderDetail.DetailsList;

                    RefreshGridControl();

                }));


            }
        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            foreach(StructOrderDetail detail in this.details)
            {
                AddNewRow(detail);
            }
        }

        //添加新行
        private void AddNewRow(StructOrderDetail detail)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.Type.ToString()] = SysManage.GetProductTypeName(detail.Category);
            row[TitleList.Name.ToString()] = detail.Goodsname;
            row[TitleList.Price.ToString()] = detail.Price;
            row[TitleList.Num.ToString()] = detail.Num;
            row[TitleList.Money.ToString()] = float.Parse(detail.Price) * detail.Num;

        }
        #endregion
    }
}
