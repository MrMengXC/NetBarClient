using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools;

namespace NetBarMS.Views.HomePage
{
    public partial class CallServiceView : RootUserControlView
    {
        enum TitleList
        {
            None,
            Number = 0,                      //序号
            CallPerson,                     //呼叫人
            Area,                           //设备编号
            CallMatter,                     //呼叫事项
            Staff,                          //值班人
            Operation,                      //操作
        }
        public CallServiceView()
        {
            InitializeComponent();
            InitUI();
        }
       //呼叫服务
        private void InitUI()
        {
         
            ToolsManage.SetGridView(this.gridView1, GridControlType.CallService, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;

        }

    }
}
