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

namespace NetBarMS.Views.HomePage
{
    public partial class ChatManageView : RootUserControlView
    {
        public ChatManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "聊天管理";
            AddData();
        }
        /// <summary>
        /// 添加ListView数据
        /// </summary>
        private void AddData()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ChatManage, out this.mainDataTable);
            //DataRow row = this.mainDataTable.NewRow();
            //this.mainDataTable.Rows.Add(row);
            //row["column_0"] = "dasdasd";
            this.gridControl1.DataSource = this.mainDataTable;

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
