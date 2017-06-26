using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Tools
{
    class SysManage
    {
        //单例类
        private static SysManage _manage = null;

        #region delegate
        public delegate void ResultHandle();
        public event ResultHandle resultEvent;
        ////获取会员类型代理
        //public delegate void GetMemberTypesHandle(List<StructDictItem> types);
        //public event GetMemberTypesHandle GetMemberTypesEvent;

        ////获取商品类型代理
        //public delegate void GetProductTypesHandle(List<StructDictItem> types);
        //public event GetProductTypesHandle GetProductTypesEvent;
        ////获取区域的代理
        //public delegate void GetAreasHandle(List<StructDictItem> types);
        //public event GetAreasHandle GetAreasEvent;

        #endregion

        //首页所有电脑
        public List<StructRealTime> computers = new List<StructRealTime>();
        //区域数组
        private List<StructDictItem> areas;
        //区域字典
        private Dictionary<string, StructDictItem> areaDict = new Dictionary<string, StructDictItem>();
        
        //商品类型
        private List<StructDictItem> productTypes;
        //商品字典
        private Dictionary<int, StructDictItem> productDict = new Dictionary<int, StructDictItem>();
       
        //会员类型
        private List<StructDictItem> memberTypes;
        //会员字典     
        private Dictionary<int, StructDictItem> memberDict = new Dictionary<int, StructDictItem>(); 

        //单例
        public static SysManage Manage()
        {
            if(_manage == null)
            {
                _manage = new SysManage();
            }
            return _manage;
        }

        #region 获取应提前知道的信息（会员类型。区域。商品类型）

        //获取系统信息（会员类型，区域,商品类型）
        public void RequestSysInfo()
        {
            GetAreaList();
            GetProductTypes();
            GetMemberLvList();
        }
        #endregion
        public void UpdateHomePageComputers(IList<StructRealTime> tem)
        {
            this.computers = tem.ToList<StructRealTime>();

        }
        #region 会员等级功能
        //获取会员等级列表
        private void GetMemberLvList(){
            SystemManageNetOperation.GetMemberLvSetting(GetMemberLvSettingResult);
        }
        //获取会员等级设置的结果回调
        private void GetMemberLvSettingResult(ResultModel result)
        {
            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.lvParent))
            {

                NetMessageManage.Manager().RemoveResultBlock(GetMemberLvSettingResult);
                //System.Console.WriteLine("GetMemberLvSettingResult:" + result.pack);
                System.Console.WriteLine("获取会员等级信息");
                if (result.pack.Content.MessageType == 1)
                {
                    this.memberTypes = result.pack.Content.ScSysInfo.ChildList.ToList<StructDictItem>();
                    this.memberDict.Clear();
                    foreach (StructDictItem item in this.memberTypes)
                    {
                        memberDict.Add(item.Id, item);
                    }


                }

            }
           
        }
        //更新会员数据（会员等级设定使用）
        public void UpdateMemberTypeData(IList<StructDictItem> newMemberTypes)
        {

            this.memberTypes = newMemberTypes.ToList<StructDictItem>();
            memberDict.Clear();
            foreach (StructDictItem item in this.memberTypes)
            {
                memberDict.Add(item.Id, item);
            }
        }
        //获取会员类型名称
        public string GetMemberTypeName(int id)
        {

            StructDictItem item;
            this.memberDict.TryGetValue(id, out item);
            if (item == null)
            {
                return "该会员等级已移除";
            }
            else
            {
                return item.GetItem(0);
            }
        }
        //获取会员类型
        public void GetMembersTypes(out List<StructDictItem>items)
        {
            //如果存在应该直接返回
            if(this.memberTypes != null)
            {
                items = this.memberTypes.ToList<StructDictItem>();
            }
            else
            {
                items = new List<StructDictItem>();
            }
        }
        #endregion

        #region 区域功能
        //获取区域列表
        private void GetAreaList()
        {
            SystemManageNetOperation.GetAreaList(GetAreaListResult);

        }
        //获取区域列表的结果回调
        private void GetAreaListResult(ResultModel result)
        {
           
            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.areaParent))
            {

                NetMessageManage.Manager().RemoveResultBlock(GetAreaListResult);
                //System.Console.WriteLine("GetAreaList:" + result.pack);
                System.Console.WriteLine("获取区域信息");
                if (result.pack.Content.MessageType == 1)
                {
                    this.areas = result.pack.Content.ScSysInfo.ChildList.ToList<StructDictItem>();
                    areaDict.Clear();
                    foreach (StructDictItem item in this.areas)
                    {
                        areaDict.Add(item.Code.ToString(), item);
                    }
                }


            }

            
        

        }
        //获取区域名称
        public string GetAreaName(string code)
        {
            StructDictItem item = null;
            this.areaDict.TryGetValue(code, out item);
            if(item == null)
            {
                return "未标注区域";
            }
            else
            {
                return item.GetItem(0);
            }
        }
        //获取区域列表
        public void GetAreasList(out List<StructDictItem>items)
        {
            //如果存在应该直接返回
            if (this.areas != null)
            {
                items = this.areas;
            }
            else
            {
                items = new List<StructDictItem>();
            }
        }

        // 更新区域数据
        public void UpdateAreaData(IList<StructDictItem> items)
        {
            this.areas = items.ToList<StructDictItem>();
            this.areaDict.Clear();
            foreach (StructDictItem item in this.areas)
            {
                areaDict.Add(item.Code.ToString(), item);
            }
        }
        #endregion

        #region 商品类别的处理
        //获取商品类别列表
        private void GetProductTypes()
        {
            SystemManageNetOperation.ProductTypeInfo(ProductTypeInfoResult);
        }
        //获取商品类型结果回调
        private void ProductTypeInfoResult(ResultModel result)
        {
            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.productTypeParent))
            {
                //System.Console.WriteLine("ProductTypeInfoResult:" + result.pack);
                NetMessageManage.Manager().RemoveResultBlock(ProductTypeInfoResult);
                System.Console.WriteLine("获取商品类别信息");
                if (result.pack.Content.MessageType == 1)
                {
                    this.productTypes = result.pack.Content.ScSysInfo.ChildList.ToList<StructDictItem>();
                    productDict.Clear();
                    foreach (StructDictItem item in this.productTypes)
                    {
                        productDict.Add(item.Id, item);
                    }

                }
            }
          
        }
        //更新商品类别
        public void UpdateProductData(IList<StructDictItem> newProductTypes)
        {

            this.productTypes = newProductTypes.ToList<StructDictItem>();
            productDict.Clear();
            foreach (StructDictItem item in this.productTypes)
            {
                productDict.Add(item.Id, item);
            }
        }
        
        // 获取产品类型名称
        public string GetProductTypeName(int id)
        {

            StructDictItem item;
            this.productDict.TryGetValue(id, out item);

            if(item == null)
            {
                return "该类型已移除";
            }else
            {
                return item.GetItem(0);
            }


        }
        
        // 获取产品的类型
        public void GetProductTypes(out List<StructDictItem> items)
        {
            if(this.productTypes != null)
            {
                items = this.productTypes;
            }
            else
            {
                items = new List<StructDictItem>();

            }
        }
        #endregion

        //#region 移除结果回调
        ////移除商品类别的结果回调
        //public void RemoveProductTypesResult(GetProductTypesHandle handle)
        //{
        //    this.GetProductTypesEvent -= handle;
        //}
        ////移除会员类型的结果回调
        //public void RemoveMemberTypesResult(GetMemberTypesHandle handle)
        //{
        //    this.GetMemberTypesEvent -= handle;
        //}
        ////移除区域的结果回调
        //public void RemoveAreasResult(GetAreasHandle handle)
        //{
        //    this.GetAreasEvent -= handle;
        //}
        //#endregion

    }
}
