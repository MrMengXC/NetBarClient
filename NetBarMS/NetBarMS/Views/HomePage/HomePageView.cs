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
using NetBarMS.Views.ProductManage;
using NetBarMS.Codes.Model;
using NetBarMS.Views.RateManage;
using NetBarMS.Views.InCome;
using NetBarMS.Views.SystemSearch;
using NetBarMS.Views.NetUserManage;
using NetBarMS.Views.EvaluateManage;
using NetBarMS.Views.OtherMain;
using NetBarMS.Views.SystemManage;
using NetBarMS.Views.ManagersManage;
using NetBarMS.Codes.Tools.NetOperation;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace NetBarMS.Views.HomePage
{
    public partial class HomePageView : UserControl
    {
        public HomePageView()
        {
            InitializeComponent();
            InitUI();
        }

        //初始化UI
        private void InitUI()
        {
            //添加按钮列
            List<HomePageNodeModel> modelList = XMLDataManage.GetNodesXML();
           
            for (int i = modelList.Count-1; i>=0; i--)
            {
                HomePageNodeModel nodeModel = modelList[i];
                SimpleButton button = new SimpleButton();
                button.Text = nodeModel.nodeName;
                button.Size = new Size(50, 50);
                button.Dock = DockStyle.Top;
                button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                button.Click += Button_Click ;
                button.MouseDown += Button_MouseDown;
                button.Tag = nodeModel.nodeid;
                this.functionPanel.Controls.Add(button);
            }
        }

        //按钮单击事件
        private void Button_Click(object sender, EventArgs e)
        {
            int nodeId = (int)((SimpleButton)sender).Tag;
            HomePageNodeModel nodeModel = XMLDataManage.GetHomePageNodeModel(nodeId);
            ShowView(nodeModel);
        }

        //鼠标右键点击
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
           
            SimpleButton button = (SimpleButton)sender;
            if (e.Button == MouseButtons.Right)
            {
                int nodeId = (int)button.Tag;
                HomePageNodeModel nodeModel = XMLDataManage.GetHomePageNodeModel(nodeId);

                //设置右键弹出框
                if (nodeModel.childNodes.Count > 0)
                {
                    this.popupMenu1.ClearLinks();
                    foreach (HomePageNodeModel model in nodeModel.childNodes)
                    {
                        BarButtonItem item = new BarButtonItem();
                        item.Caption = model.nodeName;
                        item.Tag = model.nodeid;
                        item.ItemClick += Item_ItemClick;
                        this.popupMenu1.AddItem(item);
                    }

                    Point screenPoint = button.PointToScreen(new Point(button.Width, 0));
                   popupMenu1.ShowPopup(screenPoint);
                }
            }

        }
        

        //右键弹出框点击时间
        private void Item_ItemClick(object sender, ItemClickEventArgs e)
        {

            BarButtonItem item = (BarButtonItem)e.Item;
            int nodeId = (int)item.Tag;
            HomePageNodeModel nodeModel = XMLDataManage.GetHomePageNodeModel(nodeId);
            ShowView(nodeModel);

        }
       
        //点击显示视图
        private void ShowView(HomePageNodeModel nodeModel)
        {

            RootUserControlView view = null;
            TreeNodeTag tag = (TreeNodeTag)Enum.Parse(typeof(TreeNodeTag), nodeModel.nodeTag);

            switch (tag)
            {
                case TreeNodeTag.None:

                    break;
                #region 上网用户
                case TreeNodeTag.MemberManage:     //会员管理
                    view = new MemberManageView();
                    break;
                #endregion

                #region 商品管理
                case TreeNodeTag.ProductManage:     //商品管理
                    view = new ProductManageView();
                    break;
                case TreeNodeTag.ProductSellRank:   //商品销售排行
                    view = new ProductSellRankView();
                    break;
                #endregion

                #region 费率管理管理
                case TreeNodeTag.RataManage:     //费率管理
                    view = new RateManageView();
                    break;
                case TreeNodeTag.OtherCostManage:     //其他费用管理
                    view = new OtherCostView();
                    break;
                case TreeNodeTag.IntegralManage:   //积分管理
                    view = new IntegralManageView();
                    break;
                case TreeNodeTag.AwardManage:   //奖励管理
                    view = new AwardManageView();
                    break;
                #endregion

                #region 营收管理
                case TreeNodeTag.InComeManage:   //营收管理
                    view = new DayInComeView();
                    break;
                case TreeNodeTag.DayInCome:   //日营收
                    view = new DayInComeView();
                    break;
                case TreeNodeTag.MonthInCome:   //月营收
                    view = new MonthInComeView();
                    break;
                case TreeNodeTag.YearInCome:   //年营收
                    view = new YearInComeView();
                    break;
                #endregion

                #region 系统查询

                case TreeNodeTag.ChangeShiftsRecord:   //交接班记录查询
                    view = new ChangeShiftsRecordView();
                    break;
                case TreeNodeTag.UserPayedRecord:   //用户充值记录查询
                    view = new UserRechargeView();
                    break;
                case TreeNodeTag.UserNetRecord:   //用户上网记录查询
                    //view = new UserNetRecordView();
                    break;
                case TreeNodeTag.UserConsumeRecord:   //用户消费记录查询
                    view = new UserConsumeRecordView();
                    break;
                case TreeNodeTag.OpenMemberRecord:   //会员办理查询
                    view = new OpenMemberRecordView();
                    break;
                case TreeNodeTag.ProductIndent:   //商品订单查询
                    view = new ProductIndentView();
                    break;
                case TreeNodeTag.AttendanceSearch:   //上座率查询
                    view = new AttendanceSearchView();
                    break;
                #endregion

                #region 绩效考核
                case TreeNodeTag.JXInspect:   //绩效考核
                    view = new JXInspectView();
                    break;
                #endregion

                #region 评价管理
                case TreeNodeTag.NetBarEvaluate:        //管理人员添加
                    view = new NetBarEvaluateView();
                    break;
                case TreeNodeTag.StaffEvaluate:     //管理人员
                    view = new StaffEvaluateView();
                    break;
                #endregion

                #region 系统管理
                case TreeNodeTag.NetPassWord:   //上网密码设置
                    view = new NetPassWordView();
                    break;
                case TreeNodeTag.StaffMoney:   //员工提成
                    view = new StaffMoneyView();
                    break;
                case TreeNodeTag.MemberLevManage:   //会员等级
                    view = new MemberLevManageView();
                    break;
                case TreeNodeTag.ProductType:   //商品类别
                    view = new ProductTypeManageView();
                    break;
                case TreeNodeTag.AreaManage:   //区域设置
                    view = new AreaManageView();
                    break;
                case TreeNodeTag.ClientManage:   //客户端设置
                    view = new ClientManageView();
                    break;
                case TreeNodeTag.BackUpManage:   //备份设置
                    view = new BackUpManageView();
                    break;
                case TreeNodeTag.SmsManage:   //短信设置
                    view = new SmsManageView();
                    break;
                #endregion

                #region 员工账号管理
                case TreeNodeTag.StaffList:        //管理人员添加
                    view = new StaffListView();
                    break;
                case TreeNodeTag.ManagerManage:     //管理人员
                    view = new ManagerManageView();
                    break;
                #endregion

                #region 日志管理
                case TreeNodeTag.LogManage:     //日志管理
                    view = new LogManageView();
                    break;
                #endregion


                default:
                    break;
            }

            if (view != null)
            {
                foreach(UserControl control in this.contentBgPanel.Controls)
                {
                    if(!control.GetType().Equals(typeof(HomePageListView)))
                    {
                        this.contentBgPanel.Controls.Remove(control);
                    }
                }

                view.Dock = DockStyle.Fill;
                this.contentBgPanel.Controls.Add(view);
            }
        }
    }

}
