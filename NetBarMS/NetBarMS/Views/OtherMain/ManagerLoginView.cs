﻿using System;
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


namespace NetBarMS.Views.OtherMain
{
    public partial class ManagerLoginView : RootUserControlView
    {

        private int num = 5;
        public ManagerLoginView()
        {
            InitializeComponent();
            NetMessageManage.Manage(ConnectResultBlock);
            this.loginButton.Click += LoginButtonClick;
            this.loginButton.Enabled = false;

        }


        #region 进行准备工作连接服务器进行服务器认证

        // 连接服务器的回调
        public void ConnectResultBlock()
        {
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

            NetMessageManage.Manage().RemoveResultBlock(ClientAuthenBlock);
           // System.Console.WriteLine(result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                //获取提前预知信息
                SysManage.Manage().RequestSysInfo(RequestSysInfoResult);
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
                this.Invoke(new UIHandleBlock(delegate {
                    SysManage.Manage().RemoveRequestSysInfo(RequestSysInfoResult);
                    this.loginButton.Enabled = true;
                }));
            }
        }
        #endregion

        #region 进行登录
        //进行登录
        private void LoginButtonClick(object sender, EventArgs e)
        {

            ManagerNetOperation.ManagerLogin(ManagerLoginBlock);
        }

        // 管理员登录回调
        public void ManagerLoginBlock(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_LOGIN)
            {

            }
            NetMessageManage.Manage().RemoveResultBlock(ManagerLoginBlock);
            System.Console.WriteLine("ManagerLoginBlock:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {               
                this.Invoke(new UIHandleBlock(delegate () {
                    this.FindForm().DialogResult = DialogResult.OK;
                    this.FindForm().Close();
                }));

            }
        }
        #endregion
    }
}
