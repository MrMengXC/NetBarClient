using System;
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

namespace NetBarMS.Views.SystemManage
{
    public partial class ProductTypeAddView : RootFormView
    {
        private StructDictItem item = null;

        public ProductTypeAddView()
        {
            InitializeComponent();
        }

        public ProductTypeAddView(StructDictItem tem)
        {
            InitializeComponent();
            this.item = tem;
            InitUI();
        }
        #region 初始化UI
        private void InitUI()
        {
            if (this.item != null)
            {
                this.typeTextEdit.Text = this.item.GetItem(0);
            }
        }
        #endregion

        #region 保存信息
        //保存等级信息
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //保存
            //等级名称
            string productType = this.typeTextEdit.Text;

            if (productType.Equals(""))
            {
                return;
            }
            if (this.item == null)
            {
                StructDictItem.Builder temitem = new StructDictItem.Builder()
                {
                    Id = 0,
                    Code = 0,
                };
                temitem.AddItem(productType);

                SystemManageNetOperation.AddProductType(AddProductTypeResult, temitem.Build());
            }
            else
            {
                StructDictItem.Builder temitem = new StructDictItem.Builder(this.item);
                temitem.ClearItem();
                temitem.AddItem(productType);
                SystemManageNetOperation.UpdateProductType(UpdateProductTypeResult, temitem.Build());
            }
        }

        //添加结果回调
        private void AddProductTypeResult(ResultModel result)
        {
           

            if (result.pack.Cmd != Cmd.CMD_SYS_ADD)
            {
                return;
            }
            if (result.pack.Content.MessageType == 1)
            {
                NetMessageManage.RemoveResultBlock(AddProductTypeResult);
                System.Console.WriteLine("AddProductTypeInfoResult:" + result.pack);

                this.Invoke(new RefreshUIHandle(delegate
                {
                    MessageBox.Show("添加成功");

                }));
            }


        }
        //更新结果回调
        private void UpdateProductTypeResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_UPDATE)
            {
                return;
            }
            if (result.pack.Content.MessageType == 1)
            {
                NetMessageManage.RemoveResultBlock(UpdateProductTypeResult);
                this.Invoke(new RefreshUIHandle(delegate
                {
                    MessageBox.Show("更新成功");

                }));
            }

         
        }
        #endregion
    }
}
