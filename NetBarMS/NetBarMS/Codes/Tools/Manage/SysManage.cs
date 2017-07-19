using NetBarMS.Codes.Model;
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
        #region Property
        //单例类
        private static SysManage _manage = null;
        //获取请求信息结果
        private event DataResultBlock RequestSysEvent;

        //区域数组
        private List<AreaTypeModel> areas = new List<AreaTypeModel>();
        //区域字典
        private Dictionary<string, AreaTypeModel> areaDict = new Dictionary<string, AreaTypeModel>();

        //商品类型
        private List<ProductTypeModel> productTypes = new List<ProductTypeModel>();
        //商品字典
        private Dictionary<int, ProductTypeModel> productDict = new Dictionary<int, ProductTypeModel>();
       
        //会员类型
        private List<MemberTypeModel> memberTypes = new List<MemberTypeModel>();
        //会员字典 code
        private Dictionary<int, MemberTypeModel> memberDict = new Dictionary<int, MemberTypeModel>();

        //管理员类型
        private List<StructRole> managers = new List<StructRole>();
        //管理员字典     
        private Dictionary<string, StructRole> managerDict = new Dictionary<string, StructRole>();

        //员工列表
        private List<StructAccount> staffs = new List<StructAccount>();
        //员工字典     
        private Dictionary<string, StructAccount> staffDict = new Dictionary<string, StructAccount>();


        #endregion

        #region 单例
        private static SysManage Manage()
        {
            if(_manage == null)
            {
                _manage = new SysManage();
            }
            return _manage;
        }
        #endregion

        #region 获取应提前知道的信息（会员类型。区域。商品类型）

        //获取系统信息（会员类型，区域,商品类型）
        public static void RequestSysInfo(DataResultBlock result)
        {
            SysManage.Manage().RequestSysEvent += result;
            SysManage.Manage().GetAreaList();
            SysManage.Manage().GetProductTypes();
            SysManage.Manage().GetMemberLvList();
            SysManage.Manage().GetManagerList();
            SysManage.Manage().GetStaffList();
        }
        #endregion

        #region 移除请求系统信息
        public static void RemoveRequestSysInfo(DataResultBlock result)
        {
            SysManage.Manage().RequestSysEvent -= result;
        }
        #endregion

        #region 会员等级功能
        //获取会员等级列表
        private void GetMemberLvList(){
            SystemManageNetOperation.GetMemberLvSetting(GetMemberLvSettingResult);
        }
        //获取会员等级设置的结果回调
        private void GetMemberLvSettingResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_SYS_INFO || !result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.lvParent))
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(GetMemberLvSettingResult);
           // System.Console.WriteLine("GetMemberLvSettingResult:" + result.pack);
            System.Console.WriteLine("获取会员等级信息");
            if (result.pack.Content.MessageType == 1)
            {

                this.memberTypes.Clear();
                this.memberDict.Clear();

                foreach (StructDictItem item in result.pack.Content.ScSysInfo.ChildList)
                {
                    MemberTypeModel model = new MemberTypeModel(item);
                    this.memberDict.Add(item.Code, model);
                    this.memberTypes.Add(model);
                }
                if (RequestSysEvent != null)
                {
                    this.RequestSysEvent(result);
                }

            }

        }
        //更新会员数据（会员等级设定使用）
        public static void UpdateMemberTypeData(IList<StructDictItem> newMemberTypes)
        {

            SysManage.Manage().memberTypes.Clear();
            SysManage.Manage().memberDict.Clear();

            foreach (StructDictItem item in newMemberTypes)
            {
                MemberTypeModel model = new MemberTypeModel(item);
                SysManage.Manage().memberDict.Add(item.Code, model);
                SysManage.Manage().memberTypes.Add(model);
            }
        }
        //获取会员类型名称
        public static string GetMemberTypeName(string temId)
        {
            try
            {
                int id = int.Parse(temId);
                MemberTypeModel model;
                SysManage.Manage().memberDict.TryGetValue(id, out model);
                if (model == null)
                {
                    //if(id == IdTools.TEM_MEMBER_ID)
                    //{
                    //    return "临时会员";
                    //}
                    return "该会员等级已移除";
                }
                else
                {
                    return model.typeName;
                }
            }
            catch (Exception exc)
            {
                return "";
            }
           
        }
        //获取会员类型
        public static List<MemberTypeModel> MemberTypes
        {
            get
            {
                //如果存在应该直接返回
                if (SysManage.Manage().memberTypes != null)
                {
                    return SysManage.Manage().memberTypes.ToList<MemberTypeModel>();
                }
                else
                {
                    return new List<MemberTypeModel>();
                }
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

                NetMessageManage.RemoveResultBlock(GetAreaListResult);
                //System.Console.WriteLine("GetAreaList:" + result.pack);
                System.Console.WriteLine("获取区域信息");
                if (result.pack.Content.MessageType == 1)
                {
                    this.areas.Clear();
                    this.areaDict.Clear();
                    foreach (StructDictItem item in result.pack.Content.ScSysInfo.ChildList)
                    {
                        AreaTypeModel model = new AreaTypeModel(item);
                        areaDict.Add(item.Code.ToString(), model);
                        this.areas.Add(model);
                    }
                    if (RequestSysEvent != null)
                    {
                        this.RequestSysEvent(result);
                    }
                }


            }

            
        

        }
        //获取区域名称
        public static string GetAreaName(string code)
        {
            AreaTypeModel item = null;
            SysManage.Manage().areaDict.TryGetValue(code, out item);
            if(item == null)
            {
                return "未标注区域";
            }
            else
            {
                return item.areaName;
            }
        }
        //获取区域列表
        public static List<AreaTypeModel> Areas
        {
            get
            {
                //如果存在应该直接返回
                if (SysManage.Manage().areas != null)
                {
                    return SysManage.Manage().areas.ToList<AreaTypeModel>();
                }
                else
                {
                    return new List<AreaTypeModel>();
                }
            }
           
        }

        // 更新区域数据
        public static void UpdateAreaData(IList<StructDictItem> items)
        {
            SysManage.Manage().areas.Clear();
            SysManage.Manage().areaDict.Clear();

            foreach (StructDictItem item in items)
            {
                AreaTypeModel model = new AreaTypeModel(item);
                SysManage.Manage().areaDict.Add(item.Code.ToString(), model);
                SysManage.Manage().areas.Add(model);
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
            if (result.pack.Cmd != Cmd.CMD_SYS_INFO || !result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.productTypeParent))
            {
                return;
            }

            //System.Console.WriteLine("ProductTypeInfoResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(ProductTypeInfoResult);
            System.Console.WriteLine("获取商品类别信息");
            if (result.pack.Content.MessageType == 1)
            {
                this.productTypes.Clear();
                this.productDict.Clear();
                foreach (StructDictItem item in result.pack.Content.ScSysInfo.ChildList)
                {
                    ProductTypeModel model = new ProductTypeModel(item);
                    this.productTypes.Add(model);
                    productDict.Add(item.Code, model);
                }
                if (RequestSysEvent != null)
                {
                    this.RequestSysEvent(result);
                }

            }
        }
        //更新商品类别
        public static void UpdateProductData(IList<StructDictItem> newProductTypes)
        {

            SysManage.Manage().productTypes.Clear();
            SysManage.Manage().productDict.Clear();

            foreach (StructDictItem item in newProductTypes)
            {
                ProductTypeModel model = new ProductTypeModel(item);
                SysManage.Manage().productTypes.Add(model);
                SysManage.Manage().productDict.Add(item.Code, model);
            }
        }
        
        // 获取产品类型名称
        public static string GetProductTypeName(int code)
        {

            ProductTypeModel item;
            SysManage.Manage().productDict.TryGetValue(code, out item);

            if(item == null)
            {
                return "该类型已移除";
            }else
            {
                return item.typeName;
            }


        }
        
        // 获取产品的类型
        public static List<ProductTypeModel> ProductTypes
        {
            get
            {
                if (SysManage.Manage().productTypes != null)
                {
                    return SysManage.Manage().productTypes.ToList<ProductTypeModel>();
                }
                else
                {
                    return new List<ProductTypeModel>();

                }
            }
           
        }
        #endregion

        #region 管理员类别功能
        //获取管理员列表
        private void GetManagerList()
        {
            ManagerNetOperation.GetManagerList(GetManagerListResult);
        }
        //获取管理员列表结果回调
        private void GetManagerListResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_ROLE_LIST)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetManagerListResult);
            //System.Console.WriteLine("GetManagerListResult:" + result.pack);
            System.Console.WriteLine("获取管理员");

            if (result.pack.Content.MessageType == 1)
            {

                this.managers = result.pack.Content.ScRoleList.RolesList.ToList<StructRole>();
                this.managerDict.Clear();
                foreach (StructRole role in this.managers)
                {
                    managerDict.Add(role.Roleid, role);
                }
                if (RequestSysEvent != null)
                {
                    this.RequestSysEvent(result);
                }

            }
        }
       
        //更新管理员数据（管理员管理界面使用）
        public static void UpdateManagerData(IList<StructRole> temmanagers)
        {

            SysManage.Manage().managers.Clear();
            SysManage.Manage().managerDict.Clear();

            foreach (StructRole role in temmanagers)
            {
                SysManage.Manage().managerDict.Add(role.Roleid, role);
                SysManage.Manage().managers.Add(role);
            }
        }
        //获取管理员名称
        public static string GetManagerName(string id)
        {

            StructRole role;
            SysManage.Manage().managerDict.TryGetValue(id, out role);
            if (role == null)
            {
                return "该管理员角色已移除";
            }
            else
            {
                return role.Name;
            }
        }
        //获取管理员数据
        public static List<StructRole> Managers
        {
            get
            {
                //如果存在应该直接返回
                if (SysManage.Manage().managers != null)
                {
                    return SysManage.Manage().managers.ToList<StructRole>();
                }
                else
                {
                    return new List<StructRole>();
                }
            }
           
        }
        #endregion

        #region 员工列表
        //获取员工列表
        private void GetStaffList()
        {
            StaffNetOperation.GetStaffList(GetStaffListResult);
        }

        //获取员工列表结果回调
        private void GetStaffListResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_STAFF_LIST)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetStaffListResult);
           System.Console.WriteLine("GetStaffListResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                System.Console.WriteLine("获取员工列表");

                this.staffs = result.pack.Content.ScAccountList.AccountList.ToList<StructAccount>();
                this.staffDict.Clear();
                foreach (StructAccount staff in this.staffs)
                {
                    staffDict.Add(staff.Guid, staff);
                }
                if (RequestSysEvent != null)
                {
                    this.RequestSysEvent(result);
                }
            }
            else
            {
                System.Console.WriteLine("GetStaffListResult:" + result.pack);
            }
        }
       

        //更新员工数据（修改短信推送，修改员工信息）
        public static void UpdateStaffData(IList<StructAccount> tem)
        {

            SysManage.Manage().staffs.Clear();
            SysManage.Manage().staffDict.Clear();

            foreach (StructAccount staff in tem)
            {
                SysManage.Manage().staffDict.Add(staff.Guid, staff);
                SysManage.Manage().staffs.Add(staff);
            }
        }
        //获取员工姓名
        public static string GetStaffName(string id)
        {

            StructAccount staff;
            SysManage.Manage().staffDict.TryGetValue(id, out staff);
            if (staff == null)
            {
                return "该员工已移除";
            }
            else
            {
                return staff.Nickname;
            }
        }
        //获取员工数据
        public static List<StructAccount> Staffs
        {
            get
            {
                //如果存在应该直接返回
                if (SysManage.Manage().staffs != null)
                {
                    return SysManage.Manage().staffs.ToList<StructAccount>();
                }
                else
                {
                    return new List<StructAccount>();
                }
            }
           
        }
        #endregion
    }
}
