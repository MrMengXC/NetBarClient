using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Model
{
    #region 会员类型Model
    /// <summary>
    /// 会员类型model
    /// </summary>
    class MemberTypeModel
    {
        /// <summary>
        /// 类型ID
        /// </summary>
        public int typeId;
        /// <summary>
        /// 会员类型名称
        /// </summary>
        public string typeName;
        /// <summary>
        /// 会员所需金额
        /// </summary>
        public string payMoney;

        public MemberTypeModel(StructDictItem item)
        {
            this.typeId = item.Code;
            this.typeName = item.GetItem(0);
            this.payMoney = item.GetItem(1);

        }
    }
    #endregion

    #region 商品类型Model
    class ProductTypeModel
    {
        /// <summary>
        /// 商品类型ID
        /// </summary>
        public int typeId;
        /// <summary>
        /// 商品类型名称
        /// </summary>
        public string typeName;

        public ProductTypeModel(StructDictItem item)
        {
            this.typeId = item.Code;
            this.typeName = item.GetItem(0);
        }

    }
    #endregion


    #region 区域类型Model
    class AreaTypeModel
    {
        /// <summary>
        /// 区域类型ID
        /// </summary>
        public int areaId;
        /// <summary>
        /// 区域类型名称
        /// </summary>
        public string areaName;

        public AreaTypeModel(StructDictItem item)
        {
            this.areaId = item.Code;
            this.areaName = item.GetItem(0);
        }

    }
    #endregion
}
