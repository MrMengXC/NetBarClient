using System;
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
            try
            {
                MessagePack.Builder pack = new MessagePack.Builder();
                pack.SetCmd(Cmd.CMD_REALTIME_INFO);
                NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
            }
            catch(Exception exc)
            {
                System.Console.WriteLine("获取上网实时列表失败："+exc);
            }

         

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

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_EMK_CHECKIN);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);

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

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_EMK_CHECKOUT);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);

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

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_PRECHARGE);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);

        }
        #endregion

        #region 充值
        // 获取充值结果
        public static void GetRecharge(DataResultBlock resultBlock)
        {
            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_TOCHARGE);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion
    }
}
