using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools.FlowManage
{
    /// <summary>
    /// 用户激活流程
    /// </summary>
    class ActiveFlowManage
    {

        /// <summary>
        /// 进行用户开卡机会
        /// </summary>
        /// <param name="idnumber"></param>
        public static void IsActive(string idnumber)
        {

            HomePageNetOperation.CardCheckIn(CardCheckInBlock);
           



        }
        public static void CardCheckInBlock(ResultModel model)
        {

        }

    }
}
