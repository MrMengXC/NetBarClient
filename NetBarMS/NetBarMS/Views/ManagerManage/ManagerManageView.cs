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

namespace NetBarMS.Views.ManagerManage
{
    public partial class ManagerManageView : RootUserControlView
    {
        enum TitleList
        {
            None,
            Check = 0,                  //勾选
            Number,                     //序号
            ManagerName,                //角色名称
            ManagerLimit,               //角色权限
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
            ToolsManage.SetGridView(this.gridView1, GridControlType.ManagerManage, out this.mainDataTable,ButtonPressedEventClick,null);
            this.gridControl1.DataSource = this.mainDataTable;

        }
        private void GetManagerList()
        {
            ManagerNetOperation.GetManagerList(GetManagerListResult, CurrentStaffManage.Manage().GetCurrentStaffId());
        }
        private void GetManagerListResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_ROLE_LIST)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(GetManagerListResult);
            System.Console.WriteLine("GetManagerListResult:"+result.pack);
            if(result.pack.Content.MessageType == 1)
            {

            }

        }
        //添加角色
        private void addManagerButton_Click(object sender, EventArgs e)
        {
            ManagerAddView view = new ManagerAddView();
            ToolsManage.ShowForm(view, false);

        }


        //按钮列功能
        private void ButtonPressedEventClick(object sender, ButtonPressedEventArgs e)
        {
            int row = this.gridView1.FocusedRowHandle;
            //进行修改
            ManagerAddView view = new ManagerAddView();
            ToolsManage.ShowForm(view, false);

        }
    }
}
