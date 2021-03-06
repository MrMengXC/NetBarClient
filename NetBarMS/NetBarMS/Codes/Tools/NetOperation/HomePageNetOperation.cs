﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetBarMS.Codes.Tools.NetOperation
{
    class HomePageNetOperation
    {

        #region 上机信息实时列表
        /// <summary>
        /// 上机信息实时列表
        /// </summary>
        public static void HompageList(DataResultBlock resultBlock)
        {
            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_REALTIME_INFO,
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 上机激活
        /// <summary>
        /// 上机激活
        /// </summary>
        public static void CardCheckIn(DataResultBlock resultBlock,string card)
        {

            CSEmkCheckin.Builder checkin = new CSEmkCheckin.Builder();
            checkin.SetCardnumber(card);

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsEmkCheckin(checkin);

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_EMK_CHECKIN,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);

        }
        #endregion

        #region 下机结算
        /// <summary>
        /// 下机结算
        /// </summary>
        public static void CardCheckOut(DataResultBlock resultBlock,string card)
        {
            CSEmkCheckout.Builder checkout = new CSEmkCheckout.Builder();
            checkout.SetCardnumber(card);

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsEmkCheckout(checkout);

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_EMK_CHECKOUT,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);

        }
        #endregion

        #region 获取充值二维码
        // 获取充值二维码
        public static void GetRechargeCode(DataResultBlock resultBlock, string card,int money,int payMode,int offical)
        {
            CSPreCharge.Builder pay = new CSPreCharge.Builder();
            pay.Cardnumber = card;
            pay.Amount = money;
            pay.Paymode = payMode; //1 - 微信 2 - 支付宝 3 - 现金
            pay.Offical = offical;  //是否办理正式会员1办理 0不办理

            //System.Console.WriteLine("pay:"+pay);
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsPreCharge = pay.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_PRECHARGE,
                content = content.Build()
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 充值结果
        // 获取充值结果
        public static void GetRecharge(DataResultBlock resultBlock)
        {
     
            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_TOCHARGE,
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 管理员操作
        public static void ManagerCommandOperation(DataResultBlock resultBlock,COMMAND_TYPE type,List<string>pars)
        {
            CSCommand.Builder command = new CSCommand.Builder();
            command.Cmd = (int)type;
            if(pars != null && pars.Count > 0)
            {
                foreach(string param in pars)
                {
                    command.AddParams(param);
                }
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsCommand = command.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_COMMAND,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 获取呼叫列表
        /// <summary>
        /// 获取呼叫列表
        /// </summary>
        /// <param name="resultBlock"></param>
        public static void GetCallList(DataResultBlock resultBlock)
        {           

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_CALL_LIST,
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 处理呼叫
        /// <summary>
        /// 处理呼叫
        /// </summary>
        /// <param name="resultBlock"></param>
        /// <param name="callid"></param>
        public static void HandleCall(DataResultBlock resultBlock,int callid)
        {
            CSCallProcess.Builder call = new CSCallProcess.Builder();
            call.Callid = callid;
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsCallProcess = call.Build();
            
            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_CALL_PROCESS,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 添加交接班
        /// <summary>
        /// 添加交接班
        /// </summary>
        /// <param name="resultBlock">结果回调</param>
        /// <param name="giveps">交班人密码</param>
        /// <param name="received">接班人</param>
        /// <param name="ps">密码</param>
        /// <param name="isCheck">是否正确</param>
        /// <param name="remark">备注</param>
        public static void AddChangeStaff(DataResultBlock resultBlock, string giveps,string receive,string ps,int isCheck,string remark)
        {
            CSShiftAdd.Builder add = new CSShiftAdd.Builder();
            add.DeliveredPwd = giveps;
            add.ReceivedBy = receive;
            add.ReceivedPwd = ps;
            add.Ischeck = isCheck;
            add.Remark = remark;
            MessageContent.Builder content = new MessageContent.Builder();
            content.MessageType = 1;
            content.CsShiftAdd = add.Build();

            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_SHIFT_ADD,
                content = content.Build(),
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

        #region 获取交班人信息
        public static void GetGiveStaffInfo(DataResultBlock resultBlock)
        {
   
            SendModel send = new SendModel()
            {
                cmd = Cmd.CMD_SHIFT_DELIVEREDBY,
            };
            NetMessageManage.SendMsg(send, resultBlock);
        }

        #endregion

    }
}
