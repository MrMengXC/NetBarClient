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
        //获取首页数据
        public delegate void GetDataResultHandle(bool success);
        private event GetDataResultHandle GetDataResultEvent;
        //更新计算机数据
        public delegate void UpdateComputerDataHandle(StructRealTime com);
        private event UpdateComputerDataHandle UpdateComputerDataEvent;
        //更新计算机所在区域信息
        private event UpdateComputerDataHandle UpdateComputerAreaEvent;
        //更新信息个数
        public delegate void UpdateMsgNumHandle(int num);
        //更新呼叫服务数
        private event UpdateMsgNumHandle UpdateCallMsgNumEvent;
        //更新客户端报错数量
        private event UpdateMsgNumHandle UpdateExceptionMsgNumEvent;
        //更新商品订单数量
        private event UpdateMsgNumHandle UpdateOrderMsgNumEvent;


        //刷新状态数量UI
        private event RefreshUIHandle RefreshStatusNumEvent;
        //刷新显示当日上机数量UI 刷新显示当日金额UI
        private event RefreshUIHandle RefreshDailyCountEvent;


        #endregion

        //电脑数据
        private List<StructRealTime> computers = new List<StructRealTime>();

        private static HomePageMessageManage _manage = null;

        private int dailyOnlineCount = 0, dailyTradeAmount = 0;

        //单例方法
        public static HomePageMessageManage Manage()
        {
            if(_manage == null)
            {
                _manage = new HomePageMessageManage();
            }
            return _manage;
        }

        #region 获取首页数据列表
        public void GetHomePageList(GetDataResultHandle result,
            UpdateComputerDataHandle update,
            UpdateComputerDataHandle updateArea,
            RefreshUIHandle refreshStauts)
        {
            this.GetDataResultEvent += result;
            this.UpdateComputerDataEvent += update;
            this.UpdateComputerAreaEvent += updateArea;
            this.RefreshStatusNumEvent += refreshStauts;
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

                //发送刷新设备状态信息的个数
                if(this.RefreshStatusNumEvent != null)
                {
                    this.RefreshStatusNumEvent();
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
                        if (this.UpdateCallMsgNumEvent != null)
                        {
                            int num = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.UpdateCallMsgNumEvent(num);
                        }
                        break;

                    //订单信息
                    case SYSMSG_TYPE.ORDER:

                        if(this.UpdateOrderMsgNumEvent != null)
                        {
                            int num = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.UpdateOrderMsgNumEvent(num);
                        }
                        break;
                    //异常信息
                    case SYSMSG_TYPE.EXCEPTION:
                        if(this.UpdateExceptionMsgNumEvent != null)
                        {
                            int num = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.UpdateExceptionMsgNumEvent(num);
                        }
                        break;

                    //当日上网人数
                    case SYSMSG_TYPE.DAILY_ONLINE_COUNT:
                        if(this.RefreshDailyCountEvent != null)
                        {
                            int num = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.dailyOnlineCount = num;
                            this.RefreshDailyCountEvent();
                        }

                        break;
                    //当日营收金额
                    case SYSMSG_TYPE.DAILY_TRADE_AMOUNT:
                        if (this.RefreshDailyCountEvent != null)
                        {
                            int num = pars[0].Equals("") ? 0 : int.Parse(pars[0]);
                            this.dailyTradeAmount = num;
                            this.RefreshDailyCountEvent();
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
            RefreshStatusNumEvent();
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
            RefreshStatusNumEvent();

        }
        #endregion

        #region 更新首页数据
        private void UpdateHomePage(int index,StructRealTime com)
        {
            if(this.UpdateComputerDataEvent != null)
            {
                this.UpdateComputerDataEvent(com);
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

        #region 更新首页电脑所在区域与名称
        public void UpdateHomePageComputerArea(List<StructRealTime> tem)
        {
            for(int i = 0;i<tem.Count;i++)
            {
                StructRealTime ori = this.computers[i];
                StructRealTime change = tem[i];
                if (!ori.Area.Equals(change.Area))
                {
                    StructRealTime.Builder newCom = new StructRealTime.Builder(ori);
                    newCom.Area = change.Area;
                    this.computers[i] = newCom.Build();
                    if (this.UpdateComputerAreaEvent != null)
                    {
                        this.UpdateComputerAreaEvent(newCom.Build());
                    }
                }
                else
                {
                    if (this.UpdateComputerAreaEvent != null)
                    {
                        this.UpdateComputerAreaEvent(ori);
                    }
                }
            }
        }
        #endregion

        #region 删除/修改区域后更新电脑区域
        public void ChangeAreaUpdateComputerArea()
        {
            for (int i = 0; i < this.computers.Count; i++)
            {
                StructRealTime ori = this.computers[i];
                if (this.UpdateComputerAreaEvent != null)
                {
                    this.UpdateComputerAreaEvent(ori);
                }
            }
        }
        #endregion

        #region 移除代理
        public void RemoveResultHandel(GetDataResultHandle result)
        {
            this.GetDataResultEvent -= result;
         
        }
        #endregion

        #region 添加首页信息个数代理
        public void AddMsgNumDelegate(UpdateMsgNumHandle call, 
            UpdateMsgNumHandle exception,
            UpdateMsgNumHandle order,
            RefreshUIHandle dailyCount,
            RefreshUIHandle statusUI)
        {
            this.UpdateCallMsgNumEvent += call;
            this.UpdateExceptionMsgNumEvent += exception;
            this.UpdateOrderMsgNumEvent += order;
            this.RefreshDailyCountEvent += dailyCount;
            this.RefreshStatusNumEvent += statusUI;
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
        public static  void GetFilterComputers(COMPUTERSTATUS status, int areaId, string key,out List<StructRealTime> coms)
        {
           coms = Manage().computers.ToList<StructRealTime>();
            if(status != COMPUTERSTATUS.无)
            {
                coms = coms.Where(tem => tem.Status.Equals(((int)status).ToString())).ToList<StructRealTime>();
            }
            if (areaId >= 0)
            {
                coms = coms.Where(tem => tem.Area.Equals(areaId.ToString())).ToList<StructRealTime>();
            }
            if(key != null && !key.Equals(""))
            {
                
                coms = coms.Where(tem => (tem.Ip.Contains(key) || tem.Mac.Contains(key) || tem.Computer.Contains(key))).ToList<StructRealTime>();
            }
        }
        #endregion

        
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

    }
}
