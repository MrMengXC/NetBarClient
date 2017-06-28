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
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Views.RateManage
{
    public partial class RateManageView : RootUserControlView
    {
        private Label selectTypeLabel, selectAreaLabel;
        private IList<StructUserArea> userAreas;
        private IList<StructBillSetting> settings ;

        private CSSysBillUpdate.Builder updateRateMange = new CSSysBillUpdate.Builder();          //更新


        public RateManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "费率管理";
            InitUI();
        }

        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            string[] titls = {
                "星期日","星期一", "星期二", "星期三", "星期四", "星期五", "星期六", 
            };
            //this.dataGridView1.Rows.Clear();
            for (int i = 0;i< titls.Count(); i++)
            {
                DataGridViewRow dr = new DataGridViewRow();
                int index = this.dataGridView1.Rows.Add(dr);
                dataGridView1.Rows[index].Cells[0].Value = titls[i];
            }
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;


            //添加会员
            string[] memberTypes = {
                "临时会员","普通会员", "黄金会员", "钻石会员"
            };

            for(int i = memberTypes.Count()-1;i>=0;i--)
            {
                CreateLabel(this.memberTypePanel,"type_" + (i + 1),memberTypes[i]);
            }
            
            //添加区域
            string[] areas = {
                "A区","B区", "C区"
            };
            for (int i = areas.Count() - 1; i >= 0; i--)
            {
                CreateLabel(this.areaPanel, "area_"+(i+1), areas[i]);
            }

            RateManageList();

        }

     
        //创建Label
        private void CreateLabel(Panel parent,string name,string text)
        {

            Label newLabel = new Label();
            newLabel.AutoSize = false;
            newLabel.Size = new Size(112, 34);
            newLabel.BackColor = Color.White;
            newLabel.Text = text;
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.ForeColor = Color.Black;
            newLabel.BorderStyle = BorderStyle.FixedSingle;
            newLabel.Name = name;
            newLabel.Click += NewLabel_Click;
            parent.Controls.Add(newLabel);
            newLabel.Dock = DockStyle.Top;
        }
        #endregion

        #region 获取费率列表 /结果回调
        //获取费率管理列表
        private void RateManageList()
        {

            RateManageNetOperation.RateManageList(RateManageResult);

        }
        //获取费率管理列表回调结果
        private void RateManageResult(ResultModel result)
        {
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(RateManageResult);

            if (result.pack.Cmd == Cmd.CMD_SYS_BILLING_LIST)
            {
                this.userAreas = result.pack.Content.ScSysBillList.UserAreaList;
                this.settings = result.pack.Content.ScSysBillList.SettingList;

                System.Console.WriteLine("RateManageListResult:" + result.pack);
            }
            else if (result.pack.Cmd == Cmd.CMD_SYS_BILLING_UPDATE)
            {
                System.Console.WriteLine("RateManageListResult:" + result.pack);
                this.userAreas = result.pack.Content.ScSysBillUpdate.UserAreaList;
                this.settings = result.pack.Content.ScSysBillUpdate.SettingList;
                this.updateRateMange.Clear();
                this.Invoke(new UIHandleBlock(delegate {
                    MessageBox.Show("保存费率设置成功");
                }));
            }

        }

        #endregion

        #region 区域类型选择
        //选择区域/类型
        private void NewLabel_Click(object sender, EventArgs e)
        {

            //保存当前
            this.SaveCurrentAreaSetting();

            //设置选择的Label
            Label select = (Label)sender;
            select.BackColor = Color.Blue;
            select.ForeColor = Color.White;

            string[] splits = select.Name.Split('_');
            if(splits[0].Equals("type"))
            {
                if(this.selectTypeLabel != null && !this.selectTypeLabel.Equals(select))
                {
                    this.selectTypeLabel.BackColor = Color.White;
                    this.selectTypeLabel.ForeColor = Color.Black;
                }
                this.selectTypeLabel = select;

            }
            else if(splits[0].Equals("area") )
            {
                if( this.selectAreaLabel != null&& !this.selectAreaLabel.Equals(select))
                {
                    this.selectAreaLabel.BackColor = Color.White;
                    this.selectAreaLabel.ForeColor = Color.Black;
                }
                this.selectAreaLabel = select;
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
                    && !this.nDurPrieceTextEdit.Text.Equals("")
                    && !this.bDurComboBoxEdit.Text.Equals("")
                    && !this.bDurPrieceTextEdit.Text.Equals(""))
                {

                    // 判断一下是否与之前的都一样 
                    DeleteUserArea(type, area);

                    //设置新Setting ，UserType
                    StructBillSetting setting = this.GetSelectRateSetting().Build();

                    StructUserArea.Builder currentUserArea = new StructUserArea.Builder();
                    currentUserArea.OrdinaryInterval = Int32.Parse(this.nDurComboBoxEdit.Text);
                    currentUserArea.OrdinaryPrice = Int32.Parse(this.nDurPrieceTextEdit.Text);
                    currentUserArea.NightInterval = Int32.Parse(this.bDurComboBoxEdit.Text);
                    currentUserArea.NightPrice = Int32.Parse(this.bDurPrieceTextEdit.Text);
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
            this.nDurPrieceTextEdit.Text = UserArea.OrdinaryPrice.ToString();
            this.bDurComboBoxEdit.Text = UserArea.NightInterval.ToString();
            this.bDurPrieceTextEdit.Text = UserArea.NightPrice.ToString();

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
           RateManageNetOperation.RateManageUpdate(RateManageResult, updateRateMange.Build());

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
                && temuserArea.NightInterval == userArea.NightInterval
                && temuserArea.NightPrice == userArea.NightPrice)
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
                this.nRateLabel.Text = ((60 / Int32.Parse(this.nDurComboBoxEdit.Text) * Int32.Parse(this.nDurPrieceTextEdit.Text))).ToString();
                this.bRateLabel.Text = ((60 / Int32.Parse(this.bDurComboBoxEdit.Text) * Int32.Parse(this.bDurPrieceTextEdit.Text))).ToString();
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
    }
}