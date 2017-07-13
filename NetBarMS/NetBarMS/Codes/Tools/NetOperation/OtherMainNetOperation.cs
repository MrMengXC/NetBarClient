using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetBarMS.Codes.Tools.NetOperation
{
    class OtherMainNetOperation
    {
        #region 获取绩效数据列表
        public static void GetJXList(DataResultBlock resultBlock,Int32 year, Int32 month)
        {
            CSStaffPerform.Builder perform = new CSStaffPerform.Builder();
            perform.Year = year;
            perform.Month = month;

            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsStaffPerform = perform.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.Cmd = Cmd.CMD_STAFF_PERFORM;
            pack.Content = content.Build();
            NetMessageManage.SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 获取日志数据列表
        public static void GetLogList(DataResultBlock resultBlock, StructPage page, string start, string end, string staff, string keyword)
        {
            CSLog.Builder log = new CSLog.Builder();
            log.Page = page;
            if (start != null && !start.Equals(""))
            {
                log.Starttime = start;
                log.Endtime = end;
            }
            if (staff != null && !staff.Equals(""))
            {
                log.Operator = staff;
            }
            if (keyword != null && !keyword.Equals(""))
            {
                log.Keyword = keyword;
            }
          //  System.Console.WriteLine(log);
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsLog = log.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.Cmd = Cmd.CMD_LOG;
            pack.Content = content.Build();
            NetMessageManage.SendMsg(pack.Build(), resultBlock);
        }
        #endregion


    }
}
