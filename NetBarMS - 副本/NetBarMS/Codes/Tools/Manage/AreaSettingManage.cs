using NetBarMS.Codes.Model;
using NetBarMS.Codes.Tools.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools
{
    class AreaSettingManage
    {
        //从首页获得的所有电脑数据
        private List<StructRealTime> allComputers;
        //当前选择的区域对应的电脑数据
        public List<StructRealTime> currentComs;
        //其他可以选择的所有电脑
        public List<StructRealTime> otherComs = new List<StructRealTime>();
        //已经改变的字典(key：电脑id)     
        private Dictionary<int, StructRealTime> changeComDict = new Dictionary<int, StructRealTime>();

        /// <summary>
        /// 初始化方法获取所有电脑
        /// </summary>
        public AreaSettingManage()
        {
            //获取所有电脑数据
            HomePageMessageManage.GetComputers(out allComputers);
        }

        #region 获取区域所对应的电脑和其他可以选择的电脑
        public void GetOtherComputers(string code)
        {
            List<AreaTypeModel> areas = SysManage.Areas;
            this.currentComs = new List<StructRealTime>();
            this.otherComs = new List<StructRealTime>();

            for (int i = 0; i < this.allComputers.Count; i++)
            {
                StructRealTime com = this.allComputers[i];
                //判断修改的字典
                this.changeComDict.TryGetValue(com.Computerid, out com);
                if(com == null)
                {
                    com = this.allComputers[i];
                }
                if(com.Area.Equals(code))
                {
                    currentComs.Add(com);
                }
                else if(areas.Where(area=>area.areaId == int.Parse(com.Area)).Count() == 0)      //不包含
                {
                    otherComs.Add(com);
                }
            }
        }
        #endregion

        #region 修改总电脑数组code（从某区域删除/添加电脑时使用）
        public void UpdateComputersCode(List<StructRealTime> changes)
        {
            //添加到所有改变字典中
            foreach (StructRealTime com in changes)
            {
                this.changeComDict[com.Computerid] = com;
            }



        }
        #endregion

        #region 获取所有修改过的电脑
        public CSComputerUpdate GetAllChangedComs()
        {
            //添加到所有字典
            CSComputerUpdate.Builder update = new CSComputerUpdate.Builder();
            foreach(StructRealTime com in this.changeComDict.Values)
            {
                //电脑
                StructComputer.Builder computer = new StructComputer.Builder();
                computer.Computerid = com.Computerid;
                computer.Name = com.Computer;
                computer.Area = com.Area;
                update.AddComputer(computer);
            }
            return update.Build();
        }
        #endregion

        #region 修改电脑区域从属信息成功-更新首页区域数据
        public void UpateHomePageComputerArea()
        {
            foreach(StructRealTime change in this.changeComDict.Values)
            {
                int index = this.allComputers.FindIndex(com => com.Computerid == change.Computerid);
                StructRealTime ori = this.allComputers[index];
                //修改电脑
                if (!ori.Area.Equals(change.Area) || !ori.Computer.Equals(change.Computer))
                {
                    this.allComputers[index] = change;
                }

            }          
            HomePageMessageManage.UpdateHomePageComputerArea(this.changeComDict.Values.ToList<StructRealTime>(), AREA_SETTING.NONE);
            this.changeComDict.Clear();
        }
        #endregion

        #region 更新首页电脑区域
        /// <summary>
        /// 更新首页的电脑区域
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="setting"></param>
        public void UpateHomePageComputerArea(int areaId,AREA_SETTING setting)
        {
            if(setting == AREA_SETTING.ADD)
            {
                HomePageMessageManage.UpdateHomePageComputerArea(null, setting);
                return;
            }
            var returnChanges= this.allComputers.Where(com => com.Area.Equals(areaId.ToString())).ToList<StructRealTime>();
            if (setting == AREA_SETTING.DELETE)
            {
                //修改所有数组和改变过的字典
                foreach(StructRealTime changeCom in returnChanges)
                {

                    int index = this.allComputers.FindIndex(com => com.Computerid == changeCom.Computerid);
                    StructRealTime.Builder newCom = new StructRealTime.Builder(this.allComputers[index]);
                    newCom.Area = "0";
                    this.allComputers[index] = newCom.Build();
                }

                var changeds = this.changeComDict.Values.Where(com => com.Area.Equals(areaId.ToString())).ToList<StructRealTime>() ;
                foreach(StructRealTime changed in changeds)
                {
                    StructRealTime.Builder newChanged = new StructRealTime.Builder(changed);
                    newChanged.Area = "0";
                    this.changeComDict[newChanged.Computerid] = newChanged.Build();
                }

                 
            }
            HomePageMessageManage.UpdateHomePageComputerArea(returnChanges, setting);

        }
        #endregion

    }
}
