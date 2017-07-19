using NetBarMS.Codes.Model;
using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools.Manage
{

    /// <summary>
    /// 首页信息管理
    /// </summary>
    class HomePageMessageManage
    {
        #region 代理方法
 
        public delegate void GetDataResultHandle(bool success);
        /// <summary>
        /// 获取首页数据
        /// </summary>
        private event GetDataResultHandle GetDataResultEvent;


        /// <summary>
        /// 更新单个计算机数据的委托
        /// </summary>
        /// <param name="com">所更新的计算机</param>
        public delegate void UpdateComputerDataHandle(StructRealTime com);
        
        /// <summary>
        /// 更新单个计算机信息（上机。下机。认证）（通用）
        /// </summary>
        private event UpdateComputerDataHandle UpdateComputerDataEvent;

        /// <summary>
        /// 更新单个计算机所在区域信息（列表视图使用）
        /// </summary>
        private event UpdateComputerDataHandle UpdateComputerAreaEvent;

        /// <summary>
        /// 更新区域回调方法（电脑视图时使用）
        /// </summary>
        private event RefreshUIHandle UpdateAreaEvent;


        /// <summary>
        /// 更新首页提醒信息的数量委托（呼叫服务/客户端报错/商品订单）
        /// </summary>
        private event RefreshUIHandle UpdateMsgNumEvent;

        /// <summary>
        /// 更新各状态数量UI 的回调方法
        /// </summary>
        private event RefreshUIHandle UpdateStatusNumEvent;
        /// <summary>
        /// 刷新显示当日上机数量UI 刷新显示当日金额UI
        /// </summary>
        private event RefreshUIHandle UpdateDailyCountEvent;

        /// <summary>
        /// 过滤电脑数据回调方法
        /// </summary>
        private event RefreshUIHandle FilterComputersEvent;

        /// <summary>
        /// 刷新区域ComBox
        /// </summary>
        private event RefreshUIHandle RefreshAreaComBox;

        #endregion

        #region property
        //单例
        private static HomePageMessageManage _manage = null;
        //电脑数据
        private List<StructRealTime> computers = new List<StructRealTime>();

        //过滤后的电脑数据
        private List<StructRealTime> filterComs = new List<StructRealTime>();
        private bool isFilter = false;
        //搜所条件

        private COMPUTERSTATUS s_status;
        private int s_areaId;
        private string s_key;

        //日上机数量，日营收金额
        private int dailyOnlineCount = 0, dailyTradeAmount = 0;
        //呼叫服务数量/客户端报错数量/商品订单数量
        private int callMsgNum = 0, exceptionMsgNum = 0, orderMsgNum = 0;
        #endregion

        #region 单例方法
        public static HomePageMessageManage Manage()
        {
            if(_manage == null)
            {
                _manage = new HomePageMessageManage();
            }
            return _manage;
        }
        #endregion

        #region 添加首页信息个数代理
        /// <summary>
        /// 添加首页信息个数代理
        /// </summary>
        /// <param name="msg">提醒消息回调</param>
        /// <param name="dailyCount">日常数据回调</param>
        /// <param name="statusUI">计算机状态数量回调</param>
        public void AddMsgNumDelegate(
            RefreshUIHandle msg,
            RefreshUIHandle dailyCount,
            RefreshUIHandle statusUI)
        {
            this.UpdateMsgNumEvent += msg;
            this.UpdateDailyCountEvent += dailyCount;
            this.UpdateStatusNumEvent += statusUI;
        }
        #endregion

        #region 添加修改区域下拉列表的回调
        /// <summary>
        /// 添加刷新区域下拉菜单的回调
        /// </summary>
        /// <param name="area">回调方法</param>
        public static void AddRefreshAreaComBox(RefreshUIHandle area)
        {
            Manage().RefreshAreaComBox += area;
        }
        #endregion

        #region 添加/ 移除更新数据回调
        public static void AddUpdateDataEvent(
            UpdateComputerDataHandle update,
            UpdateComputerDataHandle updateComArea,
            RefreshUIHandle updateArea,
            RefreshUIHandle filter)
        {
            if (update != null)
            {
                Manage().UpdateComputerDataEvent += update;
            }
            if (updateComArea != null)
            {
                Manage().UpdateComputerAreaEvent += updateComArea;
            }
            if (updateArea != null)
            {
                Manage().UpdateAreaEvent += updateArea;
            }
            if (filter != null)
            {
                Manage().FilterComputersEvent += filter;
            }
        }
        public static void RemoveUpdateDataEvent(
           UpdateComputerDataHandle update,
           UpdateComputerDataHandle updateComArea,
           RefreshUIHandle updateArea,
             RefreshUIHandle filter)
        {
            if (update != null)
            {
                Manage().UpdateComputerDataEvent -= update;
            }
            if (updateComArea != null)
            {
                Manage().UpdateComputerAreaEvent -= updateComArea;
            }
            if (updateArea != null)
            {
                Manage().UpdateAreaEvent -= updateArea;
            }
            if(filter != null)
            {
                Manage().FilterComputersEvent -= filter;
            }
        }
        #endregion

        #region 获取首页数据列表
        public void GetHomePageList(
            GetDataResultHandle result)
        {
            this.GetDataResultEvent += result;
            //获取上网信息
            HomePageNetOperation.HompageList(HomePageListResult);
        }

        // 获取首页计算机列表结果回调
        private void HomePageListResult(ResultModel result)
        {
           
            if (result.pack.Cmd != Cmd.CMD_REALTIME_INFO)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(HomePageListResult);
         //  System.Console.WriteLine("HomePageListResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.computers = result.pack.Content.ScRealtimeInfo.RealtimesList.ToList<StructRealTime>();
                this.filterComs = this.computers.ToList<StructRealTime>();
                //发送刷新设备状态信息的个数
                if (this.UpdateStatusNumEvent != null)
                {
                    this.UpdateStatusNumEvent();
                }
                if (this.FilterComputersEvent != null)
                {
                    this.FilterComputersEvent();
                }
                //获取系统消息回调
                GetSysMessage();
            }
            else
            {

            }
            if (this.GetDataResultEvent != null)
            {
                this.GetDataResultEvent(result.pack.Content.MessageType == 1);
            }
        }

        #endregion

        #region 获取系统信息
        private void GetSysMessage()
        {
            //获取上网信息
            NetMessageManage.AddResultBlock(GetSysMessageResult);
            
        }
        //获取系统信息反馈回调
        private void GetSysMessageResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_MESSAGE)
            {
                return;
            }
            System.Console.WriteLine("GetSysMessageResult:"+result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                SCMessage message = result.pack.Content.ScMessage;
                IList<string> pars = message.ParamsList;
                SYSMSG_TYPE msg = (SYSMSG_TYPE)message.Cmd;

                switch (msg)
                {
                    //上机
                    case SYSMSG_TYPE.LOGON:
                        UserUpComputer(pars);
                        break;
                    //下机
                    case SYSMSG_TYPE.LOGOFF:
                        UserDownComputer(pars);
                        break;
                    //更新状态
                    case SYSMSG_TYPE.UPSTATUS:
                        UpdateUserStatus(pars);
                        break;

                    //更新验证
                    case SYSMSG_TYPE.VERIFY:
                        UpdateUserVerifyStatus(pars);
                        break;

                    //有呼叫消息
                    case SYSMSG_TYPE.CALL:
                        if (this.UpdateMsgNumEvent != null)
                        {
                            this.callMsgNum = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.UpdateMsgNumEvent();
                        }
                        break;

                    //订单信息
                    case SYSMSG_TYPE.ORDER:

                        if(this.UpdateMsgNumEvent != null)
                        {
                            this.orderMsgNum = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.UpdateMsgNumEvent();
                        }
                        break;
                    //异常信息
                    case SYSMSG_TYPE.EXCEPTION:
                        if(this.UpdateMsgNumEvent != null)
                        {
                            this.exceptionMsgNum = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.UpdateMsgNumEvent();
                        }
                        break;

                    //当日上网人数
                    case SYSMSG_TYPE.DAILY_ONLINE_COUNT:
                        if(this.UpdateDailyCountEvent != null)
                        {
                            int num = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.dailyOnlineCount = num;
                            this.UpdateDailyCountEvent();
                        }

                        break;
                    //当日营收金额
                    case SYSMSG_TYPE.DAILY_TRADE_AMOUNT:
                        if (this.UpdateDailyCountEvent != null)
                        {
                            int num = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.dailyTradeAmount = num;
                            this.UpdateDailyCountEvent();
                        }

                        break;
                    default:

                        break;

                }
            }
            

        }
        #endregion

        #region 更新电脑数据
        #region 用户上机
        private void UserUpComputer(IList<string> pars)
        {
            string comid = pars[0];
            //获取需要修改的电脑数据
            int index = GetComputerIndex(int.Parse(comid));
            StructRealTime com = this.computers[index];

            //生成新StructRealTime
            StructRealTime.Builder newCom = new StructRealTime.Builder(com);
            newCom.Status = ((int)COMPUTERSTATUS.在线).ToString();
            newCom.Name = pars[1];
            newCom.Cardnumber = pars[2];
            newCom.Usertype = pars[3];
            newCom.Billing = pars[4];
            newCom.Verify = pars[5];

            //----// 余额，余时。开始时间。已用时。结束时间
            newCom.Balance = pars[6];
            newCom.Starttime = pars[7];
            newCom.Usedtime = pars[8];
            newCom.Stoptime = pars[9];
            //计算剩余时间
            DateTime start = DateTime.Parse(newCom.Starttime);
            DateTime end = DateTime.Parse(newCom.Stoptime);
            TimeSpan ts = end.Subtract(start);
            int dateDiffSecond = ts.Days *24 * 60 + ts.Hours * 60+ ts.Minutes;
            newCom.Remaintime = (dateDiffSecond - int.Parse(newCom.Usedtime)) + "";

            //修改数组字典数据
            this.computers[index] = newCom.Build();
            //this.computerDict[int.Parse(comid)] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());
            //刷新首页状态数量
            UpdateStatusNumEvent();
        }
        #endregion

        #region 更新用户状态
        private void UpdateUserStatus(IList<string> pars)
        {
            string comid = pars[0];
            //获取需要修改的电脑数据
            int index = GetComputerIndex(int.Parse(comid));
            StructRealTime com = this.computers[index];
            //生成新StructRealTime
            StructRealTime.Builder newCom = new StructRealTime.Builder(com);

            //----// 余额，开始时间。已用时。结束时间
            newCom.Balance = pars[1];
            newCom.Starttime = pars[2];
            newCom.Usedtime = pars[3];
            newCom.Stoptime = pars[4];

            //计算剩余时间
            DateTime start = DateTime.Parse(newCom.Starttime);
            DateTime end = DateTime.Parse(newCom.Stoptime);
            TimeSpan ts = end.Subtract(start);
            int dateDiffSecond = ts.Days * 24 * 60 + ts.Hours * 60 + ts.Minutes;
            newCom.Remaintime = (dateDiffSecond - int.Parse(newCom.Usedtime)) + "";

            //修改数组字典数据
            this.computers[index] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());
        }
        #endregion

        #region 更新用户验证状态
        private void UpdateUserVerifyStatus(IList<string> pars)
        {
            string comid = pars[0];
            //获取需要修改的电脑数据
            int index = GetComputerIndex(int.Parse(comid));
            StructRealTime com = this.computers[index];

            //生成新StructRealTime
            StructRealTime.Builder newCom = new StructRealTime.Builder(com);
            newCom.Verify = "1";
            //修改数组字典数据
            this.computers[index] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());
        }
        #endregion

        #region 用户下机
        private void UserDownComputer(IList<string> pars)
        {
            string comid = pars[0];
            int index = GetComputerIndex(int.Parse(comid));
            //获取需要修改的电脑数据
            StructRealTime com = this.computers[index];

            //生成新StructRealTime
            StructRealTime.Builder newCom = new StructRealTime.Builder(com);
            newCom.Status = ((int)COMPUTERSTATUS.空闲).ToString();
            newCom.Name = "";
            newCom.Cardnumber = "";
            newCom.Usertype = "";
            newCom.Billing = "";
            newCom.Verify = "";
            //----// 余额，余时。开始时间。已用时。结束时间
            newCom.Balance ="";
            newCom.Starttime ="";
            newCom.Usedtime = "";
            newCom.Remaintime = "";
            newCom.Stoptime = "";

            //修改数组字典数据
            this.computers[index] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());
            //刷新首页状态数量
            UpdateStatusNumEvent();

        }
        #endregion

        #region 更新首页数据
        private void UpdateHomePage(int index,StructRealTime newcom)
        {
            //如果当前在过滤条件下以及电脑状态也在过滤条件下则重新搜索过滤数据
            if(IsFilter && this.s_status != COMPUTERSTATUS.无)
            {
                //判断是否影响当前搜索
                HomePageMessageManage.GetFilterComputers(this.s_status, this.s_areaId, this.s_key);
            }
            //否则更新单个电脑状态
            else
            {
                if (this.UpdateComputerDataEvent != null)
                {
                    this.UpdateComputerDataEvent(newcom);
                }
            }
            
        }

        #endregion

        #endregion

        #region 获取区域电脑
        public void GetComputers(out List<StructRealTime> tem)
        {
            if(this.computers != null)
            {
                tem = this.computers.ToList<StructRealTime>();
            }
            else
            {
                tem = new List<StructRealTime>();
            }
        }
        #endregion

        #region 获取在线电脑
        public static void GetStatusComputers(out List<StructRealTime> tem,COMPUTERSTATUS status)
        {
            tem = new List<StructRealTime>();
            if (HomePageMessageManage.Manage().computers != null)
            {
                IEnumerable<StructRealTime> onlines = from StructRealTime com in Manage().computers where com.Status.Equals(((int)status).ToString()) select com;
                tem = onlines.ToList<StructRealTime>();
            }
           
        }
        #endregion

        #region 更新首页电脑所在区域与名称（区域设置调用点击最后完成时）
        public static  void UpdateHomePageComputerArea(List<StructRealTime> tem)
        {
            for(int i = 0;i<tem.Count;i++)
            {
                StructRealTime ori = Manage().computers[i];
                StructRealTime change = tem[i];

                if (!ori.Area.Equals(change.Area))
                {
                    StructRealTime.Builder newCom = new StructRealTime.Builder(ori);
                    newCom.Area = change.Area;
                    Manage().computers[i] = newCom.Build();
                    if (Manage().UpdateComputerAreaEvent != null && Manage().s_areaId < 0)
                    {
                        Manage().UpdateComputerAreaEvent(newCom.Build());
                    }
                }
                else
                {
                    //被移除了
                    if (Manage().UpdateComputerAreaEvent != null && Manage().s_areaId < 0)
                    {
                        Manage().UpdateComputerAreaEvent(ori);
                    }
                }
            }

            if(Manage().UpdateAreaEvent != null)
            {
                Manage().UpdateAreaEvent();
                if(Manage().s_areaId >= 0)
                {
                    //需要更新一下
                    GetFilterComputers(Manage().s_status, Manage().s_areaId, Manage().s_key);
                }
            }

         

            else
            {
                GetFilterComputers(Manage().s_status, Manage().s_areaId, Manage().s_key);
            }
        }
        #endregion

        #region 删除/修改/添加区域后更新电脑区域
        /// <summary>
        /// 删除或修改区域后进行更新电脑区域
        /// </summary>
        public static void ChangeAreaUpdateComputerArea()
        {
            //当电脑视图时修改了区域进行调用
            if (Manage().UpdateAreaEvent != null)
            {
                Manage().UpdateAreaEvent();
            }
            //列表视图
            else
            {
                //没有将区域作为筛选添加
                if(Manage().s_areaId < 0)
                {
                    //更新了每一台电脑
                    for (int i = 0; i < Manage().computers.Count; i++)
                    {
                        StructRealTime ori = Manage().computers[i];

                        if (Manage().UpdateComputerAreaEvent != null)
                        {
                            Manage().UpdateComputerAreaEvent(ori);
                        }
                    }
                }
                else
                {
                    GetFilterComputers(Manage().s_status, Manage().s_areaId, Manage().s_key);
                }
                
            }

        }
        /// <summary>
        /// 增删改之后区域列表进行更新（更新区域下拉菜单）
        /// </summary>
        public static void ChangeComputerArea()
        {

            if(Manage().RefreshAreaComBox != null)
            {
                Manage().RefreshAreaComBox();
            }
        }
        #endregion

        #region 移除代理
        public void RemoveResultHandel(GetDataResultHandle result)
        {
            this.GetDataResultEvent -= result;
         
        }
        #endregion

        #region 获取设备数量
        

        /// <summary>
        /// 获取在线设备数量
        /// </summary>
        public static int OnLineNum
        {
            get
            {
                string status = ((int)COMPUTERSTATUS.在线).ToString();
                IEnumerable<StructRealTime> num1 = from StructRealTime tem in Manage().computers where tem.Status.Equals(status) select tem;
                return num1.Count<StructRealTime>();
   
            }
        }

        /// <summary>
        /// 获取设备数量
        /// </summary>
        public static Dictionary<string,int> StatusNum
        {
            get
            {
                IEnumerable<IGrouping<string, StructRealTime>> comps = Manage().computers.GroupBy(com => com.Status);
                Dictionary<string, int> dict = comps.ToDictionary(tem => tem.Key, tem2 => tem2.Count());
                return dict;
            }
        }
        #endregion

        #region 通过电脑id获取电脑所在数组索引
        private int GetComputerIndex(int comid)
        {
            return HomePageMessageManage.GetComputerIndex(comid,Manage().computers);
        }
        public static int GetComputerIndex(int comid,List<StructRealTime> coms)
        {
            try
            {
                int comIndex = coms.Select((StructRealTime com, int
              index) => new { com, index }).Where(a => a.com.Computerid == comid).First().index;
                return comIndex;
            }
            catch(Exception exc)
            {
                return -1;
            }
          
        }

        #endregion

        #region 过滤条件获取数组
        public static  void GetFilterComputers(COMPUTERSTATUS status, int areaId, string key)
        {
            Manage().filterComs  = Manage().computers.ToList<StructRealTime>();
            //是否是过滤状态
            Manage().isFilter = false;
            Manage().s_status = COMPUTERSTATUS.无;
            Manage().s_areaId = -1;
            Manage().s_key = "";

            if(status != COMPUTERSTATUS.无)
            {
                Manage().filterComs = Manage().filterComs.Where(tem => tem.Status.Equals(((int)status).ToString())).ToList<StructRealTime>();
                Manage().isFilter = true;
                Manage().s_status = status;

            }
            if (areaId >= 0)
            {
                Manage().filterComs = Manage().filterComs.Where(tem => tem.Area.Equals(areaId.ToString())).ToList<StructRealTime>();
                Manage().isFilter = true;
                Manage().s_areaId = areaId;
            }
            if (key != null && !key.Equals(""))
            {
                Manage().filterComs = Manage().filterComs.Where(tem => (tem.Ip.Contains(key) || tem.Mac.Contains(key) || tem.Computer.Contains(key))).ToList<StructRealTime>();
                Manage().isFilter = true;
                Manage().s_key = key;
            }
            if (Manage().FilterComputersEvent != null)
            {
                Manage().FilterComputersEvent();
            }

        }
        #endregion

        #region 获取区域字典（首页电脑视图使用）
        public static Dictionary<string, List<StructRealTime>> GetAreaComsDict()
        {
            //获取已有区域
            List<AreaTypeModel> areas = SysManage.Areas;
            //以区域划分
            IEnumerable<IGrouping<string, StructRealTime>> comps = Manage().computers.GroupBy(com => com.Area);
            Dictionary<string, List<StructRealTime>> dict = new Dictionary<string, List<StructRealTime>>();

            List<StructRealTime> noArea = new List<StructRealTime>();
            foreach (IGrouping<string, StructRealTime> tem in comps)
            {
                string areaId = tem.Key;
                int num = areas.Where(areaModel => areaModel.areaId == int.Parse(areaId)).Count();
                //添加到无名的区域
                if (num == 0)
                {
                    noArea.AddRange(tem.ToList<StructRealTime>());
                }
                else
                {
                    dict[areaId] = tem.ToList<StructRealTime>();
                }


            }
            //将无名的区域添加到字典中
            if(noArea.Count > 0)
            {
                dict["-1"] = noArea.OrderBy(com => com.Computerid).ToList<StructRealTime>();
            }
            return dict;
        }


        #endregion

        #region 获取当日营收等信息
        /// <summary>
        /// 获取当日营收金额
        /// </summary>
        public static int DailyTradeAmount
        {
            get
            {
                return Manage().dailyTradeAmount;
            }
        }
        /// <summary>
        /// 获取当日在线人数
        /// </summary>
        public static int DailyOnlineCount {
            get
            {
                return Manage().dailyOnlineCount;
            }

        }
        #endregion

        #region 获取首页提醒数量（呼叫服务/客户端报错/商品订单）
        /// <summary>
        /// 呼叫服务提醒数量
        /// </summary>
        public static int CallMsgNum
        {
            get
            {
                return Manage().callMsgNum;
            }
        }
        /// <summary>
        /// 客户端报错提醒数量
        /// </summary>
        public static int ExceptionMsgNum
        {
            get
            {
                return Manage().exceptionMsgNum;
            }
        }
        /// <summary>
        /// 商品订单提醒数量
        /// </summary>
        public static int OrderMsgNum
        {
            get
            {
                return Manage().orderMsgNum;
            }
        }
        #endregion

        #region 获取过滤后的电脑数据
        public static List<StructRealTime> FilterComputers
        {
            get
            {
                return Manage().filterComs;
            }
        }


        #endregion

        #region 获取当前数据是否是过滤过得(电脑视图使用)
        public static bool IsFilter
        {
            get
            {
                return Manage().isFilter;
            }
        }
        #endregion


    }
}
