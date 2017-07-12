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
using NetBarMS.Codes.Tools.NetOperation;

namespace NetBarMS.Views.ManagersManage
{
    public partial class ManagerAddView : RootUserControlView
    {

        public StructRole manager;
        public ManagerAddView(StructRole role)
        {

            InitializeComponent();
            this.titleLabel.Text = "角色添加修改";
            if(role != null)
            {
                manager = role;
                
            }
            InitUI();
        }
        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            //
            if(this.manager != null)
            {
                this.textEdit1.Text = this.manager.Name;
            }
            List<HomePageNodeModel> modelList = XMLDataManage.GetNodesXML();
            AddTreeNode(null, modelList);
            this.treeView1.ShowLines = false;           //不显示线
            this.treeView1.ExpandAll();                 //展开所有节点
            this.treeView1.ShowPlusMinus = false;       //不显示节点图标
            this.treeView1.ItemHeight = 19;
        }
        private void AddTreeNode(TreeNode parent, List<HomePageNodeModel> modelList)
        {

            foreach (HomePageNodeModel nodeModel in modelList)
            {
                TreeNode node = new TreeNode(nodeModel.nodeName);
                node.Tag = nodeModel.nodeTag;
                node.ForeColor = Color.Black;
                node.Tag = nodeModel.nodeid;
                
                if(this.manager != null && !this.manager.Rights.Equals(""))
                {
                  
                   if (ToolsManage.TestRights(this.manager.Rights,nodeModel.nodeid))
                    {
                        node.Checked = true;
                    }
                }
                if(nodeModel.childNodes !=null && nodeModel.childNodes.Count > 0)
                {
                    AddTreeNode(node, nodeModel.childNodes);
                }
                if(parent == null)
                {
                    this.treeView1.Nodes.Add(node);
                }
                else
                {
                    parent.Nodes.Add(node);
                }




            }
        }
        #endregion

        #region 保存
        //保存
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            //更新
            if(this.manager != null)
            {
                Updateanager();
            }
            else
            {
                AddManager();
            }
           



        }
        #region 更新信息
        private void Updateanager()
        {
            string name = this.textEdit1.Text;
            if (!name.Equals("") && !name.Equals(this.manager.Name))
            {
                ManagerNetOperation.UpdateManagerName(UpdateManagerNameResult, int.Parse(this.manager.Roleid), name);
            }

            List<int> rights = new List<int>();
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                //System.Console.WriteLine("node:" + node.Checked);
                if(node.Checked)
                {
                    int nodeId = (int)node.Tag;
                    rights.Add(nodeId);
                }
                foreach (TreeNode child in node.Nodes)
                {
                    if (child.Checked)
                    {
                        int nodeId = (int)child.Tag;
                        rights.Add(nodeId);
                    }
                }
            }

            BigInteger big = ToolsManage.SumRights(rights);
            //System.Console.WriteLine(big.ToString(10));
            ManagerNetOperation.UpdateManagerRights(UpdateManagerRightsResult, int.Parse(this.manager.Roleid), 1, big.ToString(10));

        }

        
        //更新管理员姓名结果回调
        private void UpdateManagerNameResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_ROLE_UPDATE)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(UpdateManagerNameResult);
            System.Console.WriteLine("UpdateManagerNameResult：" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                MessageBox.Show("更新姓名成功");

            }
        }

        //更新管理员权限结果回调
        private void UpdateManagerRightsResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_ROLE_RIGHTS)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(UpdateManagerRightsResult);
            System.Console.WriteLine("UpdateManagerRightsResult：" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                MessageBox.Show("更新权限成功");
            }
        }
        #endregion

        #region 添加
        private void AddManager()
        {
            string name = this.textEdit1.Text;
            if (name.Equals(""))
            {
                return;
            }
            ManagerNetOperation.AddManager(AddManagerResult, name);

        }
        //添加结果回调
        private void AddManagerResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_ROLE_ADD)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(AddManagerResult);
            System.Console.WriteLine("AddManagerResult："+result.pack);

            if(result.pack.Content.MessageType == 1)
            {
                MessageBox.Show("添加成功");
            }
        }
        #endregion
        
        #endregion




    }
}
