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
using static NetBarMS.Codes.Tools.NetMessageManage;
using DevExpress.XtraEditors;

namespace NetBarMS.Views.SystemManage
{
    public partial class SmsManageView : RootUserControlView
    {
        enum TitleList
        {
            None,
            Check = 0 ,                  //勾选
            Staff,                     //员工姓名
            TelNumber,                 //手机号码
        }
        private List<StructDictItem> oriPushItems;         //原版Push
        private List<StructDictItem> showPushItems;        //这是显示版

        private List<StructAccount> oriStaffs;             //原版员工
        private List<StructAccount> showStaffs;            //显示版员工

        private SimpleButton selectPush = null;                //当前选择的区域

        public SmsManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "短信设置";
            InitUI();
        }

        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.SmsManage, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;

            this.pushFlowLayoutPanel.AutoSize = true;
            this.pushFlowLayoutPanel.MaximumSize = new Size(MaximumSize.Width, this.pushBgPanel.Size.Height - this.addPushButton.Size.Height);
            GetPushMessageList();
            GetStaffList();
        }
        #endregion

        #region 获取员工列表
        //获取员工列表
        private void GetStaffList()
        {
            StaffNetOperation.GetStaffList(GetStaffListResult);
        }
        //获取员工列表列表的结果回调
        private void GetStaffListResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_ADMIN_LIST)
            {
                System.Console.WriteLine("GetStaffListResult:" + result.pack);
                NetMessageManage.Manager().RemoveResultBlock(GetStaffListResult);
                this.Invoke(new UIHandleBlock(delegate
                {
                    this.oriStaffs = result.pack.Content.ScAccountList.AccountList.ToList<StructAccount>();
                    this.showStaffs = this.oriStaffs.ToList<StructAccount>();
                    RefreshGridControl();
                }));
            }

        }
        //刷新GridControl
        private void RefreshGridControl()
        {
            foreach(StructAccount account in this.showStaffs)
            {
                DataRow row = this.mainDataTable.NewRow();
                this.mainDataTable.Rows.Add(row);
                row[TitleList.Staff.ToString()] = account.Nickname;
                row[TitleList.TelNumber.ToString()] = account.Phone;
            }

        }
        #endregion

        #region 获取推送信息的列表
        private void GetPushMessageList()
        {
            SystemManageNetOperation.SmsPushMessageInfo(SmsPushMessageInfoResult);
        }
        //获取推送信息列表的结果回调
        private void SmsPushMessageInfoResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.smspush))
            {
                System.Console.WriteLine("SmsPushMessageInfoResult:" + result.pack);
                NetMessageManage.Manager().RemoveResultBlock(SmsPushMessageInfoResult);
                this.Invoke(new UIHandleBlock(delegate
                {
                    List<StructDictItem> temShow = this.showPushItems;

                    this.oriPushItems = result.pack.Content.ScSysInfo.ChildList.ToList<StructDictItem>();
                    //重新将之前的赋值
                    this.showPushItems = this.oriPushItems.ToList<StructDictItem>();
                    InitPushMsgUI(temShow);
                }));
            }

        }
        #endregion

        #region 初始化推送事项UI
        private void InitPushMsgUI(List<StructDictItem> temPushItems)
        {
            this.pushFlowLayoutPanel.Controls.Clear();
            this.textBox1.Text = "";
            this.selectPush = null;
            //更新右侧员工数据
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);
                row[TitleList.Check.ToString()] = false;
            }

            for (int i = 0; i < this.showPushItems.Count; i++)
            {
                StructDictItem item = this.showPushItems[i];
                SimpleButton button = new SimpleButton();
                button.AutoSize = false;
                button.Size = new Size(this.pushFlowLayoutPanel.Size.Width, 34);
                button.Appearance.BackColor = Color.White;
                button.Text = item.GetItem(0);
                button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                this.pushFlowLayoutPanel.Controls.Add(button);
                button.Click += Text_Click;
                button.Tag = i.ToString();
                button.Margin = new Padding(0);

                //判断之前是否改过内容
                if(temPushItems != null)
                {
                    foreach(StructDictItem temItem in temPushItems)
                    {
                        if(temItem.Id == item.Id && !temItem.GetItem(1).Equals(item.GetItem(1)))
                        {
                            this.showPushItems[i] = temItem;
                            break;
                        }
                    }



                }

            }
        }

        //标签点击
        private void Text_Click(object sender, EventArgs e)
        {

           //保存当前勾选的状态
            this.SaveCurrentSetting();
           
            //设置选中按钮状态
            SimpleButton button = (SimpleButton)sender;
            if (this.selectPush != null && this.selectPush.Equals(button))
            {
                return;
            }
            if (selectPush != null)
            {
                this.selectPush.Appearance.BackColor = Color.White;
            }
            button.Appearance.BackColor = Color.Blue;
            this.selectPush = button;

            //获取输入短信内容
            int index = int.Parse((string)this.selectPush.Tag);
            StructDictItem item = this.showPushItems[index];
            this.textBox1.Text = item.GetItem(1);


            //更新右侧员工数据
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);
                StructAccount staff = showStaffs[i];
                string[] splits = { "," };
                List<string> ids = staff.Sns.Split(splits, StringSplitOptions.None).ToList<string>();

                row[TitleList.Check.ToString()] = ids.Contains(item.Id.ToString());



            }

        }

        #endregion

        #region 添加推送事项
        //添加推送事项
        private void addPushButton_Click(object sender, EventArgs e)
        {
            //List<string> ids = new List<string>() { "701" };

            //SystemManageNetOperation.DeleteSmsPushMessage(DeleteAreaResult, ids);
            //return;

            //string message = this.textBox1.Text;

            //保存当前的
            SaveCurrentSetting();

            //进行添加推送事项
            StructDictItem.Builder item = new StructDictItem.Builder();
            item.Code = 0;
            item.Id = 0;
            string areaName = (new Random().Next() % 111) + "xxx事项";
            string content = "请在此编辑推送的短信内容";
            item.AddItem(areaName);
            item.AddItem(content);
            SystemManageNetOperation.AddSmsPushMessage(AddSmsPushMessage, item.Build());


        }
        //添加推送事项回调
        private void AddSmsPushMessage(ResultModel result)
        {
            System.Console.WriteLine("AddSmsPushMessage:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_ADD)
            {
                NetMessageManage.Manager().RemoveResultBlock(AddSmsPushMessage);
                //重新获取短信列表
                this.GetPushMessageList();
            }
        }
        //删除区域结果回调
        private void DeleteSmsPushMessage(ResultModel result)
        {
            System.Console.WriteLine("DeleteSmsPushMessage:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_DEL)
            {
                NetMessageManage.Manager().RemoveResultBlock(DeleteSmsPushMessage);
                this.Invoke(new UIHandleBlock(delegate {
                 
                }));
              
            }
        }
        #endregion 添加推送事项

        #region 点击保存
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveCurrentSetting();

            //根据Ori进行判断是否修改过
            //员工判断
            List<StructAccount> changeStaffs = new List<StructAccount>();
            for(int i = 0;i<this.oriStaffs.Count;i++)
            {
                StructAccount ori = this.oriStaffs[i];
                StructAccount change = this.showStaffs[i];
                if(!ori.Sns.Equals(change.Sns))
                {
                    changeStaffs.Add(change);
                    System.Console.WriteLine("change:"+change);
                }
            }

            //推送事项
            List<StructDictItem> changePush = new List<StructDictItem>();
            for (int i = 0; i < this.oriPushItems.Count; i++)
            {
                StructDictItem ori = this.oriPushItems[i];
                StructDictItem change = this.showPushItems[i];
                if (!ori.GetItem(1).Equals(change.GetItem(1)))
                {
                    changePush.Add(change);
                }
            }
            if(changePush.Count >0)
            {
                System.Console.WriteLine("UpdateSmsPushMessage");
                SystemManageNetOperation.UpdateSmsPushMessage(UpdateSmsPushMessage, changePush);

            }
            if (changeStaffs.Count > 0)
            {
                StaffNetOperation.UpdateStaff(UpdateStaffResult, changeStaffs);
            }
        }
        //更新短信推送事项结果回调
        private void UpdateSmsPushMessage(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_UPDATE)
            {
                System.Console.WriteLine("UpdateSmsPushMessage:" + result.pack);
                NetMessageManage.Manager().RemoveResultBlock(UpdateSmsPushMessage);
                // this.oriPushItems = new IList<StructDictItem>();
                this.oriPushItems = this.showPushItems.ToList<StructDictItem>();


            }
        }
        //更新员工结果回调
        private void UpdateStaffResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_ADMIN_UPDATE)
            {
                System.Console.WriteLine("UpdateStaffResult:" + result.pack);
                NetMessageManage.Manager().RemoveResultBlock(UpdateStaffResult);
                this.oriStaffs = this.showStaffs.ToList<StructAccount>();



            }
        }
        #endregion

        #region 保存当前设置的数据
        private void SaveCurrentSetting()
        {
            if(this.selectPush == null)
            {
                return;
            }

            //获取当前选中的推送事项
            int index = int.Parse((string)this.selectPush.Tag);
            StructDictItem item = this.showPushItems[index];

            #region 修改员工短信Sns
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);


                string value = row[TitleList.Check.ToString()].ToString();
                StructAccount staff = showStaffs[i];
                char[] splits = { ',' };
                List<string> ids = staff.Sns.Split(splits,StringSplitOptions.RemoveEmptyEntries).ToList<string>();

                //勾选上的
                if (value.Equals("True"))
                {
                    //判断之前是否保存过,保存过就不保存了
                    if (!ids.Contains(item.Id.ToString()))
                    {
                        ids.Add(item.Id.ToString());
                    }
                }
                else
                {
                    //判断之前是否保存过,保存过就删除掉
                    if (ids.Contains(item.Id.ToString()))
                    {
                        ids.Remove(item.Id.ToString());
                    }
                }

                string sns = "";
                
                for (int j = 0; j < ids.Count; j++)
                {
                    string tem = ids[j];
                    if (tem.Equals(""))
                    {
                        continue;
                    }
                    if (sns.Equals(""))
                    {
                        sns += ids[j];
                    }
                    else
                    {
                        sns += ("," + ids[j]);
                    }
                }
               // System.Console.WriteLine("sns:"+sns);
                //有改变
                if (!sns.Equals(staff.Sns))
                {
                    StructAccount.Builder newStaff = new StructAccount.Builder(staff);
                    newStaff.Sns = sns;
                    this.showStaffs[i] = newStaff.Build();
                }
            }
            #endregion

            #region 修改推送事项内容
            if (!item.GetItem(1).Equals(textBox1.Text))
            {
                StructDictItem.Builder newItem = new StructDictItem.Builder(item);
                newItem.SetItem(1, textBox1.Text);
                this.showPushItems[index] = newItem.Build();
            }
            #endregion

        }
        #endregion

    }
}
