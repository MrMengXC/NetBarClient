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
        private List<StructRealTime> allComputers;     //从首页获得的所有电脑数据
        public List<StructRealTime> currentComs;       //当前选择的电脑数据
        public List<StructRealTime> otherComs = new List<StructRealTime>();         //其他的所有电脑
        private Dictionary<int, StructRealTime> changeComDict = new Dictionary<int, StructRealTime>();//已经改变的字典(key：电脑id)

        public AreaSettingManage()
        {
            //获取所有电脑数据
            HomePageMessageManage.Manage().GetComputers(out allComputers);
        }

        #region 获取区域所对应的电脑和其他电脑
        public void GetOtherComputers(string code, List<string> areas)
        {
            this.currentComs = new List<StructRealTime>();
            this.otherComs = new List<StructRealTime>();

            for (int i = 0; i < this.allComputers.Count; i++)
            {
                StructRealTime com = this.allComputers[i];
                if(com.Area.Equals(code))
                {
                    currentComs.Add(com);
                }
                else if(!areas.Contains(com.Area))      //不包含
                {
                    otherComs.Add(com);
                }
            }
        }
        #endregion

        #region 修改总电脑数组code
        public void UpdateComputersCode(Dictionary<int, StructRealTime> dict)
        {
            //添加到所有字典
            foreach (StructRealTime com in dict.Values)
            {
                if(this.changeComDict.ContainsKey(com.Computerid))
                {
                    this.changeComDict.Remove(com.Computerid);
                }
                this.changeComDict.Add(com.Computerid, com);
            }
            for(int i = 0;i<this.allComputers.Count;i++)
            {
                StructRealTime com = this.allComputers[i];
                StructRealTime changeCom = null;
                this.changeComDict.TryGetValue(com.Computerid, out changeCom);
                if(changeCom != null)
                {
                    //修改电脑
                    if (!com.Area.Equals(changeCom.Area) ||!com.Computer.Equals(changeCom.Computer) )
                    {
                        this.allComputers[i] = changeCom;
                    }
                }
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
            this.changeComDict.Clear(); 
            HomePageMessageManage.Manage().UpdateHomePageComputerArea(this.allComputers);
        }
        #endregion

        #region 修改区域信息成功-更新首页区域数据
        public void ChangeAreaUpateHomePageComputerArea()
        {
            HomePageMessageManage.Manage().ChangeAreaUpdateComputerArea();
        }
        #endregion
    }
}
