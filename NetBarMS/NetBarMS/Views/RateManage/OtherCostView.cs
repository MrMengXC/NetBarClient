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

namespace NetBarMS.Views.RateManage
{
    public partial class OtherCostView : RootUserControlView
    {
        private IList<StructDictItem> items;
        public OtherCostView()
        {
            InitializeComponent();
            this.titleLabel.Text = "其他费用管理";
            InitUI();
        }
         
        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            RateManageNetOperation.GetOtherSetting(GetOthertSettingResult);
        }
        //设置界面
        private void SetSetting()
        {
            StructDictItem item = this.items[0];
            this.memberCheckEdit.Checked = int.Parse(item.GetItem(0)) == 1;
            this.memberMinuteTextEdit.Text = item.GetItem(1);
            this.temCheckEdit.Checked = int.Parse(item.GetItem(2)) == 1;
            this.temMinuteTextEdit.Text = item.GetItem(3);

        }
        #endregion

        #region 结果回调
        //获取其他设置信息的结果回调
        private void GetOthertSettingResult(ResultModel result)
        {
            System.Console.WriteLine("GetOthertSettingResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(RateManageNetOperation.otherParent))
            {
                NetMessageManage.RemoveResultBlock(GetOthertSettingResult);
                this.Invoke(new UIHandleBlock(delegate {
                    this.items = result.pack.Content.ScSysInfo.ChildList;
                    SetSetting();
                }));

            }
        }
        //更新其他设置信息的结果回调
        private void UpdateOtherSettingResult(ResultModel result)
        {
            System.Console.WriteLine("UpdateOtherSettingResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_UPDATE)
            {
                NetMessageManage.RemoveResultBlock(UpdateOtherSettingResult);
                this.Invoke(new UIHandleBlock(delegate {
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
                string item1 = this.memberCheckEdit.Checked?"1":"0";
                string item2 = this.memberMinuteTextEdit.Text.Equals("") ? "0" : this.memberMinuteTextEdit.Text;
                string item3 = this.temCheckEdit.Checked ? "1" : "0";
                string item4 = this.temMinuteTextEdit.Text.Equals("") ? "0" : this.temMinuteTextEdit.Text;

                item.AddItem(item1);
                item.AddItem(item2);
                item.AddItem(item3);
                item.AddItem(item4);
                System.Console.WriteLine(item);
                RateManageNetOperation.UpdateOtherSetting(UpdateOtherSettingResult, item.Build());
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现错误请稍后重试");
            }

        }
        #endregion

    }
}

