using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Model;
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS.Views.HomePage
{
    public partial class HomePageView : RootUserControlView
    {
        //区域列表
        private List<AreaTypeModel> areas;
        //首页列表视图
        private HomePageListView homePageListView = null;
        //首页电脑视图
        private HomePageComputerView homePageComputerView = null;

        public HomePageView()
        {
            InitializeComponent();
            InitUI();
        }
        #region 初始化UI

        private void InitUI()
        {            
            //设置电脑状态Combox
            foreach (string name in Enum.GetNames(typeof(COMPUTERSTATUS)))
            {
                this.comboBoxEdit1.Properties.Items.Add(name);
            }
            //刷新区域
            RefreshAreaCombox();
            //添加视图UI
            AddHomePageListView();
            HomePageMessageManage.AddRefreshAreaComBox(RefreshAreaCombox);
            //获取账户信息
            ManagerManage.Manage().GetAccountInfo(GetAccountInfoResult);
        }   
      
        // 获取账户信息的回调
        public void GetAccountInfoResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_ACCOUNT_INFO)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(GetAccountInfoResult);
            if(result.pack.Content.MessageType == 1)
            {
                //获取首页数据
                HomePageMessageManage.Manage().GetHomePageList(GetHomePageListResult);
            }
        
        }
        #endregion

        #region 刷新区域ComBox
        private void RefreshAreaCombox()
        {
            this.comboBoxEdit2.SelectedIndexChanged -= comboBoxEdit2_SelectedIndexChanged;
            int areaid = -1;
            if (this.comboBoxEdit2.SelectedIndex > 0)
            {
                areaid = this.areas[this.comboBoxEdit2.SelectedIndex - 1].areaId;
            }
            this.comboBoxEdit2.Text = null;
            this.comboBoxEdit2.Properties.Items.Clear();
            //设置区域combox
            this.comboBoxEdit2.Properties.Items.Add("无");
            this.areas = SysManage.Areas;
            foreach (AreaTypeModel model in areas)
            {
                int index = this.comboBoxEdit2.Properties.Items.Add(model.areaName);
                if (areaid == model.areaId)
                {
                    this.comboBoxEdit2.Text = model.areaName;
                }
            }
            this.comboBoxEdit2.SelectedIndexChanged += comboBoxEdit2_SelectedIndexChanged;

        }
        #endregion

        #region 获取首页数据列表
        public void GetHomePageListResult(bool success)
        {
            HomePageMessageManage.Manage().RemoveResultHandel(GetHomePageListResult);
            if (success)
            {
              

            }
        }
        #endregion

        #region 添加首页列表视图
        private void AddHomePageListView()
        {
            if (this.panel1.Controls.Contains(this.homePageListView))
            {
                return;
            }
            //移除代理
            if(this.panel1.Controls.Contains(this.homePageComputerView))
            {
                HomePageMessageManage.RemoveUpdateDataEvent(this.homePageComputerView.UpdateHomePageData,
                    null, 
                    this.homePageComputerView.UpdateHomePageArea, 
                    this.homePageComputerView.FilterComputers);
                this.panel1.Controls.Remove(this.homePageComputerView);
            }
            if (this.homePageListView == null)
            {
                this.homePageListView = new HomePageListView();
            }
            else
            {
                this.homePageListView.FilterComputers();
            }
            this.panel1.Controls.Add(this.homePageListView);
            this.homePageListView.Location = new Point(0, 0);
            this.homePageListView.Size = this.panel1.Size;
            this.homePageListView.Dock = DockStyle.Fill;
            this.homePageListView.BringToFront();
            HomePageMessageManage.AddUpdateDataEvent(this.homePageListView.UpdateHomePageData, 
                this.homePageListView.UpdateHomePageArea,
                null,
                this.homePageListView.FilterComputers);



        }
        #endregion

        #region 添加首页电脑视图
        private void AddHomePageComputerView()
        {
            if (this.panel1.Controls.Contains(this.homePageComputerView))
            {
                return;
            }
            //移除代理
            if (this.panel1.Controls.Contains(this.homePageListView))
            {
                HomePageMessageManage.RemoveUpdateDataEvent(this.homePageListView.UpdateHomePageData,
                    this.homePageListView.UpdateHomePageArea, 
                    null, 
                    this.homePageListView.FilterComputers);
                this.panel1.Controls.Remove(this.homePageListView);
            }

            if (this.homePageComputerView == null)
            {
                this.homePageComputerView = new HomePageComputerView();
            }
            else
            {
                this.homePageComputerView.FilterComputers();
            }
            this.panel1.Controls.Add(this.homePageComputerView);
            this.homePageComputerView.Location = new Point(0, 0);
            this.homePageComputerView.Size = this.panel1.Size;
            this.homePageComputerView.Dock = DockStyle.Fill;
            this.homePageComputerView.BringToFront();
            HomePageMessageManage.AddUpdateDataEvent(this.homePageComputerView.UpdateHomePageData,
                null , 
                this.homePageComputerView.UpdateHomePageArea,
                this.homePageComputerView.FilterComputers);



        }
        #endregion

        #region 按照条件筛选获取设备
        //按照设备查询
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSearchComputers();
        }
        //按照区域查询
        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterSearchComputers();
        }

        //按照关键字搜索
        private void SearchButton_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            FilterSearchComputers();
        }

        private void FilterSearchComputers()
        {

            string key = "";
            if (!this.buttonEdit1.Text.Equals(this.buttonEdit1.Properties.NullText))
            {
                key = this.buttonEdit1.Text;
            }

            COMPUTERSTATUS status = COMPUTERSTATUS.无;
            if(this.comboBoxEdit1.SelectedIndex > 0)
            {
                Enum.TryParse<COMPUTERSTATUS>(this.comboBoxEdit1.Text, out status);
            }

            int areaId = -1;
            if (this.comboBoxEdit2.SelectedIndex > 0)
            {
                AreaTypeModel model = this.areas[this.comboBoxEdit2.SelectedIndex - 1];
                areaId = model.areaId;
            }
            HomePageMessageManage.GetFilterComputers(status, areaId, key);
        }

        #endregion

        #region 修改显示视图
        private void ChangeView_ButtonClick(object sender, EventArgs e)
        {
            if(sender.Equals(this.ComViewButton))
            {
                AddHomePageComputerView();

            } else if(sender.Equals(this.ListViewButton))
            {
                AddHomePageListView();
            }
        }
        #endregion
    }
}
