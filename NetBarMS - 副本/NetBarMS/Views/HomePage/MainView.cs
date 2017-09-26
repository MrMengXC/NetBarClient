#define PRODUCT
#region using
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
using NetBarMS.Views.UserUseCp;
using NetBarMS.Codes.Tools.Manage;
#endregion

namespace NetBarMS.Views.HomePage
{
    public partial class MainView : UserControl
    {
        private char[] sp = { '\n', ':', '：' };
        /// <summary>
        /// 是否是办理会员
        /// </summary>
        private bool IsOpenMember = false;
        /// <summary>
        /// 是否是激活
        /// </summary>
        private bool IsActiveCard = false;

        /// <summary>
        /// 当前选择的列表按钮
        /// </summary>
        private SimpleButton selectButton = null;
        /// <summary>
        /// 选择时候的背景颜色
        /// </summary>
        private static Color SEL_BACK_COLOR = Color.FromArgb(255, Color.White);
        private static Color NOR_BACK_COLOR = Color.FromArgb((int)(255 * 0.1), Color.White);


        public MainView()
        {
            InitializeComponent();
            InitUI();  
        }

        #region 初始化UI
        private void InitUI()
        {
            MainViewManage.MainView = this.mainPanel ;
            //添加按钮列
            List<HomePageNodeModel> modelList = XMLDataManage.GetNodesXML();           
            for (int i = modelList.Count-1; i>=0; i--)
            {
                HomePageNodeModel nodeModel = modelList[i];
                SimpleButton button = new SimpleButton();
                button.Text = nodeModel.nodeName;
                button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                button.Appearance.BackColor = NOR_BACK_COLOR;
                button.Size = new Size(50, 50);
                button.ForeColor = Color.White;
                button.Font = new Font("宋体", 15, GraphicsUnit.Pixel);
                button.Margin = new Padding(0);
                button.Padding = new Padding(0);
                button.Dock = DockStyle.Top;
                button.AllowFocus = false;
                button.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
                //button.ImageToTextAlignment = ImageAlignToText.LeftCenter;
                button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                button.Click += Button_Click ;
                button.Tag = nodeModel;
                button.Paint += Button_Paint;
                if (nodeModel.imgName == null || nodeModel.imgName == "" )
                {
                    button.Image = Imgs.icon_huiyuan;
                }
                else
                {
                    button.Image = Imgs.GetBitImg(nodeModel.imgName);
                }
                this.functionPanel.Controls.Add(button);
                Image img = Imgs.GetBitImg(nodeModel.imgName);
            }
            ////添加首页视图
            AddHomePageView();
            //添加系统消息监听
            AddMsgDelegate();
        }
        #endregion

        #region 列表按钮重新绘制
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            SimpleButton button = sender as SimpleButton;
            Rectangle rect = button.ClientRectangle;
            Graphics gr = e.Graphics;
            Color bc = Color.FromArgb(20, Color.White);
            ControlPaint.DrawBorder(gr, rect,
                bc, ButtonBorderStyle.Solid);
                //bc, 1, ButtonBorderStyle.Solid,
                //Color.Transparent, 0, ButtonBorderStyle.None,
                //bc, 1, ButtonBorderStyle.Solid);




        }
        #endregion

        #region 添加系统消息监听
        private void AddMsgDelegate()
        {
            HomePageMessageManage.Manage().AddMsgNumDelegate(UpdateMsgNumResult, UpdateDailyDataResult, UpdateStatusNum);
        }
        //刷新状态数量显示
        private void UpdateStatusNum()
        {

            this.Invoke(new RefreshUIHandle(delegate {

                Dictionary<string, int> dict = HomePageMessageManage.StatusNum;
                int idle = 0, online = 0, hangup = 0, exception = 0;
                dict.TryGetValue(((int)COMPUTERSTATUS.空闲).ToString(), out idle);
                dict.TryGetValue(((int)COMPUTERSTATUS.在线).ToString(), out online);
                dict.TryGetValue(((int)COMPUTERSTATUS.挂机).ToString(), out hangup);
                dict.TryGetValue(((int)COMPUTERSTATUS.异常).ToString(), out exception);

                //当前上网上网人数（在线+关机）
                this.netUserLabel.Text = string.Format("{0}\n{1}", (online + hangup), this.netUserLabel.Text.Split(sp)[1]);
                //当前占座率
                this.attenDanceLabel.Text = string.Format("{0}%\n{1}", (online + hangup) * 100 / (online + hangup + exception + idle), this.attenDanceLabel.Text.Split(sp)[1]);


            }));

        }
        //呼叫消息通知回调
        private void UpdateMsgNumResult()
        {
            this.Invoke(new RefreshUIHandle(delegate {

                this.homePageButton5.Num = HomePageMessageManage.CallMsgNum;
                this.homePageButton4.Num = HomePageMessageManage.OrderMsgNum;
                this.homePageButton6.Num = HomePageMessageManage.ExceptionMsgNum;
            }));

        }
        //日上机用户消息通知回调
        private void UpdateDailyDataResult()
        {
            this.Invoke(new RefreshUIHandle(delegate {
                this.dailyOnlineCountLabel.Text = string.Format("{0}\n{1}", HomePageMessageManage.DailyOnlineCount, this.dailyOnlineCountLabel.Text.Split(sp)[1]);
                this.amountLabel.Text = string.Format("{0}\n{1}", HomePageMessageManage.DailyTradeAmount, this.amountLabel.Text.Split(sp)[1]);
            }));

        }
        #endregion

        #region 添加首页列表视图
        private void AddHomePageView()
        {

            HomePageView homePage = new HomePageView();
            this.mainPanel.Controls.Add(homePage);
            homePage.Location = new Point(0, 0);
            homePage.Size = this.mainPanel.Size;
            homePage.Dock = DockStyle.Fill;
            homePage.BringToFront();
        }
        #endregion

        #region 按钮单击事件
        private void Button_Click(object sender, EventArgs e)
        {
            HomePageNodeModel nodeModel = (HomePageNodeModel)(((SimpleButton)sender).Tag);
            //列表类型
            bool isList = nodeModel.childNodes.Count > 0;


            if (selectButton == sender && !isList)
            {
                return;
            }

            //设置回原来的样子
            if(selectButton != null)
            {
                HomePageNodeModel selectNodeModel = (HomePageNodeModel)(selectButton.Tag);
                selectButton.ForeColor = Color.White;
                selectButton.Appearance.BackColor = NOR_BACK_COLOR;
                if (selectNodeModel.imgName == null || selectNodeModel.imgName == "")
                {
                    selectButton.Image = Imgs.icon_huiyuan;
                }
                else
                {
                    selectButton.Image = Imgs.GetBitImg(selectNodeModel.imgName);
                }
            }

            //设置成选择状态
            selectButton = sender as SimpleButton;
            selectButton.ForeColor = Color.FromArgb(108, 140, 190);
            selectButton.Appearance.BackColor = SEL_BACK_COLOR;
            if (nodeModel.selName == null || nodeModel.selName == "")
            {
                selectButton.Image = Imgs.icon_huiyuan2;
            }
            else
            {
                selectButton.Image = Imgs.GetBitImg(nodeModel.selName);
            }
            //判断是否有子菜单
            //设置右键弹出框
            if (isList)
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

                Point screenPoint = selectButton.PointToScreen(new Point(selectButton.Width, 0));
                popupMenu1.ShowPopup(screenPoint);
            }
            else
            {
                //显示右侧内容列表
                ShowView(nodeModel);
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
        #endregion
         
        #region 点击显示视图
        private void ShowView(HomePageNodeModel nodeModel)
        {
            if(!ManagerManage.Manage().IsRightUse(nodeModel.nodeid))
            {
                return;
            }
            RootUserControlView view = null;
            TreeNodeTag tag = (TreeNodeTag)Enum.Parse(typeof(TreeNodeTag), nodeModel.nodeTag);

            switch (tag)
            {
                case TreeNodeTag.None:

                    break;

                #region 首页
                case TreeNodeTag.HomePage:
                    {

                    }
                    break;
                #endregion

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
                   // view = new StaffMoneyView();
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

                #region 设备信息管理
                case TreeNodeTag.EquipmentInfo:
                    view = new SoftwareMsgManageView();
                    break;

                #endregion

                default:
                    break;
            }

            MainViewManage.ShowView(view);
        }
        #endregion
       
        #region 顶部菜单的按钮功能
        //关闭闲机
        private void CloseMache_ButtonClick(object sender, EventArgs e)
        {
            CloseMacheView view = new CloseMacheView();
            ToolsManage.ShowForm(view, false);
        }
        //全部结帐
        private void CheckOut_ButtonClick(object sender, EventArgs e)
        {
            CheckOutView view = new CheckOutView();
            ToolsManage.ShowForm(view, false);
        }
        //交班
        private void ChangeShifts_ButtonClick(object sender, EventArgs e)
        {
            ChangeShiftsView view = new ChangeShiftsView();
            MainViewManage.ShowView(view);
        }

        //商品订单
        private void PayedProductIndent_ButtonClick(object sender, EventArgs e)
        {
            PayedProductIndentView view = new PayedProductIndentView();
            MainViewManage.ShowView(view);
        }

        //呼叫服务
        private void CallService_ButtonClick(object sender, EventArgs e)
        {
            CallServiceView view = new CallServiceView();
            ToolsManage.ShowForm(view, false);
        }
        //客户端异常
        private void ClientExpection_ButtonClick(object sender, EventArgs e)
        {




        }
        //消息发送
        private void ChatManage_ButtonClick(object sender, EventArgs e)
        {
            ChatManageView view = new ChatManageView();
            MainViewManage.ShowView(view);
        }
        //锁定列表
        private void LockList_ButtonClick(object sender, EventArgs e)
        {
            LockListView view = new LockListView();
            MainViewManage.ShowView(view);
        }

        //开通会员
        private void OpenMember_ButtonClick(object sender, EventArgs e)
        {
#if PRODUCT
            //先连接设备进行读卡
            this.IsOpenMember = true;
            IdCardReaderManage.ReadCard(ReadCardResult, ConnectReaderResult, AuthenticateCardResult);

#else
            OpenMemberView view = new OpenMemberView(null);
            MainViewManage.ShowView(view);
#endif

        }

        // 激活上网
        private void UserActive_ButtonClick(object sender, EventArgs e)
        {
#if PRODUCT
            //先连接设备进行读卡
            this.IsActiveCard = true;
            IdCardReaderManage.ReadCard(ReadCardResult, ConnectReaderResult, AuthenticateCardResult);
#else
            UserActiveView view = new UserActiveView();
            ToolsManage.ShowForm(view, false);
#endif
        }

        #endregion

        #region 与读卡器交互回调

        //读卡结果
        private void ReadCardResult(StructCard readCard, bool isSuccess)
        {
            if (readCard != null && isSuccess)
            {
                //激活
                RefreshUIHandle active = new RefreshUIHandle(delegate
                {
                    this.IsActiveCard = false;
                    UserActiveView view = new UserActiveView(readCard);
                    ToolsManage.ShowForm(view, false);
                });
                //开通会员
                RefreshUIHandle open = new RefreshUIHandle(delegate
                {
                    this.IsOpenMember = false;
                    OpenMemberView view = new OpenMemberView(readCard);
                    MainViewManage.ShowView(view);
                });

                IdCardReaderManage.RemoveEvent(ReadCardResult, ConnectReaderResult, AuthenticateCardResult);
                if (this.InvokeRequired)
                {
                    if (this.IsOpenMember) { this.Invoke(open); }
                    else if (this.IsActiveCard) { this.Invoke(active); }

                }
                else
                {
                    if (this.IsOpenMember) { open(); }
                    else if (this.IsActiveCard) { active(); }
                }
            }
            else
            {
                this.IsOpenMember = this.IsActiveCard = false;
                IdCardReaderManage.OffCardReader(ReadCardResult, ConnectReaderResult, AuthenticateCardResult);
                MessageBox.Show("读取身份证信息失败");
            }


        }
        //认证是否放身份证回调
        private void AuthenticateCardResult(bool isSuccess)
        {

            if (!isSuccess)
            {
                this.IsOpenMember = this.IsActiveCard = false;
                IdCardReaderManage.OffCardReader(ReadCardResult, ConnectReaderResult, AuthenticateCardResult);
                MessageBox.Show("请放置身份证");
            }
        }
        //连接读卡器回调
        private void ConnectReaderResult(bool isSuccess)
        {
            if (!isSuccess)
            {
                this.IsOpenMember = this.IsActiveCard = false;
                IdCardReaderManage.OffCardReader(ReadCardResult, ConnectReaderResult, AuthenticateCardResult);
                MessageBox.Show("请检查读卡器是否连接");
            }
        }
        #endregion

    }

}
