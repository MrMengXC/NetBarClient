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

namespace NetBarMS.Views.NetUserManage
{
    public partial class OpenMemberRecordView : RootUserControlView
    {
        enum TitleList
        {
            None,

            MemberName = 0,              //会员姓名
            MemberType,               //会员类型
            IdNumber,                 //身份证号
            RechargeMoney,                   //充值金额
            GiveMoney,             //赠送金额
            Staff,              //办理人
            OpenTime,           //办理时间
            PayChannel,         //付款渠道
            IndentNumber,       //第三方支付订单号

        }
        public OpenMemberRecordView()
        {
            InitializeComponent();
            this.titleLabel.Text = "会员办理记录";
            InitUI();

        }
        #region 初始化UI
        // 初始化UI
        private void InitUI()
        {
         
            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.OpenMemberRecord, out this.mainDataTable, null, null);
            this.gridControl1.DataSource = this.mainDataTable;
        }
        #endregion

    }
}
