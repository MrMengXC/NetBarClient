using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.ProtocolBuffers.Collections;

namespace NetBarMS.Codes.Tools.NetOperation
{
    class MemberNetOperation
    {
        #region 获取会员列表
        //获取会员列表
        public static void GetMemberList(DataResultBlock resultBlock,StructPage page)
        {
            
            CSMemberList.Builder memberlist = new CSMemberList.Builder();
            memberlist.SetPage(page);

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsMemberList(memberlist);

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_MEMBER_LIST,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);


        }
        #endregion

        #region 添加会员
        /// <summary>
        /// 添加会员入口
        /// </summary>
        /// <param name="resultBlock">反馈结果回调</param>
        /// <param name="card">身份证号</param>
        public static void OpenMember(DataResultBlock resultBlock,string card)
        {
            CSEmkApplyMember.Builder member = new CSEmkApplyMember.Builder();
            member.Cardnumber = card;
            member.Channel = (int)MANAGECHANNEL.系统后台;

            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsEmkApplyMember = member.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_EMK_APPLY_MEMBER,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion
        
        #region 进入充值入口
        /// <summary>
        /// 进入充值入口
        /// </summary>
        /// <param name="resultBlock">反馈结果回调</param>
        /// <param name="card">身份证号</param>
        public static void BeiginRecharge(DataResultBlock resultBlock, string card)
        {
            CSEmkCharge.Builder charge = new CSEmkCharge.Builder();
            charge.Cardnumber = card;

            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsEmkCharge = charge.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_EMK_RECHARGE,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 添加身份证信息
        /// <summary>
        /// 添加身份证信息（添加临时会员）
        /// </summary>
        /// <param name="resultBlock">结果反馈</param>
        /// <param name="card">身份证信息</param>
        public static void AddCardInfo(DataResultBlock resultBlock,StructCard card)
        {
            CSEmkAddCardInfo.Builder info = new CSEmkAddCardInfo.Builder();
            info.Card = card;

            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsEmkAddCardInfo = info.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_EMK_ADD_CARDINFO,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 删除会员
        /// <summary>
        /// 删除会员
        /// </summary>
        public static void DeleteMember(DataResultBlock resultBlock, List<int> ids)
        {

            CSMemberDel.Builder memberDel = new CSMemberDel.Builder();

            foreach (int id in ids)
            {
                memberDel.AddMemberid(id);
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsMemberDel(memberDel);

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_MEMBER_DEL,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

       

        #region 按条件查询会员
        /// <summary>
        /// 按条件查询会员
        /// </summary>
        /// <param name="resultBlock"></param>
        /// <param name="page">分页</param>    
        /// <param name="status">状态</param> 
        /// <param name="right">会员等级</param>
        /// <param name="keywords">姓名</param>
        public static void SearchConditionMember(DataResultBlock resultBlock, StructPage page, Int32 status, Int32 right, string keywords)
        {

            CSMemberFind.Builder memberFind = new CSMemberFind.Builder();
            memberFind.SetPage(page);
            if (status > 0)
            {
                memberFind.SetStatus(status);
            }
            if (right > 0)
            {
                memberFind.SetRight(right);
            }
            if (keywords != null && !keywords.Equals(""))
            {
                memberFind.SetKeywords(keywords);
                System.Console.WriteLine(keywords);
            }

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsMemberFind(memberFind);

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_MEMBER_FIND,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }

        #endregion

        #region 会员信息查询
        /// <summary>
        /// 会员信息查询
        /// </summary>
        public static void MemberInfo(DataResultBlock resultBlock, int mid)
        {
            CSMemberCardInfo.Builder info = new CSMemberCardInfo.Builder()
            {
                Memberid = mid,
            };
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsMemberCardInfo(info);

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_MEMBER_CARD_INFO,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);

        }
        #endregion

        #region 通过身份证号查询会员信息
        /// <summary>
        /// 通过身份证号查询用户信息
        /// </summary>
        /// <param name="resultBlock">查询结果反馈</param>
        /// <param name="card">身份证号</param>
        public static void MemberInfo(DataResultBlock resultBlock, string card)
        {
            CSEmkUserInfo.Builder info = new CSEmkUserInfo.Builder()
            {
                Cardnumber = card,

            };
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsEmkUserInfo = info.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_EMK_USERINFO,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 取消操作
        public static void CancelOperation(DataResultBlock resultBlock)
        {
            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_EMK_CANCEL,
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }


        #endregion

    }
}
