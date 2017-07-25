using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools.NetOperation
{
    /// <summary>
    /// 营收网络请求
    /// </summary>
    class IncomeNetOperation
    {

        #region 获取日营收
        public static void GetIncomeDetail(DataResultBlock resultBlock, string start,string end,IncomeType type)
        {

            CSEarning.Builder earing = new CSEarning.Builder();
            earing.Starttime = start;
            earing.Endtime = end;
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsEarning(earing);

            SendModel send = new SendModel()
            {
                content = content.Build(),
            };

            if(type == IncomeType.DAY_INCOME)
            {
                send.cmd = Cmd.CMD_EARNING_DAY;
            }
            else if(type == IncomeType.MONTH_INCOME)
            {
                send.cmd = Cmd.CMD_EARNING_MONTH;
            }
            else
            {
                send.cmd = Cmd.CMD_EARNING_YEAR;
            }
          
            NetMessageManage.SendMsg(send, resultBlock);
        }
        #endregion

    }
}
