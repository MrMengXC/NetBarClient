using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools.NetOperation
{
    /// <summary>
    /// 记录查询操作
    /// </summary>
    class RecordNetOperation
    {
        #region 获取用户充值记录
        /// <summary>
        ///  获取用户充值记录
        /// </summary>
        /// <param name="resultBlock">结果回调</param>
        /// <param name="page">分页</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="pay">支付方式</param>
        /// <param name="name">会员姓名或卡号</param>
        public static void GetUserRechargeRecord(DataResultBlock resultBlock, StructPage page, string start, string end,int pay,string name)
        {
            CSQueryCharge.Builder charge = new CSQueryCharge.Builder();
            charge.Page = page;
            if (start != null && !start.Equals(""))
            {
                charge.Starttime = start;
                charge.Stoptime = end;
            }

            if(pay > 0)
            {
                charge.Paymode = pay;
            }
            if(name != null && !name.Equals(""))
            {
                charge.Name = name; 
            }


            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsQueryCharge = charge.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_QUERY_CHARGE);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 会员办理记录
        /// <summary>
        /// 会员办理记录
        /// </summary>
        /// <param name="resultBlock">结果回调</param>
        /// <param name="page">分页</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="staff">办理人</param>
        /// <param name="membertype">会员类型</param>
        /// <param name="name">姓名或卡号</param>
        public static void GetOpenMemberRecord(DataResultBlock resultBlock, StructPage page, string start, string end, string staff, int membertype,string name)
        {
            CSQueryApply.Builder apply = new CSQueryApply.Builder();
            apply.Page = page;
            if (start != null && !start.Equals(""))
            {
                apply.Starttime = start;
                apply.Stoptime = end;
            }

            if (staff != null && !staff.Equals(""))
            {
                apply.Operator = staff;
            }
            if (membertype > 0)
            {
                apply.Rightid = membertype;
            }

            if (name != null && !name.Equals(""))
            {
                apply.Name = name;
            }


            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsQueryApply = apply.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_QUERY_APPLY);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 用户上网记录
        /// <summary>
        /// 用户上网记录
        /// </summary>
        /// <param name="resultBlock">结果回调</param>
        /// <param name="page">分页</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="name">姓名或卡号</param>
        /// <param name="mid">会员id，个人搜索记录使用</param>
        /// <param name="comId">电脑id</param>

        public static void GetUserNetRecord(DataResultBlock resultBlock, StructPage page, string start, string end,string name,int mid,int comId)
        {
            CSQueryEmk.Builder emk = new CSQueryEmk.Builder();
            emk.Page = page;
            if (start != null && !start.Equals(""))
            {
                emk.Starttime = start;
                emk.Stoptime = end;
            }

            if (name != null && !name.Equals(""))
            {
                emk.Name = name;
            }
            if(mid >= 0)
            {
                emk.Memberid = mid;
            }
            if(comId >= 0)
            {
                emk.Computerid = comId;
            }
            System.Console.WriteLine(emk);
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsQueryEmk = emk.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_QUERY_EMBARKATION);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 用户消费记录
        /// <summary>
        /// 用户消费记录
        /// </summary>
        /// <param name="resultBlock">结果回调</param>
        /// <param name="page">分页</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="use">用途</param>
        /// <param name="pay">支付方式</param>
        /// <param name="mid">会员id，个人消费记录查询</param>

        public static void GetUserConsumeRecord(DataResultBlock resultBlock, StructPage page, string start, string end, int use,int pay,int mid)
        {
            CSQueryConsum.Builder consume = new CSQueryConsum.Builder();
            consume.Page = page;
            if (start != null && !start.Equals(""))
            {
                consume.Starttime = start;
                consume.Stoptime = end;
            }

            if (use > 0)
            {
                consume.Usage = use;
            }
            if(pay > 0)
            {
                consume.Paymode = pay;
            }
            if(mid >= 0)
            {
                consume.Memberid = mid;
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsQueryConsum = consume.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_QUERY_CONSUM);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 上座率查询
        /// <summary>
        /// 上座率查询
        /// </summary>
        /// <param name="resultBlock">结果回调</param>
        /// <param name="areaId">区域id</param>
        /// <param name="date">日期</param>
        public static void GetAttendanceSearch(DataResultBlock resultBlock,int areaId,string date)
        {
            CSQueryOccup.Builder search = new CSQueryOccup.Builder();
            if(areaId > 0)
            {
                search.Areaid = areaId;
            }

            search.Date = date;

            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsQueryOccup = search.Build();

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_QUERY_OCCUPANCY);
            pack.SetContent(content.Build());
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

    }
}
