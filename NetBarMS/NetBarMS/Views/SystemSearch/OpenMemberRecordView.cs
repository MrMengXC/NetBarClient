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
using NetBarMS.Codes.Model;
using NetBarMS.Codes.Tools.NetOperation;

namespace NetBarMS.Views.NetUserManage
{
    public partial class OpenMemberRecordView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,
            MemberName,     //会员姓名
            MemberType,         //会员类型
            IdNumber,           //身份证号
            RechargeMoney,      //充值金额
            GiveMoney,          //赠送金额
            Staff,              //办理人
            OpenTime,           //办理时间
            PayChannel,         //付款渠道
            IndentNumber,       //第三方支付订单号
            Channel,            //办理渠道
        }
        private DateTime lastDate = DateTime.MinValue;
        private string startTime = "", endTime = "";    //搜索的开始时间/结束时间
        private List<StructAccount> staffs;             //员工列表数组
        private List<MemberTypeModel> memberTypes;      //会员类型数组
        private IList<StructApply> records;             //记录列表数组
        private int pageBegin = 0, pageSize = 15;
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
            this.staffs = SysManage.Staffs;
            this.comboBoxEdit1.Properties.Items.Add("无");
            foreach (StructAccount staff in this.staffs)
            {
                this.comboBoxEdit1.Properties.Items.Add(staff.Nickname);
            }

            this.memberTypes = SysManage.MemberTypes;
            this.comboBoxEdit2.Properties.Items.Add("无");
            foreach (MemberTypeModel model in this.memberTypes)
            {
                this.comboBoxEdit2.Properties.Items.Add(model.typeName);
            }

            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.OpenMemberRecord, out this.mainDataTable, null, null);
            this.gridControl1.DataSource = this.mainDataTable;

            GetOpenMemberRecord();
        }
        #endregion

        #region 会员办理记录
        private void GetOpenMemberRecord()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pageBegin,
                Pagesize = this.pageSize,
                Order = 1,
                Fieldname = 0,
            };

            int type = -1;
            string staff = "", name = "";
            if(!this.buttonEdit1.Text.Equals(this.buttonEdit1.Properties.NullText))
            {
                name = this.buttonEdit1.Text;
            }
            if(this.comboBoxEdit2.SelectedIndex > 0)
            {
                type = this.memberTypes[this.comboBoxEdit2.SelectedIndex - 1].typeId;
            }
            if (this.comboBoxEdit1.SelectedIndex > 0)
            {
                staff = this.staffs[this.comboBoxEdit1.SelectedIndex - 1].Nickname;
            }
            RecordNetOperation.GetOpenMemberRecord(GetOpenMemberRecordResult, page.Build(),this.startTime, this.endTime, staff, type, name);

        }
        //获取会员办理记录回调
        private void GetOpenMemberRecordResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_QUERY_APPLY)
            {
                return;
            }

            System.Console.WriteLine("GetOpenMemberRecordResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(GetOpenMemberRecordResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {
                    records = result.pack.Content.ScQueryApply.ApplysList;
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
            foreach (StructApply apply in records)
            {
                AddNewRow(apply);
            }
        }

        //添加新行
        private void AddNewRow(StructApply apply)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.MemberName.ToString()] = apply.Name;
            row[TitleList.MemberType.ToString()] = SysManage.GetMemberTypeName(apply.Rightid.ToString());
            row[TitleList.IdNumber.ToString()] = apply.Cardnumber;
            row[TitleList.RechargeMoney.ToString()] = apply.ChargeAmount;
            row[TitleList.GiveMoney.ToString()] = apply.BonusAmount;
            row[TitleList.Staff.ToString()] = apply.Operator;
            row[TitleList.OpenTime.ToString()] = apply.Addtime;
            row[TitleList.PayChannel.ToString()] = Enum.GetName(typeof(PAYCHANNEL), apply.Paymode);
            row[TitleList.IndentNumber.ToString()] = apply.Receiptid;
            row[TitleList.Channel.ToString()] = Enum.GetName(typeof(MANAGECHANNEL), apply.Applyid);

        }
        #endregion

        #region 日期选择
        //日期选择触发
        private void DateNavigator_Click(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }
        #endregion

        #region 关闭日期选择菜单
        private void ComboBoxEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (!this.startTime.Equals("") && !this.endTime.Equals(""))
            {
                this.popupContainerEdit1.Text = string.Format("{0}-{1}", this.startTime, this.endTime);
            }
            GetOpenMemberRecord();
        }

       
        #endregion

        #region 关键字搜索
        private void SearchButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GetOpenMemberRecord();
        }
        #endregion

        #region 会员类型搜索
        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOpenMemberRecord();

        }
        #endregion

        #region 当班人搜索
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOpenMemberRecord();

        }
        #endregion
    }
}
