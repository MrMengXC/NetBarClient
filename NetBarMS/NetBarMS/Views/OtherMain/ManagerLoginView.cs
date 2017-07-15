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
using NetBarMS.Codes;
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS.Views.OtherMain
{
    public partial class ManagerLoginView : RootFormView
    {

        private int num = 5;
        private List<StructAccount> staffs;
        public ManagerLoginView()
        {
            InitializeComponent();
            //连接服务器
            NetMessageManage.ConnectServer(ConnectServerResult);
            this.loginButton.Click += LoginButtonClick;
            this.loginButton.Enabled = false;

        }


        #region 进行准备工作连接服务器进行服务器认证

        // 连接服务器的回调
        public void ConnectServerResult()
        {
            NetMessageManage.RemoveConnetServer(ConnectServerResult);
            //进行客户端认证
            ManagerNetOperation.ClientAuthen(ClientAuthenBlock);
        }

       
        // 服务器认证的回调
        public void ClientAuthenBlock(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_AUTHEN)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(ClientAuthenBlock);
           // System.Console.WriteLine(result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                //获取提前预知信息
                SysManage.RequestSysInfo(RequestSysInfoResult);
            }
            else
            {
                System.Console.WriteLine(result.pack);
                MessageBox.Show("认证失败");
            }
            
        }
        //获取系统信息结果
        private void RequestSysInfoResult(ResultModel result)
        {
            this.num--;
            if(this.num == 0)
            {
                this.Invoke(new RefreshUIHandle(delegate {
                    SysManage.RemoveRequestSysInfo(RequestSysInfoResult);
                    this.loginButton.Enabled = true;
                    //设置用户名列表
                    this.staffs = SysManage.Staffs;
                    foreach (StructAccount staff in staffs)
                    {
                        this.comboBoxEdit1.Properties.Items.Add(staff.Username);
                    }
                }));
            }
        }
        #endregion

        #region 进行登录
        //进行登录
        private void LoginButtonClick(object sender, EventArgs e)
        {
            string userName = this.comboBoxEdit1.Text;
            string ps = this.textEdit2.Text;

            if(userName.Equals("") || ps.Equals(""))
            {
                MessageBox.Show("请输入用户名或密码");
                return;
            }

            if(this.comboBoxEdit1.SelectedIndex >= 0)
            {
                ManagerManage.Manage().AccountId = this.staffs[this.comboBoxEdit1.SelectedIndex].Guid;
            }
            ManagerNetOperation.ManagerLogin(ManagerLoginBlock,userName,ps);
        }

        // 管理员登录回调
        public void ManagerLoginBlock(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_LOGIN)
            {

            }
            NetMessageManage.RemoveResultBlock(ManagerLoginBlock);
            System.Console.WriteLine("ManagerLoginBlock:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {               
                this.Invoke(new RefreshUIHandle(delegate () {
                    this.FindForm().DialogResult = DialogResult.OK;
                    this.FindForm().Close();
                }));

            }
        }
        #endregion
    }
}
