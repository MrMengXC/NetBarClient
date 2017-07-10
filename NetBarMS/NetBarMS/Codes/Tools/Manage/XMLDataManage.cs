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
