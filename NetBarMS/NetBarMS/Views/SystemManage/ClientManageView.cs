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
//using System.Data.SqlClient;
using NetBarMS.Codes.Model;
using DevExpress.XtraGrid.Views.Base;
using NetBarMS.Codes.Tools.NetOperation;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace NetBarMS.Views.SystemManage
{
    public partial class ClientManageView : RootUserControlView
    {
        enum TitleList
        {
            None = 0,
            Wecome,
            Operation
        }

        private StructDictItem clientItem;
        private List<StructDictItem> wecomeitems;

        public ClientManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "客户端设置";
            InitUI();
        }
        #region 初始化UI
        private void InitUI()
        {
            TextEdit[] edits = {
                this.textEdit1,this.textEdit2,this.textEdit3,this.textEdit4,this.textEdit5
            };
            InitTextEdit(edits);

            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.ClientManage,out this.mainDataTable, ColumnButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;

            SystemManageNetOperation.ClientInfo(ClientInfoResult);
            SystemManageNetOperation.ClientWecomeInfo(ClientWecomeInfoResult);

        }
        //刷新客户端基本设置UI
        private void RefreshClientUI()
        {
            //
            this.textEdit1.Text = this.clientItem.GetItem(0);
            this.textEdit2.Text = this.clientItem.GetItem(1);
            this.textEdit3.Text = this.clientItem.GetItem(2);
            this.textEdit4.Text = this.clientItem.GetItem(3);
            this.textEdit5.Text = this.clientItem.GetItem(4);

        }
        //刷新客户端欢迎词UI
        private void RefreshClientWecomeUI()
        {
            this.mainDataTable.Clear();

            foreach(StructDictItem item in this.wecomeitems)
            {
                DataRow row = this.mainDataTable.NewRow();
                this.mainDataTable.Rows.Add(row);
                row[TitleList.Wecome.ToString()] = item.GetItem(0);
            }
        }
        #endregion

        #region 获取结果回调
        //客户端基本设置结果
        private void ClientInfoResult(ResultModel result)
        {
            System.Console.WriteLine("ClientInfoResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.client))
            {
                NetMessageManage.RemoveResultBlock(ClientInfoResult);
                this.Invoke(new RefreshUIHandle(delegate {
                    this.clientItem = result.pack.Content.ScSysInfo.GetChild(0);
                    RefreshClientUI();
                }));

            }
        }
        //客户端欢迎辞结果
        private void ClientWecomeInfoResult(ResultModel result)
        {
            System.Console.WriteLine("ClientWecomeInfoResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.clientWelcome))
            {
                NetMessageManage.RemoveResultBlock(ClientWecomeInfoResult);
                this.Invoke(new RefreshUIHandle(delegate {

                    this.wecomeitems = result.pack.Content.ScSysInfo.ChildList.ToList<StructDictItem>();
                    RefreshClientWecomeUI();

                }));

            }
        }
        #endregion

        #region 保存基本设置信息
        //保存基本设置
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string item1 = this.textEdit1.Text;
            string item2 = this.textEdit2.Text;
            string item3 = this.textEdit3.Text;
            string item4 = this.textEdit4.Text;
            string item5 = this.textEdit5.Text;

            StructDictItem.Builder item = new StructDictItem.Builder(clientItem);
            item.ClearItem();
            item.AddItem(item1);
            item.AddItem(item2);
            item.AddItem(item3);
            item.AddItem(item4);
            item.AddItem(item5);

            this.clientItem = item.Build();
            SystemManageNetOperation.UpdateClient(UpdateClientResult,clientItem);

        }
        //更新客户端基本设置结果回调
        private void UpdateClientResult(ResultModel result)
        {
            System.Console.WriteLine("UpdateClientResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_UPDATE)
            {
                NetMessageManage.RemoveResultBlock(UpdateClientResult);
                this.Invoke(new RefreshUIHandle(delegate
                {
                    MessageBox.Show("设置成功");
                }));

            }
        }
        #endregion

        #region 添加欢迎辞
        //添加欢迎辞
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string wecome = this.textBox1.Text;
            if(wecome.Equals(""))
            {
                return;
            }

            StructDictItem.Builder item = new StructDictItem.Builder();
            item.Id = 0;
            item.Code = 0;
            item.AddItem(wecome);
            SystemManageNetOperation.AddClientWecome(AddClientWecomeResult, item.Build());

        }
        //添加客户端欢迎辞结果回调
        private void AddClientWecomeResult(ResultModel result)
        {
            System.Console.WriteLine("AddClientWecomeResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_ADD)
            {
                NetMessageManage.RemoveResultBlock(AddClientWecomeResult);
                this.Invoke(new RefreshUIHandle(delegate
                {
                    MessageBox.Show("保存成功");
                    SystemManageNetOperation.ClientWecomeInfo(ClientWecomeInfoResult);
                }));

            }
        }
        #endregion

        #region 删除按钮
        //按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            StructDictItem item = wecomeitems[rowhandle];

            String tag = (String)e.Button.Tag;
            String[] param = tag.Split('_');
           
            //使用
            if (param[1].Equals("0"))
            {
             

            }
            //删除
            else if (param[1].Equals("1"))
            {
                List<string> ids = new List<string>()
                {
                    item.Id.ToString(),
                };

                SystemManageNetOperation.DeleteClientWecome(DeletelientWecomeResult,ids);
                //
                this.mainDataTable.Rows.RemoveAt(rowhandle);
                wecomeitems.RemoveAt(rowhandle);
            }
            
        }
        //删除客户端欢迎辞结果回调
        private void DeletelientWecomeResult(ResultModel result)
        {
            System.Console.WriteLine("DeletelientWecomeResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_DEL)
            {
                NetMessageManage.RemoveResultBlock(DeletelientWecomeResult);
                this.Invoke(new RefreshUIHandle(delegate
                {

                    MessageBox.Show("删除成功");


                }));

            }
        }
        #endregion

        protected override void Control_Paint(object sender, PaintEventArgs e)
        {
            base.Control_Paint(sender, e);
        }
    }
}
