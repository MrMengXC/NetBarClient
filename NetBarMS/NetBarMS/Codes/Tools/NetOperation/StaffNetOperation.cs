using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Codes.Tools.NetOperation
{
    class StaffNetOperation
    {


        // 获取管理员列表
        public static void GetStaffList(DataResultBlock resultBlock)
        {
            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_ADMIN_LIST);
            NetMessageManage.Manager().SendMsg(pack.Build(), resultBlock);
        }
        //修改管理员信息
        public static void UpdateStaff(DataResultBlock resultBlock,List<StructAccount> accounts)
        {
            CSAccountUpdate.Builder update = new CSAccountUpdate.Builder();
            foreach(StructAccount account in accounts)
            {
                update.AddAccount(account);
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsAccountUpdate = update.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_ADMIN_UPDATE);
            pack.Content = content.Build();
            NetMessageManage.Manager().SendMsg(pack.Build(), resultBlock);
        }

    }
}
