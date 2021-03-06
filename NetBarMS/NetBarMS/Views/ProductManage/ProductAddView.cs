﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools;
using DevExpress.XtraEditors.Controls;
using NetBarMS.Codes.Model;
using System.IO;
using NetBarMS.Codes.Tools.Manage;
using DevExpress.XtraEditors;

namespace NetBarMS.Views.ProductManage
{
    public partial class ProductAddView : RootFormView
    {

        private StructGoods product;
        private List<ProductTypeModel> productTypes;
        private string[] pictures =  new string[3];

        public ProductAddView(StructGoods updateProduct)
        {
            InitializeComponent();
            InitUI();
            if (updateProduct != null)
            {
                product = updateProduct;
                RefreshUI();
            }
        }
        #region 初始化UI
        private void InitUI()
        {
            //初始化TextEdit
            TextEdit[] edits = {
                this.textEdit2,this.textEdit4
            };
            InitTextEdit(edits);

            //首先要获取产品列表数组
            this.productTypes = SysManage.ProductTypes;
            // 设置 comboBox的文本值不能被编辑
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            //初始化ComboBoxEdit
            for (int i = 0; i < productTypes.Count(); i++)
            {
                ProductTypeModel item = this.productTypes[i];
                this.comboBoxEdit1.Properties.Items.Add(item.typeName);
            }
        }
        //刷新UI
        private void RefreshUI()
        {
            this.textEdit1.Text = this.product.GoodsName;
            this.textEdit2.Text = this.product.Count+"";
            this.textEdit3.Text = this.product.Price +"";
            this.textEdit4.Text = this.product.Integal + "";
            if(this.productTypes!=null)
            {
                this.comboBoxEdit1.Text = SysManage.GetProductTypeName(this.product.Category);
            }

            this.productPicture1.NetPath = this.product.GoodsImg1;
            this.productPicture2.NetPath = this.product.GoodsImg2;
            this.productPicture3.NetPath = this.product.GoodsImg3;

            this.checkedListBoxControl1.Items[0].CheckState = this.product.UseIntegal ? CheckState.Checked : CheckState.Unchecked;
            this.checkedListBoxControl1.Items[2].CheckState = this.product.Hide ? CheckState.Checked : CheckState.Unchecked;


        }
        #endregion
        //保存/修改
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string pname = this.textEdit1.Text;
            int index = this.comboBoxEdit1.SelectedIndex;
            string num = textEdit2.Text;
            string price = textEdit3.Text;
            string integal = textEdit4.Text;

            if(index < 0 || pname.Equals("") || num.Equals("") || price.Equals("") ||integal.Equals(""))
            {
                MessageBox.Show("请完整添加选项");
                return;
            }
            StructGoods.Builder newProduct;
            //修改
            if (this.product != null)
            {
                newProduct = new StructGoods.Builder(this.product);
            }
            //添加
            else
            {
                newProduct = new StructGoods.Builder();
                newProduct.GoodsId = 0;
            }
            newProduct.GoodsName = pname;
            newProduct.Category = this.productTypes[index].typeId;
            newProduct.Count = int.Parse(num);
            newProduct.Price = price;
            newProduct.Integal = int.Parse(integal);
            newProduct.GoodsImg1 = this.productPicture1.NetPath;
            newProduct.GoodsImg2 = this.productPicture2.NetPath;
            newProduct.GoodsImg3 = this.productPicture3.NetPath;

            newProduct.UseIntegal = this.checkedListBoxControl1.Items[0].CheckState == CheckState.Checked;
            newProduct.Hide = this.checkedListBoxControl1.Items[2].CheckState == CheckState.Checked;
            //
            if (this.product != null)
            {
                System.Console.WriteLine("newProduct:"+ newProduct);
                ProductNetOperation.UpdateProduct(ProductResult, newProduct.Build());
            }
            //添加
            else
            {
                ProductNetOperation.AddProduct(ProductResult, newProduct.Build());
            }
        }

        //添加修改结果回调
        private void ProductResult(ResultModel result)
        {

          
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_GOODS_ADD)
            {
                NetMessageManage.RemoveResultBlock(ProductResult);
                System.Console.WriteLine("ProductResult:" + result.pack);
                this.Invoke(new RefreshUIHandle(delegate
                {
                    MessageBox.Show("添加成功");
                }));
            }
            else if (result.pack.Cmd == Cmd.CMD_GOODS_UPDATE)
            {
                NetMessageManage.RemoveResultBlock(ProductResult);
                System.Console.WriteLine("ProductResult:" + result.pack);
                this.Invoke(new RefreshUIHandle(delegate
                {
                    MessageBox.Show("修改成功");
                }));
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
