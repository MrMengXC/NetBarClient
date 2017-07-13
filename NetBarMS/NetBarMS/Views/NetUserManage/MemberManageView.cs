﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPTable.Models;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Tools.NetOperation;
using DevExpress.XtraEditors.Controls;
using NetBarMS.Views.OtherMain;
using DevExpress.XtraEditors;
using NetBarMS.Codes.Model;

namespace NetBarMS.Views.NetUserManage
{
    
    public partial class MemberManageView : RootUserControlView
    {
        private enum TitleList
        {
            None,

            Check = 0,              //勾选
            IdNumber,               //身份证号
            Gender,                 //性别
            Name,                   //姓名
            MemberType,             //会员类型
            PhoneNumber,            //手机号
            OpenCardTime,           //开卡时间
            LastUseTime,            //上次使用时间
            RemMoney,               //剩余金额
            AccRcMoney,             //累积充值金额
            AccGvMoney,             //累积赠送金额
            Integral,               //积分
            UseIntegral,            //已用积分
            LoopsStatus,            //指纹状态
            Status,                 //状态
            Verify,                 //验证
            UserMsg,                //用户信息
            CsRecord,               //消费记录
            NetRecord,              //上网记录


        }
        private Int32 pageBegin = 0,pageSize = 15;        //页面开始的页数,开始的Size
        private Int32 field = 0;            //需要按照排序的字段
        private Int32 order = 1;            //升序还是降序
        private IList<StructMember> members;
        private List<MemberTypeModel> memberTypes;

        public MemberManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "会员管理";
            InitUI();
        }

        #region 初始化UI
        // 初始化UI
        private void InitUI()
        {

            //初始化ComboBoxEdit
            //会员状态
            foreach(string status in Enum.GetNames(typeof(MEMBERSTATUS)))
            {
                this.statusComboBoxEdit.Properties.Items.Add(status);
            }

            //会员类型
            this.memberTypes = SysManage.MemberTypes;
            this.memberTypeComboBoxEdit.Properties.Items.Add("无");
            for (int i = 0; i < this.memberTypes.Count(); i++)
            {
                this.memberTypeComboBoxEdit.Properties.Items.Add(memberTypes[i].typeName);
            }
            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.MemberManage, out this.mainDataTable,ColumnButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;

            GetMemberList();

        }
        #endregion

        #region 获取会员列表
        //获取会员列表
        private void GetMemberList()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pageBegin,
                Pagesize = this.pageSize,
                Fieldname = this.field,
                Order = this.order,      //
            };
            MemberNetOperation.GetMemberList(MemberListResult, page.Build());
        }
        
        // 获取所有会员列表数据的回调
        public void MemberListResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_MEMBER_LIST)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(MemberListResult);
            //System.Console.WriteLine("MemberListBlock:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {           
                this.Invoke(new UIHandleBlock(delegate () {
                    this.UpdateGridControl(result.pack.Content.ScMemberList.MembersList);
                }));
            }
        }
        #endregion

        #region 更新GridControl
        //更新GridControl
        private void UpdateGridControl(IList<StructMember> tem)
        {
            this.mainDataTable.Clear();
            this.members = tem;
            for (int i = 0; i < this.members.Count; i++)
            {
                StructMember member = this.members[i];
                AddNewRow(member);

            }
        }

        //添加新行数据
        private void AddNewRow(StructMember member)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IdNumber.ToString()] = member.Cardnumber;
            row[TitleList.Gender.ToString()] = member.Gender;
            row[TitleList.Name.ToString()] = member.Name;
            row[TitleList.MemberType.ToString()] = member.Membertype;
            row[TitleList.PhoneNumber.ToString()] = member.Phone;
            row[TitleList.OpenCardTime.ToString()] = member.Opentime;
            row[TitleList.LastUseTime.ToString()] = member.Lasttime;
            row[TitleList.RemMoney.ToString()] = member.Balance;
            row[TitleList.AccRcMoney.ToString()] = member.TotalRecharge;
            row[TitleList.AccGvMoney.ToString()] = member.TotalBonus;
            row[TitleList.Integral.ToString()] = member.Integal;
            row[TitleList.UseIntegral.ToString()] = member.UsedIntegal;
            row[TitleList.Status.ToString()] = member.Status;
            row[TitleList.Verify.ToString()] = member.Verify;

        }
        #endregion

        #region 添加会员及回调方法
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton6_Click(object sender, EventArgs e)
        {
           //进入开卡页面
            OpenMemberView view = new OpenMemberView();
            ToolsManage.ShowForm(view, false, OpenMemberView_FormClose);
        }
        //会员办理窗体关闭回调事件
        public void OpenMemberView_FormClose()
        {
      
            GetMemberList();
        }
        #endregion

        #region 会员删除以及回调
        //删除
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            List<int> ids = GetCheckIds();
            if(ids.Count <= 0)
            {
                return;
            }
            MemberNetOperation.DeleteMember(DeleteMemberResult,ids);

        }
        //删除会员回调
        private void DeleteMemberResult(ResultModel result)
        {
           
            if (result.pack.Cmd == Cmd.CMD_MEMBER_DEL && result.pack.Content.MessageType == 1)
            {
                NetMessageManage.RemoveResultBlock(DeleteMemberResult);
                System.Console.WriteLine("DeleteMemberResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    GetMemberList();
                }));
            

            }
        }
        #endregion
      

        #region 多条件查询会员
        //按照会员状态查询
        private void statusComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchMember();
        }

        //按照会员等级查询
        private void memberTypeComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchMember();
        }
        //输入卡号或者姓名查询
        private void SearchButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SearchMember();
        }

        //通过条件查询会员
        private void SearchMember()
        {
            //会员类型
            int type = 0;
            if(this.memberTypeComboBoxEdit.SelectedIndex > 0)
            {
                MemberTypeModel item = this.memberTypes[this.memberTypeComboBoxEdit.SelectedIndex - 1];
                type = item.typeId;
            }

            MEMBERSTATUS status = MEMBERSTATUS.无;
            Enum.TryParse<MEMBERSTATUS>(this.statusComboBoxEdit.Text, out status);

            string key = "";
            if (!this.searchButtonEdit.Text.Equals(this.searchButtonEdit.Properties.NullText))
            {
                key = this.searchButtonEdit.Text;
            }

            //System.Console.WriteLine("type:" + type + "\nstatus:" + status + "\nkey:" + key);
            //测试多条件查询
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pageBegin,
                Pagesize = this.pageSize,
                Fieldname = field,
                Order = order,      //
            };

            MemberNetOperation.SearchConditionMember(SearchMemberResult, page.Build(), (int)status, type, key);
        }
        //按条件查询会员的回调
        private void SearchMemberResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_MEMBER_FIND)
            {
                return;
            }
            if (result.pack.Content.MessageType == 1)
            {
                //锁定0 激活1 在线2 离线3
                NetMessageManage.RemoveResultBlock(SearchMemberResult);
                //System.Console.WriteLine("SearchMemberResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    UpdateGridControl(result.pack.Content.ScMemberFind.MembersList);
                }));

            }
        }
        #endregion

        #region 控件事件
        //获取所有勾选的id
        private List<int> GetCheckIds()
        {
            List<int> ids = new List<int>();

            //获取所有勾选的column
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);
                string value = row[TitleList.Check.ToString()].ToString();
                if (value.Equals("True"))
                {
                    StructMember member = members[i];
                    ids.Add(member.Memberid);
                }
            }
            return ids;
        }

     

        //按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            DataRow row = this.gridView1.GetDataRow(rowhandle);
            StructMember member = members[rowhandle];


            String tag = (String)e.Button.Tag;
            String[] param = tag.Split('_');
            //查看用户身份信息
            if(param[0].Equals(TitleList.UserMsg.ToString()))
            {
                UserIdDetailView view = new UserIdDetailView(member.Memberid);
                ToolsManage.ShowForm(view, false);
            }
            //消费记录
            else if(param[0].Equals(TitleList.CsRecord.ToString())) 
            {
                MemberConsumeRecordView view = new MemberConsumeRecordView(member.Memberid);
                ToolsManage.ShowForm(view, false);
            }
            //上网记录
            else if(param[0].Equals(TitleList.NetRecord.ToString()))
            {
                MemberNetRecordView view = new MemberNetRecordView(member.Memberid);
                ToolsManage.ShowForm(view, false);
            }
            System.Console.WriteLine("button.Tag:"+ e.Button.Tag);
          




        }
        #endregion

     

    }

}
