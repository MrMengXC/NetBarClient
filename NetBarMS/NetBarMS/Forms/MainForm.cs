using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Forms;
using System.Xml;
using System.IO;
using XPTable.Models;
using NetBarMS.Codes.Model;
using NetBarMS.Codes.Tools;

using NetBarMS.Views;
using NetBarMS.Views.RateManage;
using NetBarMS.Views.NetUserManage;
using NetBarMS.Views.ProductManage;
using NetBarMS.Views.InCome;
using NetBarMS.Views.ManagerManage;
using NetBarMS.Views.SystemManage;
using NetBarMS.Views.SystemSearch;
using NetBarMS.Views.EvaluateManage;
using NetBarMS.Views.OtherMain;
using NetBarMS.Views.HomePage;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Views.UserUseCp;
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS
{

   
    public partial class MainForm : Form
    {

        private HomePageListView homePageListView = null;
        private HomePageComputerView homePageComputerView = null;

        public MainForm()
        {
            InitializeComponent();
            
            //初始化树形菜单
            InitManageTreeView();
            //添加首页视图
            AddHomePageListView();

            //添加系统消息监听
            AddMsgDelegate();
           

        }

        //添加系统消息监听
        private void AddMsgDelegate()
        {
            HomePageMessageManage.Manage().AddMsgNumDelegate(UpdateCallMsgNumResult,UpdateExceptionMsgNumResult,UpdateOrderMsgNumResult);
        }
        //呼叫消息通知回调
        private void UpdateCallMsgNumResult(int num)
        {
            this.Invoke(new UIHandleBlock(delegate {
                this.simpleButton7.Text = "呼叫服务\n" + num;
            }));

        }
        //客户端报错消息通知回调
        private void UpdateExceptionMsgNumResult(int num)
        {
            this.Invoke(new UIHandleBlock(delegate {
                this.simpleButton8.Text = "客户端异常\n" + num;

            }));

        }
        //订单消息通知回调
        private void UpdateOrderMsgNumResult(int num)
        {
            this.Invoke(new UIHandleBlock(delegate {
                this.simpleButton6.Text = "商品订单\n" + num;
            }));

        }
        //添加首页列表视图
        private void AddHomePageListView()
        {
            if (this.homePageListPanel.Controls.Contains(this.homePageListView) == true)
            {
                return;
            }

            if (this.homePageListView == null)
            {
                this.homePageListView = new HomePageListView();
            }
            if(this.homePageComputerView != null)
            {
                this.Controls.Remove(this.homePageComputerView);
            }
            this.homePageListPanel.Controls.Add(this.homePageListView);
            this.homePageListView.Location = new Point(0,0);
            this.homePageListView.Size = this.homePageListPanel.Size;
            //this.homePageListView.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.homePageListView.Dock = DockStyle.Fill;//AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.homePageListView.BringToFront();
        }

        #region 初始化TreeView
        private void InitManageTreeView()
        {
            //添加点击事件
            this.manageTreeView.NodeMouseClick += ManageTreeViewNodeMouseClick;
            this.manageTreeView.ShowLines = false;
            //this.manageTreeView.ImageIndex
           
            List<HomePageNodeModel> modelList = XMLDataManage.GetNodesXML();

            foreach(HomePageNodeModel nodeModel in modelList)
            {
                TreeNode rootTreeNode = new TreeNode(nodeModel.nodeName);
                rootTreeNode.Tag = nodeModel.nodeTag;
                rootTreeNode.ForeColor = Color.White;

                foreach (HomePageNodeModel childNodeModel in nodeModel.childNodes)
                {
                    TreeNode childTreeNode = new TreeNode(childNodeModel.nodeName);
                    childTreeNode.Tag = childNodeModel.nodeTag;
                    rootTreeNode.Nodes.Add(childTreeNode);
                    childTreeNode.ForeColor = Color.White;

                }
                this.manageTreeView.Nodes.Add(rootTreeNode);


            }

        }
        #endregion

        #region 树形结构控件点击事件
        private void ManageTreeViewNodeMouseClick(object sender,TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Bounds.Contains(e.Location))
            {
                this.manageTreeView.SelectedNode = e.Node;
                //System.Console.WriteLine("e.Node.Tag:"+ e.Node.Tag);
                RootUserControlView view = null;
                TreeNodeTag tag = (TreeNodeTag)Enum.Parse(typeof(TreeNodeTag), (string)e.Node.Tag);
                CloseFormHandle closeEvent = null;

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
                        view = new MemberRechargeView();
                        break;
                    case TreeNodeTag.UserNetRecord:   //用户上网记录查询
                        view = new UserNetRecordView();
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
                    
                    ToolsManage.ShowForm(view,false, closeEvent);
                }
            

            }
           
        }

        #endregion

        //列表视图按钮点击事件
        private void simpleButton2_Click(object sender, EventArgs e)
        {

            AddHomePageListView();

        }
        //电脑视图点击事件 
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (this.homePageListPanel.Controls.Contains(this.homePageComputerView) == true)
            {
                return;
            }

            if (this.homePageComputerView == null)
            {
                this.homePageComputerView = new HomePageComputerView();
            }
            if (this.homePageListView != null)
            {
                this.homePageListPanel.Controls.Remove(this.homePageListView);

            }

            this.homePageListPanel.Controls.Add(this.homePageComputerView);
            this.homePageComputerView.Location = new Point(0, 0);
            this.homePageComputerView.Size = this.homePageListPanel.Size;
            this.homePageComputerView.Dock = DockStyle.Fill;//AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.homePageComputerView.BringToFront();
        }

        /// <summary>
        /// 用户开卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            OpenMemberView view = new OpenMemberView();
            ToolsManage.ShowForm(view, false);
        }

        /// <summary>
        /// 用户充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            UserPayView view = new UserPayView();
            ToolsManage.ShowForm(view, false);
        }
        /// <summary>
        /// 用户结算回调
        /// </summary>
        /// <param name="model"></param>
        private void CardCheckOutBlock(ResultModel model)
        {
            System.Console.WriteLine(model.pack);


        }

        #region 顶部菜单的按钮功能

        //关闭闲机
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            CloseMacheView view = new CloseMacheView();
            ToolsManage.ShowForm(view, false);
        }
        //全部结帐
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            CheckOutView view = new CheckOutView();
            ToolsManage.ShowForm(view, false);
        }
        //交班
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            ChangeShiftsView view = new ChangeShiftsView();
            ToolsManage.ShowForm(view, false);
        }

        //商品订单
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            PayedProductIndentView view = new PayedProductIndentView();
            ToolsManage.ShowForm(view, false);
        }

        //呼叫服务
        private void simpleButton7_Click(object sender, EventArgs e)
        {
            CallServiceView view = new CallServiceView();
            ToolsManage.ShowForm(view, false);
        }
        //客户端异常
        private void simpleButton8_Click(object sender, EventArgs e)
        {




        }
        //消息发送
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            ChatManageView view = new ChatManageView();
            ToolsManage.ShowForm(view, false);
        }
        //解锁
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            LockListView view = new LockListView();
            ToolsManage.ShowForm(view, false);
        }

        //开卡
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            ReminderScanView view = new ReminderScanView();
            ToolsManage.ShowForm(view, false);
        }

        //上网
        private void simpleButton13_Click(object sender, EventArgs e)
        {
            UserActiveView view = new UserActiveView();
            ToolsManage.ShowForm(view, false);
        }
        #endregion


    }
}





