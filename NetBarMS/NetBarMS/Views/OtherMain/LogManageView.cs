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

namespace NetBarMS.Views
{
    public partial class LogManageView : RootUserControlView
    {
        enum TitleList
        {
            None,
            Check = 0,                          //勾选
            OperationPerson,                    //操作人
            OperationExplain,                   //操作说明
            OperationIp,                        //操作Ip地址
            OperationTime,                      //操作状态
            OperationStatus,
        }
        public LogManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "日志管理";

            AddData();
        }

        /// <summary>
        /// 添加ListView数据
        /// </summary>
        private void AddData()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.LogManage, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
        }
    }
}
