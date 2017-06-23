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

namespace NetBarMS.Views.HomePage
{
    public partial class PayedProductIndentDetailView : RootUserControlView
    {
        public PayedProductIndentDetailView()
        {
            InitializeComponent();
            this.titleLabel.Text = "订单详情";
        }
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ProductIndentDetail, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
        }
    }
}
