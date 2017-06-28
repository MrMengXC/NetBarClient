using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Codes.Tools.NetOperation
{
    /// <summary>
    /// 营收网络请求
    /// </summary>
    class IncomeNetOperation
    {

        #region 获取日营收
        public static void GetProductList(DataResultBlock resultBlock, StructPage page, Int32 category, string keywords)
        {

            CSGoodsFind.Builder products = new CSGoodsFind.Builder();
            products.SetPage(page);
            if (category >= 0)
            {
                products.SetCategory(category);
            }
            if (keywords != null)
            {
                products.SetKeywords(keywords);
            }

            System.Console.WriteLine(products); ;
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsGoodsFind(products);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_FIND);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);

        }
        #endregion

    }
}
