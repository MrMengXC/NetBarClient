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
using NetBarMS.Codes.Tools.NetOperation;
using DevExpress.XtraEditors.Controls;

namespace NetBarMS.Views.SystemManage
{
    public partial class MemberLevManageView : RootUserControlView
    {
        private IList<StructDictItem> items;

        enum TitleList
        {
            None,
            Check = 0,                  //勾选
            Number,                     //序号
            Type,                       //类别
            RechargeMoney,                   //充值金额
            GiveIntegral,                      //赠送积分
            Operation,                     //操作
        }
        public MemberLevManageView()
        {
            InitializeComponent();
            InitUI();
        }
        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.MemberLevManage, out this.mainDataTable, ColumnButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;
            GetMemberLvList();
        }
        #endregion

        #region 获取会员等级列表
        private void GetMemberLvList()
        {
            SystemManageNetOperation.GetMemberLvSetting(GetMemberLvSettingResult);
        }
        //获取会员等级设置的结果回调
        private void GetMemberLvSettingResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_SYS_INFO)
            {
                return;
            }

            //System.Console.WriteLine("GetMemberLvSetting:" + result.pack);
            NetMessageManage.RemoveResultBlock(GetMemberLvSettingResult);

            if (result.pack.Content.MessageType == 1 && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.lvParent))
            {
                this.Invoke(new RefreshUIHandle(delegate 
                {
                    //更新系统管理数据
                    SysManage.UpdateMemberTypeData(result.pack.Content.ScSysInfo.ChildList);
                    //更新界面
                    items = result.pack.Content.ScSysInfo.ChildList;
                    UpdateGridControlData();
                }));
            }
        }
        #endregion

        #region 更新GridControl 数据
        //更新GridControl
        private void UpdateGridControlData()
        {
            this.mainDataTable.Clear();
            foreach(StructDictItem item in this.items)
            {
                if(item.Code != 1)
                {
                    AddNewRow(item);
                }
           
            }
        }
        //GridControl 添加新行
        private void AddNewRow(StructDictItem item)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.Number.ToString()] = this.mainDataTable.Rows.Count+"";
            row[TitleList.Type.ToString()] = item.GetItem(0);
            row[TitleList.RechargeMoney.ToString()] = item.GetItem(1);
            row[TitleList.GiveIntegral.ToString()] = item.GetItem(2);
        }





        #endregion

        #region 添加会员等级
        //添加会员等级
        private void button1_Click(object sender, EventArgs e)
        {
            MemberLevAddView view = new MemberLevAddView();
            ToolsManage.ShowForm(view, false, CloseMemberLevAddViewBlock);
        }
        //关闭会员添加页面的回调
        private void CloseMemberLevAddViewBlock()
        {
            //刷新列表
            GetMemberLvList();
        }
        #endregion

        #region 按钮列触发事件
        //按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            DataRow row = this.gridView1.GetDataRow(rowhandle);
            StructDictItem item = items[rowhandle];
            MemberLevAddView view = new MemberLevAddView(item);
            ToolsManage.ShowForm(view, false, CloseMemberLevAddViewBlock);
        }

        #endregion

        #region 获取所有勾选的id
        private List<string> GetCheckIds()
        {
            List<string> ids = new List<string>();

            //获取所有勾选的column
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);
                string value = row[TitleList.Check.ToString()].ToString();
                if (value.Equals("True"))
                {
                    StructDictItem item = items[i];
                    ids.Add(item.Id.ToString());
                }
            }
            return ids;
        }
        #endregion

        #region 删除
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> ids = this.GetCheckIds();
            if(ids.Count == 0)
            {
                return;
            }
            SystemManageNetOperation.DeleteMemberLv(DeleteMemberLvResult, ids);


        }
        //获取会员等级设置的结果回调
        private void DeleteMemberLvResult(ResultModel result)
        {
           
            if (result.pack.Cmd != Cmd.CMD_SYS_DEL)
            {
                return;
            }

            System.Console.WriteLine("DeleteMemberLvResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(DeleteMemberLvResult);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate
                {
                    this.GetMemberLvList();
                    MessageBox.Show("删除成功");
                }));
            }
        }
        
#endregion
    }
}
