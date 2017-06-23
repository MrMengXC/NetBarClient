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

namespace NetBarMS.Views.OtherMain
{
    public partial class MsgBoardView : RootUserControlView
    {
        public MsgBoardView()
        {
            InitializeComponent();
            this.titleLabel.Text = "留言板";
            AddData();
        }
        /// <summary>
        /// 添加ListView数据
        /// </summary>
        private void AddData()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.MsgBoard, out this.mainDataTable);
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row["column_0"] = "dasdasd";
            this.gridControl1.DataSource = this.mainDataTable;
        }
    }
}
