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
            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_STAFF_LIST,
            };
            NetMessageManage.SendMsg(send, resultBlock);
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

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_STAFF_SNS,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);
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

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_STAFF_UPDATE,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);
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

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_STAFF_ADD,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);
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

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_STAFF_DEL,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);

        }
        #endregion

        #region 获取员工交接班记录
        /// <summary>
        /// 获取员工交接班记录
        /// </summary>
        /// <param name="resultBlock"></param>
        public static void GetStaffShiftsRecordList(DataResultBlock resultBlock,StructPage page,string start,string end)
        {
            CSShiftFind.Builder find = new CSShiftFind.Builder();
            find.Page = page;
            if(start != null && !start.Equals(""))
            {
                find.Starttime = start;
                find.Stoptime = end;
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsShiftFind = find.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_SHIFT_FIND,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion
    }
}
