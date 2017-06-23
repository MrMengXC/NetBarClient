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
using DevExpress.XtraEditors.Controls;
using NetBarMS.Codes.Tools.NetOperation;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Views.ProductManage
{
    enum TitleList
    {
        None,

        Check = 0,              //勾选
        Number,                 //序号
        ProductName,            //名称
        Type,                   //类别
        ChildType,              //子类别
        UnitPrice,              //单价
        IsIntegralExchange,       //是否积分兑换
        IsShowShop,               //在商城中显示
        IntegralExchange,            //积分兑换
        StockNum,               //库存数量
        SellRecord,               //销售记录
        Operation,               //操作



    }
    public partial class ProductManageView : RootUserControlView
    {


        private enum TitleList
        {

            None = 0,
            Check,
            Number,
            Name,
            Type,
            Price,
            IsIntegral,
            IsShowStore,
            Integral,
            Num,
            SellRecord,
            Operation,

        }

        private List<StructDictItem> productTypes;
        private IList<StructGoods> products;
        private int pageBegin = 0;
        private int pageSize = 15;

        public ProductManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "上架商品管理";
            InitUI();
            
        }

        #region 初始化UI
        private void InitUI()
        {
            this.productTypes = null;
            SysManage.Manage().GetProductTypes(out this.productTypes);
            if (productTypes != null)
            {
                //初始化ComboBoxEdit
                for (int i = 0; i < productTypes.Count(); i++)
                {
                    StructDictItem item = productTypes[i];

                    this.comboBoxEdit1.Properties.Items.Add(item.GetItem(0));
                }
            }
            // 设置 comboBox的文本值不能被编辑
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;

            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductManage, out this.mainDataTable,ColumnButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;

            GetProductList();
        }
        #endregion

        #region 获取商品列表
        private void GetProductList()
        {
            Int32 category = -1;
            if(this.comboBoxEdit1.SelectedIndex >= 0)
            {
                category = this.productTypes[this.comboBoxEdit1.SelectedIndex].Id;
            }
            string keyWords = this.buttonEdit1.Text;
            if(keyWords.Equals(""))
            {
                keyWords = null;
            }
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagesize = pageSize,
                Pagebegin = pageBegin,
                Fieldname = 0,
                Order = 0,

            };
            ProductNetOperation.GetProductList(GetProductListResult, page.Build(), category, keyWords);
           
        }
        //获取商品列表结果回调
        private void GetProductListResult(ResultModel result)
        {

            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if(result.pack.Cmd == Cmd.CMD_GOODS_FIND)
            {
                NetMessageManage.Manager().RemoveResultBlock(GetProductListResult);
                System.Console.WriteLine("GetProductListResult:"+result.pack);
                this.Invoke(new UIHandleBlock(delegate
                {
                    products = result.pack.Content.ScGoodsFind.GoodsList;
                    RefreshGridControl();
                }));
            }
        }
        #endregion

        #region 显示GridControl 数据
        //刷新GridControl
        private void RefreshGridControl()
        {
            foreach(StructGoods product in this.products)
            {
                AddNewRow(product);
            }
        }
        //添加新行
        private void AddNewRow(StructGoods product)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.Number.ToString()] = this.mainDataTable.Rows.Count + "";
            row[TitleList.Name.ToString()] = product.GoodsName;
            row[TitleList.Type.ToString()] =SysManage.Manage().GetProductTypeName(product.Category);
            row[TitleList.Price.ToString()] = product.Price;
            row[TitleList.IsIntegral.ToString()] = product.UseIntegal;
            row[TitleList.IsShowStore.ToString()] = product.Hide;
            row[TitleList.Integral.ToString()] = product.Integal;
            row[TitleList.Num.ToString()] = product.Count;
        }
        #endregion

        #region 添加商品
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ProductAddView view = new ProductAddView(null);
            CloseFormHandle close =  new CloseFormHandle(delegate
            {
                this.mainDataTable.Clear();
                GetProductList();
            });
            ToolsManage.ShowForm(view, false,close);
        }
        #endregion

        #region 打印库存清单
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ProductStoreList view = new ProductStoreList();
            ToolsManage.ShowForm(view, false);
        }
        #endregion

        #region 按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            StructGoods product = this.products[rowhandle];

            DataRow row = this.gridView1.GetDataRow(rowhandle);
            String tag = (String)e.Button.Tag;
            String[] param = tag.Split('_');
            //查看用户身份信息
            if (param[0].Equals(TitleList.SellRecord.ToString()))
            {
                ProductSellRecordView view = new ProductSellRecordView(product.GoodsId);
                ToolsManage.ShowForm(view, false);

            }else if(param[0].Equals(TitleList.Operation.ToString()))
            {
                //修改信息
                if(param[1].Equals("0"))
                {
                    ProductAddView view = new ProductAddView(product);
                    CloseFormHandle close = new CloseFormHandle(delegate
                    {
                        this.mainDataTable.Clear();
                        GetProductList();
                    });
                    ToolsManage.ShowForm(view, false, close);
                }
                //删除
                else
                {
                    List<int> ids = new List<int>()
                    {
                        product.GoodsId,
                    };
                    ProductNetOperation.DeleteProduct(DeleteProductResult, ids);

                }
            }
        }
        #endregion

        #region 删除商品
        //删除选中商品
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            for(int i = 0;i<this.mainDataTable.Rows.Count;i++)
            {
                StructGoods prodcut = this.products[i];
                DataRow row = this.mainDataTable.Rows[i];

                if(row[TitleList.Check.ToString()].ToString().Equals("True"))
                {
                    ids.Add(prodcut.GoodsId);
                }

            }
            if(ids.Count == 0)
            {
                return;
            }
            ProductNetOperation.DeleteProduct(DeleteProductResult, ids);

        }
        //删除结果回调
        private void DeleteProductResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_GOODS_DEL)
            {
                NetMessageManage.Manager().RemoveResultBlock(DeleteProductResult);
                System.Console.WriteLine("DeleteProductResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate
                {
                    MessageBox.Show("删除成功");
                    this.mainDataTable.Clear();
                    GetProductList();
                }));
            }
        }
        #endregion

        #region 进行搜索
        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.mainDataTable.Clear();
            GetProductList();
        }
        #endregion

        #region 选择进行搜索
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mainDataTable.Clear();
            GetProductList();
        }
        #endregion
    }
}
