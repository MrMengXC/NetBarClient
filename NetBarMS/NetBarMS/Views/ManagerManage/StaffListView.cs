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
    public partial class StaffListView : RootUserControlView
    {
        enum TitleList
        {
            None = 0,
            Number,                  //序号
            StaffName,                     //姓名
            TelNumber,                   //手机号码
            UserName,                   //用户名
            Role,                  //角色
            Operation,                  //操作


        }
        public StaffListView()
        {
            InitializeComponent();
            this.titleLabel.Text = "员工列表";
            InitUI();
        }
      
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.StaffList, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
        }

        //添加员工
        private void addManagerButton_Click(object sender, EventArgs e)
        {
            StaffAddView view = new StaffAddView();
            ToolsManage.ShowForm(view, false);

        }
    }
}
