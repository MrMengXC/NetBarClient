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
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Views.EvaluateManage
{
    public partial class StaffEvaluateView : RootUserControlView
    {
        private enum TitleList
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

        private string startTime = "", endTime = "";
        private DateTime lastDate = DateTime.MinValue;
        private int pagebegin = 0, pageSize = 15;
        private IList<StructComment> comments;
        private List<StructAccount> staffs;

        public StaffEvaluateView()
        {
            InitializeComponent();
            this.titleLabel.Text = "员工评价";
            InitUI();
        }

        //初始化UI
        private void InitUI()
        {
           
            ToolsManage.SetGridView(this.gridView1, GridControlType.StaffEvaluate, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;
            SysManage.Manage().GetStaffs(out this.staffs);
            //先获取员工列表
            foreach (StructAccount staff in this.staffs)
            {
                this.comboBoxEdit1.Properties.Items.Add(staff.Nickname);
            }
            GetStaffEvaluateList();
        }
        #region 获取员工评价列表
        //获取员工评价列表
        private void GetStaffEvaluateList()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pagebegin,
                Pagesize = this.pageSize,
                Fieldname = 0,
                Order = 0
            };
            string staff = "";
            if(this.comboBoxEdit1.SelectedIndex >= 0)
            {
                staff = this.staffs[this.comboBoxEdit1.SelectedIndex].Nickname;
            }
            string member = this.buttonEdit1.Text;
            EvaluateNetOperation.GetStaffEvaluateList(GetStaffEvaluateListResult,page.Build(),this.startTime,this.endTime,staff,member);
        }
        //获取员工评价列表结果回调
        private void GetStaffEvaluateListResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_STAFF_COMMENT)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(GetStaffEvaluateListResult);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {

                    this.comments = result.pack.Content.ScStaffComment.CommentsList;
                    RefreshGridControl();

                }));
            }
            else
            {
                System.Console.WriteLine("GetStaffEvaluateListResult:" + result.pack);
            }


        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            foreach(StructComment com in this.comments)
            {
                AddNewRow(com);
            }
        }

        //获取新行
        private void AddNewRow(StructComment com)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.ETime.ToString()] = com.Addtime;
            row[TitleList.EPerson.ToString()] = com.Customer;
            row[TitleList.EIdNumber.ToString()] = com.Cardnumber;
            row[TitleList.GiveIntegral.ToString()] = com.Bonus;
            row[TitleList.StaffName.ToString()] = com.Staff;
            row[TitleList.EScore.ToString()] = com.Point;
            row[TitleList.EDetail.ToString()] = com.Detail;
        }
        #endregion

        #region 日期选择
        //日期选择触发
        private void DateNavigator_EditValueChanged(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator1, lastDate, out this.startTime, out this.endTime);
        }

       
        #endregion

        #region 关闭日期
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            //进行查询
            System.Console.WriteLine("start:" + startTime + "end:" + endTime);
            this.GetStaffEvaluateList();


        }
        #endregion

        #region 条件搜索
        //进行搜索点击
        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.GetStaffEvaluateList();
        }
        //进行员工姓名选择
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetStaffEvaluateList();
        }
        #endregion
    }
}
