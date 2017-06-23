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

namespace NetBarMS.Views.EvaluateManage
{
    public partial class StaffEvaluateView : RootUserControlView
    {
        enum TitleList
        {
            None,

            ETime = 0,                  //评论时间
            EPerson,                    //评论人
            EIdNumber,                //评论人身份证
            GiveIntegral,                   //赠送积分
            StaffName,                      //员工姓名
            EScore,                     //评论得分
            EDetail,                    //评价详情

        }
        public StaffEvaluateView()
        {
            InitializeComponent();
            this.titleLabel.Text = "员工评价";
            AddData();
        }

        /// <summary>
        /// 添加ListView数据
        /// </summary>
        private void AddData()
        { 
            ToolsManage.SetGridView(this.gridView1, GridControlType.StaffEvaluate, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
        }
    }
}
