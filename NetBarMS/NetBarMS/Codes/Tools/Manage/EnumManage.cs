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

    #region 系统接收信息类别s
    public enum SYSMSG_TYPE
    {
        /// <summary>
        /// 上机
        /// </summary>
        LOGON = 1,
        /// <summary>
        /// 下机
        /// </summary>
        LOGOFF = 2,
        /// <summary>
        /// 更新状态（扣费）
        /// </summary>
        UPSTATUS = 4,
        /// <summary>
        /// 验证
        /// </summary>
        VERIFY = 8,
        /// <summary>
        /// 会员呼叫
        /// </summary>
        CALL = 10,
        /// <summary>
        /// 订单
        /// </summary>
        ORDER = 11,
        /// <summary>
        /// 客户端异常
        /// </summary>
        EXCEPTION = 12,
    }
    #endregion


    #region 订单类型
    public enum ORDER_TYPE
    {

        //1提交 2付款完成 3订单处理完成（发货完成）
        //"1提交","2完成","3撤销"
    }

    //流程状态（充值，注册会员）
    public enum FLOW_STATUS
    {
        NONE_STATUS,        //无状态
        NORMAL_STATUS,      //正常状态，不需要其他操作
        ACTIVE_STATUS,      //激活状态，返回激活页面，再次激活
    }
    //充值类型
    public enum PRECHARGE_TYPE
    {
        NOT_MEMBER = 0,        //不开通会员
        OPEN_MEMBER,      //开通会员
    }

    #endregion
}
