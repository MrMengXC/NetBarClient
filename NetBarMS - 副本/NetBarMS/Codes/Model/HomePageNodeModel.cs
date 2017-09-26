using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Model
{
    /// <summary>
    /// 主页面树节点的Model
    /// </summary>
    class HomePageNodeModel
    {
        //tag
        public string nodeTag = "None";
        /// <summary>
        /// 节点名称
        /// </summary>
        public string nodeName;
        /// <summary>
        /// 节点id
        /// </summary>
        public int nodeid;
        /// <summary>
        /// 图片名称
        /// </summary>
        public string imgName;
        /// <summary>
        /// 选中图片名
        /// </summary>
        public string selName;

        /// <summary>
        /// 子节点数组
        /// </summary>
        public List<HomePageNodeModel> childNodes;

    }


}
