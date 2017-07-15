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

namespace NetBarMS.Views.SystemSearch
{
    public partial class ProductIndentView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,
            IndentNumber,           //订单号
            IndentUser,             //订单用户
            IdNumber,               //身份证号
            Area,                   //位置
            IndentMoney,            //订单金额
            IndentTime,             //下单时间
            HandleTime,             //处理时间
            Staff,                  //当班人
            IndetState,             //订单状态
            PayChannel,             //付款渠道
            PayNumber,              //支付订单号
            Detail                  //订单详情
        }
        private Int32 pageBegin = 0, pageSize = 15;
        private DateTime addLastDate = DateTime.MinValue,handleDateTime = DateTime.MinValue;
        private string addStart = "", addEnd = "", handleStart = "", handleEnd = "";
        private IList<StructOrder> orders;

        public ProductIndentView()
        {
            InitializeComponent();
            this.titleLabel.Text = "商品订单查询";
            InitUI();
        }
        
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductIndent, out this.mainDataTable,ColumnButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;

            //设置时间表
            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;
            this.dateNavigator2.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator2.UpdateSelectionWhenNavigating = false;
            this.dateNavigator2.SyncSelectionWithEditValue = false;

            //添加状态
            string[] statuses = {"提交","完成","撤销" }; 
            foreach(string statuStr in statuses)
            {
                this.comboBoxEdit1.Properties.Items.Add(statuStr);
            }


            GetProductIndentList();

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

            string keyWords = null;
            if(!this.buttonEdit1.Text.Equals(this.buttonEdit1.Properties.NullText))
            {
                keyWords = this.buttonEdit1.Text;
            }
            int status = this.comboBoxEdit1.SelectedIndex + 1;

            ProductNetOperation.GetProdcutIndentList(GetProdcutIndentListResult,page.Build(), status, addStart, addEnd, handleStart, handleEnd, keyWords);


        }
        //获取销售记录结果回调
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
                this.Invoke(new RefreshUIHandle(delegate {
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
            foreach(StructOrder order in this.orders)
            {
                AddNewRow(order);
            }

        }

       

        //添加新行
        private void AddNewRow(StructOrder order)
        {
           
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IndentNumber.ToString()] = order.Orderid;
            row[TitleList.IndentUser.ToString()] = order.Username;
            row[TitleList.IdNumber.ToString()] = order.Cardnumber;
            row[TitleList.Area.ToString()] = order.Areaname;
            row[TitleList.IndentMoney.ToString()] = order.Money;
            row[TitleList.IndentTime.ToString()] = order.Addtime;
            row[TitleList.HandleTime.ToString()] = order.Proctime;
            row[TitleList.Staff.ToString()] = order.Operator;
            row[TitleList.IndetState.ToString()] = order.Status;
            row[TitleList.PayChannel.ToString()] = order.Paymode;
            row[TitleList.PayNumber.ToString()] = order.Payid;


        }
        #endregion

        //按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int row = this.gridView1.FocusedRowHandle;
            StructOrder order = this.orders[row];

            ProductIndentDetailView view = new ProductIndentDetailView(order);
            ToolsManage.ShowForm(view, false);

        }
        #region 日期选择
        //日期选择触发
        private void DateNavigator_EditValueChanged(object sender, System.EventArgs e)
        {
            if(sender.Equals(this.dateNavigator1))
            {
                addLastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator1, addLastDate, out this.addStart, out this.addEnd);

            }
            else if(sender.Equals(this.dateNavigator2))
            {
                handleDateTime = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator2, handleDateTime, out this.handleStart, out this.handleEnd);
            }
        }
        #endregion

        #region 关闭日期
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //进行查询
            this.mainDataTable.Clear();
            GetProductIndentList();
        }
        #endregion

        #region 按钮输入框搜索
        private void ButtonEdit1_Click(object sender, System.EventArgs e)
        {
           
        }
        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //进行查询
            this.mainDataTable.Clear();
            GetProductIndentList();
        }


        #endregion

        #region 选择状态
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mainDataTable.Clear();
            GetProductIndentList();
        }

        #endregion
    }
}
