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
    public partial class NetBarEvaluateView : RootUserControlView
    {
        enum TitleList
        {
            None,

            ETime = 0,                  //评论时间
            EPerson,                    //评论人
            EIdNumber,                //评论人身份证
            GiveIntegral,                   //赠送积分
            EnvironmentScore,                   //环境分
            SeverScore,               //服务分
            HardwareScore,             //硬件得分
            UserMsg,                    //用户留言

        }
        public NetBarEvaluateView()
        {
            InitializeComponent();
            this.titleLabel.Text = "网吧评价";
            AddData();
        }
        /// <summary>
        /// 添加ListView数据
        /// </summary>
        private void AddData()
        {
        
            ToolsManage.SetGridView(this.gridView1, GridControlType.NetBarEvaluate, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
        }
    }
}
