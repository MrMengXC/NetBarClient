using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Model;
using NetBarMS.Codes.Tools;

namespace NetBarMS.Views.ManagerManage
{
    public partial class ManagerAddView : RootUserControlView
    {
        
        public ManagerAddView()
        {

            InitializeComponent();
            this.titleLabel.Text = "角色添加修改";
            InitUI();
        }

        //初始化UI
        private void InitUI()
        {
         
            List<HomePageNodeModel> modelList = XMLDataManage.ReadManagerManageNodesXML();

            foreach (HomePageNodeModel nodeModel in modelList)
            {
                TreeNode rootTreeNode = new TreeNode(nodeModel.nodeName);
                rootTreeNode.Tag = nodeModel.nodeTag;
                rootTreeNode.ForeColor = Color.Black;
                foreach (HomePageNodeModel childNodeModel in nodeModel.childNodes)
                {
                    TreeNode childTreeNode = new TreeNode(childNodeModel.nodeName);
                    childTreeNode.Tag = childNodeModel.nodeTag;
                    childTreeNode.ForeColor = Color.Black;
                    rootTreeNode.Nodes.Add(childTreeNode);
                }
                this.treeView1.Nodes.Add(rootTreeNode);


            }
            this.treeView1.ShowLines = false;           //不显示线
            this.treeView1.ExpandAll();                 //展开所有节点
            this.treeView1.ShowPlusMinus = false;       //不显示节点图标
            this.treeView1.ItemHeight = 19;
        }

        //保存
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach(TreeNode node in this.treeView1.Nodes)
            {
                System.Console.WriteLine("node:"+node.Checked);
                foreach (TreeNode child in node.Nodes)
                {
                    System.Console.WriteLine("child:" + child.Checked);

                }
            }
        }
    }
}
