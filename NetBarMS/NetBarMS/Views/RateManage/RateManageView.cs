using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Model;
using DevExpress.XtraEditors;

namespace NetBarMS.Views.RateManage
{
    public partial class RateManageView : RootUserControlView
    {

        //选择的类型Label。 选中的区域Label
        private Label selectTypeLabel, selectAreaLabel;
        //费率数组
        private IList<StructUserArea> userAreas;
        //费率设置数组
        private IList<StructBillSetting> settings ;
        //更新
        private CSSysBillUpdate.Builder updateRateMange = new CSSysBillUpdate.Builder();          //更新

        #region 关于会员类型
        //选中的会员类型文字color
        private Color S_TYPE_F_COLOR = Color.Black;
        //正常状态会员类型文字color
        private Color N_TYPE_F_COLOR = Color.FromArgb(136, 136, 136);
        //选中时会员类型底部横条颜色
        private Color S_TYPE_LINE_COLOR = Color.FromArgb(0, 165, 248);
        #endregion

        #region 关于区域
        //选中的区域文字颜色
        private Color S_AREA_F_COLOR = Color.White;
        //正常状态区域文字颜色
        private Color N_AREA_F_COLOR = Color.FromArgb(0, 165, 248);
        //选中的区域背景颜色
        private Color S_AREA_B_COLOR = Color.FromArgb(0, 165, 248);
        //正常状态区背景颜色
        private Color N_AREA_B_COLOR = Color.White;
        #endregion

        public RateManageView()
        {
            InitializeComponent();
            InitUI();
        }

        #region 初始化UI
        const int LABEL_WIDTH = 112;

        //初始化UI
        private void InitUI()
        {
            //初始化TextEdit
            TextEdit[] edits = {
                this.nDurPrieceText,this.nMinConsumeText,this.bDurPrieceText,this.bMinConsumeText
            };
            InitTextEdit(edits);
            //初始化星期表单
            string[] titls = {
                "星期日","星期一", "星期二", "星期三", "星期四", "星期五", "星期六", 
            };
            //this.dataGridView1.Rows.Clear();
            for (int i = 0;i< titls.Count(); i++)
            {
                DataGridViewRow dr = new DataGridViewRow();
                dr.Height = 25;
                int index = this.dataGridView1.Rows.Add(dr);
                dataGridView1.Rows[index].Cells[0].Value = titls[i];
            }
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            //隐藏最左侧行头
            this.dataGridView1.RowHeadersVisible = false;
           
            //获取会员类型列表
            List<MemberTypeModel> types = SysManage.MemberTypes ;
            this.memberTypeScollPanel.Hide();
            this.memberTypeScrollBar.Hide();
            for (int i = types.Count()-1;i>=0;i--)
            {
                string name = "type_" + types[i].typeId;
                string text = types[i].typeName;

                Label type =  CreateLabel(this.memberTypeScollPanel,name,text, DockStyle.Left);
                type.ForeColor = N_TYPE_F_COLOR;
                type.Paint += Type_Paint;
            }
            InitMemberScollBar();
            this.memberTypeScollPanel.Show();

            //添加区域
            List<AreaTypeModel> areas = SysManage.Areas;
            this.areaScrollPanel.Hide();
            this.areaScrollBar.Hide();
            for (int i = 0; i < areas.Count; i++)
            {
                string name = "area_" + areas[i].areaId;
                string text = areas[i].areaName;
                Label areaL = CreateLabel(this.areaScrollPanel, name, text, DockStyle.Left);
                areaL.Tag = i;
                areaL.Paint += AreaLabel_Paint;
                areaL.ForeColor = N_AREA_F_COLOR;
                areaL.BackColor = N_AREA_B_COLOR;
            }
            this.areaScrollPanel.Show();
            InitAreaScollBar();

            //获取费率列表数据
            RateManageList();

        }

        //TableLayoutPanel 重绘触发的方法
        private void AreaLabel_Paint(object sender, PaintEventArgs e)
        {
            Label areaL = sender as Label;
            Graphics labeGraphics = e.Graphics;
            Rectangle angle = areaL.ClientRectangle;


            int tag = (int)((Label)sender).Tag;
            if(tag == 0)
            {
                ControlPaint.DrawBorder(labeGraphics, angle, S_AREA_B_COLOR, ButtonBorderStyle.Solid);
            }
            else
            {
                ControlPaint.DrawBorder(labeGraphics, angle,
                   S_AREA_B_COLOR, 1, ButtonBorderStyle.Solid,
                   S_AREA_B_COLOR, 1, ButtonBorderStyle.Solid,
                   Color.Transparent, 0, ButtonBorderStyle.None,
                   S_AREA_B_COLOR, 1, ButtonBorderStyle.Solid);
            }

        }

        //会员类型重绘控件触发的方法
        private void Type_Paint(object sender, PaintEventArgs e)
        {
            Label typeL = sender as Label;
            Graphics labeGraphics = e.Graphics;
            Rectangle angle = typeL.ClientRectangle;

            if (sender.GetType() == typeof(Label)&&
                this.selectTypeLabel != null && 
                this.selectTypeLabel.Equals(sender))
            {
                ControlPaint.DrawBorder(labeGraphics, angle,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    S_TYPE_LINE_COLOR, 2, ButtonBorderStyle.Solid);
            }
        }



        //创建Label
        private Label CreateLabel(Panel parent,string name,string text,DockStyle dock)
        {
            Label newLabel = new Label();
            newLabel.AutoSize = false;
            newLabel.Size = new Size(LABEL_WIDTH, parent.Height);
            newLabel.BackColor = Color.Transparent;
            newLabel.Text = text;
            newLabel.Font = new Font("宋体", 18,FontStyle.Bold, GraphicsUnit.Pixel);
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.Name = name;
            newLabel.Click += NewLabel_Click;
            newLabel.Margin = new Padding(0);
            parent.Controls.Add(newLabel);
            newLabel.Dock = dock;
            return newLabel;

        }
        #endregion

        #region 获取费率列表 /结果回调
        //获取费率管理列表
        private void RateManageList()
        {
            RateManageNetOperation.RateManageList(RateManageListResult);

        }
        //获取费率管理列表回调结果
        private void RateManageListResult(ResultModel result)
        {
            
            if (result.pack.Cmd != Cmd.CMD_SYS_BILLING_LIST)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(RateManageListResult);
            //System.Console.WriteLine("RateManageListResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.userAreas = result.pack.Content.ScSysBillList.UserAreaList;
                this.settings = result.pack.Content.ScSysBillList.SettingList;
            }
        }

        #endregion

        #region 区域类型选择
        //选择区域/类型
        private void NewLabel_Click(object sender, EventArgs e)
        {

            //保存当前
            SaveCurrentAreaSetting();

            Label select = (Label)sender;
            //设置选择的Label
            string[] splits = select.Name.Split('_');           
            //这是会员类型点击
            if(splits[0].Equals("type"))
            {
                if(this.selectTypeLabel != null && !this.selectTypeLabel.Equals(select))
                {
                    this.selectTypeLabel.ForeColor = N_TYPE_F_COLOR;
                }
                this.selectTypeLabel = select;
                select.ForeColor = S_TYPE_F_COLOR;
            }
            else if(splits[0].Equals("area") )
            {
                if( this.selectAreaLabel != null&& !this.selectAreaLabel.Equals(select))
                {
                    this.selectAreaLabel.ForeColor = N_AREA_F_COLOR;
                    this.selectAreaLabel.BackColor = N_AREA_B_COLOR;
                }
                this.selectAreaLabel = select;
                this.selectAreaLabel.ForeColor = S_AREA_F_COLOR;
                this.selectAreaLabel.BackColor = S_AREA_B_COLOR;

            }

            //显示最新的
            if (this.selectAreaLabel != null && this.selectTypeLabel != null)
            {
                Int32 area = Int32.Parse(this.selectAreaLabel.Name.Split('_')[1]);
                Int32 type = Int32.Parse(this.selectTypeLabel.Name.Split('_')[1]);
                StructUserArea UserArea;
                StructBillSetting setting;
                this.GetUserArea(type, area,out UserArea, out setting);
                ShowAreaSetting(UserArea,setting);
            }

        }

        #endregion

        #region 保存当前区域设置
        //保存当前区域设置
        private void SaveCurrentAreaSetting()
        {
           
            if (this.selectAreaLabel != null && this.selectTypeLabel != null)
            {
                Int32 area = Int32.Parse(this.selectAreaLabel.Name.Split('_')[1]);
                Int32 type = Int32.Parse(this.selectTypeLabel.Name.Split('_')[1]);
                if (!this.nDurComboBoxEdit.Text.Equals("")
                    && !this.nDurPrieceText.Text.Equals("")
                    && !this.nMinConsumeText.Text.Equals("")
                    && !this.bDurComboBoxEdit.Text.Equals("")
                    && !this.bDurPrieceText.Text.Equals("")
                    && !this.bMinConsumeText.Text.Equals(""))
                {

                    // 判断一下是否与之前的都一样 
                    DeleteUserArea(type, area);

                    //设置新Setting ，UserType
                    StructBillSetting setting = this.GetSelectRateSetting().Build();

                    StructUserArea.Builder currentUserArea = new StructUserArea.Builder();
                    currentUserArea.OrdinaryInterval = Int32.Parse(this.nDurComboBoxEdit.Text);
                    currentUserArea.OrdinaryPrice = Int32.Parse(this.nDurPrieceText.Text);
                    currentUserArea.OrdinaryMin = Int32.Parse(this.nMinConsumeText.Text);

                    currentUserArea.NightInterval = Int32.Parse(this.bDurComboBoxEdit.Text);
                    currentUserArea.NightPrice = Int32.Parse(this.bDurPrieceText.Text);
                    currentUserArea.NightMin = Int32.Parse(this.bMinConsumeText.Text);
                    currentUserArea.Areatype = area;
                    currentUserArea.Usertype = type;
                    currentUserArea.Index = 0;

                    //相对于服务器保存的进行判断是否改变
                    if (this.IsChangeUserArea(currentUserArea.Build(),setting))
                    {
                        this.DeleteUserArea(type, area);
                    }
                    else
                    {
                        this.updateRateMange.AddSetting(setting);
                        int index = this.updateRateMange.SettingCount - 1;
                        currentUserArea.Index = index;
                        this.updateRateMange.AddUserArea(currentUserArea);

                    }
                }
            }

        }
        #endregion

        #region 从上传列表内删除不需要的UserArea
        private void DeleteUserArea(Int32 type,Int32 area)
        {
            Int32 temIndex = Int32.MaxValue;
            for (int i = 0; i < this.updateRateMange.UserAreaCount; i++)
            {
                StructUserArea tem = this.updateRateMange.UserAreaList[i];
                if (tem.Usertype == type && tem.Areatype == area)
                {
                    temIndex = tem.Index;
                    //移除之前的设置
                    this.updateRateMange.SettingList.RemoveAt(temIndex);
                }
                if (tem.Index > temIndex)
                {
                    StructUserArea.Builder newArea = new StructUserArea.Builder(tem);
                    newArea.Index -= 1;
                    this.updateRateMange.SetUserArea(i, newArea);
                }

            }
            if (temIndex < this.updateRateMange.UserAreaCount)
            {
                this.updateRateMange.UserAreaList.RemoveAt(temIndex);
            }


        }
        #endregion

        #region 类型-区域-时段设置
        //显示区域设置
        private void ShowAreaSetting(StructUserArea UserArea,StructBillSetting setting)
        {
            //
            this.dataGridView1.ClearSelection();

            this.nDurComboBoxEdit.Text = UserArea.OrdinaryInterval.ToString();
            this.nDurPrieceText.Text = UserArea.OrdinaryPrice.ToString();
            this.nMinConsumeText.Text = UserArea.OrdinaryMin.ToString();

            this.bDurComboBoxEdit.Text = UserArea.NightInterval.ToString();
            this.bDurPrieceText.Text = UserArea.NightPrice.ToString();
            this.bMinConsumeText.Text = UserArea.NightMin.ToString();

            this.nRateLabel.Text = ((60 / UserArea.OrdinaryInterval) * UserArea.OrdinaryPrice).ToString();
            this.bRateLabel.Text = ((60 / UserArea.NightInterval) * UserArea.NightPrice).ToString();


            //显示选择的区域
            SetDataGridViewSelectCells(setting,this.nRateLabel.Text, this.bRateLabel.Text);

        }
        //设置GridViewSelectCells
        private void SetDataGridViewSelectCells(StructBillSetting setting,string nRate,string bRate)
        {
            for (int row = 0; row < 7; row++)
            {
                Int32 day = 0;
                if (row == 0)
                {
                    day = setting.Day0;
                }
                else if (row == 1)
                {
                    day = setting.Day1;
                }
                else if (row == 2)
                {
                    day = setting.Day2;
                }
                else if (row == 3)
                {
                    day = setting.Day3;
                }
                else if (row == 4)
                {
                    day = setting.Day4;
                }
                else if (row == 5)
                {
                    day = setting.Day5;
                }
                else
                {
                    day = setting.Day6;
                }

                string dur = Convert.ToString(day, 2).PadLeft(24, '0');
                for (int column = 1; column < this.dataGridView1.ColumnCount; column++)
                {
                    DataGridViewCell cell = this.dataGridView1.Rows[row].Cells[column];
                    int isSelect = int.Parse(dur.Substring(column - 1, 1));
                    if (isSelect == 1)
                    {
                        cell.Selected = true;
                        cell.Value = nRate;
                        //cell.ToolTipText = nRate;
                    }
                    else
                    {
                        cell.Value = bRate;
                    }
                }
            }

        }
        #endregion

        #region 点击保存
        //保存设置
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //保存当前设置
            SaveCurrentAreaSetting();
           // System.Console.WriteLine("updateRateMange:" + updateRateMange);
           
            if (this.updateRateMange.UserAreaCount == 0)
            {
                return;
            }

            //上传
           RateManageNetOperation.RateManageUpdate(RateManageUpdateResult, updateRateMange.Build());

        }
        //更新费率管理结果回调
        private void RateManageUpdateResult(ResultModel result)
        {
           
            if (result.pack.Cmd != Cmd.CMD_SYS_BILLING_UPDATE)
            {
                return;
            }

            //System.Console.WriteLine("RateManageUpdateResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(RateManageUpdateResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.userAreas = result.pack.Content.ScSysBillUpdate.UserAreaList;
                this.settings = result.pack.Content.ScSysBillUpdate.SettingList;
                this.updateRateMange.Clear();
                this.Invoke(new RefreshUIHandle(delegate {
                    MessageBox.Show("保存费率设置成功");
                }));
            }
        }
        #endregion

        #region 获取每周每一天小时安排
        private StructBillSetting.Builder GetSelectRateSetting()
        {
            StructBillSetting.Builder setting = new StructBillSetting.Builder();
            for (int row = 0; row < 7; row++)
            {
                string dur = "";
                for (int column = 1; column < this.dataGridView1.ColumnCount; column++)
                {
                    DataGridViewCell cell = this.dataGridView1.Rows[row].Cells[column];
                    bool isContains = this.dataGridView1.SelectedCells.Contains(cell);
                    dur += isContains == true ? 1 : 0;
                }
                Int32 num = Convert.ToInt32(dur,2);
                if (row == 0)
                {
                    setting.Day0 = num;
                }else if(row == 1)
                {
                    setting.Day1 = num;
                }
                else if (row == 2)
                {
                    setting.Day2 = num;
                }
                else if (row == 3)
                {
                    setting.Day3 = num;
                }
                else if (row == 4)
                {
                    setting.Day4 = num;
                }
                else if (row == 5)
                {
                    setting.Day5 = num;
                }
                else if (row == 6)
                {
                    setting.Day6 = num;
                }

               // System.Console.WriteLine("num:"+ Convert.ToString(num, 2).PadLeft(24, '0') + "dur:"+dur);


            }
            return setting;
            
        }
        #endregion

        #region 获取StructUserArea StructBillSetting
        private void GetUserArea(Int32 type,Int32 area, out StructUserArea userArea,out StructBillSetting setting)
        {
        
            StructUserArea temuserArea = null;
            StructUserArea defaultArea = null;

            
            for (int i = 0; i < this.updateRateMange.UserAreaCount; i++)
            {
                StructUserArea tem = this.updateRateMange.GetUserArea(i);
                if (tem.Usertype == type && tem.Areatype == area)
                {
                    temuserArea = tem;
                }

            }

            if (temuserArea != null)
            {
                userArea = temuserArea;
                setting = this.updateRateMange.GetSetting(userArea.Index);
                return;
            }

            for (int i = 0;i<this.userAreas.Count;i++)
            {
                StructUserArea tem = this.userAreas[i];
                if(tem.Usertype == type && tem.Areatype ==area)
                {
                        temuserArea = tem;
                }
                if(tem.Usertype == 0 && tem.Areatype == 0)
                {
                    defaultArea = tem;
                }
            }
            if(temuserArea == null)
            {
                temuserArea = defaultArea;
            }

            userArea = temuserArea;
            setting = this.settings[userArea.Index];

        }

    
        #endregion

        #region 判断StructUserArea StructBillSetting是否改变 返回真：未改变 反之
        private bool IsChangeUserArea(StructUserArea userArea ,StructBillSetting setting)
        {

            StructUserArea temuserArea = null;
            StructUserArea defaultArea = null;
            
            for (int i = 0; i < this.userAreas.Count; i++)
            {
                StructUserArea tem = this.userAreas[i];
                if (tem.Usertype == userArea.Usertype && tem.Areatype == userArea.Areatype)
                {
                    temuserArea = tem;
                }
                if (tem.Usertype == 0 && tem.Areatype == 0)
                {
                    defaultArea = tem;
                }
            }

            if (temuserArea == null)
            {
                temuserArea = defaultArea;
            }

            bool userAreaChange = true,settingChange = true;
            if(temuserArea.OrdinaryInterval == userArea.OrdinaryInterval
                && temuserArea.OrdinaryPrice == userArea.OrdinaryPrice 
                && temuserArea.OrdinaryMin == userArea.OrdinaryMin
                && temuserArea.NightInterval == userArea.NightInterval
                && temuserArea.NightPrice == userArea.NightPrice
                && temuserArea.NightMin == userArea.NightMin
                )
            {
                userAreaChange = false;
            }

            StructBillSetting  temSetting = this.settings[temuserArea.Index];
            if(temSetting.Day0 == setting.Day0
                && temSetting.Day1 == setting.Day1
                && temSetting.Day2 == setting.Day2
                && temSetting.Day3 == setting.Day3
                && temSetting.Day4 == setting.Day4
                && temSetting.Day5 == setting.Day5
                && temSetting.Day6 == setting.Day6)
            {
                settingChange = false;
            }


            return (!userAreaChange) && (!settingChange);

        }
        #endregion

        #region 输入框输入改变费率值
        private void PrieceTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            ChangeRate();
        }

        private void ComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
           ChangeRate();
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ChangeRate();
        }

        //费率修改
        private void ChangeRate()
        {
            try
            {
                this.nRateLabel.Text = ((60 / Int32.Parse(this.nDurComboBoxEdit.Text) * Int32.Parse(this.nDurPrieceText.Text))).ToString();
                this.bRateLabel.Text = ((60 / Int32.Parse(this.bDurComboBoxEdit.Text) * Int32.Parse(this.bDurPrieceText.Text))).ToString();
                for (int row = 0; row < 7; row++)
                {
                    for (int column = 1; column < this.dataGridView1.ColumnCount; column++)
                    {
                        DataGridViewCell cell = this.dataGridView1.Rows[row].Cells[column];
                        if (cell.Selected)
                        {
                            cell.Value = this.nRateLabel.Text;
                            //cell.ToolTipText = nRate;
                        }
                        else
                        {
                            cell.Value = this.bRateLabel.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
        }


        #endregion

        #region 区域滚动条
        private void areaScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.areaScrollPanel.Left -= e.NewValue - e.OldValue;
        }
        #endregion

        #region 重置区域ScrollBar
        private void InitAreaScollBar()
        {
            this.areaScrollBar.Hide();
            //判断是否出现滑动条
            if (this.areaScrollPanel.Width > this.areaBgPanel.Width)
            {

                this.areaScrollBar.Minimum = 0;
                this.areaScrollBar.Maximum = this.areaScrollPanel.Width - this.areaBgPanel.Width + 15;
                this.areaScrollBar.Show();
            }
        }


        #endregion

        #region 会员类型滑动条
        private void memberTypeScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.memberTypeScollPanel.Left -= e.NewValue - e.OldValue;
        }

        #endregion

        #region 会员类型背景视图尺寸变化
        private void memberTypeBgPanel_SizeChanged(object sender, EventArgs e)
        {
            InitMemberScollBar();
           
        }


        #endregion
        #region gridView sizechanged
        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            
            for(int row  = 0;row < this.dataGridView1.RowCount;row++)
            {
                DataGridViewRow dr = this.dataGridView1.Rows[row];
                dr.Height = (this.dataGridView1.Height -  this.dataGridView1.ColumnHeadersHeight)/ this.dataGridView1.RowCount;
            }
            for (int col = 1; col < this.dataGridView1.ColumnCount;col++)
            {
                DataGridViewColumn column = this.dataGridView1.Columns[col];

                column.Width = (this.dataGridView1.Width - this.dataGridView1.Columns[0].Width) / (this.dataGridView1.ColumnCount - 1);
            }
        }
        #endregion
        #region 重置会员类型ScrollBar
        private void InitMemberScollBar()
        {
            this.memberTypeScrollBar.Hide();
            //判断是否出现滑动条
            if (this.memberTypeScollPanel.Width > this.memberTypeBgPanel.Width)
            {

                this.memberTypeScrollBar.Minimum = 0;
                this.memberTypeScrollBar.Maximum = this.memberTypeScollPanel.Width - this.memberTypeBgPanel.Width + 15;
                this.memberTypeScrollBar.Show();
            }
        }
        #endregion

    }
}