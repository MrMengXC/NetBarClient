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
using NetBarMS.Views.ManagerManage;
using NetBarMS.Codes.Tools.NetOperation;
using DevExpress.XtraEditors;

namespace NetBarMS.Views.HomePage
{
    public partial class HomePageView : RootUserControlView
    {

        public HomePageView()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            //添加按钮列
            //添加点击事件
            //this.manageTreeView.NodeMouseClick += ManageTreeViewNodeMouseClick;
            //this.manageTreeView.ShowLines = false;
            //this.manageTreeView.ImageIndex

            List<HomePageNodeModel> modelList = XMLDataManage.ReadNodesXML();
           
            for (int i = modelList.Count-1; i>=0; i--)
            {
                HomePageNodeModel nodeModel = modelList[i];
                SimpleButton button = new SimpleButton();
                button.Text = nodeModel.nodeName;
                button.Size = new Size(50, 50);
                button.Dock = DockStyle.Top;
                button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                
                this.functionPanel.Controls.Add(button);



                //TreeNode rootTreeNode = new TreeNode(nodeModel.nodeName);
                //rootTreeNode.Tag = nodeModel.nodeTag;
                //rootTreeNode.ForeColor = Color.White;

                //foreach (HomePageNodeModel childNodeModel in nodeModel.childNodes)
                //{
                //    TreeNode childTreeNode = new TreeNode(childNodeModel.nodeName);
                //    childTreeNode.Tag = childNodeModel.nodeTag;
                //    rootTreeNode.Nodes.Add(childTreeNode);
                //    childTreeNode.ForeColor = Color.White;

                //}
                //this.manageTreeView.Nodes.Add(rootTreeNode);


            }


        }






    }

}
