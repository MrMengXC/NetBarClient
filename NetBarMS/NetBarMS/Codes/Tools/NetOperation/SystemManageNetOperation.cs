using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Codes.Tools.NetOperation
{
    class SystemManageNetOperation
    {

        //密码设置
        public static string pwParent = "password";
        //会员等级
        public static string lvParent = "right";
        //区域电脑的区域名称
        public static string areaParent = "area";

        //商品类别Parent
        public static string productTypeParent = "category";
        //客户端基本设置
        public static string client = "client";
        //客户端基本设置-欢迎辞
        public static string clientWelcome = "welcome";
        //短信推送
        public static string smspush = "sns";
        
        #region 密码设置更新
        public static void UpdatePwSetting(DataResultBlock resultBlock, StructDictItem child)
        {
            SysNetOperation.UpdateSysInfo(resultBlock, pwParent, child);
        }
        #endregion

        #region 密码设置
        public static void GetPwSetting(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, pwParent);
        }
        #endregion

        #region 会员等级的设置
        #region 会员等级设置更新
        public static void UpdateMemberLvSetting(DataResultBlock resultBlock, StructDictItem child)
        {
            SysNetOperation.UpdateSysInfo(resultBlock, lvParent, child);
        }
        #endregion

        #region 会员等级设置列表
        public static void GetMemberLvSetting(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, lvParent);
        }
        #endregion

        #region 添加会员等级设置
        public static void AddMemberLv(DataResultBlock resultBlock, StructDictItem child)
        {
            SysNetOperation.AddSysInfo(resultBlock, lvParent, child);
        }
        #endregion

        #region 删除会员等级设置
        public static void DeleteMemberLv(DataResultBlock resultBlock, List<string> ids)
        {
            SysNetOperation.DeleteSysInfo(resultBlock, lvParent, ids);
        }
        #endregion

        #endregion

        #region 区域列表的获取
        public static void GetAreaList(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, areaParent);
        }
        #endregion

        #region 添加区域
        public static void AddArea(DataResultBlock resultBlock,StructDictItem item)
        {
            SysNetOperation.AddSysInfo(resultBlock, areaParent, item);
        }
        #endregion

        #region 删除区域区域
        public static void DeleteArea(DataResultBlock resultBlock, List<string>ids)
        {
            SysNetOperation.DeleteSysInfo(resultBlock, areaParent, ids);
        }
        #endregion

        #region 修改区域电脑从属
        public static void UpdateAreaComputer(DataResultBlock resultBlock, CSComputerUpdate update)
        {
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetCsComputerUpdate(update);
            content.SetMessageType(1);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_COMPUTER_UPDATE);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);


        }
        #endregion

        #region 商品类别

        //获取商品类别信息
        public static void ProductTypeInfo(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, productTypeParent);
        }
     
        //添加商品类别信息
        public static void AddProductType(DataResultBlock resultBlock,StructDictItem item)
        {
            SysNetOperation.AddSysInfo(resultBlock, productTypeParent, item);
        }
        
        //修改商品类别信息
        public static void UpdateProductType(DataResultBlock resultBlock, StructDictItem item)
        {
            SysNetOperation.UpdateSysInfo(resultBlock, productTypeParent, item);
        }
        
        //删除商品类别信息
        public static void DeleteProductType(DataResultBlock resultBlock,List<string> ids)
        {
            SysNetOperation.DeleteSysInfo(resultBlock, productTypeParent, ids);
        }
        #endregion

        #region 客户端基本设置
        //获取客户端基本设置信息
        public static void ClientInfo(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, client);
        }

        //修改客户端基本设置信息
        public static void UpdateClient(DataResultBlock resultBlock, StructDictItem item)
        {
            SysNetOperation.UpdateSysInfo(resultBlock,client,item);
        }

        //获取客户端欢迎辞信息
        public static void ClientWecomeInfo(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, clientWelcome);
        }

        //添加客户端欢迎辞信息
        public static void AddClientWecome(DataResultBlock resultBlock, StructDictItem item)
        {
            SysNetOperation.AddSysInfo(resultBlock, clientWelcome, item);
        }
        //删除客户端欢迎辞
        public static void DeleteClientWecome(DataResultBlock resultBlock, List<string>ids)
        {
            SysNetOperation.DeleteSysInfo(resultBlock, clientWelcome, ids);
        }
        #endregion

        #region 短信推送
        //获取短信推送事项
        public static void SmsPushMessageInfo(DataResultBlock resultBlock)
        {
            SysNetOperation.SysInfo(resultBlock, smspush);
        }
        //添加短信推送信息
        public static void AddSmsPushMessage(DataResultBlock resultBlock, StructDictItem item)
        {
            SysNetOperation.AddSysInfo(resultBlock, smspush, item);
        }
        //删除短信推送
        public static void DeleteSmsPushMessage(DataResultBlock resultBlock, List<string> ids)
        {
            SysNetOperation.DeleteSysInfo(resultBlock, smspush, ids);
        }
        //更新短信推送事项
        public static void UpdateSmsPushMessage(DataResultBlock resultBlock, List<StructDictItem> items)
        {
            SysNetOperation.UpdateSysInfo(resultBlock, smspush, items);
        }
        #endregion
    }
}
