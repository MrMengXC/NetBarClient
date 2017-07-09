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
using DevExpress.XtraEditors.Controls;
using NetBarMS.Codes.Tools.NetOperation;

namespace NetBarMS.Views.HomePage
{
    public partial class CallServiceView : RootUserControlView
    {
        enum TitleList
        {
            None = 0,
            Number,                      //序号
            Name,                     //呼叫人
            Area,                           //设备编号
            Message,                     //呼叫事项
            Operation,                      //操作
        }

        private IList<StructCall> calls;
        public CallServiceView()
        {
            InitializeComponent();
            InitUI();
        }
        #region 初始化UI
        private void InitUI()
        {
         
            ToolsManage.SetGridView(this.gridView1, GridControlType.CallService, out this.mainDataTable, ButtonColumn_ButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;
           
            GetCallServerList();

        }
        #endregion

        #region 获取呼叫服务列表
        private void GetCallServerList()
        {
            HomePageNetOperation.GetCallList(GetCallListResult);
        }
        //获取呼叫列表
        private void GetCallListResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_CALL_LIST)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(GetCallListResult);
            System.Console.WriteLine("GetCallListResult："+result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    this.calls = result.pack.Content.ScCallList.CallsList;
                    RefreshGridControl();
                }));
            }

        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Rows.Clear();
            foreach(StructCall call in this.calls)
            {
                AddNewRow(call);
            }
        }
        //添加新行
        private void AddNewRow(StructCall call)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);

            row[TitleList.Number.ToString()] = this.mainDataTable.Rows.Count;
            row[TitleList.Name.ToString()] = call.Caller;
            row[TitleList.Area.ToString()] = call.Device;
            row[TitleList.Message.ToString()] = call.Info;




        }
        #endregion

        #region 进行解锁某用户
        //按钮列按钮点击
        private void ButtonColumn_ButtonClick(object sender,ButtonPressedEventArgs arg)
        {
            //处理事件
            int row = this.gridView1.FocusedRowHandle;
            StructCall call = this.calls[row];
            HomePageNetOperation.HandleCall(HandleCallResult, call.Callid);


        }
        private void HandleCallResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_CALL_PROCESS)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(HandleCallResult);
            System.Console.WriteLine("HandleCallResult：" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                GetCallServerList();
            }
        }
        #endregion
    }
}
