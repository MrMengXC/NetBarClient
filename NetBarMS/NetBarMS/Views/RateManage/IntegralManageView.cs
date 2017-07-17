using System;
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
using NetBarMS.Codes.Tools.Manage;
using DevExpress.XtraEditors;

namespace NetBarMS.Views.RateManage
{
    public partial class IntegralManageView : RootUserControlView
    {

        private IList<StructDictItem> items;
        public IntegralManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "积分管理";
            InitUI();
        }

       
        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            //初始化TextEdit
            TextEdit[] edits = {
                this.dRechargeText,this.dRechargeItText,this.staffPjItText,this.netBarPjItText,this.bingingItText,this.logItText,this.aRechargeText,this.aRechargItText
            };
            InitTextEdit(edits);
            //初始化ComboxEdit
            this.startComboBoxEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.endComboBoxEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            RateManageNetOperation.GetIntegralDefaultSetting(GetIntegralDefaultSettingResult);
        }
        private void SetSetting()
        {
            StructDictItem defaultItem = this.items[0];
            StructDictItem activeItem = this.items[1];

            this.dRechargeText.Text = defaultItem.GetItem(0);
            this.dRechargeItText.Text = defaultItem.GetItem(1);
            this.staffPjItText.Text = defaultItem.GetItem(2);
            this.netBarPjItText.Text = defaultItem.GetItem(3);
            this.logItText.Text = defaultItem.GetItem(4);
            this.bingingItText.Text = defaultItem.GetItem(5);

            this.aRechargeText.Text = activeItem.GetItem(0);
            this.aRechargItText.Text = activeItem.GetItem(1);

            endComboBoxEdit.Text = activeItem.GetItem(3);
            startComboBoxEdit.Text = activeItem.GetItem(2);

        }
        #endregion

        #region 结果回调
        //获取积分设置信息的结果回调
        private void GetIntegralDefaultSettingResult(ResultModel result)
        {
            System.Console.WriteLine("GetIntegralDefaultSettingResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }

            if (result.pack.Cmd == Cmd.CMD_SYS_INFO && result.pack.Content.ScSysInfo.Parent.Equals(RateManageNetOperation.integralParent))
            {
                NetMessageManage.RemoveResultBlock(GetIntegralDefaultSettingResult);
                this.Invoke(new RefreshUIHandle(delegate {
                    this.items = result.pack.Content.ScSysInfo.ChildList;
                    SetSetting();
                }));

            }
        }
        //更新积分设置信息的结果回调
        private void UpdateIntegralDefaultSettingResult(ResultModel result)
        {
            System.Console.WriteLine("UpdateIntegralDefaultSettingResult:" + result.pack);
            if (result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_SYS_UPDATE)
            {
                NetMessageManage.RemoveResultBlock(UpdateIntegralDefaultSettingResult);
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

                if (sender.Equals(this.defaultButton))
                {
                    StructDictItem.Builder item = new StructDictItem.Builder(this.items[0]);
                    item.ClearItem();
                    string item1 = this.dRechargeText.Text.Equals("") ? "0" : this.dRechargeText.Text;
                    string item2 = this.dRechargeItText.Text.Equals("") ? "0" : this.dRechargeItText.Text;
                    string item3 = this.staffPjItText.Text.Equals("") ? "0" : this.staffPjItText.Text;
                    string item4 = this.netBarPjItText.Text.Equals("") ? "0" : this.netBarPjItText.Text;
                    string item5 = this.logItText.Text.Equals("") ? "0" : this.logItText.Text;
                    string item6 = this.bingingItText.Text.Equals("") ? "0" : this.bingingItText.Text;

                    item.AddItem(item1);
                    item.AddItem(item2);
                    item.AddItem(item3);
                    item.AddItem(item4);
                    item.AddItem(item5);
                    item.AddItem(item6);
                    RateManageNetOperation.UpdateIntegralDefaultSetting(UpdateIntegralDefaultSettingResult, item.Build());
                }
                else if (sender.Equals(this.activeButton))
                {
                    StructDictItem.Builder item = new StructDictItem.Builder(items[1]);
                    item.ClearItem();

                    string item1 = this.aRechargeText.Text.Equals("") ? "0" : this.aRechargeText.Text;
                    string item2 = this.aRechargItText.Text.Equals("") ? "0" : this.aRechargItText.Text;

                    string item3 = this.startComboBoxEdit.DateTime.ToString("yyyy-MM-dd");
                    string item4 = this.endComboBoxEdit.DateTime.ToString("yyyy-MM-dd");
                    if(item3.Equals("") || item4.Equals(""))
                    {
                        return;
                    }
                    item.AddItem(item1);
                    item.AddItem(item2);
                    item.AddItem(item3);
                    item.AddItem(item4);
                    RateManageNetOperation.UpdateIntegralDefaultSetting(UpdateIntegralDefaultSettingResult, item.Build());
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("出现错误请稍后重试");
            }
            
        }
        #endregion
        protected override void Control_Paint(object sender, PaintEventArgs e)
        {
            base.Control_Paint(sender, e);
        }
    }
}
