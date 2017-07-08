using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools
{
    #region 收入类型
    /// <summary>
    /// 收入类型
    /// </summary>
    public enum IncomeType
    {
       /// <summary>
       /// 日收入
       /// </summary>
        DAY_INCOME,  
        /// <summary>
        /// 月收入
        /// </summary>
        MONTH_INCOME,
        /// <summary>
        /// 年收入
        /// </summary>
        YEAR_INCOME,
    }
    #endregion

    #region 管理员操作
    /// <summary>
    /// 管理员操作
    /// </summary>
    public enum COMMAND_TYPE
    {
        /// <summary>
        /// 强制退出
        /// </summary>
        TICKOFF = 1,
        /// <summary>
        /// 锁定
        /// </summary>     
        LOCK = 2,
        /// <summary>
        /// 解锁
        /// </summary>
        UNLOCK = 3,         
        /// <summary>
        /// 验证
        /// </summary>
        VERIFY = 4, 
        /// <summary>
        /// 全部结帐
        /// </summary>
        CHECKOUT =  5,     
        /// <summary>
        /// 关闭闲机
        /// </summary>
        IDLEOFF = 6,

        /// <summary>
        /// 通知全部用户
        /// </summary>
        NOTIFYALL = 7,
        /// <summary>
        /// 管理员发消息给用户
        /// </summary>
        NOTIFY = 8,
        /// <summary>
        /// 用户发消息给管理员
        /// </summary>
        CALL = 9,
    }
    #endregion
}
