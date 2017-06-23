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

        //名称
        public string nodeName;


        //子节点
        public List<HomePageNodeModel> childNodes;

    }


}
