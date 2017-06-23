using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Codes.Tools.NetOperation
{
    class HomePageNetOperation
    {

        /// <summary>
        /// 上机信息实时列表
        /// </summary>
        public static void HompageList(DataResultBlock resultBlock)
        {
            try
            {
                MessagePack.Builder pack = new MessagePack.Builder();
                pack.SetCmd(Cmd.CMD_REALTIME_INFO);
                NetMessageManage.Manager().SendMsg(pack.Build(), resultBlock);
            }
            catch(Exception exc)
            {
                System.Console.WriteLine("获取上网实时列表失败："+exc);
            }

         

        }

        /// <summary>
        /// 上机激活
        /// </summary>
        public static void CardCheckIn(DataResultBlock resultBlock)
        {

            CSEmkCheckin.Builder checkin = new CSEmkCheckin.Builder();
            checkin.SetCardnumber("511725198904225281");

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsEmkCheckin(checkin);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_EMK_CHECKIN);
            pack.SetContent(content);
            NetMessageManage.Manager().SendMsg(pack.Build(), resultBlock);

        }
        /// <summary>
        /// 下机结算
        /// </summary>
        public static void CardCheckOut(DataResultBlock resultBlock)
        {
            CSEmkCheckout.Builder checkout = new CSEmkCheckout.Builder();
            checkout.SetCardnumber("511725198904225281");

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsEmkCheckout(checkout);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_EMK_CHECKOUT);
            pack.SetContent(content);
            NetMessageManage.Manager().SendMsg(pack.Build(), resultBlock);

        }
    }
}
