using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools.Manage
{
    /// <summary>
    /// 管理员管理
    /// </summary>
    class ManagerManage
    {
        private static ManagerManage manage = null;
        private event DataResultBlock DataResultEvent;
        private string aid;


        public static ManagerManage Manage()
        {
            if(manage == null)
            {
                manage = new ManagerManage();
            }
            return manage;
        }
        /// <summary>
        /// 获取账户信息
        /// </summary>
        public void GetAccountInfo(DataResultBlock result)
        {
            this.DataResultEvent += result;
            //获取账户信息
            ManagerNetOperation.AccountInfo(AccountInfoBlock,this.aid);
        }

        // 获取账户信息的回调
        public void AccountInfoBlock(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_ACCOUNT_INFO)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(AccountInfoBlock);
            System.Console.WriteLine("AccountInfoBlock:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
               if(this.DataResultEvent != null)
                {
                    this.DataResultEvent(result);
                }

            }
        }

        /// <summary>
        /// 移除账户信息结果回调
        /// </summary>
        /// <param name="result"></param>
        public void RemoveAccountInfoResultBlock(DataResultBlock result)
        {

            manage.DataResultEvent -= result;

        }


        public string AccountId
        {
            set
            {
                this.aid = value;
            }
        }
    }
}
