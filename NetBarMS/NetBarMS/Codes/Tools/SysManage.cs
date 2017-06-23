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
        public delegate void ResultHandle();
        public event ResultHandle resultEvent;

        private static SysManage _manage = null;

        //会员类型字典

        //电脑区域字典
        public Dictionary<string, StructDictItem> areaDict = new Dictionary<string, StructDictItem>();
        public List<StructRealTime> computers = new List<StructRealTime>();

        private List<StructDictItem> productTypes;      //商品类型
        private Dictionary<int, StructDictItem> productDict = new Dictionary<int, StructDictItem>(); //商品字典

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
        //获取系统信息（会员类型，区域）
        public void RequestSysInfo(ResultHandle handle)
        {
            if(handle != null)
            {
                this.resultEvent += handle;
            }
            SystemManageNetOperation.GetAreaList(GetAreaListResult);

            //获取商品类型
            SystemManageNetOperation.ProductTypeInfo(ProductTypeInfoResult);

        }
        //获取商品类型结果回调
        private void ProductTypeInfoResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.productTypeParent))
            {
                System.Console.WriteLine("ProductTypeInfoResult:" + result.pack);
                NetMessageManage.Manager().RemoveResultBlock(ProductTypeInfoResult);

                this.productTypes = result.pack.Content.ScSysInfo.ChildList.ToList<StructDictItem>();
                productDict.Clear();
                foreach(StructDictItem item in this.productTypes)
                {
                    productDict.Add(item.Id,item);

                }
            }
        }


        //获取会员等级设置的结果回调
        private void GetAreaListResult(ResultModel result)
        {
            System.Console.WriteLine("GetAreaList:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.areaParent))
            {
                NetMessageManage.Manager().RemoveResultBlock(GetAreaListResult);

                areaDict.Clear();
                IList<StructDictItem> items = result.pack.Content.ScSysInfo.ChildList;
                foreach(StructDictItem item in items)
                {
                    areaDict.Add(item.Code.ToString(), item);
                }
                HomePageNetOperation.HompageList(HomePageListBlock);
            }

        }
       


        // 获取计算机列表结果回调
        private void HomePageListBlock(ResultModel result)
        {

             if (result.pack.Cmd == Cmd.CMD_REALTIME_INFO && result.pack.Content.MessageType == 1)
            {
                System.Console.WriteLine("HomePageListBlock:" + result.pack);
                SCRealtimeInfo info = result.pack.Content.ScRealtimeInfo;
                computers = result.pack.Content.ScRealtimeInfo.RealtimesList.ToList<StructRealTime>();
                if(this.resultEvent != null)
                {
                    this.resultEvent();
                }

            }
        }
        #endregion

        #region 获取区域名称
        public string GetArea(string code)
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
        #endregion

        #region 更新区域数据
        public void UpdateAreaData(IList<StructDictItem> items)
        {
            this.areaDict.Clear();
            foreach (StructDictItem item in items)
            {
                areaDict.Add(item.Code.ToString(), item);
            }
        }
        #endregion

        #region 商品类别的处理

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
        /// <summary>
        /// 获取产品类型名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 获取产品的类型
        /// </summary>
        /// <param name="types"></param>
        public void GetProductTypes(out List<StructDictItem> types)
        {
            if(this.productTypes == null)
            {
                types = null;
            }
            else
            {
                types = this.productTypes;
            }
        }
        #endregion

    }
}
