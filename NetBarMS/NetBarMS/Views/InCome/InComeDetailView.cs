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

namespace NetBarMS.Views.InCome
{
    public partial class IncomeDetailView : RootFormView
    {
        private enum TitleList
        {
            None = 0,
            Time,               //时间段
            SellMoney,          //购物消费金额
            PayMoney,           //网费充值金额
            AllIncome,          //收入总额
            ZfbIncome,          //支付宝收入
            WxIncome,           //微信收入
            CashIncome          //现金收入
        }

        
        private IncomeType incomeType;
        private List<StructEarn> earns;
        private int year;
        private int month;

        public IncomeDetailView(IncomeType type,List<StructEarn> tem,int temyear,int temmonth)
        {
            InitializeComponent();
            incomeType = type;
            earns = tem;
            year = temyear;
            month = temmonth;
            InitUI();
        }

        //初始化UI
        private void InitUI()
        {
            switch(this.incomeType)
            {
                case IncomeType.DAY_INCOME:
                    ToolsManage.SetGridView(this.gridView1, GridControlType.DayIncomeDetail, out this.mainDataTable);
                    this.titleLabel.Text = "日营收详情";

                    break;
                case IncomeType.MONTH_INCOME:
                    ToolsManage.SetGridView(this.gridView1, GridControlType.MonthIncomeDetail, out this.mainDataTable);
                    this.titleLabel.Text = "月营收详情";

                    break;
                case IncomeType.YEAR_INCOME:
                    ToolsManage.SetGridView(this.gridView1, GridControlType.YearIncomeDetail, out this.mainDataTable);
                    this.titleLabel.Text = "年营收详情";

                    break;
            }

            this.gridControl1.DataSource = this.mainDataTable;

            RefreshGridControl();
        }

        //刷新GridControl
        private void RefreshGridControl()
        {
            if(this.earns == null)
            {
                return;
            }
            foreach(StructEarn earn in this.earns)
            {
                AddNewRow(earn);
            }

            //求合计
            this.gridView1.Columns[TitleList.SellMoney.ToString()].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView1.Columns[TitleList.PayMoney.ToString()].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView1.Columns[TitleList.AllIncome.ToString()].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView1.Columns[TitleList.ZfbIncome.ToString()].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView1.Columns[TitleList.WxIncome.ToString()].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.gridView1.Columns[TitleList.CashIncome.ToString()].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.Time.ToString()] = "合计";
            row[TitleList.SellMoney.ToString()] = this.gridView1.Columns[TitleList.SellMoney.ToString()].SummaryItem.SummaryValue;
            row[TitleList.PayMoney.ToString()] = this.gridView1.Columns[TitleList.PayMoney.ToString()].SummaryItem.SummaryValue;
            row[TitleList.AllIncome.ToString()] = this.gridView1.Columns[TitleList.AllIncome.ToString()].SummaryItem.SummaryValue;
            row[TitleList.ZfbIncome.ToString()] = this.gridView1.Columns[TitleList.ZfbIncome.ToString()].SummaryItem.SummaryValue;
            row[TitleList.WxIncome.ToString()] = this.gridView1.Columns[TitleList.WxIncome.ToString()].SummaryItem.SummaryValue;
            row[TitleList.CashIncome.ToString()] = this.gridView1.Columns[TitleList.CashIncome.ToString()].SummaryItem.SummaryValue;
            

        }

        //添加新行
        private void AddNewRow(StructEarn earn)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            if(this.incomeType == IncomeType.DAY_INCOME)
            {
                row[TitleList.Time.ToString()] = earn.Datetime;
            }
            else if(this.incomeType == IncomeType.MONTH_INCOME)
            {
                row[TitleList.Time.ToString()] =year +"年"+month+"月"+earn.Datetime+"日";
            }
            else
            {
                row[TitleList.Time.ToString()] = year + "年" + earn.Datetime + "月";
            }
            row[TitleList.SellMoney.ToString()] = earn.CashSale + earn.TenpaySale +earn.AlipaySale;
            row[TitleList.PayMoney.ToString()] = earn.CashCharge +earn.TenpayCharge + earn.AlipayCharge;
            row[TitleList.AllIncome.ToString()] = earn.CashSale + earn.TenpaySale + earn.AlipaySale+ earn.CashCharge + earn.TenpayCharge + earn.AlipayCharge;
            row[TitleList.ZfbIncome.ToString()] = earn.AlipayCharge + earn.AlipaySale;
            row[TitleList.WxIncome.ToString()] = earn.TenpayCharge +earn.TenpaySale;
            row[TitleList.CashIncome.ToString()] = earn.CashCharge + earn.CashSale;


        }
    }
}
