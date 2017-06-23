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
    public partial class MemberRechargeView : RootUserControlView
    {
        enum TitleList
        {
            None,

            IndentNumber = 0,              //订单号
            MemberName,               //会员姓名
            MemberType,                 //会员类型
            IdNumber,                   //身份证号
            Area,             //区域
            RechargeMoney,              //充值金额
            GiveMoney,           //赠送金额
            PayChannel,         //付款渠道
            PayIndentNumber,       //第三方支付订单号
            PayIndentState,       //订单状态

        }
        public MemberRechargeView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户充值记录查询";
            InitUI();
        }
        #region 初始化UI
        // 初始化UI
        private void InitUI()
        {
            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.MemberRechargeRecord, out this.mainDataTable, null, null);
            this.gridControl1.DataSource = this.mainDataTable;
        }
        #endregion
    }
}
