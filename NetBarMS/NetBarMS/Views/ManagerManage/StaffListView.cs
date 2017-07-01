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
using NetBarMS.Codes.Tools.NetOperation;
using static NetBarMS.Codes.Tools.NetMessageManage;
using DevExpress.XtraEditors.Controls;


namespace NetBarMS.Views.ManagerManage
{
    public partial class StaffListView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,
            Number,                  //序号
            StaffName,                     //姓名
            TelNumber,                   //手机号码
            UserName,                   //用户名
            Role,                  //角色
            Operation,                  //操作


        }

        private IList<StructAccount> staffs;
        public StaffListView()
        {
            InitializeComponent();
            this.titleLabel.Text = "员工列表";
            InitUI();
        }
      
        //初始化UI
        private void InitUI()
        {
            //new 
            ToolsManage.SetGridView(this.gridView1, GridControlType.StaffList, out this.mainDataTable, ButtonPressedEventClick,null);
            this.gridControl1.DataSource = this.mainDataTable;
            GetStaffList();
        }
        #region 获取员工列表
        private void GetStaffList()
        {
            StaffNetOperation.GetStaffList(GetStaffListResult);
        }

        //获取员工列表结果回调
        private void GetStaffListResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_STAFF_LIST)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(GetStaffListResult);
            System.Console.WriteLine("GetStaffListResult:" + result.pack);

            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    SysManage.Manage().UpdateStaffData(result.pack.Content.ScAccountList.AccountList);
                    this.staffs = result.pack.Content.ScAccountList.AccountList;
                    RefreshGridControle();
                }));

            }
        }
        #endregion

        #region 刷新GridControl
        private void RefreshGridControle()
        {
            this.mainDataTable.Clear();
            foreach(StructAccount staff in this.staffs)
            {
                AddNewRow(staff);
            }
        }

        //添加新行
        private void AddNewRow(StructAccount staff)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.Number.ToString()] = this.mainDataTable.Rows.Count;
            row[TitleList.StaffName.ToString()] = staff.Nickname;
            row[TitleList.TelNumber.ToString()] = staff.Phone;
            row[TitleList.UserName.ToString()] = staff.Username;
            row[TitleList.Role.ToString()] = SysManage.Manage().GetManagerName(staff.Roleid);
        }
        #endregion

        #region 按钮列
        //按钮列功能
        private void ButtonPressedEventClick(object sender, ButtonPressedEventArgs e)
        {
            int row = this.gridView1.FocusedRowHandle;
            StructAccount staff = this.staffs[row];
            char[] splits = { '_' };
            string[] res = ((string)e.Button.Tag).Split(splits);
            //修改
            if(res[1].Equals("0"))
            {
                CloseFormHandle closeEvent = new CloseFormHandle(delegate {
                    GetStaffList();
                });
                StaffAddView view = new StaffAddView(staff);
                ToolsManage.ShowForm(view, false, closeEvent);
            }
            //删除
            else if(res[1].Equals("1"))
            {
                StaffNetOperation.DeleteStaffs(DeleteStaffsResult, staff.Guid);
            }



        }
        #endregion

        #region 删除员工结果回调
        private void DeleteStaffsResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_STAFF_DEL)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(DeleteStaffsResult);
            System.Console.WriteLine("DeleteStaffsResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                MessageBox.Show("删除成功");
                GetStaffList();
            }


        }
        #endregion

        #region 添加员工
        private void addManagerButton_Click(object sender, EventArgs e)
        {

            CloseFormHandle closeEvent = new CloseFormHandle(delegate {
                GetStaffList();
            });
            StaffAddView view = new StaffAddView(null);
            ToolsManage.ShowForm(view, false,closeEvent);
        }
        #endregion

    }
}
