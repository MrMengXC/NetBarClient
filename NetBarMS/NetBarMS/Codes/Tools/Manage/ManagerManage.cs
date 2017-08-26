using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //账户信息
        private SCAccountInfo accountInfo;
        #region 单例方法
        public static ManagerManage Manage()
        {
            if(manage == null)
            {
                manage = new ManagerManage();
            }
            return manage;
        }
        #endregion

        #region 获取账户信息
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
            NetMessageManage.RemoveResultBlock(AccountInfoBlock);
            System.Console.WriteLine("AccountInfoBlock:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                accountInfo = result.pack.Content.ScAccountInfo;
               if (this.DataResultEvent != null)
                {
                    this.DataResultEvent(result);
                }

            }
        }
        #endregion

        #region 移除账户信息结果回调
        /// <summary>
        /// 移除账户信息结果回调
        /// </summary>
        /// <param name="result"></param>
        public void RemoveAccountInfoResultBlock(DataResultBlock result)
        {
            manage.DataResultEvent -= result;
        }
        #endregion

        #region 当前账户Id
        public string AccountId
        {
            set
            {
                this.aid = value;
            }
        }
        #endregion

        /// <summary>
        /// 是否有权限使用该菜单功能
        /// </summary>
        /// <param name="nodeId">菜单Id</param>
        /// <returns></returns>
        public bool IsRightUse(int nodeId)
        {
            //TODO:打开
            return true;
            string rights = accountInfo.Role.Rights;
            bool isRight = BigInteger.BigIntegerTools.TestRights(rights, nodeId);
            if (!isRight) { MessageBox.Show("很抱歉，您无权限使用该功能");}
            return isRight;
        }
    }
}
