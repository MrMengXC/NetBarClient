﻿using System;
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

namespace NetBarMS.Views.HomePage
{
    public partial class LockListView : RootUserControlView
    {
        private enum TitleList
        {
            None = 0,
            Name,
            Card,
            Gender,
            Type,
            LastTime,
            Reason,
            Operation,
        }

        private IList<StructMember> locks;
        private Int32 pageBegin = 0, pageSize = 15;

        public LockListView()
        {
            InitializeComponent();
            InitUI();
        }
        #region 初始化UI
        private void InitUI()
        {
            
            ToolsManage.SetGridView(this.gridView1, GridControlType.LockList, out this.mainDataTable, ButtonColumn_ButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;
            GetLockList();
        }
        #endregion

        #region 获取锁定的会员列表
        //获取锁定的会员列表
        private void GetLockList()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = pageBegin,
                Pagesize = pageSize,
                Fieldname = 0,
                Order = 1,
            };

            string name = this.buttonEdit1.Text;
           
            MemberNetOperation.SearchConditionMember(GetMemberLockListResult, page.Build(), (int)MEMBERSTATUS.锁定, -1, name);

        }
        //获取锁定列表结果回调
        private void GetMemberLockListResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_MEMBER_FIND)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(GetMemberLockListResult);
           // System.Console.WriteLine("GetMemberLockListResult:"+result.pack);

            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {
                    this.locks = result.pack.Content.ScMemberFind.MembersList;
                    RefreshGridControl();
                }));
            }

     
        }
        #endregion

        #region 刷新GridControl
        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            foreach (StructMember member in this.locks)
            {
                AddNewRow(member);
            }

        }
        //添加新行
        private void AddNewRow(StructMember member)
        {
            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);

            row[TitleList.Name.ToString()] = member.Name;
            row[TitleList.Card.ToString()] = member.Cardnumber;
            row[TitleList.Gender.ToString()] = member.Gender;
            row[TitleList.Type.ToString()] = SysManage.GetMemberTypeName(member.Membertype.ToString());
            row[TitleList.LastTime.ToString()] = member.Lasttime;
            row[TitleList.Reason.ToString()] = member.Reason;

        }
        #endregion

        #region 解锁
        //按钮列点击事件
        private void ButtonColumn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs args)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            StructMember member = this.locks[rowhandle];
            //解锁
            List<string> cards = new List<string>() { member.Cardnumber};

            HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.UNLOCK, cards);
        }

        //解锁结果回调
        private void ManagerCommandOperationResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_COMMAND)
            {
                return;
            }
          
            NetMessageManage.RemoveResultBlock(ManagerCommandOperationResult);
            System.Console.WriteLine("ManagerCommandOperationResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {
                    GetLockList();
                    MessageBox.Show("解锁成功");
                }));
            }

        }
        #endregion

        #region 身份证搜索事件
        private void ButtonSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs args)
        {
            GetLockList();
        }
        #endregion
    }
}
