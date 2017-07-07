using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools
{
    //收入类型
    public enum IncomeType
    {
        DAY_INCOME,     //日收入
        MONTH_INCOME,   //月收入
        YEAR_INCOME,    //年收入
    }

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
        LOCK = 2,           //锁定
        /// <summary>
        /// 解锁
        /// </summary>
        UNLOCK = 3,         
        /// <summary>
        /// 验证
        /// </summary>
        VERIFY = 4,         //验证
        /// <summary>
        /// 全部结帐
        /// </summary>
        CHECKOUT =  5,     
        /// <summary>
        /// 关闭闲机
        /// </summary>
        IDLEOFF = 6,        //关闭闲机
    }
}
