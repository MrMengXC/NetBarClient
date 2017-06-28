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
        #region 客户端认证
        /// <summary>
        /// 客户端认证
        /// </summary>
        public static void ClientAuthen(DataResultBlock resultBlock)
        {

            CSAuthen.Builder auther = new CSAuthen.Builder();
            auther.Text = "zyc";
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetCsAuthen(auther);
            content.SetMessageType(1);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_AUTHEN);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 管理员登录
        /// <summary>
        /// 管理员登录
        /// </summary>
        public static void ManagerLogin(DataResultBlock resultBlock)
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
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 获取账户信息
        /// <summary>
        /// 账户信息
        /// </summary>
        public static void AccountInfo(DataResultBlock resultBlock)
        {
            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_ACCOUNT_INFO);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 获取管理员角色列表
        /// <summary>
        /// 获取管理员角色列表
        /// </summary>
        public static void GetManagerList(DataResultBlock resultBlock,Int32 roleId)
        {

            CSRoleList.Builder list = new CSRoleList.Builder();
            list.Roleid = roleId;

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetCsRoleList(list);
            content.SetMessageType(1);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_ROLE_LIST);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        

    }
        #endregion
        #region 添加管理员新角色
        /// <summary>
        /// 添加管理员新角色
        /// </summary>
        public static void AddManager(DataResultBlock resultBlock)
        {

        }
        #endregion
        #region 修改管理员的角色
        /// <summary>
        /// 修改管理员的角色
        /// </summary>
        public static void UpdateManager(DataResultBlock resultBlock)
        {

        }
        #endregion
        #region 删除管理员的角色
        /// <summary>
        /// 删除管理员的角色
        /// </summary>
        public static void DeleteManager(DataResultBlock resultBlock)
        {

        }
        #endregion
    }
}
