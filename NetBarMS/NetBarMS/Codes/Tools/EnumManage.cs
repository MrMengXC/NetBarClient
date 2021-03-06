﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools
{
    #region 首页树形节点类型
    public enum TreeNodeTag
    {
        None = 1,
        /// <summary>
        /// 首页
        /// </summary>
        HomePage,
        NetRecord,              //上网记录
        MemberManage,           //会员管理

        ProductManage,          //上架商品管理
        ProductSellRank,        //销售排行

        RataManage,         //费率管理
        AwardManage,        //奖励管理
        IntegralManage,     //积分管理
        OtherCostManage,    //其他费用管理

        InComeManage,       //营收管理
        DayInCome,          //日营收
        MonthInCome,        //月营收
        YearInCome,         //年营收

        UserNetRecord,      //用户上网记录
        UserPayedRecord,    //用户充值记录
        UserConsumeRecord,  //用户消费记录
        //ProductSellRecord,  //商品销售记录
        OpenCardRecord,     //开卡记录
        ChangeShiftsRecord, //交接班记录
        ProductIndent,      //商品订单查寻
        OpenMemberRecord,        //  会员办理记录
        AttendanceSearch,       //上座率查询
        UserDrawBackRecord,     //用户退款记录

        JXInspect,          //绩效考核

        NetBarEvaluate,     //网吧评价
        StaffEvaluate,      //员工评价

        NetPassWord,        //上网密码
        StaffMoney,         //员工提成
        MemberLevManage,        //会员等级
        ProductType,        //商品类别
        ClientManage,       //客户端管理
        AreaManage,         //区域管理
        BackUpManage,       //备份管理
        SmsManage,          //短信管理

        StaffList,          //员工列表
        ManagerManage,      //管理人员

        LogManage,          //日志管理

        /// <summary>
        /// 设备信息管理
        /// </summary>
        EquipmentInfo,


    }
    #endregion

    #region GridControl 数据类型
    /// <summary>
    /// GridControl 数据类型
    /// </summary>
    public enum GridControlType
    {

        None = 1,
        /// <summary>
        /// 主页列表
        /// </summary>
        HomePageList,           //主页列表
        /// <summary>
        /// 开通会员
        /// </summary>
        OpenMember,             //开通会员
        /// <summary>
        /// 被锁列表
        /// </summary>
        LockList,               //被锁列表
        /// <summary>
        /// 已付款商品订单
        /// </summary>
        PayedProductIndent,     //已付款商品订单
        /// <summary>
        /// 上网记录
        /// </summary>
        NetRecord,              //上网记录
        /// <summary>
        /// 会员管理
        /// </summary>
        MemberManage,           //会员管理
        /// <summary>
        /// 上架商品管理
        /// </summary>
        ProductManage,      //上架商品管理
        /// <summary>
        /// 商品库存清单
        /// </summary>
        ProductStockList,   //商品库存清单
        /// <summary>
        /// 商品订单查询
        /// </summary>
        ProductIndent,      //商品订单查询
        /// <summary>
        /// 商品订单详情
        /// </summary>
        ProductIndentDetail,      //商品订单详情
        /// <summary>
        /// 费率管理
        /// </summary>
        RataManage,         //费率管理
        /// <summary>
        /// 正常奖励
        /// </summary>
        NormalAward,        //正常奖励
        /// <summary>
        /// 会员日奖励
        /// </summary>
        MemberDayAward,     //会员日奖励
        /// <summary>
        /// 营收详情
        /// </summary>
        InComeDetail,
        /// <summary>
        /// 聊天管理
        /// </summary>
        ChatManage,
        /// <summary>
        /// 绩效考核
        /// </summary>
        JXInspect,
        /// <summary>
        /// 用户上网记录
        /// </summary>
        UserNetRecord,
        /// <summary>
        /// 用户消费记录
        /// </summary>
        UserConsumeRecord,
        /// <summary>
        /// 商品销售记录
        /// </summary>
        ProductSellRecord,
        /// <summary>
        /// 开卡记录
        /// </summary>
        OpenCardRecord,
        /// <summary>
        /// 交班记录
        /// </summary>
        GiveShiftsRecord,
        /// <summary>
        /// 接班记录
        /// </summary>
        ReceiveShiftsRecord,
        /// <summary>
        /// 会员办理记录
        /// </summary>
        OpenMemberRecord,
        /// <summary>
        /// 会员充值记录
        /// </summary>
        MemberRechargeRecord,

        /// <summary>
        /// 网吧评价
        /// </summary>
        NetBarEvaluate,
        /// <summary>
        /// 员工评价
        /// </summary>
        StaffEvaluate,
        /// <summary>
        /// 留言板
        /// </summary>
        MsgBoard,

        /// <summary>
        /// 会员等级
        /// </summary>
        MemberLevManage,
        /// <summary>
        /// 商品类别
        /// </summary>
        ProductType,
        /// <summary>
        /// 客户端管理
        /// </summary>
        ClientManage,
        /// <summary>
        /// 区域管理
        /// </summary>
        AreaManage,
        /// <summary>
        /// 备份管理
        /// </summary>
        BackUpManage,
        /// <summary>
        /// 短信管理
        /// </summary>
        SmsManage,
        /// <summary>
        /// 管理人员
        /// </summary>
        ManagerManage,
        /// <summary>
        /// 日志管理
        /// </summary>
        LogManage,
        /// <summary>
        /// 呼叫服务
        /// </summary>
        CallService,
        /// <summary>
        /// 员工列表
        /// </summary>
        StaffList,
        /// <summary>
        /// 产品销售排行
        /// </summary>
        ProductSellRank,

        /// <summary>
        /// 日营收详情
        /// </summary>
        DayIncomeDetail,
        /// <summary>
        /// 月营收详情
        /// </summary>
        MonthIncomeDetail,
        /// <summary>
        /// 年营收详情
        /// </summary>
        YearIncomeDetail,

        /// <summary>
        /// 退款记录
        /// </summary>
        DrawBackRecord,

    }
    #endregion

    #region GridControl Column Type
    /// <summary>
    /// GridControl Column Type
    /// </summary>
    public enum ColumnType
    {
        /// <summary>
        /// 文字显示列
        /// </summary>
        C_Text = 0,
        /// <summary>
        /// 按钮列
        /// </summary>
        C_Button,       //按钮
        /// <summary>
        /// 复选框列
        /// </summary>
        C_Check,        //复选框
        /// <summary>
        /// 链接列
        /// </summary>
        C_LineLink,     //链接列
        /// <summary>
        /// 自定义列
        /// </summary>
        C_Custom
    }
    #endregion


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

    //"无","锁定","激活","在线","离线"
    #region 会员状态
    /// <summary>
    /// 会员状态设置
    /// </summary>
    public enum MEMBERSTATUS
    {
        无 = 0,
        锁定,
        激活,
        在线,
        离线,
    }
    #endregion

    #region 付款渠道
    /// <summary>
    /// 付款渠道
    /// </summary>
    public enum PAYCHANNEL
    {
        无 = 0,
        支付宝,
        微信,
        积分兑换,
        现金,
    }
    #endregion

    #region 消费用途
    /// <summary>
    /// 消费用途
    /// </summary>
    public enum CONSUMEUSE
    {
        无 = 0,
        购物,
        充值,
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
        CHECKOUT = 5,
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
        /// <summary>
        /// 当日营收金额
        /// </summary>
        DAILY_TRADE_AMOUNT = 14,

        /// <summary>
        /// 当日上机数量
        /// </summary>
        DAILY_ONLINE_COUNT = 15,
    }
    #endregion

    #region 订单类型
    public enum ORDER_TYPE
    {

        //1提交 2付款完成 3订单处理完成（发货完成）
        //"1提交","2完成","3撤销"
    }
    #endregion

    #region 流程状态（充值，注册会员）
    public enum FLOW_STATUS
    {
        NONE_STATUS,        //无状态
        /// <summary>
        /// 正常状态，不需要其他操作
        /// </summary>
        NORMAL_STATUS,
        /// <summary>
        /// 办理会员状态
        /// </summary>
        MEMBER_STATUS,
        /// <summary>
        /// 激活状态，返回激活页面，再次激活
        /// </summary>
        ACTIVE_STATUS,
    }
    #endregion

    #region 充值类型
    public enum PRECHARGE_TYPE
    {
        NOT_MEMBER = 0,        //不开通会员
        OPEN_MEMBER,      //开通会员
    }
    #endregion

    #region 办理渠道
    public enum MANAGECHANNEL
    {
        无 = 0,
        智能终端 = 1,
        电脑客户端 = 2,
        系统后台 = 3,
    }
    #endregion

    #region UI 的边框
    /// <summary>
    /// 边框类型
    /// </summary>
    public enum BORDER_TYPE
    {
        /// <summary>
        /// 输入框边框
        /// </summary>
        TEXTEDIT_BORDER = 0,
        /// <summary>
        /// 按钮边框蓝色
        /// </summary>
        BUTTON_BORDER,

    }
    #endregion

    #region 进行激活、开通会员、充值的错误信息
    public enum FLOW_ERROR
    {
        /// <summary>
        /// 其他
        /// </summary>
        OTHER = 0,
        /// <summary>
        /// 需要添加身份证信息（临时会员）
        /// </summary>
        NEED_ADD_CARD = 207,
        /// <summary>
        /// 需要充值
        /// </summary>
        NEED_RECHARGE = 208,

        /// <summary>
        /// 用户已锁定
        /// </summary>
        USER_LOCK = 205,

        /// <summary>
        /// 已经是会员不能进行办理会员
        /// </summary>
        IS_MEMBER = 210,

    }

    #endregion

    #region 电脑设备状态
    public enum COMPUTERSTATUS
    {
        无 = -1,
        空闲 = 0,
        在线 = 1,
        挂机 = 2,
        异常 = 3,
    }




    #endregion

    #region 订单到帐状态
    /// <summary>
    /// 订单到帐状态
    /// </summary>
    public enum INDENT_FINISH_STATUS
    {
        无 = 0,
        提交订单,
        付款成功,
        处理完成
    }

    #endregion


    #region 区域设置
    enum AREA_SETTING
    {
        /// <summary>
        /// 无
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 添加区域
        /// </summary>
        ADD,
        /// <summary>
        /// 删除区域
        /// </summary>
        DELETE,
        /// <summary>
        /// 修改区域
        /// </summary>
        UPDATE,


    }


    #endregion

}
