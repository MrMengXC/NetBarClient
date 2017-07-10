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
        public static SysManage Manage()
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
        public void RequestSysInfo(DataResultBlock result)
        {
            this.RequestSysEvent += result;
            GetAreaList();
            GetProductTypes();
            GetMemberLvList();
            GetManagerList();
            GetStaffList();
        }
        #endregion

        #region 移除请求系统信息
        public void RemoveRequestSysInfo(DataResultBlock result)
        {
            this.RequestSysEvent -= result;
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

            NetMessageManage.Manage().RemoveResultBlock(GetMemberLvSettingResult);
            //System.Console.WriteLine("GetMemberLvSettingResult:" + result.pack);
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
        public void UpdateMemberTypeData(IList<StructDictItem> newMemberTypes)
        {

            this.memberTypes.Clear();
            this.memberDict.Clear();

            foreach (StructDictItem item in newMemberTypes)
            {
                MemberTypeModel model = new MemberTypeModel(item);
                this.memberDict.Add(item.Code, model);
                this.memberTypes.Add(model);
            }
        }
        //获取会员类型名称
        public string GetMemberTypeName(string temId)
        {
            try
            {
                int id = int.Parse(temId);
                MemberTypeModel model;
                this.memberDict.TryGetValue(id, out model);
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
        public void GetMembersTypes(out List<MemberTypeModel>items)
        {
            //如果存在应该直接返回
            if(this.memberTypes != null)
            {
                items = this.memberTypes.ToList<MemberTypeModel>();
            }
            else
            {
                items = new List<MemberTypeModel>();
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

                NetMessageManage.Manage().RemoveResultBlock(GetAreaListResult);
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
        public string GetAreaName(string code)
        {
            AreaTypeModel item = null;
            this.areaDict.TryGetValue(code, out item);
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
        public void GetAreasList(out List<AreaTypeModel>items)
        {
            //如果存在应该直接返回
            if (this.areas != null)
            {
                items = this.areas.ToList<AreaTypeModel>();
            }
            else
            {
                items = new List<AreaTypeModel>();
            }
        }

        // 更新区域数据
        public void UpdateAreaData(IList<StructDictItem> items)
        {
            this.areas.Clear();
            this.areaDict.Clear();
            foreach (StructDictItem item in items)
            {
                AreaTypeModel model = new AreaTypeModel(item);
                areaDict.Add(item.Code.ToString(), model);
                this.areas.Add(model);
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
            NetMessageManage.Manage().RemoveResultBlock(ProductTypeInfoResult);
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
        public void UpdateProductData(IList<StructDictItem> newProductTypes)
        {

            this.productTypes.Clear();
            this.productDict.Clear();
            foreach (StructDictItem item in newProductTypes)
            {
                ProductTypeModel model = new ProductTypeModel(item);
                this.productTypes.Add(model);
                productDict.Add(item.Code, model);
            }
        }
        
        // 获取产品类型名称
        public string GetProductTypeName(int code)
        {

            ProductTypeModel item;
            this.productDict.TryGetValue(code, out item);

            if(item == null)
            {
                return "该类型已移除";
            }else
            {
                return item.typeName;
            }


        }
        
        // 获取产品的类型
        public void GetProductTypes(out List<ProductTypeModel> items)
        {
            if(this.productTypes != null)
            {
                items = this.productTypes.ToList<ProductTypeModel>();
            }
            else
            {
                items = new List<ProductTypeModel>();

            }
        }
        #endregion

        #region 管理员类别功能
        //获取管理员列表
        private void GetManagerList()
        {
            ManagerNetOperation.GetManagerList(GetManagerListResult, CurrentStaffManage.Manage().GetCurrentStaffId());
        }
        //获取管理员列表结果回调
        private void GetManagerListResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_ROLE_LIST)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(GetManagerListResult);
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
        public void UpdateManagerData(IList<StructRole> temmanagers)
        {

            this.managers = temmanagers.ToList<StructRole>();

            managerDict.Clear();
            foreach (StructRole role in this.managers)
            {
                managerDict.Add(role.Roleid, role);
            }
        }
        //获取管理员名称
        public string GetManagerName(string id)
        {

            StructRole role;
            this.managerDict.TryGetValue(id, out role);
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
        public void GetManagers(out List<StructRole> items)
        {
            //如果存在应该直接返回
            if (this.managers != null)
            {
                items = this.managers.ToList<StructRole>();
            }
            else
            {
                items = new List<StructRole>();
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
            NetMessageManage.Manage().RemoveResultBlock(GetStaffListResult);
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
        public void UpdateStaffData(IList<StructAccount> tem)
        {

            this.staffs = tem.ToList<StructAccount>();

            this.staffDict.Clear();
            foreach (StructAccount staff in this.staffs)
            {
                this.staffDict.Add(staff.Guid, staff);
            }
        }
        //获取员工姓名
        public string GetStaffName(string id)
        {

            StructAccount staff;
            this.staffDict.TryGetValue(id, out staff);
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
        public void GetStaffs(out List<StructAccount> items)
        {
            //如果存在应该直接返回
            if (this.staffs != null)
            {
                items = this.staffs.ToList<StructAccount>();
            }
            else
            {
                items = new List<StructAccount>();
            }
        }
        #endregion
    }
}
