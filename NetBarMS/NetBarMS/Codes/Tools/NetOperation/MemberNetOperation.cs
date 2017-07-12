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

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_MEMBER_LIST);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);

        }
        #endregion

        #region 添加会员
        /// <summary>
        /// 添加会员
        /// </summary>
        public static void AddMember(DataResultBlock resultBlock, CSMemberAdd.Builder member)
        {
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsMemberAdd(member);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_MEMBER_ADD);
            pack.SetContent(content);

            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 更新会员
        /// <summary>
        /// 更新会员
        /// </summary>
        public static void UpdateMember(DataResultBlock resultBlock, CSMemberAdd.Builder member)
        {
            //MessageContent.Builder content = new MessageContent.Builder();
            //content.SetMessageType(1);
            //content.SetCsMemberAdd(member);

            //MessagePack.Builder pack = new MessagePack.Builder();
            //pack.SetCmd(Cmd.CMD_MEMBER_ADD);
            //pack.SetContent(content);

            //NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
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
            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_MEMBER_DEL);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 会员验证
        /// <summary>
        /// 验证会员
        /// </summary>
        public static void VerifyMember(DataResultBlock resultBlock, List<int> ids)
        {

            //CSMemberVerify.Builder memberVer = new CSMemberVerify.Builder();
            //foreach (int id in ids)
            //{
            //    memberVer.AddMemberid(id);
            //}
            //MessageContent.Builder content = new MessageContent.Builder();
            //content.SetMessageType(1);
            //content.SetCsMemberVerify(memberVer);
            //MessagePack.Builder pack = new MessagePack.Builder();
            //pack.SetCmd(Cmd.CMD_MEMBER_VERIFY);
            //pack.SetContent(content);
            //NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
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

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_MEMBER_FIND);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
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
            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_MEMBER_CARD_INFO);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        

    }
}
