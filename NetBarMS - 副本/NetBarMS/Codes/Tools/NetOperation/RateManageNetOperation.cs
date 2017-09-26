using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools.NetOperation
{
    class RateManageNetOperation
    {

        //费率
        public static string awardParent = "reward";
        public static string memberDayAwardParent = "activity";
        //积分设置
        public static string integralParent = "integal";
        //其他设置
        public static string otherParent = "free";
   

        #region 获取费率管理列表/更新列表
        //费率管理更新
        public static void RateManageUpdate(DataResultBlock resultBlock, CSSysBillUpdate update)
        {
         
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsSysBillUpdate(update);

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_SYS_BILLING_UPDATE,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);

        }
        //费率管理列表
        public static void RateManageList(DataResultBlock resultBlock)
        {
 
            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_SYS_BILLING_LIST,
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 充值奖励管理
        //充值奖励管理
        public static void AwardManageList(DataResultBlock resultBlock)
        {
           SysNetOperation.SysInfo(resultBlock, awardParent);
        }
        //会员日充值奖励管理
        public static void MemberDayAwardManageList(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, memberDayAwardParent);
        }
        #endregion

        #region 充值奖励添加
        public static void AddAwardManage(DataResultBlock resultBlock,StructDictItem item)
        {
            SysNetOperation.AddSysInfo(resultBlock, awardParent,item);
        }
        //会员日充值奖励添加
        public static void AddMemberDayAwardManage(DataResultBlock resultBlock, StructDictItem item)
        {
            SysNetOperation.AddSysInfo(resultBlock, memberDayAwardParent,item);
        }

        #endregion

        #region 充值奖励删除
        public static void DeleteAwardManage(DataResultBlock resultBlock, List<string> ids)
        {
            SysNetOperation.DeleteSysInfo(resultBlock, awardParent, ids);
        }
        //会员日充值奖励添加
        public static void DeleteMemberDayAwardManage(DataResultBlock resultBlock, List<string>ids)
        {
            SysNetOperation.DeleteSysInfo(resultBlock, memberDayAwardParent, ids);
        }

        #endregion

        #region 充值奖励更新
        public static void UpdateAwardManage(DataResultBlock resultBlock, StructDictItem child)
        {
            SysNetOperation.UpdateSysInfo(resultBlock, awardParent,child);
        }
        //会员日充值奖励更新
        public static void UpdateMemberDayAwardManage(DataResultBlock resultBlock, StructDictItem child)
        {
            SysNetOperation.UpdateSysInfo(resultBlock, memberDayAwardParent,child);
        }
        #endregion
       
        #region 积分管理设置更新
        public static void UpdateIntegralDefaultSetting(DataResultBlock resultBlock, StructDictItem child)
        {
            SysNetOperation.UpdateSysInfo(resultBlock, integralParent, child);
        }
        #endregion

        #region 获取积分管理数据
        public static void GetIntegralDefaultSetting(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, integralParent);
        }
        #endregion

        #region 其他设置管理设置更新
        public static void UpdateOtherSetting(DataResultBlock resultBlock, StructDictItem child)
        {
            SysNetOperation.UpdateSysInfo(resultBlock, otherParent, child);
        }
        #endregion

        #region 其他设置管理数据
        public static void GetOtherSetting(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, otherParent);
        }
        #endregion

    }
}
