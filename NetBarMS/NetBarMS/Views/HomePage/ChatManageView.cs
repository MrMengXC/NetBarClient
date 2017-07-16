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
using NetBarMS.Codes.Tools.Manage;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

namespace NetBarMS.Views.HomePage
{
    public partial class ChatManageView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,
            Check,
            Name,
            Card,
            Ip,
        }
        public ChatManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "聊天管理";
            InitUI();
        }
        private List<StructRealTime> onlines;
        private Int32 pageBegin = 0, pageSize = 15;

        #region 初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ChatManage, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            //监听勾选
            GridColumn column = this.gridView1.Columns[TitleList.Check.ToString()];
            RepositoryItemCheckEdit edit = (RepositoryItemCheckEdit)column.ColumnEdit;
        
            edit.CheckedChanged += Edit_CheckedChanged;
            GetOnLineList();
        }
        //监听勾选
        private void Edit_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox1.Checked = false;
        }
        #endregion

        #region 获取锁定的会员列表
        private void GetOnLineList()
        {
            HomePageMessageManage.GetStatusComputers(out onlines,COMPUTERSTATUS.在线);
            RefreshGridControl();

        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Rows.Clear();
            foreach (StructRealTime com in this.onlines)
            {
                AddNewRow(com);
            }

        }

        
        //添加新行
        private void AddNewRow(StructRealTime com)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            //row[TitleList.Check.ToString()] = "";
            row[TitleList.Name.ToString()] = com.Name;
            row[TitleList.Card.ToString()] = com.Cardnumber;
            row[TitleList.Ip.ToString()] = com.Ip;
            row[TitleList.Check.ToString()] = this.checkBox1.Checked;



        }
        #endregion

        #region 发送
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string msg = this.textBox1.Text;
            List<string> pars = new List<string>();

            if (this.checkBox1.Checked)
            {
                pars.Add(msg);
                HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.NOTIFYALL, pars);
            }
            else
            {
                //TODO：判断是否是群发
                for (int i = 0; i < this.mainDataTable.Rows.Count; i++)
                {
                    StructRealTime com = this.onlines[i];
                    DataRow row = this.mainDataTable.Rows[i];

                    if (row[TitleList.Check.ToString()].ToString().Equals("True"))
                    {
                        pars.Add(com.Cardnumber);
                    }
                }
                if (pars.Count > 0)
                {
                    pars.Add(msg);
                    HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.NOTIFY, pars);
                }
            }

        }
        //发送消息的结果回调
        private void ManagerCommandOperationResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_COMMAND)
            {
                return;
            }
            System.Console.WriteLine("ManagerCommandOperationResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(ManagerCommandOperationResult);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {
                    MessageBox.Show("发送成功");
                }));
            }
        }

      
        #endregion

        #region 进行全选
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (this.checkBox1.Checked)
            {
                // this.gridView1.Columns[TitleList.Check.ToString()];
                foreach (DataRow row in this.mainDataTable.Rows)
                {
                    row[TitleList.Check.ToString()] = true;
                }
            }
            else
            {

            }




        }
        #endregion

        #region 进行关键字搜索过滤
        private void SearchButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            //获取所有在线设备
            HomePageMessageManage.GetStatusComputers(out onlines, COMPUTERSTATUS.在线);
            if (!this.buttonEdit1.Text.Equals(buttonEdit1.Properties.NullText))
            {
                string key = this.buttonEdit1.Text;

                //进行过滤
                this.onlines = this.onlines.Where(com => com.Ip.Contains(key) || com.Computer.Contains(key) || com.Mac.Contains(key)).ToList<StructRealTime>();

            }
            RefreshGridControl();
        }
        #endregion
    }
}
