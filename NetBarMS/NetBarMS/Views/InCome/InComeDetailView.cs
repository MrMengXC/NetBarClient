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
using System.IO;

namespace NetBarMS.Views.InCome
{
    public partial class InComeDetailView : RootUserControlView
    {
        enum TitleList
        {
            None,

            IndentNumber = 0,        //订单号
            Date,                    //日期
            UserName,                //用户姓名
            IdNumber,                   //身份证号
            CpName,                   //设备名称
            IndentMoney,               //金额
            PayChannel,             //营收渠道
            PayIndentNuber,         //支付订单号
            Use,                    //用途
            Detail,                 //具体事项
        }
        public InComeDetailView()
        {
            InitializeComponent();
            this.titleLabel.Text = "营收详情";
            AddData();
        }
        /// <summary>
        /// 添加ListView数据
        /// </summary>
        private void AddData()
        {

            ToolsManage.SetGridView(this.gridView1, GridControlType.InComeDetail, out this.mainDataTable);
            //DataRow row = this.mainDataTable.NewRow();
            //this.mainDataTable.Rows.Add(row);
            //row["column_0"] = "dasdasd";
            this.gridControl1.DataSource = this.mainDataTable;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            ToolsManage.ExportGridControl(this.gridControl1);
        }
    }
}
