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
        private DateTime lastDate = DateTime.MinValue;
        private string startTime = "", endTime = "";
        List<StructAccount> staffs;
        List<MemberTypeModel> memberTypes;

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
            SysManage.Manage().GetStaffs(out this.staffs);
            foreach (StructAccount staff in this.staffs)
            {
                this.comboBoxEdit1.Properties.Items.Add(staff.Nickname);
            }
            SysManage.Manage().GetMembersTypes(out this.memberTypes);
            foreach(MemberTypeModel model in this.memberTypes)
            {
                this.comboBoxEdit2.Properties.Items.Add(model.typeName);
            }

            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.OpenMemberRecord, out this.mainDataTable, null, null);
            this.gridControl1.DataSource = this.mainDataTable;
        }
        #endregion

        #region 会员办理记录
        private void OpenMemberRecord()
        {
            //StructPage.Builder page = new StructPage.Builder()
            //{
            //    Pagebegin = 0,
            //    Pagesize = 15,
            //    Order = 1,
            //    Fieldname = 0,
            //};
            //System.Console.WriteLine("start" + startTime + "\nend:" + endTime);
            //StaffNetOperation.GetStaffShiftsRecordList(GetStaffShiftsRecordListResult, page.Build(), startTime, endTime);
        }
        //获取员工交班记录列表
        private void OpenMemberRecordResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SHIFT_FIND)
            {
                return;
            }

            System.Console.WriteLine("OpenMemberRecordResult:" + result.pack);
            NetMessageManage.Manage().RemoveResultBlock(OpenMemberRecordResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate
                {
                    //records = result.pack.Content.ScShiftFind.ShiftsList;
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
            //this.giveTable.Rows.Clear();
            //this.receiveTable.Rows.Clear();
            //foreach (StructShift shift in records)
            //{
            //    AddNewRow(shift);
            //}
        }

        //添加新行
        private void AddNewRow(StructShift shift)
        {
            
        



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


        }
        #endregion
    }
}
