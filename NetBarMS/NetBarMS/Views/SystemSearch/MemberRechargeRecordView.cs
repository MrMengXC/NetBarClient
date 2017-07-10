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
            //PAYCHANNEL_TYPE
            foreach(string name in Enum.GetNames(typeof(PAYCHANNEL)))
            {
                this.comboBoxEdit1.Properties.Items.Add(name);
            }

            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.MemberRechargeRecord, out this.mainDataTable, null, null);
            this.gridControl1.DataSource = this.mainDataTable;
        }
        #endregion


        #region 会员充值记录
        private void MemberRechargeRecord()
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
        private void MemberRechargeRecordResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SHIFT_FIND)
            {
                return;
            }

            System.Console.WriteLine("MemberRechargeRecordResult:" + result.pack);
            NetMessageManage.Manage().RemoveResultBlock(MemberRechargeRecordResult);
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
    }
}
