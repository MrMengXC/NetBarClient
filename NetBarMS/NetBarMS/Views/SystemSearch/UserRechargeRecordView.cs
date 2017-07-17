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
using NetBarMS.Codes.Tools.NetOperation;
using DevExpress.XtraEditors.Controls;

namespace NetBarMS.Views.SystemSearch
{
    public partial class UserRechargeView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,

            IndentNumber,              //订单号
            MemberName,               //会员姓名
            MemberType,                 //会员类型
            IdNumber,                   //身份证号
            Area,             //区域
            RechargeMoney,              //充值金额
            GiveMoney,           //赠送金额
            AddTime,           //添加时间

            PayChannel,         //付款渠道
            PayIndentNumber,       //第三方支付订单号
            IndentStatus,       //订单状态

        }
        private int pageBeign = 0, pageSize = 15;
        private DateTime lastDate = DateTime.MinValue;
        private string startTime = "", endTime = "";
        private IList<StructCharge> chargeRecords;
        public UserRechargeView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户充值记录查询";
            InitUI();
        }
        #region 初始化UI
        // 初始化UI
        private void InitUI()
        {
            //PAYCHANNEL_TYPE
            foreach(string name in Enum.GetNames(typeof(PAYCHANNEL)))
            {
                this.comboBoxEdit1.Properties.Items.Add(name);
            }
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;

            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.MemberRechargeRecord, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;

          
            GetUserRechargeRecord();
        }
        #endregion

        #region 会员充值记录
        private void GetUserRechargeRecord()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pageBeign,
                Pagesize = this.pageSize,
                Order = 1,
                Fieldname = 0,
            };
            string name = "";
            PAYCHANNEL paychannel = PAYCHANNEL.无;
            Enum.TryParse<PAYCHANNEL>(this.comboBoxEdit1.Text, out paychannel);

            if (!buttonEdit1.Text.Equals(buttonEdit1.Properties.NullText))
            {
                name = buttonEdit1.Text;
            }
            RecordNetOperation.GetUserRechargeRecord(GetUserRechargeRecordResult, page.Build(), this.startTime, this.endTime, (int)paychannel, name);
        }
        //获取会员充值结果反馈
        private void GetUserRechargeRecordResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_QUERY_CHARGE)
            {
                return;
            }

            System.Console.WriteLine("GetUserRechargeRecordResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(GetUserRechargeRecordResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {
                    this.chargeRecords = result.pack.Content.ScQueryCharge.ChargesList;
                    RefreshGridControl();
                }));
            }
            else
            {
            }


        }
        #endregion

        #region 刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Rows.Clear();
           foreach(StructCharge charge in this.chargeRecords)
            {
                AddNewRow(charge);
            }
        }

        //添加新行
        private void AddNewRow(StructCharge charge)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IndentNumber.ToString()] = charge.Productid;
            row[TitleList.MemberName.ToString()] = charge.Name;
            row[TitleList.MemberType.ToString()] = SysManage.GetMemberTypeName(charge.Rightid.ToString());
            row[TitleList.IdNumber.ToString()] = charge.Cardnumber;
            row[TitleList.Area.ToString()] = SysManage.GetAreaName(charge.Areaid.ToString());
            row[TitleList.RechargeMoney.ToString()] = charge.ChargeAmount;
            row[TitleList.GiveMoney.ToString()] = charge.BonusAmount;
            row[TitleList.PayChannel.ToString()] = Enum.GetName(typeof(PAYCHANNEL),charge.Paymode);
            row[TitleList.PayIndentNumber.ToString()] = charge.Receiptid;
            INDENT_FINISH_STATUS status = INDENT_FINISH_STATUS.无;
            Enum.TryParse<INDENT_FINISH_STATUS>(charge.Status.ToString(), out status);
            row[TitleList.IndentStatus.ToString()] = Enum.GetName(typeof(INDENT_FINISH_STATUS),status);
            row[TitleList.AddTime.ToString()] = charge.Addtime;


        }
        #endregion

        #region 过滤条件搜索/日期/用途/付款渠道
        //关闭日期选择菜单
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if(!this.startTime.Equals("") && !this.endTime.Equals(""))
            {
                this.popupContainerEdit1.Text = string.Format("{0}-{1}", this.startTime, this.endTime);
            }
            GetUserRechargeRecord();
        }
        //日期选择触发
        private void DateNavigator_EditValueChanged(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }
        #endregion

        #region 搜索按钮点击
        private void SearchButton_ButtonClick(object sender,ButtonPressedEventArgs args)
        {
            GetUserRechargeRecord();
        }
        #endregion

        #region 选择支付方式
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUserRechargeRecord();
        }
        #endregion
    }
}
