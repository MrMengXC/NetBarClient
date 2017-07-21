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
using System.Threading;
using DevExpress.XtraEditors;
using NetBarMS.Forms;
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS.Views.SystemManage
{
    public partial class AreaManageView : RootUserControlView
    {

         private  enum TitleList
        {
            None = 0,
            CpName,                  //设备名称
            Ip,                             //ip
            Mac,                        //Mac
            Operation,                     //操作
        }

        #region property
        //所有的区域
        private IList<StructDictItem> areas;
        //当前选择的区域
        private Label selectArea = null;
        //当前选择的按钮            
        private List<SimpleButton> selectButtons = new List<SimpleButton>();
        //区域管理
        AreaSettingManage areaManage = new AreaSettingManage();
        #endregion

        #region 声明方法
        public AreaManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "区域设置";
            InitUI();
        }
        #endregion
        
        #region 初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.AreaManage, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;


            this.panel1.MaximumSize = new Size(this.areaPanel.Width-this.addAreaLabel.Width - this.deleteAreaLabel.Width - this.updateLabel.Width, this.areaPanel.Height);
            this.panel1.AutoSize = true;
            this.panel1.AutoScroll = true;
            this.MouseWheel += AreaFlowPanel_MouseWheel;
            this.areaPanel.SizeChanged += AreaPanel_SizeChanged;
          
            //获取区域列表
            GetAreaList();
        }
        //bgSize change
        private void AreaPanel_SizeChanged(object sender, EventArgs e)
        {
            this.panel1.MaximumSize = new Size(this.areaPanel.Width - this.addAreaLabel.Width - this.deleteAreaLabel.Width - this.updateLabel.Width, this.areaPanel.Height);
        }
        #endregion

        #region 获取区域列表
        private void GetAreaList()
        {
            SystemManageNetOperation.GetAreaList(GetAreaListResult);
        }
        //获取区域列表
        private void GetAreaListResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_INFO || !result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.areaParent))
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetAreaListResult);
            //System.Console.WriteLine("GetAreaList:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {
                    UpdateAreaUI(result.pack.Content.ScSysInfo);
                }));
            }
        }
        #endregion

        #region 更新区域UI
        private void UpdateAreaUI(SCSysInfo info)
        {
            SysManage.UpdateAreaData(info.ChildList);
            areas = info.ChildList;
            InitAreaUI();
        }
        #endregion

        #region 初始化区域UI
        const int AREABTN_WITH = 10;
        private void InitAreaUI()
        {

            this.mainDataTable.Clear();
            this.currentComsPanel.Controls.Clear();
            this.selectArea = null;
            this.selectButtons.Clear();
            this.panel1.Controls.Clear();
            using (Graphics gra = CreateGraphics())
            {
                for (int i = 0; i < this.areas.Count; i++)
                {
                    StructDictItem item = this.areas[i];
                    Label area = new Label();
                    area.AutoSize = false;
                    area.BackColor = Color.Transparent;
                    area.ForeColor = Color.Gray;
                    area.Text = item.GetItem(0);
                    area.Click += AreaLabel_Click;
                    area.Tag = i;
                    area.TextAlign = ContentAlignment.MiddleCenter;
                    area.Margin = new Padding(0);
                    area.Paint += Area_Paint;
                    this.panel1.Controls.Add(area);
                    area.Dock = DockStyle.Left;

                    SizeF size = gra.MeasureString(area.Text, area.Font);
                    area.Size = new Size((int)size.Width + AREABTN_WITH, this.panel1.Size.Height);

                }
            }
                
        }

        private void Area_Paint(object sender, PaintEventArgs e)
        {

            Label tem = (Label)sender;

            //如果是同一个返回
            if (tem != null && tem.Equals(this.selectArea))
            {
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Blue, 2, ButtonBorderStyle.Solid);

            }

        }

        //标签点击
        private void AreaLabel_Click(object sender, EventArgs e)
        {
            Label tem = this.selectArea;
            this.selectArea = (Label)sender;

            //如果是同一个返回
            if (tem != null&&tem.Equals(this.selectArea))
            {
                return;
            }
            if (tem != null)
            {
                tem.ForeColor = Color.Gray ;
            }
            this.selectArea.ForeColor = Color.Black;

            //将选中的按钮数组清空
            this.selectButtons.Clear();
            //更新区域从属电脑和其他电脑列表
            RefreshComputersList();
        }
        #endregion

        #region 刷新界面数据
        //刷新电脑列表
        private void RefreshComputersList()
        {

            int index  = (int)this.selectArea.Tag;
            string code = this.areas[index].Code.ToString();
            this.areaManage.GetOtherComputers(code);
            RefreshGridControl();
            RefreshAreaComsPanel();

        }

        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();

            foreach(StructRealTime time in this.areaManage.otherComs)
            {
                DataRow row = this.mainDataTable.NewRow();
                this.mainDataTable.Rows.Add(row);
                row[TitleList.CpName.ToString()] = time.Computer;
                row[TitleList.Ip.ToString()] = time.Ip;
                row[TitleList.Mac.ToString()] = time.Mac;
            }
        }
        //刷新区域电脑
        private void RefreshAreaComsPanel()
        {
            this.currentComsPanel.Controls.Clear();

            for (int i = 0;i< this.areaManage.currentComs.Count;i++)
            {
                StructRealTime time = this.areaManage.currentComs[i];
                SimpleButton button = new SimpleButton();
                button.Text = time.Computer;
                button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                button.Size = new Size(50, 50);
                button.Click += Button_Click;
                button.Tag = i.ToString();
                this.currentComsPanel.Controls.Add(button);
            }

        }
        //点击区域从属电脑
        private void Button_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            if(selectButtons.Contains(button))
            {
                selectButtons.Remove(button);
                button.Appearance.BackColor = Color.White;
            }
            else
            {               
                selectButtons.Add(button);
                button.Appearance.BackColor = Color.Green;
            }
        }
        #endregion

        #region 区域的添加
        private void AddArea_ButtonClick(object sender, EventArgs e)
        {
            string areaName = "";
            using (MessageForm form = new MessageForm(""))
            {
                if(form.ShowDialog() == DialogResult.OK)
                {

                    areaName = form.InputText;
                }

            }
            if(areaName.Equals(""))
            {
                return;
            }
            StructDictItem.Builder item = new StructDictItem.Builder();
            item.Code = 0;
            item.Id = 0;
            item.AddItem(areaName);
            SystemManageNetOperation.AddArea(AddAreaResult, item.Build());

        }
    
        //添加区域结果回调
        private void AddAreaResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_SYS_ADD || !result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.areaParent))
            {
                return;   
            }

            NetMessageManage.RemoveResultBlock(AddAreaResult);
            System.Console.WriteLine("AddAreaResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                //重新获取区域列表
                this.Invoke(new RefreshUIHandle(delegate {
                    UpdateAreaUI(result.pack.Content.ScSysInfo);
                    areaManage.UpateHomePageComputerArea(0, AREA_SETTING.ADD);
                }));
              
            }

        }

        #endregion

        #region 删除区域
        private void DeleteArea_ButtonClick(object sender, EventArgs e)
        {
            if(this.selectArea == null)
            {
                return;
            }
            int index = (int)this.selectArea.Tag;
            List<string> ids = new List<string>() { this.areas[index].Id.ToString() };
            SystemManageNetOperation.DeleteArea(DeleteAreaResult, ids);
        }
        //删除区域结果回调
        private void DeleteAreaResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_DEL)
            {
                return;
            }
           // System.Console.WriteLine("DeleteAreaResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(DeleteAreaResult);
            if (result.pack.Content.MessageType == 1)
            {
                //重新获取区域列表
                this.Invoke(new RefreshUIHandle(delegate {
                    //获取区域id
                    int index = (int)this.selectArea.Tag;
                    int areaId = this.areas[index].Code;
                    //更新区域UI
                    UpdateAreaUI(result.pack.Content.ScSysInfo);
                    //修改首页
                    areaManage.UpateHomePageComputerArea(areaId, AREA_SETTING.DELETE);
                    MessageBox.Show("删除成功");
                }));
            }
            else
            {
                MessageBox.Show("删除区域失败,请先删除区域所有所属电脑！");
            }
        }
        #endregion

        #region 更新区域
        private void UpdateArea_ButtonClick(object sender, EventArgs e)
        {
            if (this.selectArea == null)
            {
                return;
            }

            string areaName = "";
            using (MessageForm form = new MessageForm(""))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {

                    areaName = form.InputText;
                }

            }
            if (areaName.Equals(""))
            {
                return;
            }

            int index = (int)this.selectArea.Tag;
            StructDictItem.Builder update = new StructDictItem.Builder(this.areas[index]);
            update.ItemList.Clear();
            update.AddItem(areaName);
            SystemManageNetOperation.UpdateArea(UpdateAreaResult, update.Build());
        }
        //更新结果回调
        private void UpdateAreaResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_UPDATE)
            {
                return;
            }
            //System.Console.WriteLine("UpdateAreaResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(UpdateAreaResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {
                    //获取区域id
                    int index = (int)this.selectArea.Tag;
                    int areaId = this.areas[index].Code;

                    UpdateAreaUI(result.pack.Content.ScSysInfo);
                    //修改首页
                    areaManage.UpateHomePageComputerArea(areaId, AREA_SETTING.UPDATE);
                    MessageBox.Show("修改成功");
                }));
              
            }
        }
        #endregion

        #region 将设备列表的电脑添加到区域
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //1.获取设备列表所有选中的行
            int[] rows = this.gridView1.GetSelectedRows();
            //2.判断数组和是否有选中区域
            if(rows.Count() == 0 || selectArea == null)
            {
                return;
            }

            List<StructRealTime> changeComs = new List<StructRealTime>();
            int index = (int)this.selectArea.Tag;
            //3.改变管理工具电脑数组
            foreach (int row in rows)
            {
                StructRealTime.Builder com = new StructRealTime.Builder(this.areaManage.otherComs[row]);
                com.Area = this.areas[index].Code.ToString();
                changeComs.Add(com.Build());
            }
            this.areaManage.UpdateComputersCode(changeComs);
            //重新赋值
            this.areaManage.GetOtherComputers(this.areas[index].Code.ToString());
            //5.删除选中行
            this.gridView1.DeleteSelectedRows();

            //刷新电脑区域列表
            RefreshAreaComsPanel();

        }
        #endregion

        #region 将电脑区域的选中的电脑移除
        private void simpleButton3_Click(object sender, EventArgs e)
        {

            //判断数组和是否有选中区域
            if (this.selectButtons.Count == 0)
            {
                return;
            }

            List<StructRealTime> changeComs = new List<StructRealTime>();

            //Dictionary<int, StructRealTime> changeComDict = new Dictionary<int, StructRealTime>();//已经改变的字典
            //改变管理工具电脑数组
            foreach (SimpleButton button in selectButtons)
            {
                int btnIndex = int.Parse((string)button.Tag);
                StructRealTime.Builder com = new StructRealTime.Builder(this.areaManage.currentComs[btnIndex]);
                com.Area = "0";
                changeComs.Add(com.Build());
                //移除按钮
                this.currentComsPanel.Controls.Remove(button);
               
            }
            //更新电脑数据
            this.areaManage.UpdateComputersCode(changeComs);
            //重新赋值
            int index = (int)this.selectArea.Tag;

            this.areaManage.GetOtherComputers(this.areas[index].Code.ToString());
            
            //删除选中的电脑
            this.selectButtons.Clear();
            //刷新设备列表
            RefreshComputersList();
        }
        #endregion

        #region 保存修改数据
        //将修改数据保存到服务器
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //获取所有修改过的电脑
            CSComputerUpdate update = this.areaManage.GetAllChangedComs();
            if(update.ComputerCount == 0)
            {
                return;
            }
            //System.Console.WriteLine("update:" + update);
            SystemManageNetOperation.UpdateAreaComputer(UpdateAreaComputerResult, update);
        }
        //更新区域电脑结果回调
        private void UpdateAreaComputerResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_COMPUTER_UPDATE)
            {
                return;
            }
            //System.Console.WriteLine("UpdateAreaComputerResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(UpdateAreaComputerResult);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {
                    //修改首页
                    this.areaManage.UpateHomePageComputerArea();
                    MessageBox.Show("保存成功");
                }));
            }
        }
        #endregion

        #region 鼠标滚轮事件的监听
        private void AreaFlowPanel_MouseWheel(object sender, MouseEventArgs e)
        {

            ////获取鼠标位于本页面的文职
            //Point aPoint = new Point(e.X, e.Y); 
            ////AreaPanel 所在父视图的坐标
            //Rectangle r = new Rectangle(this.areaPanel.Location.X+this.tableLayoutPanel1.Location.X, this.areaPanel.Location.Y+ this.tableLayoutPanel1.Location.Y, this.areaPanel.Width, this.areaPanel.Height);
            ////判断鼠标是不是在flowLayoutPanel1区域内
            //if (r.Contains(aPoint))
            //{
            //    //设置鼠标滚动幅度的大小
            //    //flowLayoutPanel1.AutoScrollPosition = new Point(0, flowLayoutPanel1.VerticalScroll.Value - e.Delta / 2);
            //    System.Console.WriteLine("滚动中");
            //    Point loc = this.panel1.Location;
            //    loc .Y-= 1;
            //    this.panel1.Location = loc;

            //}


        }
        #endregion

        
    }
}
