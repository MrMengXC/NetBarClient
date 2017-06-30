using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Codes.Tools.NetOperation
{
    class EvaluateNetOperation
    {


        #region 获取网吧评价列表
        public static void GetNetBarEvaluateList(DataResultBlock resultBlock,StructPage page)
        {
            CSAccountSnsSet.Builder set = new CSAccountSnsSet.Builder();
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsAccountSnsSet(set.Build());

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_STAFF_SNS);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 获取员工评价列表
        /// <summary>
        /// 获取员工评价列表
        /// </summary>
        /// <param name="resultBlock"></param>
        /// <param name="page">页数</param>
        /// <param name="type">请求类型 1网吧评价 2员工评价</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="staff">员工姓名</param>
        /// <param name="member">评价人姓名或身份证号</param>
        public static void GetStaffEvaluateList(DataResultBlock resultBlock, StructPage page,Int32 type,string start,string end,string staff,string member)
        {
            CSStaffComment.Builder comment = new CSStaffComment.Builder();
            comment.Page = page;
            comment.Type = type; 
            if(start != null && !start.Equals(""))
            {
                comment.Starttime = start;
                comment.Endtime = end;
            }
            if(staff != null && !staff.Equals(""))
            {
                comment.Staff = staff;
            }
            if (member != null && !member.Equals(""))
            {
                comment.Customer = member;
            }

            System.Console.WriteLine(comment);
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsStaffComment = comment.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.Cmd = Cmd.CMD_STAFF_COMMENT;
            pack.Content = content.Build();
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion
    }
}
