using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetBarMS.Codes.Tools.NetOperation
{
    class EvaluateNetOperation
    {


        #region 获取网吧评价列表
        /// <summary>
        /// 获取网吧评价列表
        /// </summary>
        /// <param name="resultBlock"></param>
        /// <param name="page">页数</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="member">评论的会员</param>
        public static void GetNetBarEvaluateList(DataResultBlock resultBlock,StructPage page, string start, string end, string member)
        {
            CSStaffComment.Builder comment = new CSStaffComment.Builder();
            comment.Page = page;
            comment.Type = 1;
            if (start != null && !start.Equals(""))
            {
                comment.Starttime = start;
                comment.Endtime = end;
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

        #region 获取员工评价列表
        /// <summary>
        /// 获取员工评价列表
        /// </summary>
        /// <param name="resultBlock"></param>
        /// <param name="page">页数</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="staff">员工姓名</param>
        /// <param name="member">评价人姓名或身份证号</param>
        public static void GetStaffEvaluateList(DataResultBlock resultBlock, StructPage page,string start,string end,string staff,string member)
        {
            CSStaffComment.Builder comment = new CSStaffComment.Builder();
            comment.Page = page;
            comment.Type = 2; 
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
