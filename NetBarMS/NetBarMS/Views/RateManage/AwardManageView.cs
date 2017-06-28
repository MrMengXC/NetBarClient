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
using static NetBarMS.Codes.Tools.NetMessageManage;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace NetBarMS.Views.RateManage
{
    public partial class AwardManageView : RootUserControlView
    {

        enum TitleList
        {
            None,
            Check = 0,
            Number,
            MemberType,
            RechargeMoney,
            GiveMoney,
            ValidDay,
        }

        private DataTable table1;
        private DataTable table2;
        private IList<StructDictItem> nitems;
        private IList<StructDictItem> mitems;
        private DateTime nlastDate = DateTime.MinValue,mlastDate = DateTime.MinValue;
        private string nstartTime = "", nendTime = "", mstartTime = "", mendTime = "";

   


        public AwardManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "充值奖励管理";
            InitUI();
        }
        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.NormalAward, out this.table1);
            this.gridControl1.DataSource = this.table1;

            ToolsManage.SetGridView(this.gridView4, GridControlType.MemberDayAward, out this.table2);
            this.gridControl2.DataSource = this.table2;

            //设置两个ComboBox

            string[] types = {"普通会员", "黄金会员","钻石会员"};
            foreach(string type in types)
            {
                this.comboBoxEdit1.Properties.Items.Add(type);
                this.comboBoxEdit3.Properties.Items.Add(type);

            }
            this.comboBoxEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.popupContainerEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.comboBoxEdit3.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.popupContainerEdit2.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;

            this.dateNavigator1.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator1.UpdateSelectionWhenNavigating = false;
            this.dateNavigator1.SyncSelectionWithEditValue = false;
            //获取数据
            RateManageNetOperation.AwardManageList(AwardManageListResult);
            RateManageNetOperation.MemberDayAwardManageList(MemberDayAwardManageListResult);


        }
        #endregion

        #region 获取奖励列表/会员日奖励列表
        //获取奖励列表结果回调
        private void AwardManageListResult(ResultModel result)
        {
            System.Console.WriteLine(result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if(result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(RateManageNetOperation.awardParent))
            {

                NetMessageManage.Manage().RemoveResultBlock(AwardManageListResult);
                this.Invoke(new UIHandleBlock(delegate
                {
                    this.nitems = result.pack.Content.ScSysInfo.ChildList;
                    UpdateGridControlData(result.pack.Content.ScSysInfo,this.table1);

                }));
            }
        }

        //获取会员日奖励列表结果回调
        private void MemberDayAwardManageListResult(ResultModel result)
        {
            System.Console.WriteLine(result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(RateManageNetOperation.memberDayAwardParent))
            {
                NetMessageManage.Manage().RemoveResultBlock(MemberDayAwardManageListResult);
                
                this.Invoke(new UIHandleBlock(delegate
                {
                    this.mitems = result.pack.Content.ScSysInfo.ChildList;
                    UpdateGridControlData(result.pack.Content.ScSysInfo,this.table2);
                }));
            }
        }
        #endregion

        #region 更新GridControl
        //更新GridControl1
        private void UpdateGridControlData(SCSysInfo info,DataTable table)
        {
            
            table.Clear();
            for (int i = 0;i<info.ChildCount;i++)
            {
                StructDictItem item = info.GetChild(i);
                AddNewRow(item,table);
            }
        }
      
        //添加新的一行
        private void AddNewRow(StructDictItem item,DataTable table)
        {
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            row[TitleList.Number.ToString()] = table.Rows.Count;
            row[TitleList.MemberType.ToString()] = item.GetItem(0);
            row[TitleList.RechargeMoney.ToString()] = item.GetItem(1);
            row[TitleList.GiveMoney.ToString()] = item.GetItem(2);
            row[TitleList.ValidDay.ToString()] = item.GetItem(3)+"-"+item.GetItem(4);
          

        }

        #endregion

        #region 日期选择
        //日期选择触发
        private void DateNavigator_Click(object sender, System.EventArgs e)
        {
            if (sender.Equals(dateNavigator))
            {
                nlastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, nlastDate, out this.nstartTime, out this.nendTime);

            }
            else if (sender.Equals(dateNavigator1))
            {
                mlastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator1, mlastDate, out this.mstartTime, out this.mendTime);

            }
        }
       

        #endregion

        #region 添加奖励/会员日奖励
        //添加奖励
        private void AddAward_Click(object sender, EventArgs e)
        {
            if (sender.Equals(this.nAddButton))
            {
                StructDictItem item = this.GetAwardSetting(0);
                RateManageNetOperation.AddAwardManage(AddAwardResult, item);
            }
            else if(sender.Equals(this.mAddButton))
            {
                StructDictItem item = this.GetMemberAwardSetting(0);
                RateManageNetOperation.AddMemberDayAwardManage(AddMemberDayAwardResult, item);
            }

        }
        private void AddAwardResult(ResultModel result)
        {
            System.Console.WriteLine(result.pack);

            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_ADD)
            {
                NetMessageManage.Manage().RemoveResultBlock(AddAwardResult);
                this.Invoke(new UIHandleBlock(delegate
                {
                    //获取数据
                    RateManageNetOperation.AwardManageList(AwardManageListResult);

                }));
            }
            
        }
        private void AddMemberDayAwardResult(ResultModel result)
        {
            System.Console.WriteLine(result.pack);

            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_ADD)
            {
                NetMessageManage.Manage().RemoveResultBlock(AddMemberDayAwardResult);

                this.Invoke(new UIHandleBlock(delegate
                {
                    //获取数据
                    RateManageNetOperation.MemberDayAwardManageList(MemberDayAwardManageListResult);
                }));
            }
        }
        #endregion

        #region 修改费率设置
        //g修改费率设置
        private void update_Click(object sender, EventArgs e)
        {

            if (sender.Equals(this.nUpdateButton))
            {
                List<string> ids = this.GetCheckIds(this.gridView1,nitems);
                if(ids.Count > 0)
                {
                    StructDictItem item = this.GetAwardSetting(int.Parse(ids[0]));
                    RateManageNetOperation.UpdateAwardManage(UpdateAwardResult, item);

                }
            }
            else if(sender.Equals(this.mUpdateButton))
            {
                List<string> ids = this.GetCheckIds(this.gridView4, mitems);
                if(ids.Count > 0)
                {
                    StructDictItem item = this.GetMemberAwardSetting(int.Parse(ids[0]));
                    RateManageNetOperation.UpdateMemberDayAwardManage(UpdateMemberDayAwardResult,item);
                }

            }
        }

        private void UpdateAwardResult(ResultModel result)
        {
            System.Console.WriteLine(result.pack);

            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_UPDATE)
            {
                NetMessageManage.Manage().RemoveResultBlock(UpdateAwardResult);
                this.Invoke(new UIHandleBlock(delegate
                {
                    //获取数据
                    RateManageNetOperation.AwardManageList(AwardManageListResult);

                }));
            }

        }
        private void UpdateMemberDayAwardResult(ResultModel result)
        {
            System.Console.WriteLine(result.pack);

            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_UPDATE)
            {
                NetMessageManage.Manage().RemoveResultBlock(UpdateMemberDayAwardResult);

                this.Invoke(new UIHandleBlock(delegate
                {
                    //获取数据
                    RateManageNetOperation.MemberDayAwardManageList(MemberDayAwardManageListResult);
                }));
            }
        }
        #endregion

        #region 删除奖励/会员日奖励
        //删除费率管理
        private void DeletAward_Click(object sender, EventArgs e)
        {
            if(sender.Equals(this.nDeleteButton))
            {
                List<string> ids = this.GetCheckIds(this.gridView1, nitems);
                if(ids.Count >0)
                {
                    RateManageNetOperation.DeleteAwardManage(DeleteAwardResult, ids);
                }


            }else if(sender.Equals(this.mDeleteButton))
            {
                List<string> ids = this.GetCheckIds(this.gridView4, mitems);
                if (ids.Count > 0)
                {
                    RateManageNetOperation.DeleteMemberDayAwardManage(DeleteMemberDayAwardResult, ids);
                }
            }
        }
        //删除奖励结果回调
        private void DeleteAwardResult(ResultModel result)
        {
            System.Console.WriteLine(result.pack);

            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_DEL)
            {
                NetMessageManage.Manage().RemoveResultBlock(DeleteAwardResult);
                this.Invoke(new UIHandleBlock(delegate
                {
                    //获取数据
                    RateManageNetOperation.AwardManageList(AwardManageListResult);
                }));
            }
        }
        //删除会员日奖励结果回调
        private void DeleteMemberDayAwardResult(ResultModel result)
        {
            System.Console.WriteLine(result.pack);

            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_DEL)
            {
                NetMessageManage.Manage().RemoveResultBlock(DeleteMemberDayAwardResult);

                this.Invoke(new UIHandleBlock(delegate
                {
                    //获取数据
                    RateManageNetOperation.MemberDayAwardManageList(MemberDayAwardManageListResult);
                }));
            }
        }
#endregion

        #region 获取所有勾选的ID
        //获取所有勾选的id
        private List<string> GetCheckIds(GridView gridView,IList<StructDictItem> items)
        {
            List<string> ids = new List<string>();

            //获取所有勾选的column
            for (int i = 0; i < gridView.RowCount; i++)
            {
                DataRow row = gridView.GetDataRow(i);
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

        #region 获取费率设置信息/会员日费率设置信息
        //获取费率设置信息
        private StructDictItem GetAwardSetting(int id)
        {
            string type = this.comboBoxEdit1.Text;
            string recharge = this.nRechargeTextEdit.Text;
            string give = this.nGiveTextEdit.Text;
            string start = this.nstartTime;
            string end = this.nendTime;

            if (type.Equals("") || recharge.Equals("") || give.Equals("") || start.Equals("") || end.Equals(""))
            {
                return null;
            }

            StructDictItem.Builder item = new StructDictItem.Builder();
            item.Code = 0;
            item.Id = id;

            item.AddItem(type);
            item.AddItem(recharge);
            item.AddItem(give);
            item.AddItem(start);
            item.AddItem(end);

            return item.Build();
        }
        //获取会员日费率设置
        private StructDictItem GetMemberAwardSetting(int id)
        {

            string type = this.comboBoxEdit3.Text;
            string recharge = this.mRechargeTextEdit.Text;
            string give = this.mGiveTextEdit.Text;
            string start = this.mstartTime;
            string end = this.mendTime;
            if (type.Equals("") || recharge.Equals("") || give.Equals("") || start.Equals("") || end.Equals(""))
            {
                return null;
            }
            StructDictItem.Builder item = new StructDictItem.Builder();
            item.Code = 0;
            item.Id = id;
            item.AddItem(type);
            item.AddItem(recharge);
            item.AddItem(give);
            item.AddItem(start);
            item.AddItem(end);
            return item.Build();
          }
        #endregion

    }
}
