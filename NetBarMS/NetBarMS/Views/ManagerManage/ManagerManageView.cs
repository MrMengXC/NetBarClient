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
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Views.ManagerManage
{
    public partial class ManagerManageView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,
            Check,                  //勾选
            Number,                     //序号
            ManagerName,                //角色名称
            Operation,                  //操作

        }
        private IList<StructRole> managers;
        private int delNum;


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
            GetManagerList();

        }
        #region 获取管理员
        //获取管理员列表
        private void GetManagerList()
        {
            ManagerNetOperation.GetManagerList(GetManagerListResult, CurrentStaffManage.Manage().GetCurrentStaffId());
        }
        //获取管理员列表结果回调
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
                this.Invoke(new UIHandleBlock(delegate {
                    SysManage.Manage().UpdateManagerData(result.pack.Content.ScRoleList.RolesList);
                    managers = result.pack.Content.ScRoleList.RolesList;
                    RefreshGridControl();

                }));

            }

        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            foreach(StructRole role in this.managers)
            {
                AddNewRow(role);
            }
        }
        //添加新行
        private void AddNewRow(StructRole role)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.Number.ToString()] = this.mainDataTable.Rows.Count;
            row[TitleList.ManagerName.ToString()] = role.Name;
        }
        #endregion

        #region 添加角色
        private void addManagerButton_Click(object sender, EventArgs e)
        {
            CloseFormHandle close = new CloseFormHandle(delegate {
                GetManagerList();
            });
            ManagerAddView view = new ManagerAddView(null);
            ToolsManage.ShowForm(view, false, close);
        }
        #endregion

        #region 按钮列
        //按钮列功能
        private void ButtonPressedEventClick(object sender, ButtonPressedEventArgs e)
        {
            int row = this.gridView1.FocusedRowHandle;
            StructRole role = this.managers[row];
            CloseFormHandle close = new CloseFormHandle(delegate {
                GetManagerList();
            });
            ManagerAddView view = new ManagerAddView(role);
            ToolsManage.ShowForm(view, false, close);
        }
        #endregion

        #region 删除
        //删除
        private void deleteManagerButton_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            for(int i = 0;i<this.mainDataTable.Rows.Count;i++)
            {
                DataRow row = this.mainDataTable.Rows[i];
                if (row[TitleList.Check.ToString()].ToString().Equals("True"))
                {
                    ids.Add(i);
                }
            }
            this.delNum = ids.Count;
            foreach(int row in ids)
            {
                StructRole manager = this.managers[row];
                ManagerNetOperation.DeleteManager(DeleteManagerResult, int.Parse(manager.Roleid));
            }

        }
        //删除结果回调
        private void DeleteManagerResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_ROLE_DEL)
            {
                return;
            }
            this.delNum -= 1;
            NetMessageManage.Manage().RemoveResultBlock(DeleteManagerResult);
            System.Console.WriteLine("DeleteManagerResult" + result.pack);
            if(delNum == 0)
            {
                this.Invoke(new UIHandleBlock(delegate
                {
                    GetManagerList();
                }));
            }
        }
        #endregion

    }
}
