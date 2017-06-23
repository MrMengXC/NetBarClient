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
        LockList,           //被锁列表
        PayedProductIndent,
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
    }

    class XMLDataManage
    {
        
        private static XMLDataManage manage = null;
        private Dictionary<string,GridControlModel> gridControlDict = new Dictionary<string,GridControlModel>();

        /// <summary>
        /// 获取主页树节点的数据
        /// </summary>
        /// <returns></returns>
        public static List<HomePageNodeModel> ReadNodesXML()
        {

            // xmlDoc.Load(Directory.GetCurrentDirectory() + a.xml)
            List<HomePageNodeModel> datas = new List<HomePageNodeModel>();
            string xmlFilePath = Application.StartupPath + "//ManageNodes.xml";//Directory.GetCurrentDirectory() +  "ManageNodes.xml";
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

                    HomePageNodeModel childNodeModel = new HomePageNodeModel()
                    {
                        nodeName = childEle.GetAttribute("name"),
                        nodeTag = childNodeTag,
                    };
                    childNodes.Add(childNodeModel);

                }

                string nodeTag = nodeEle.GetAttribute("tag") == null||nodeEle.GetAttribute("tag") == "" ? "None" : nodeEle.GetAttribute("tag");

                HomePageNodeModel nodeModel = new HomePageNodeModel()
                {
                    nodeName = nodeEle.GetAttribute("name"),
                    childNodes = childNodes,
                    nodeTag = nodeTag,
                };
       
                datas.Add(nodeModel);

            }
            return datas;


        }

        /// <summary>
        ///单例方法
        /// </summary>
        /// <returns></returns>
        public static XMLDataManage Instance()
        {
           
            if(manage == null)
            {
                manage = new XMLDataManage();
                manage.ReadGridControlXML();
            }
            return manage;
        }

        /// <summary>
        /// 获取GridControl 的标题火数据
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


        public GridControlModel GetGridControlModel(string type)
        {

            GridControlModel model = null;
            this.gridControlDict.TryGetValue(type, out model);
            return model;
        }
    }


}
