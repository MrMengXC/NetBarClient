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

namespace NetBarMS.Views.OtherMain
{
    public partial class JXInspectView : RootUserControlView
    {
        private enum TitleList
        {
            None,

            StaffName = 0,              //员工姓名
            StaffRole,                    //员工角色
            WorkDuration,                //上班时长
            RechargeMoney,                   //充值金额
            SellMoney,                   //销售金额
            SfDegree,               //满意程度
         
        }

      
        private IList<StructPerform> performs;
        public JXInspectView()
        {
            InitializeComponent();
            InitUI();
        }
       

        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.JXInspect, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            GetJXList();
        }
        //获取绩效数据列表
        private void GetJXList()
        {
            int year, month;
            this.customMonthDate1.GetCurrentTimeDur(out year, out month);
            OtherMainNetOperation.GetJXList(GetJXListResult, year, month);
        }
        //获取绩效数据列表结果回调
        private void GetJXListResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_STAFF_PERFORM)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(GetJXListResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    this.performs = result.pack.Content.ScStaffPerform.PerformsList;
                    RefreshGridControl();
                }));
            }
            else
            {
                System.Console.WriteLine("GetJXListResult:" + result.pack);
            }

        }
        #region 刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            foreach (StructPerform perform in this.performs)
            {
                AddNewRow(perform);
            }
        }

        //获取新行
        private void AddNewRow(StructPerform perform)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.StaffName.ToString()] = perform.Name;
            row[TitleList.StaffRole.ToString()] = perform.Role;
            row[TitleList.WorkDuration.ToString()] = perform.Hours;
            row[TitleList.RechargeMoney.ToString()] = perform.Charge;
            row[TitleList.SellMoney.ToString()] = perform.Sales;
            row[TitleList.SfDegree.ToString()] = perform.Satisfy;
       
        }
        #endregion

        #region 关闭日期
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //进行查询
            GetJXList();
        }
        #endregion
    }
}
