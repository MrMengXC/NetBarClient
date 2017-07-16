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

namespace NetBarMS.Views.SystemManage
{
    public partial class AreaManageView : RootUserControlView
    {

        enum TitleList
        {
            None = 0,
            CpName,                  //设备名称
            Ip,                             //ip
            Mac,                        //Mac
            Operation,                     //操作
        }

        //所有的区域
        private IList<StructDictItem> areas;             
        //所有的区域编码         
        private List<string> areaCodes = new List<string>();

        //当前选择的区域
        private SimpleButton selectArea = null;
        //当前选择的按钮            
        private List<SimpleButton> selectButtons = new List<SimpleButton>();
        //区域管理
        AreaSettingManage areaManage = new AreaSettingManage();
        //是否是修改删除后获取列表
        bool isChange = false;

        public AreaManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "区域设置";
            InitUI();
        }

        #region 初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.AreaManage, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;


            this.panel1.MaximumSize = new Size(this.areaPanel.Width-this.addAreaButton.Width - this.deleteAreaButton.Width, this.areaPanel.Height);
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
            this.panel1.MaximumSize = new Size(this.areaPanel.Width - this.addAreaButton.Width - this.deleteAreaButton.Width, this.areaPanel.Height);
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
            if (result.pack.Cmd != Cmd.CMD_SYS_INFO)
            {
                NetMessageManage.RemoveResultBlock(GetAreaListResult);
                this.Invoke(new RefreshUIHandle(delegate
                {

                    System.Console.WriteLine("GetAreaList:" + result.pack);
                    SysManage.UpdateAreaData(result.pack.Content.ScSysInfo.ChildList);
                    areas = result.pack.Content.ScSysInfo.ChildList;
                    areaCodes.Clear();
                    foreach (StructDictItem item in areas)
                    {
                        areaCodes.Add(item.Code.ToString());
                    }

                    if (isChange)
                    {
                        isChange = false;
                        //修改首页
                        this.areaManage.ChangeAreaUpateHomePageComputerArea();
                    }
                    InitAreaUI();
                }));
            }
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.areaParent))
            {
                NetMessageManage.RemoveResultBlock(GetAreaListResult);
                this.Invoke(new RefreshUIHandle(delegate
                {

                    System.Console.WriteLine("GetAreaList:" + result.pack);
                    SysManage.UpdateAreaData(result.pack.Content.ScSysInfo.ChildList);
                    areas = result.pack.Content.ScSysInfo.ChildList;
                    areaCodes.Clear();
                    foreach (StructDictItem item in areas)
                    {
                        areaCodes.Add(item.Code.ToString());
                    }

                    if(isChange)
                    {
                        isChange = false;
                        //修改首页
                        this.areaManage.ChangeAreaUpateHomePageComputerArea();
                    }
                    InitAreaUI();
                }));
            }

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
                    SimpleButton button = new SimpleButton();
                    
                    button.Appearance.BackColor = Color.White;
                    button.Text = item.GetItem(0);
                    button.Dock = DockStyle.Left;
                    this.panel1.Controls.Add(button);
                    button.Click += Text_Click;
                    button.Tag = item.Code.ToString();
                    button.Margin = new Padding(0);
                    button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

                    SizeF size = gra.MeasureString(button.Text, button.Font);
                    button.Size = new Size((int)size.Width + AREABTN_WITH, this.panel1.Size.Height);
                }
            }
                
        }

        //标签点击
        private void Text_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            if (this.selectArea != null&&this.selectArea.Equals(button))
            {
                return;
            }
            if(selectArea != null)
            {
                this.selectArea.Appearance.BackColor = Color.White;
            }
            button.Appearance.BackColor = Color.Blue;
            this.selectArea = button;

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

            string code = (string)this.selectArea.Tag;
            this.areaManage.GetOtherComputers(code,this.areaCodes);
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

        #region 区域的添加删除

        //添加区域
        private void addAreaButton_Click(object sender, EventArgs e)
        {

            StructDictItem.Builder update = new StructDictItem.Builder(this.areas[0]);
            update.ItemList.Clear();
            string newName = (new Random().Next() % 111) + "区域";
            update.AddItem(newName);
            System.Console.WriteLine(update);
            SystemManageNetOperation.UpdateArea(UpdateAreaResult, update.Build());
            return;

            StructDictItem.Builder item = new StructDictItem.Builder();
            item.Code = 0;
            item.Id = 0;
            string areaName = (new Random().Next() % 111) + "区域";
            item.AddItem(areaName);
            SystemManageNetOperation.AddArea(AddAreaResult, item.Build());

        }
        //更新结果回调
        private void UpdateAreaResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_UPDATE)
            {
                return;
            }
            System.Console.WriteLine("UpdateAreaResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(UpdateAreaResult);
            if (result.pack.Content.MessageType == 1)
            {
                isChange = true;
                //重新获取区域列表
                GetAreaList();
                MessageBox.Show("修改成功");
            }
        }
        //添加区域结果回调
        private void AddAreaResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_SYS_ADD)
            {
                return;   
            }

            NetMessageManage.RemoveResultBlock(AddAreaResult);
            System.Console.WriteLine("AddAreaResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                //重新获取区域列表
                GetAreaList();
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
            Dictionary<int, StructRealTime> changeComDict = new Dictionary<int, StructRealTime>();//已经改变的字典
            //3.改变管理工具电脑数组
            foreach (int row in rows)
            {
                StructRealTime.Builder com = new StructRealTime.Builder(this.areaManage.otherComs[row]);
                com.Area = (string)selectArea.Tag;
                changeComDict.Add(com.Computerid, com.Build());
            }
            this.areaManage.UpdateComputersCode(changeComDict);
            //重新赋值
            this.areaManage.GetOtherComputers((string)selectArea.Tag,this.areaCodes);
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
            Dictionary<int, StructRealTime> changeComDict = new Dictionary<int, StructRealTime>();//已经改变的字典
            //改变管理工具电脑数组
            foreach (SimpleButton button in selectButtons)
            {
                int index = int.Parse((string)button.Tag);
                StructRealTime.Builder com = new StructRealTime.Builder(this.areaManage.currentComs[index]);
                com.Area = "0";
                changeComDict.Add(com.Computerid, com.Build());
                //移除按钮
                this.currentComsPanel.Controls.Remove(button);
            }

            this.areaManage.UpdateComputersCode(changeComDict);
            //重新赋值
            this.areaManage.GetOtherComputers((string)selectArea.Tag,this.areaCodes);
            
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
            System.Console.WriteLine("update:" + update);
            SystemManageNetOperation.UpdateAreaComputer(UpdateAreaComputerResult, update);
        }
        //更新区域电脑结果回调
        private void UpdateAreaComputerResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_COMPUTER_UPDATE)
            {
                return;
            }
            System.Console.WriteLine("UpdateAreaComputerResult:" + result.pack);
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

        #region 删除区域
        private void deleteAreaButton_Click(object sender, EventArgs e)
        {
            string code = (string)this.selectArea.Tag;
            List<string> ids = new List<string>() { code };
            SystemManageNetOperation.DeleteArea(DeleteAreaResult, ids);
        }
        //删除区域结果回调
        private void DeleteAreaResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_DEL)
            {
                return;
            }
            System.Console.WriteLine("DeleteAreaResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(DeleteAreaResult);
            if (result.pack.Content.MessageType == 1)
            {
                isChange = true;
                //重新获取区域列表
                GetAreaList();
                MessageBox.Show("删除成功");
            }
        }
        #endregion
    }
}
