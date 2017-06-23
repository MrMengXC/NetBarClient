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

namespace NetBarMS.Views.OtherMain
{
    public partial class JXInspectView : RootUserControlView
    {
        enum TitleList
        {
            None,

            StaffName = 0,              //员工姓名
            StaffRole,                    //员工角色
            WorkDuration,                //上班时长
            RechargeMoney,                   //充值金额
            SellMoney,                   //销售金额
            SfDegree,               //满意程度
         
        }
        public JXInspectView()
        {
            InitializeComponent();
            this.titleLabel.Text = "绩效考核";
            AddData();
        }
        /// <summary>
        /// 添加ListView数据
        /// </summary>
        private void AddData()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.JXInspect, out this.mainDataTable);
            //DataRow row = this.mainDataTable.NewRow();
            //this.mainDataTable.Rows.Add(row);
            //row["column_0"] = "dasdasd";
            this.gridControl1.DataSource = this.mainDataTable;

        }
    }
}
