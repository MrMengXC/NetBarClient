using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetBarMS.Codes.Tools.NetOperation
{
    class StaffNetOperation
    {

        #region 获取员工列表
        /// <summary>
        /// 获取员工列表
        /// </summary>
        /// <param name="resultBlock"></param>
        public static void GetStaffList(DataResultBlock resultBlock)
        {
            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_STAFF_LIST);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 修改员工短信信息
        /// <summary>
        /// 修改员工短信信息
        /// </summary>
        /// <param name="resultBlock"></param>
        /// <param name="accounts"></param>
        public static void UpdateStaffSns(DataResultBlock resultBlock, List<StructAccount> accounts)
        {
            CSAccountSnsSet.Builder set = new CSAccountSnsSet.Builder();
            foreach (StructAccount account in accounts)
            {
                set.AddAccount(account);
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsAccountSnsSet(set.Build());

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_STAFF_SNS);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 修改员工信息
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="resultBlock"></param>
        /// <param name="account"></param>
        public static void UpdateStaff(DataResultBlock resultBlock, StructAccount account)
        {
            CSAccountUpdate.Builder update = new CSAccountUpdate.Builder();
            update.SetAccount(account);

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsAccountUpdate(update.Build());

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_STAFF_UPDATE);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 添加员工
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="resultBlock"></param>
        /// <param name="account"></param>
        public static void AddStaff(DataResultBlock resultBlock,StructAccount account)
        {
            CSAccountAdd.Builder add = new CSAccountAdd.Builder();
            add.SetAccount(account);
           
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsAccountAdd(add.Build());

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_STAFF_ADD);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 删除员工
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="resultBlock"></param>
        public static void DeleteStaffs(DataResultBlock resultBlock,string adminid)
        {
            CSAccountDel.Builder del = new CSAccountDel.Builder();
            del.SetAdminid(adminid);

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsAccountDel(del.Build());

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_STAFF_DEL);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion
    }
}
