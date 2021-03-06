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
using DevExpress.XtraEditors.Controls;

namespace NetBarMS.Views.SystemManage
{
    public partial class ProductTypeManageView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,
            Check,                  //勾选
            Number,                     //序号
            Type,                       //类别
            Operation,                     //操作
        }

        private IList<StructDictItem> items;

        public ProductTypeManageView()
        {
            InitializeComponent();
            InitUI();
        }
      
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductType, out this.mainDataTable, ColumnButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;
        }
        

        #region 结果回调
        //获取商品类型
        private void ProductTypeInfoResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.productTypeParent))
            {
                NetMessageManage.RemoveResultBlock(ProductTypeInfoResult);
                System.Console.WriteLine("ProductTypeInfoResult:" + result.pack);

                this.Invoke(new RefreshUIHandle(delegate {
                    //更新系统管理
                    SysManage.UpdateProductData(result.pack.Content.ScSysInfo.ChildList);
                    this.items = result.pack.Content.ScSysInfo.ChildList;
                    RefreshGridControl();
                }));

            }
        }

        #endregion

        #region gridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();

            for(int i = 0;i<this.items.Count;i++)
            {
                AddNewRow(this.items[i]);
            }


        }
        //添加新行
        private void AddNewRow(StructDictItem item)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.Number.ToString()] = this.mainDataTable.Rows.Count + "";
            row[TitleList.Type.ToString()] = item.GetItem(0);
        }
        #endregion

        #region 按钮列触发事件
        //按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            DataRow row = this.gridView1.GetDataRow(rowhandle);

            ProductTypeAddView view = new ProductTypeAddView(items[rowhandle]);
            CloseFormHandle close = new CloseFormHandle(delegate () {
                this.Invoke(new RefreshUIHandle(delegate {
                    SystemManageNetOperation.ProductTypeInfo(ProductTypeInfoResult);
                }));
            });
            ToolsManage.ShowForm(view, false, close);


        }
        
        #endregion

        #region 获取所有勾选的ID
        //获取所有勾选的id
        private List<string> GetCheckIds()
        {
            List<string> ids = new List<string>();
            //获取所有勾选的column
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);
                string value = row[TitleList.Check.ToString()].ToString();
                if (value.Equals("True"))
                {
                    StructDictItem item = this.items[i];
                    ids.Add(item.Id.ToString());
                }
            }
            return ids;
        }
        #endregion

        #region 添加商品类别
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ProductTypeAddView view = new ProductTypeAddView();
            CloseFormHandle close = new CloseFormHandle(delegate () {
                //GetProductIndentList();
                this.Invoke(new RefreshUIHandle(delegate {
                    SystemManageNetOperation.ProductTypeInfo(ProductTypeInfoResult);
                }));
            });
            ToolsManage.ShowForm(view, false, close);

           
        }
        #endregion

        #region 删除商品类别
        private void simpleButton3_Click(object sender, EventArgs e)
        {

            List<string> ids = this.GetCheckIds();
            if(ids.Count == 0)
            {
                return;
            }
            SystemManageNetOperation.DeleteProductType(DeleteProductTypeResult, ids);


        }
        private void DeleteProductTypeResult(ResultModel result)
        {
            System.Console.WriteLine("DeleteProductTypeInfoResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_DEL)
            {
                NetMessageManage.RemoveResultBlock(DeleteProductTypeResult);
                this.Invoke(new RefreshUIHandle(delegate {
                    SystemManageNetOperation.ProductTypeInfo(ProductTypeInfoResult);
                }));

            }
        }
        #endregion

        private void ProductTypeManageView_Load(object sender, EventArgs e)
        {
            SystemManageNetOperation.ProductTypeInfo(ProductTypeInfoResult);
        }
    }
}
