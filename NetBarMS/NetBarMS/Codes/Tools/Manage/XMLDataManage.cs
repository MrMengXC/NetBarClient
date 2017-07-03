using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NetBarMS.Codes.Model;

namespace NetBarMS.Codes.Tools
{

    public enum TreeNodeTag
    {

        None = 1,
        NetRecord,              //上网记录
        MemberManage,           //会员管理

        ProductManage,          //上架商品管理
        ProductSellRank,        //销售排行

        RataManage,         //费率管理
        AwardManage,        //奖励管理
        IntegralManage,     //积分管理
        OtherCostManage,    //其他费用管理

        InComeManage,       //营收管理
        DayInCome,          //日营收
        MonthInCome,        //月营收
        YearInCome,         //年营收

        UserNetRecord,      //用户上网记录
        UserPayedRecord,    //用户充值记录
        UserConsumeRecord,  //用户消费记录
        //ProductSellRecord,  //商品销售记录
        OpenCardRecord,     //开卡记录
        ChangeShiftsRecord, //交接班记录
        ProductIndent,      //商品订单查寻
        OpenMemberRecord,        //  会员办理记录
        AttendanceSearch,       //上座率查询

        JXInspect,          //绩效考核

        NetBarEvaluate,     //网吧评价
        StaffEvaluate,      //员工评价

        NetPassWord,        //上网密码
        StaffMoney,         //员工提成
        MemberLevManage,        //会员等级
        ProductType,        //商品类别
        ClientManage,       //客户端管理
        AreaManage,         //区域管理
        BackUpManage,       //备份管理
        SmsManage,          //短信管理

        StaffList,          //员工列表
        ManagerManage,      //管理人员

        LogManage,          //日志管理


    }
    public enum GridControlType
    {
        
        None = 1,
        HomePageList,           //主页列表
        OpenMember,             //开通会员
        LockList,               //被锁列表
        PayedProductIndent,     //已付款商品订单
        NetRecord,              //上网记录
        MemberManage,           //会员管理
        ProductManage,      //上架商品管理
        ProductStockList,   //商品库存清单
        ProductIndent,      //商品订单查询
        ProductIndentDetail,      //商品订单详情

        RataManage,         //费率管理
        NormalAward,        //正常奖励
        MemberDayAward,     //会员日奖励
        InComeDetail,       //营收详情
        ChatManage,         //聊天管理
        JXInspect,          //绩效考核

        UserNetRecord,      //用户上网记录
        UserConsumeRecord,  //用户消费记录
        ProductSellRecord,  //商品销售记录
        OpenCardRecord,     //开卡记录
        ChangeShiftsRecord, //交接班记录
   
        OpenMemberRecord,       //会员办理记录
        MemberRechargeRecord,       //会员充值记录


        NetBarEvaluate,     //网吧评价
        StaffEvaluate,      //员工评价
        MsgBoard,           //留言板


        MemberLevManage,        //会员等级
        ProductType,        //商品类别
        ClientManage,       //客户端管理
        AreaManage,         //区域管理
        BackUpManage,       //备份管理
        SmsManage,          //短信管理
        ManagerManage,      //管理人员
        LogManage,          //日志管理
        CallService,        //呼叫服务
        StaffList,          //员工列表
        ProductSellRank,    //产品销售排行


        DayIncomeDetail,          //日营收
        MonthIncomeDetail,          //月营收
        YearIncomeDetail,          //年营收

    }

    class XMLDataManage
    {
        
        private static XMLDataManage manage = null;
        private Dictionary<string,GridControlModel> gridControlDict = new Dictionary<string,GridControlModel>();

        private List<HomePageNodeModel> homepageNodes = new List<HomePageNodeModel>();
        private Dictionary<int, HomePageNodeModel> homePageNodeDict = new Dictionary<int, HomePageNodeModel>();



        #region Static Fuc
        /// <summary>
        ///单例方法
        /// </summary>
        /// <returns></returns>
        private static XMLDataManage Manage()
        {
           
            if(manage == null)
            {
                manage = new XMLDataManage();
                manage.ReadGridControlXML();
                manage.ReadNodesXML();
            }
            return manage;
        }
        public static void Init()
        {
            XMLDataManage.Manage();
        }

        /// <summary>
        /// 获取主页树节点的数据
        /// </summary>
        public static List<HomePageNodeModel> GetNodesXML()
        {

            return XMLDataManage.Manage().homepageNodes;

        }



        private static List<HomePageNodeModel> GetTreeNodes(string xmlFilePath)
        {
            //SimpleButton
            List<HomePageNodeModel> datas = new List<HomePageNodeModel>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList nodeList = xmlDoc.SelectNodes("//ManageNode//Node");

            foreach (XmlElement nodeEle in nodeList)
            {

                List<HomePageNodeModel> childNodes = new List<HomePageNodeModel>();
                XmlNodeList childNodeList = nodeEle.SelectNodes("child");

                foreach (XmlElement childEle in childNodeList)
                {
                    string childNodeTag = childEle.GetAttribute("tag") == null || childEle.GetAttribute("tag") == "" ? "None" : childEle.GetAttribute("tag");
                    int childNodeId = childEle.GetAttribute("id") == null || childEle.GetAttribute("id") == "" ? 0 : int.Parse(childEle.GetAttribute("id"));

                    HomePageNodeModel childNodeModel = new HomePageNodeModel()
                    {
                        nodeName = childEle.GetAttribute("name"),
                        nodeTag = childNodeTag,
                        nodeid = childNodeId,
                    };
                    childNodes.Add(childNodeModel);

                }

                string nodeTag = nodeEle.GetAttribute("tag") == null || nodeEle.GetAttribute("tag") == "" ? "None" : nodeEle.GetAttribute("tag");
                int nodeId = nodeEle.GetAttribute("id") == null || nodeEle.GetAttribute("id") == "" ? 0 : int.Parse(nodeEle.GetAttribute("id"));

                HomePageNodeModel nodeModel = new HomePageNodeModel()
                {
                    nodeName = nodeEle.GetAttribute("name"),
                    childNodes = childNodes,
                    nodeTag = nodeTag,
                    nodeid = nodeId,
                };
               

                datas.Add(nodeModel);

            }
            return datas;
        }
        #endregion

        #region 获取节点数据

        private void ReadNodesXML()
        {
            string xmlFilePath = Application.StartupPath + "//ManageNodes.xml";
            homepageNodes = XMLDataManage.GetTreeNodes(xmlFilePath);
            foreach (HomePageNodeModel model in homepageNodes)
            {
                foreach (HomePageNodeModel child in model.childNodes)
                {
                    this.homePageNodeDict[child.nodeid] = child;

                }
                this.homePageNodeDict[model.nodeid] = model;

            }
        }
        #endregion

        #region 获取GridControl 的数据
        /// <summary>
        /// 获取GridControl 的标题数据
        /// </summary>
        /// <returns></returns>
        private void ReadGridControlXML()
        {

            string xmlFilePath = Application.StartupPath + "//GridControl.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList gridList = xmlDoc.SelectNodes("//gridcontrol//grid");
    
            foreach (XmlElement nodeEle in gridList)
            {
                string key = nodeEle.GetAttribute("type");
                GridControlModel model = new GridControlModel();
                List<ColumnModel> columns = new List<ColumnModel>();

                XmlNodeList columnList = nodeEle.SelectNodes("column");
                foreach (XmlElement columnEle in columnList)
                {
                    ColumnModel column = new ColumnModel();
                    column.name = columnEle.GetAttribute("name");
                    column.field = columnEle.GetAttribute("field") == null || columnEle.GetAttribute("field") == ""? "None":columnEle.GetAttribute("field");
                    column.tag = columnEle.GetAttribute("tag") == null || columnEle.GetAttribute("tag") == "" ? "-1" : columnEle.GetAttribute("tag");
                    column.type = (ColumnType)Enum.Parse(typeof(ColumnType), columnEle.GetAttribute("type"));

                    switch(column.type)
                    {
                        case ColumnType.C_Button:
                            char[] sp = {'/'};
                            string[] names = columnEle.GetAttribute("bnames").Split(sp);
                            column.buttonNames = names.ToList<string>();
                            break;

                        default:
                            break;
                    }


                    columns.Add(column);
                }
                model.columns = columns;

                this.gridControlDict.Add(key, model);
              
            }


        }
        #endregion

        public static GridControlModel GetGridControlModel(string type)
        {

            GridControlModel model = null;

            XMLDataManage.Manage().gridControlDict.TryGetValue(type, out model);
            return model;
        }
        public static HomePageNodeModel GetHomePageNodeModel(int nodeId)
        {
            HomePageNodeModel model = null;
            XMLDataManage.Manage().homePageNodeDict.TryGetValue(nodeId, out model);
            return model;
        }
    }


}
