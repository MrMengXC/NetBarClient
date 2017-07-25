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

namespace NetBarMS.Views.ManagersManage
{
    public partial class StaffAddView : RootFormView
    {

        private List<StructRole> managers;
        private StructAccount staff;

        public StaffAddView(StructAccount tem)
        {
            InitializeComponent();
            this.titleLabel.Text = "员工管理";
            if(tem != null)
            {
                this.staff = tem;
            }
            InitUI();
        }

        //初始化UI
        private void InitUI()
        {
            this.managers = SysManage.Managers;
            for (int index = 0; index < this.managers.Count;index ++)
            {
                StructRole role = this.managers[index];
                this.comboBoxEdit1.Properties.Items.Add(role.Name);
                if(this.staff != null && role.Roleid.Equals(staff.Roleid))
                {
                    this.comboBoxEdit1.SelectedIndex = index;
                }
            }

            if(this.staff != null)
            {
                this.nameTextBox.Text = staff.Nickname;
                this.phoneTextBox.Text = staff.Phone;
                this.userNameTextBox.Text = staff.Username;
                this.pwTextBox.Text = staff.Password;
                this.userNameTextBox.Enabled = false;
            }

        }


        //保存
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(this.staff == null)
            {
                AddStaff();
            }
            else
            {
                UpdateStaff();
            }
        }

        //添加员工
        private void AddStaff()
        {
            string name = this.nameTextBox.Text;
            string phone = this.phoneTextBox.Text;
            string userName = this.userNameTextBox.Text;
            string pw = this.pwTextBox.Text;
            int index = this.comboBoxEdit1.SelectedIndex;
            if(name.Equals("") || phone.Equals("") || userName.Equals("") || pw.Equals("") || index < 0)
            {
                MessageBox.Show("请将信息填充完整");
                return;
            }
            StructAccount.Builder staff = new StructAccount.Builder();
            staff.Guid = "0";
            staff.Nickname = name;
            staff.Username = userName;
            staff.Password = pw;
            staff.Phone = phone;
            staff.Roleid = managers[index].Roleid;

            StaffNetOperation.AddStaff(AddStaffResult, staff.Build());


        }

        //添加员工结果回调
        private void AddStaffResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_STAFF_ADD)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(AddStaffResult);
            System.Console.WriteLine("AddStaffResult:" + result.pack);

            if(result.pack.Content.MessageType == 1)
            {
                MessageBox.Show("添加成功");
            }
        }
        //更新员工信息
        private void UpdateStaff()
        {
           
            string name = this.nameTextBox.Text;
            string phone = this.phoneTextBox.Text;
            string userName = this.userNameTextBox.Text;
            string pw = this.pwTextBox.Text;
            int index = this.comboBoxEdit1.SelectedIndex;
            if (name.Equals("") || phone.Equals("") || userName.Equals("") || pw.Equals("") || index < 0)
            {
                MessageBox.Show("请将信息填充完整");
                return;
            }

            StructAccount.Builder staff = new StructAccount.Builder(this.staff);
            staff.Nickname = name;
            staff.Password = pw;
            staff.Phone = phone;
            staff.Roleid = managers[index].Roleid;
            StaffNetOperation.UpdateStaff(UpdateStaffResult, staff.Build());
        }
        //修改员工结果回调
        private void UpdateStaffResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_STAFF_UPDATE)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(UpdateStaffResult);
            System.Console.WriteLine("UpdateStaffResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                MessageBox.Show("修改成功");
            }
        }
    }
}
