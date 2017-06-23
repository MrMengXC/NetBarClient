using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBarMS.Codes.Model
{

    public enum ColumnType
    {
        C_Text = 0,
        C_Button,       //按钮
        C_Check,        //复选框
        C_Custom
    }
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
