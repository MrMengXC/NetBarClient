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
        public delegate void UpdateComputerDataHandle(int index,StructRealTime com);
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
        //刷新UI数据
        private event RefreshUIHandle RefreshStatusNumEvent;

        #endregion

        //电脑数据
        private List<StructRealTime> computers = new List<StructRealTime>();
        //电脑数据字典
        private Dictionary<Int32, StructRealTime> computerDict = new Dictionary<int, StructRealTime>();

        private static HomePageMessageManage _manage = null;

        private int idleNum = 0, onLineNum = 0, expectionNum = 0, onookNum = 0;
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
        public void GetHomePageList(GetDataResultHandle result,UpdateComputerDataHandle update, UpdateComputerDataHandle updateArea,RefreshUIHandle refreshStauts)
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
                this.computerDict.Clear();
                this.computers = result.pack.Content.ScRealtimeInfo.RealtimesList.ToList<StructRealTime>();
                foreach(StructRealTime com in this.computers)
                {
                    this.computerDict[com.Computerid] = com;
                }

               
                //获取回调
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
            onLineNum++;
            string comid = pars[0];
            //获取需要修改的电脑数据
            StructRealTime com;
            this.computerDict.TryGetValue(int.Parse(comid), out com);

            //生成新StructRealTime
            int index = this.computers.IndexOf(com);
            StructRealTime.Builder newCom = new StructRealTime.Builder(com);


            newCom.Status = ((int)COMPUTERSTATUS.在线).ToString();
            
            newCom.Cardnumber = pars[1];
            newCom.Usertype = pars[2];
            newCom.Billing = pars[3];
            newCom.Verify = pars[4];

            //----// 余额，余时。开始时间。已用时。结束时间
            newCom.Balance = pars[5];
            newCom.Starttime = pars[6];
            newCom.Usedtime = pars[7];
            newCom.Stoptime = pars[8];
            //计算剩余时间
            DateTime start = DateTime.Parse(newCom.Starttime);
            DateTime end = DateTime.Parse(newCom.Stoptime);
            TimeSpan ts = end.Subtract(start);
            int dateDiffSecond = ts.Days *24 * 60 + ts.Hours * 60+ ts.Minutes;
            newCom.Remaintime = (dateDiffSecond - int.Parse(newCom.Usedtime)) + "";

            //修改数组字典数据
            this.computers[index] = newCom.Build();
            this.computerDict[int.Parse(comid)] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());

        }
        #endregion

        #region 更新用户状态
        private void UpdateUserStatus(IList<string> pars)
        {
            string comid = pars[0];
            //获取需要修改的电脑数据
            StructRealTime com;
            this.computerDict.TryGetValue(int.Parse(comid), out com);

            //生成新StructRealTime
            int index = this.computers.IndexOf(com);
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
            this.computerDict[int.Parse(comid)] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());
        }
        #endregion

        #region 更新用户验证状态
        private void UpdateUserVerifyStatus(IList<string> pars)
        {
            string comid = pars[0];
            //获取需要修改的电脑数据
            StructRealTime com;
            this.computerDict.TryGetValue(int.Parse(comid), out com);

            //生成新StructRealTime
            int index = this.computers.IndexOf(com);
            StructRealTime.Builder newCom = new StructRealTime.Builder(com);
            newCom.Verify = "1";
            //修改数组字典数据
            this.computers[index] = newCom.Build();
            this.computerDict[int.Parse(comid)] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());
        }
        #endregion

        #region 用户下机
        private void UserDownComputer(IList<string> pars)
        {
            this.idleNum--;
            string comid = pars[0];
            //获取需要修改的电脑数据
            StructRealTime com;
            this.computerDict.TryGetValue(int.Parse(comid), out com);

            //生成新StructRealTime
            int index = this.computers.IndexOf(com);
            StructRealTime.Builder newCom = new StructRealTime.Builder(com);
            newCom.Status = ((int)COMPUTERSTATUS.空闲).ToString();
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
            this.computerDict[int.Parse(comid)] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());
        }
        #endregion

        #region 更新首页数据
        private void UpdateHomePage(int index,StructRealTime com)
        {
            if(this.UpdateComputerDataEvent != null)
            {
                this.UpdateComputerDataEvent(index, com);
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
        public void GetOnlineComputers(out List<StructRealTime> tem)
        {
            tem = new List<StructRealTime>();

            if (this.computers != null)
            {
                foreach(StructRealTime com in this.computers)
                {
                    if (!com.Cardnumber.Equals(""))
                    {
                        tem.Add(com);
                    }
                }
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
                    this.computerDict[newCom.Computerid] = newCom.Build();
                    if (this.UpdateComputerAreaEvent != null)
                    {
                        this.UpdateComputerAreaEvent(i, newCom.Build());
                    }
                }
                else
                {
                    if (this.UpdateComputerAreaEvent != null)
                    {
                        this.UpdateComputerAreaEvent(i, ori);
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
                    this.UpdateComputerAreaEvent(i, ori);
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
        public void AddMsgNumDelegate(UpdateMsgNumHandle call, UpdateMsgNumHandle exception, UpdateMsgNumHandle order)
        {
            this.UpdateCallMsgNumEvent += call;
            this.UpdateExceptionMsgNumEvent += exception;
            this.UpdateOrderMsgNumEvent += order;
        }
        #endregion

        #region 获取设备数量
        /// <summary>
        ///获取空闲设备数量
        /// </summary>
        public static int IdleNum
        {
            get
            {
            
                string status = ((int)COMPUTERSTATUS.空闲).ToString();
                IEnumerable<StructRealTime> num1 = from StructRealTime tem in Manage().computers where tem.Status.Equals(status) select tem;
                return num1.Count<StructRealTime>();
            }
        }

        /// <summary>
        /// 获取在线设备数量
        /// </summary>
        public static int OnlineNum
        {
            get
            {
                string status = ((int)COMPUTERSTATUS.在线).ToString();
                IEnumerable<StructRealTime> num1 = from StructRealTime tem in Manage().computers where tem.Status.Equals(status) select tem;
                return num1.Count<StructRealTime>();
            }
        }
        #endregion

    }
}
