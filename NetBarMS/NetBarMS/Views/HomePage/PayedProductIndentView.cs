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
using static NetBarMS.Codes.Tools.NetMessageManage;

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
        private int pageBegin = 0;
        private int pageSize = 15;

        public PayedProductIndentView()
        {
            InitializeComponent();
            this.titleLabel.Text = "已付款商品订单管理";
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.PayedProductIndent, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
        }
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

            //string keyWords = null;
            //if (!this.buttonEdit1.Text.Equals(this.buttonEdit1.Properties.NullText))
            //{
            //    keyWords = this.buttonEdit1.Text;
            //}
            //int status = this.comboBoxEdit1.SelectedIndex + 1;

            //ProductNetOperation.GetProdcutIndentList(GetProdcutIndentListResult, page.Build(), status, addStart, addEnd, handleStart, handleEnd, keyWords);


        }
        //获取销售记录结果回调
        private void GetProdcutIndentListResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_GOODS_ORDER)
            {
                NetMessageManage.Manage().RemoveResultBlock(GetProdcutIndentListResult);
                System.Console.WriteLine("GetProdcutIndentListResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate {

                  

                }));


            }
        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            //foreach (StructOrder order in this.orders)
            //{
            //    AddNewRow(order);
            //}

        }



        //添加新行
        private void AddNewRow(StructOrder order)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            //row[TitleList.IndentNumber.ToString()] = order.Orderid;
            //row[TitleList.IndentUser.ToString()] = order.Username;
            //row[TitleList.IdNumber.ToString()] = order.Cardnumber;
            //row[TitleList.Area.ToString()] = order.Areaname;
            //row[TitleList.IndentMoney.ToString()] = order.Money;
            //row[TitleList.IndentTime.ToString()] = order.Addtime;
            //row[TitleList.HandleTime.ToString()] = order.Proctime;
            //row[TitleList.Staff.ToString()] = order.Operator;
            //row[TitleList.IndetState.ToString()] = order.Status;
            //row[TitleList.PayChannel.ToString()] = order.Paymode;
            //row[TitleList.PayNumber.ToString()] = order.Payid;


        }
        #endregion
        //按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            DataRow row = this.gridView1.GetDataRow(rowhandle);

            String tag = (String)e.Button.Tag;
            String[] param = tag.Split('_');
            

        }

    }
}
