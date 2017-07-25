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


namespace NetBarMS.Views.EvaluateManage
{
    public partial class NetBarEvaluateView : RootUserControlView
    {
        private enum TitleList
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

        private string startTime = "", endTime = "";
        private DateTime lastDate = DateTime.MinValue;
        private int pagebegin = 0, pageSize = 15;
        private IList<StructComment> comments;

        public NetBarEvaluateView()
        {
            InitializeComponent();
            InitUI();

        }
     
        //初始化UI
        private void InitUI()
        {
        
            ToolsManage.SetGridView(this.gridView1, GridControlType.NetBarEvaluate, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;

            GetNetBarEvaluateList();
        }

        //获取网吧评价列表
        private void GetNetBarEvaluateList()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pagebegin,
                Pagesize = this.pageSize,
                Fieldname = 0,
                Order = 0
            };

            string member = this.buttonEdit1.Text;
            EvaluateNetOperation.GetNetBarEvaluateList(GetNetBarEvaluateListResult, page.Build(), startTime, endTime, member);
        }
        //获取网吧评价列表结果回调
        private void GetNetBarEvaluateListResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_STAFF_COMMENT)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetNetBarEvaluateListResult);
            System.Console.WriteLine("GetNetBarEvaluateListResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {

                    this.comments = result.pack.Content.ScStaffComment.CommentsList;
                    RefreshGridControl();

                }));
            }


        }
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            foreach (StructComment com in this.comments)
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
            row[TitleList.EnvironmentScore.ToString()] = com.Environment;
            row[TitleList.SeverScore.ToString()] = com.Service;
            row[TitleList.HardwareScore.ToString()] = com.Device;
            row[TitleList.UserMsg.ToString()] = com.Detail;

        }

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
            //System.Console.WriteLine("start:"+startTime +"end:"+endTime);
            if(!this.startTime.Equals("") && !this.endTime.Equals(""))
            {
                this.popupContainerEdit1.Text = string.Format("{0}-{1}", this.startTime, this.endTime);
            }
            this.GetNetBarEvaluateList();

        }
        #endregion

        //进行搜索点击
        private void ButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            this.GetNetBarEvaluateList();
        }
    }
}
