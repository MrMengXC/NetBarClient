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
using DevExpress.XtraEditors;

namespace NetBarMS.Views.SystemManage
{
    public partial class SmsManageView : RootUserControlView
    {
        enum TitleList
        {
            None,
            Check = 0,                  //勾选
            Staff,                     //员工姓名
            TelNumber,                 //手机号码
        }
        private List<StructDictItem> oriPushItems;         //原版Push
        private List<StructDictItem> showPushItems;        //这是显示版

        private List<StructAccount> oriStaffs;             //原版员工
        private List<StructAccount> showStaffs;            //显示版员工

        private Label selectPush = null;                //当前选择的区域

        //标签的未选中颜色
        private Color normal_color = Color.FromArgb(136, 136, 136);




        public SmsManageView()
        {
            InitializeComponent();
            InitUI();
        }

        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.SmsManage, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;

            //设置自动尺寸
            this.panel1.AutoSize = true;
            this.panel1.AutoScroll = true;
            this.panel1.MaximumSize = new Size(this.pushBgPanel.Width - this.addPushButton.Width, this.pushBgPanel.Height);
            this.pushBgPanel.SizeChanged += Panel1_SizeChanged;

            GetPushMessageList();
            GetStaffList();
        }

        //SizeChange
        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            this.panel1.MaximumSize = new Size(this.pushBgPanel.Width - this.addPushButton.Width, this.pushBgPanel.Height);

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

            if (result.pack.Cmd != Cmd.CMD_STAFF_LIST)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetStaffListResult);
            // System.Console.WriteLine("GetStaffListResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {

                this.Invoke(new RefreshUIHandle(delegate
                {
                    SysManage.UpdateStaffData(result.pack.Content.ScAccountList.AccountList);
                    this.oriStaffs = result.pack.Content.ScAccountList.AccountList.ToList<StructAccount>();
                    this.showStaffs = this.oriStaffs.ToList<StructAccount>();
                    RefreshGridControl();
                }));
            }
            else
            {
                System.Console.WriteLine("GetStaffListResult:" + result.pack);
            }

        }
        //刷新GridControl
        private void RefreshGridControl()
        {
            foreach (StructAccount account in this.showStaffs)
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
            if (result.pack.Cmd != Cmd.CMD_SYS_INFO || !result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.smspush))
            {
                return;
            }
            //System.Console.WriteLine("SmsPushMessageInfoResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(SmsPushMessageInfoResult);
            if (result.pack.Content.MessageType == 1)
            {

                this.Invoke(new RefreshUIHandle(delegate
                {
                    List<StructDictItem> temShow = this.showPushItems;
                    this.oriPushItems = result.pack.Content.ScSysInfo.ChildList.ToList<StructDictItem>();
                    //重新将之前的赋值
                    this.showPushItems = this.oriPushItems.ToList<StructDictItem>();
                    InitPushMsgUI(temShow);
                }));
            }
            else
            {
                System.Console.WriteLine("SmsPushMessageInfoResult:" + result.pack);
            }

        }
        #endregion

        #region 初始化推送事项UI
        const int PUSHBUTTON_W = 10;
        private void InitPushMsgUI(List<StructDictItem> temPushItems)
        {
            this.panel1.Controls.Clear();
            this.textBox1.Text = "";
            this.selectPush = null;

            this.panel1.Hide();
            //更新右侧员工数据
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);
                row[TitleList.Check.ToString()] = false;
            }
            using (Graphics graphics = CreateGraphics())
            {
                for (int i = 0; i < this.showPushItems.Count; i++)
                {
                    StructDictItem item = this.showPushItems[i];
                    //判断之前是否改过内容
                    if (temPushItems != null)
                    {
                        int index = temPushItems.FindIndex(tem => tem.Id == item.Id && !tem.GetItem(1).Equals(item.GetItem(1)));
                        if (index >= 0)
                        {
                            this.showPushItems[i] = temPushItems[index];
                        }
                    }

                    item = this.showPushItems[i];
                    Label pushLabel = new Label();
                    pushLabel.AutoSize = true;
                    pushLabel.Dock = DockStyle.Left;
                    pushLabel.BackColor = Color.Transparent;
                    pushLabel.ForeColor = normal_color;
                    pushLabel.Text = item.GetItem(0);
                    pushLabel.Click += PushButton_ButtonClick;
                    pushLabel.Font = new Font("宋体", 18, GraphicsUnit.Pixel);
                    pushLabel.Tag = item;
                    pushLabel.Margin = new Padding(0);
                    pushLabel.Paint += Button_Paint;
                    pushLabel.TextAlign = ContentAlignment.MiddleCenter;
                    SizeF sizeF = graphics.MeasureString(pushLabel.Text, pushLabel.Font);
                    pushLabel.Size = new Size((int)sizeF.Width + PUSHBUTTON_W, this.panel1.Size.Height);
                    this.panel1.Controls.Add(pushLabel);


                }

            }
            this.panel1.Show();


        }
        //重绘推送事件的Label
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Label button = (Label)sender;
            if (this.selectPush != null && this.selectPush.Equals(button))
            {
                //e.Graphics.DrawRectangle(Pens.Red,)
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Blue, 2, ButtonBorderStyle.Solid);


            }

        }

        //标签点击
        private void PushButton_ButtonClick(object sender, EventArgs e)
        {
            Label push = (Label)sender;
            push.Focus();

            //保存当前勾选的状态
            this.SaveCurrentSetting();
            //设置选中按钮/前一个选中按钮的状态
            if (this.selectPush != null && this.selectPush.Equals(push))
            {
                return;
            }

            Label tem = this.selectPush;
            this.selectPush = push;

            if (tem != null)
            {
                tem.ForeColor = normal_color;
            }
            this.selectPush.ForeColor = Color.Black;

            //获取输入短信内容
            // int index = int.Parse((string)this.selectPush.Tag);
            StructDictItem item = (StructDictItem)this.selectPush.Tag;
            this.textBox1.Text = item.GetItem(1);


            //更新右侧员工数据
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);
                StructAccount staff = showStaffs[i];
                bool check = BigInteger.BigIntegerTools.TestRights(staff.Sns, item.Id);
                row[TitleList.Check.ToString()] = check;
            }

        }

        #endregion

        #region 添加推送事项
        //添加推送事项
        private void addPushButton_Click(object sender, EventArgs e)
        {

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
            if (result.pack.Cmd != Cmd.CMD_SYS_ADD)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(AddSmsPushMessage);
            if (result.pack.Content.MessageType == 1)
            {
                //重新获取短信列表
                this.GetPushMessageList();
            }
            else
            {
                System.Console.WriteLine("AddSmsPushMessage:" + result.pack);
            }
        }
        //删除区域结果回调
        private void DeleteSmsPushMessage(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_DEL)
            {
                return;
            }

            //System.Console.WriteLine("DeleteSmsPushMessage:" + result.pack);
            NetMessageManage.RemoveResultBlock(DeleteSmsPushMessage);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {

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
            for (int i = 0; i < this.oriStaffs.Count; i++)
            {
                StructAccount ori = this.oriStaffs[i];
                StructAccount change = this.showStaffs[i];
                if (!ori.Sns.Equals(change.Sns))
                {
                    changeStaffs.Add(change);
                    // System.Console.WriteLine("ori:" + ori + "\nchange:" + change);
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
            if (changePush.Count > 0)
            {
                SystemManageNetOperation.UpdateSmsPushMessage(UpdateSmsPushMessage, changePush);
            }
            if (changeStaffs.Count > 0)
            {
                StaffNetOperation.UpdateStaffSns(UpdateStaffSnsResult, changeStaffs);
            }
        }
        //更新短信推送事项结果回调
        private void UpdateSmsPushMessage(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_UPDATE)
            {
                return;
            }

            //System.Console.WriteLine("UpdateSmsPushMessage:" + result.pack);
            NetMessageManage.RemoveResultBlock(UpdateSmsPushMessage);
            if (result.pack.Content.MessageType == 1)
            {
                // this.oriPushItems = new IList<StructDictItem>();
                this.oriPushItems = this.showPushItems.ToList<StructDictItem>();
            }
            else
            {

            }
        }
        //更新员工结果回调
        private void UpdateStaffSnsResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_STAFF_SNS)
            {
                return;
            }
            //System.Console.WriteLine("UpdateStaffSnsResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(UpdateStaffSnsResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.oriStaffs = this.showStaffs.ToList<StructAccount>();
                MessageBox.Show("更新成功");
            }
        }
        #endregion

        #region 保存当前设置的数据
        private void SaveCurrentSetting()
        {
            if (this.selectPush == null)
            {
                return;
            }

            //获取当前选中的推送事项
            StructDictItem item = (StructDictItem)this.selectPush.Tag;//this.showPushItems[index];

            #region 修改员工短信Sns
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);


                string value = row[TitleList.Check.ToString()].ToString();
                StructAccount staff = showStaffs[i];

                BigInteger.BigIntegerTools big = new BigInteger.BigIntegerTools(staff.Sns);
                //勾选上的
                if (value.Equals("True"))
                {
                    big.SumRights(item.Id);
                }
                else
                {
                    big.RemoveRights(item.Id);
                }

                string sns = big.ToString();

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
                int index = this.showPushItems.IndexOf(item);
                this.showPushItems[index] = newItem.Build();
            }
            #endregion

        }
        #endregion

    }
}
