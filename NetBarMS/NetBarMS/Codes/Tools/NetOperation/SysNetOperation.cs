using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetBarMS.Codes.Tools.NetOperation
{
    class SysNetOperation
    {


        #region 系统信息查寻
        public static void SysInfo(DataResultBlock resultBlock, string parent)
        {
            CSSysInto.Builder info = new CSSysInto.Builder()
            {
                Parent = parent,
            };
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsSysInfo(info);
            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_SYS_INFO);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 添加系统信息
        public static void AddSysInfo(DataResultBlock resultBlock, string parent, StructDictItem item)
        {
            CSAddSysInfo.Builder info = new CSAddSysInfo.Builder()
            {
                Parent = parent,
                Child = item,
            };
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsAddSysInfo(info);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_SYS_ADD);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 删除系统信息
        public static void DeleteSysInfo(DataResultBlock resultBlock, string parent, List<string> childs)
        {
            CSDelSysInfo.Builder info = new CSDelSysInfo.Builder()
            {
                Parent = parent,
            };
            foreach (string child in childs)
            {
                info.AddChild(child);
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsDelSysInfo(info);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_SYS_DEL);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 更新系统信息数据
        public static void UpdateSysInfo(DataResultBlock result, string parent, StructDictItem child)
        {
            List<StructDictItem> items = new List<StructDictItem>()
            {
                child,
            };

            SysNetOperation.UpdateSysInfo(result, parent, items);
        }
        public static void UpdateSysInfo(DataResultBlock result, string parent, List<StructDictItem> items)
        {
            CSUpdateSysInfo.Builder update = new CSUpdateSysInfo.Builder()
            {
                Parent = parent,
            };
            foreach(StructDictItem item in items)
            {
                update.AddChild(item);
            }
            //System.Console.WriteLine("UpdateSysInfo:" + update);

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsUpdateSysInfo(update);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_SYS_UPDATE);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), result);


        }
        #endregion

    }
}
