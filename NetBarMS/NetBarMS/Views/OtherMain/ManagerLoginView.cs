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
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Views.OtherMain
{
    public partial class ManagerLoginView : RootUserControlView
    {
        public ManagerLoginView()
        {
            InitializeComponent();
            NetMessageManage.Manager(ConnectResultBlock);
            this.loginButton.Click += LoginButtonClick;
        }

       

        /// <summary>
        /// 连接服务器的回调
        /// </summary>
        public void ConnectResultBlock()
        {
            System.Console.WriteLine("ConnectBlock");
            //进行客户端认证
            ManagerNetOperation.ClientAuthen(ClientAuthenBlock);
        }

        /// <summary>
        /// 服务器认证的回调
        /// </summary>
        /// <param name="result"></param>
        public void ClientAuthenBlock(ResultModel result)
        {
            if (result.pack.Cmd == Cmd.CMD_AUTHEN)
            {
                NetMessageManage.Manager().RemoveResultBlock(ClientAuthenBlock);
                System.Console.WriteLine(result.pack);
            }
        }

        //进行登录
        private void LoginButtonClick(object sender, EventArgs e)
        {

            ManagerNetOperation.ManagerLogin(ManagerLoginBlock);
            //this.FindForm().DialogResult = DialogResult.OK;
            //this.FindForm().Close();
        }

        /// <summary>
        /// 管理员登录回调
        /// </summary>
        /// <param name="result"></param>
        public void ManagerLoginBlock(ResultModel result)
        {

            if (result.pack.Cmd == Cmd.CMD_LOGIN && result.pack.Content.MessageType == 1)
            {
                NetMessageManage.Manager().RemoveResultBlock(ManagerLoginBlock);
                System.Console.WriteLine(result.pack);
                this.Invoke(new UIHandleBlock(delegate () {
                    this.FindForm().DialogResult = DialogResult.OK;
                    this.FindForm().Close();
                }));

            }
        }
    }
}
