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
        public event GetDataResultHandle GetDataResultEvent;
        //更新计算机数据
        public delegate void UpdateComputerDataHandle(int index,StructRealTime com);
        public event UpdateComputerDataHandle UpdateComputerDataEvent;
        //更新计算机所在区域信息
        public event UpdateComputerDataHandle UpdateComputerAreaEvent;
        #endregion

        //电脑数据
        private List<StructRealTime> computers = new List<StructRealTime>();
        //电脑数据字典
        private Dictionary<Int32, StructRealTime> computerDict = new Dictionary<int, StructRealTime>();

        private static HomePageMessageManage _manage = null;

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
        public void GetHomePageList(GetDataResultHandle result,UpdateComputerDataHandle update, UpdateComputerDataHandle updateArea)
        {
            this.GetDataResultEvent += result;
            this.UpdateComputerDataEvent += update;
            this.UpdateComputerAreaEvent += updateArea;
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
            NetMessageManage.Manage().RemoveResultBlock(HomePageListResult);
           //System.Console.WriteLine("HomePageListResult:" + result.pack);
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
            NetMessageManage.Manage().AddResultBlock(GetSysMessageResult);
            
        }
        //获取系统信息反馈回调
        private void GetSysMessageResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_CLIENT_SYSMESSAGE)
            {
                return;
            }
            System.Console.WriteLine("GetSysMessageResult:"+result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                SCSysMessage message = result.pack.Content.ScSysMessage;
                UpdateComputerData(message);
            }
            

        }
        #endregion

        #region 更新电脑数据
        private void UpdateComputerData(SCSysMessage message)
        {
            IList<string> pars = message.ParamsList;
            string comid = pars[0];
            //获取需要修改的电脑数据
            StructRealTime com;
            this.computerDict.TryGetValue(int.Parse(comid), out com);

            //生成新StructRealTime
            int index = this.computers.IndexOf(com);
            StructRealTime.Builder newCom = new StructRealTime.Builder(com);

            switch (message.Cmd)
            {
                //上机
                case 1:
                    UserUpComputer(pars,newCom);
                    break;
                //下机
                case 2:
                    UserDownComputer(pars, newCom);
                    break;
                case 3:

                    break;
                //更新状态
                case 4:
                    UpdateUserStatus(pars, newCom);
                    break;

                case 5:

                    break;

                default:

                    break;

            }

            //修改数组字典数据
            this.computers[index] = newCom.Build();
            this.computerDict[int.Parse(comid)] = newCom.Build();
            //更新首页数据
            UpdateHomePage(index, newCom.Build());
        }

        #region 用户上机
        private void UserUpComputer(IList<string> pars, StructRealTime.Builder newCom)
        {
          
            newCom.Status = "在线";
            
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


        }
        #endregion

        #region 更新用户状态
        private void UpdateUserStatus(IList<string> pars, StructRealTime.Builder newCom)
        {
            
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
        }
        #endregion

        #region 用户下机
        private void UserDownComputer(IList<string> pars, StructRealTime.Builder newCom)
        {
            
            newCom.Status = "0";
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
        }
        #endregion

        //更新首页数据
        private void UpdateHomePage(int index,StructRealTime com)
        {
            if(this.UpdateComputerDataEvent != null)
            {
                this.UpdateComputerDataEvent(index, com);
            }
        }
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
    }
}
