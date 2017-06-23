using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Codes.Tools.NetOperation
{      /// <summary>
       /// 网络操作
       /// </summary>
    class ManagerNetOperation
    {
        /// <summary>
        /// 客户端认证
        /// </summary>
        public static void ClientAuthen(DataResultBlock resultBlock)
        {
           
            try
            {
                CSAuthen.Builder auther = new CSAuthen.Builder();
                auther.Text = "zyc";
                MessageContent.Builder content = new MessageContent.Builder();
                content.SetCsAuthen(auther);
                content.SetMessageType(1);

                MessagePack.Builder pack = new MessagePack.Builder();
                pack.SetCmd(Cmd.CMD_AUTHEN);
                pack.SetContent(content);
                NetMessageManage.Manager().SendMsg(pack.Build(), resultBlock);
            }
            catch (Exception exc)
            {
                System.Console.WriteLine("认证失败："+exc);
            }
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        public static void ManagerLogin(DataResultBlock resultBlock)
        {
            
            try
            {
                CSLogin.Builder login = new CSLogin.Builder()
                {
                    Type = 1,
                    UserId = "lyc",
                    Password = "123",

                };

                MessageContent.Builder content = new MessageContent.Builder();
                content.SetCsLogin(login);
                content.SetMessageType(1);

                MessagePack.Builder pack = new MessagePack.Builder();
                pack.SetCmd(Cmd.CMD_LOGIN);
                pack.SetContent(content);
                NetMessageManage.Manager().SendMsg(pack.Build(), resultBlock);
            }
            catch(Exception exc)
            {
                System.Console.WriteLine("管理员登录失败："+exc);
            }
        }
        /// <summary>
        /// 账户信息
        /// </summary>
        public static void AccountInfo(DataResultBlock resultBlock)
        {
            try
            {
                MessagePack.Builder pack = new MessagePack.Builder();
                pack.SetCmd(Cmd.CMD_ACCOUNT_INFO);
                NetMessageManage.Manager().SendMsg(pack.Build(), resultBlock);
            }
            catch(Exception exc)
            {
                System.Console.WriteLine("获取账户信息失败：" + exc);

            }

        }
    }
}
