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
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ChatManage, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            GetOnLineList();
        }
        #region 获取锁定的会员列表
        private void GetOnLineList()
        {
            //for(int i = 0;i<8;i++)
            //{
            //    DataRow row = this.mainDataTable.NewRow();
            //    this.mainDataTable.Rows.Add(row);
            //}
            //return;
            HomePageMessageManage.Manage().GetOnlineComputers(out onlines);
            RefreshGridControl();

        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
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
            row[TitleList.Name.ToString()] = "xxx";
            row[TitleList.Card.ToString()] = com.Cardnumber;
            row[TitleList.Ip.ToString()] = com.Ip;
    

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
                this.Invoke(new UIHandleBlock(delegate
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
    }
}
