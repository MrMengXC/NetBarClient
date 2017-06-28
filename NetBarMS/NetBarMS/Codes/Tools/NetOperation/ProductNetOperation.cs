using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Codes.Tools.NetOperation
{
    class ProductNetOperation
    {
        #region 获取商品列表
        public static void GetProductList(DataResultBlock resultBlock, StructPage page,Int32 category,string keywords)
        {

            CSGoodsFind.Builder products = new CSGoodsFind.Builder();
            products.SetPage(page);
            if(category >= 0)
            {
                products.SetCategory(category);
            }
            if(keywords != null)
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

        #region 添加商品
        public static void AddProduct(DataResultBlock resultBlock, StructGoods product)
        {

            CSGoodsAdd.Builder addproduct = new CSGoodsAdd.Builder()
            {
                Goods = product,
            };
           
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsGoodsAdd(addproduct);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_ADD);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);

        }
        #endregion

        #region 删除商品
        public static void DeleteProduct(DataResultBlock resultBlock, List<Int32> ids)
        {

            CSGoodsDel.Builder del = new CSGoodsDel.Builder();
            foreach(Int32 id in ids)
            {
                del.AddIds(id);
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsGoodsDel(del);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_DEL);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);

        }
        #endregion

        #region 更新商品
        public static void UpdateProduct(DataResultBlock resultBlock, StructGoods product)
        {

            CSGoodsUpdate.Builder update = new CSGoodsUpdate.Builder()
            {
                Goods = product,
            };
            
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsGoodsUpdate(update);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_UPDATE);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);

        }
        #endregion

        #region 获取库存清单
        public static void GetStoreList(DataResultBlock resultBlock,StructPage page)
        {

            CSGoodsStock.Builder stock = new CSGoodsStock.Builder()
            {
                Page = page,
            };

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsGoodsStock(stock);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_STOCK);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 获取销售记录清单
        public static void GetSellRecordList(DataResultBlock resultBlock, StructPage page,Int32 id,string start,string end)
        {

            CSSalesRecord.Builder record = new CSSalesRecord.Builder()
            {
                Page = page,
                Goodsid = id
            };
            if(start != null && !start.Equals(""))
            {
                record.SetBegintime(start);
                record.SetEndtime(end);
            }

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsSalesRecord(record);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_SALES);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 获取销售排行
        public static void GetSellRankList(DataResultBlock resultBlock, StructPage page)
        {

            CSSalesTop.Builder top = new CSSalesTop.Builder()
            {
                
            };
           

            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsSalesTop(top);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_SALES_TOP);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 获取系统查询的商品订单
        public static void GetProdcutIndentList(DataResultBlock resultBlock, StructPage page,Int32 status,string addStart,string addEnd,string handleStart,string handleEnd,string keyWrods)
        {
            CSOrderList.Builder order = new CSOrderList.Builder()
            {
                Page = page,
            };
            if(status >0)
            {
                order.Status = status;
            }
            if (addStart!=null && !addStart.Equals(""))
            {
                order.AddtimeStart = addStart;
                order.AddtimeEnd = addEnd;
            }
            if (handleStart != null && !handleStart.Equals(""))
            {
                order.ProctimeStart = handleStart;
                order.ProctimeEnd = handleEnd;
            }
            if(keyWrods != null)
            {
                order.Username = keyWrods;
            }
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsOrderList(order);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_ORDER);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion

        #region 获取商品订单详情
        public static void GetProdcutIndentDetail(DataResultBlock resultBlock,Int32 orderid)
        {

            CSOrderDetail.Builder detail = new CSOrderDetail.Builder()
            {
                Orderid = orderid,
            };
           
            MessageContent.Builder content = new MessageContent.Builder();
            content.SetMessageType(1);
            content.SetCsOrderDetail(detail);

            MessagePack.Builder pack = new MessagePack.Builder();
            pack.SetCmd(Cmd.CMD_GOODS_ORDER_DETAIL);
            pack.SetContent(content);
            NetMessageManage.Manage().SendMsg(pack.Build(), resultBlock);
        }
        #endregion
    }
}
