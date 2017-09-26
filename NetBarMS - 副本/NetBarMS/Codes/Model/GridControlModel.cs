using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS.Codes.Model
{

   
    class GridControlModel
    {
        public List<ColumnModel> columns;
    }


    class ColumnModel
    {
        public string name;     //名称
        public string field;    //标签
        public string tag;      //发送查询时的tag

        public ColumnType type;     //类型
        public int width = 20;
        public int height = 20;
        public List<string> buttonNames = new List<string>();

    }
}
