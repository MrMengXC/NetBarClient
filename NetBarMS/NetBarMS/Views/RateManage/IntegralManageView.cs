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
using static NetBarMS.Codes.Tools.NetMessageManage;

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
            this.startComboBoxEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.endComboBoxEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            RateManageNetOperation.GetIntegralDefaultSetting(GetIntegralDefaultSettingResult);
        }
        private void SetSetting()
        {
            StructDictItem defaultItem = this.items[0];
            StructDictItem activeItem = this.items[1];

            this.dRechargeTextEdit.Text = defaultItem.GetItem(0);
            this.dRechargeItTextEdit.Text = defaultItem.GetItem(1);
            this.staffPjItTextEdit.Text = defaultItem.GetItem(2);
            this.netBarPjItTextEdit.Text = defaultItem.GetItem(3);
            this.logItTextEdit.Text = defaultItem.GetItem(4);
            this.bindingItTextEdit.Text = defaultItem.GetItem(5);

            this.aRechargeTextEdit.Text = activeItem.GetItem(0);
            this.aRechargeItTextEdit.Text = activeItem.GetItem(1);

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
                NetMessageManage.Manager().RemoveResultBlock(GetIntegralDefaultSettingResult);
                this.Invoke(new UIHandleBlock(delegate {
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
                NetMessageManage.Manager().RemoveResultBlock(UpdateIntegralDefaultSettingResult);
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

                if (sender.Equals(this.defaultButton))
                {
                    StructDictItem.Builder item = new StructDictItem.Builder(this.items[0]);
                    item.ClearItem();
                    string item1 = this.dRechargeTextEdit.Text.Equals("") ? "0" : this.dRechargeTextEdit.Text;
                    string item2 = this.dRechargeItTextEdit.Text.Equals("") ? "0" : this.dRechargeItTextEdit.Text;
                    string item3 = this.staffPjItTextEdit.Text.Equals("") ? "0" : this.staffPjItTextEdit.Text;
                    string item4 = this.netBarPjItTextEdit.Text.Equals("") ? "0" : this.netBarPjItTextEdit.Text;
                    string item5 = this.logItTextEdit.Text.Equals("") ? "0" : this.logItTextEdit.Text;
                    string item6 = this.bindingItTextEdit.Text.Equals("") ? "0" : this.bindingItTextEdit.Text;

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

                    string item1 = this.aRechargeTextEdit.Text.Equals("") ? "0" : this.aRechargeTextEdit.Text;
                    string item2 = this.aRechargeItTextEdit.Text.Equals("") ? "0" : this.aRechargeItTextEdit.Text;

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

    }
}
