﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools;
using DevExpress.XtraEditors;

namespace NetBarMS.Views.SystemManage
{
    public partial class NetPassWordView : RootUserControlView
    {

        private IList<StructDictItem> items;

        public NetPassWordView()
        {
            InitializeComponent();
            InitUI();
        }
        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            TextEdit[] edits = {
                this.pwTextEdit
            };
            InitTextEdit(edits);
        }
        //设置界面
        private void SetSetting()
        {
            StructDictItem item = this.items[0];
            this.pwCheckEdit.Checked = int.Parse(item.GetItem(0)) == 1;
            this.pwTextEdit.Text = item.GetItem(1);

        }
        #endregion

        #region 结果回调
        //密码设置信息的结果回调
        private void GetPwSettingResult(ResultModel result)
        {
            System.Console.WriteLine("GetPwSettingResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(SystemManageNetOperation.pwParent))
            {
                NetMessageManage.RemoveResultBlock(GetPwSettingResult);
                this.Invoke(new RefreshUIHandle(delegate {
                    this.items = result.pack.Content.ScSysInfo.ChildList;
                    SetSetting();
                }));

            }
        }
        //更新密码设置信息的结果回调
        private void UpdatePwSettingResult(ResultModel result)
        {
            System.Console.WriteLine("UpdatePwSettingResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_UPDATE)
            {
                NetMessageManage.RemoveResultBlock(UpdatePwSettingResult);
                this.Invoke(new RefreshUIHandle(delegate {
                    MessageBox.Show("保存成功");
                }));
            }


        }
        #endregion

        #region 点击保存设置
        private void SaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                StructDictItem.Builder item = new StructDictItem.Builder(items[0]);
                item.ClearItem();

                string item1 = this.pwCheckEdit.Checked ? "1" : "0";
                string item2 = this.pwTextEdit.Text.Equals("") ? "0" : this.pwTextEdit.Text;
                item.AddItem(item1);
                item.AddItem(item2);
                          
                SystemManageNetOperation.UpdatePwSetting(UpdatePwSettingResult, item.Build());
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误请稍后重试");
            }

        }
        #endregion

        private void NetPassWordView_Load(object sender, EventArgs e)
        {
            SystemManageNetOperation.GetPwSetting(GetPwSettingResult);
        }
    }
}
