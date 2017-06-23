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

namespace NetBarMS.Views.ManagerManage
{
    public partial class ManagerManageView : RootUserControlView
    {
        enum TitleList
        {
            None,
            Check = 0,                  //勾选
            Number,                     //序号
            UserName,                   //用户名
            UserRole,                   //用户角色
            Operation,                  //操作

        }
        public ManagerManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "角色管理";
            InitUI();
        }

       //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ManagerManage, out this.mainDataTable);
            //DataRow row = this.mainDataTable.NewRow();
            //this.mainDataTable.Rows.Add(row);
            //row["column_0"] = "dasdasd";
            this.gridControl1.DataSource = this.mainDataTable;

        }

       
        //添加角色
        private void addManagerButton_Click(object sender, EventArgs e)
        {
            ManagerAddView view = new ManagerAddView();
            ToolsManage.ShowForm(view, false);

        }
    }
}
