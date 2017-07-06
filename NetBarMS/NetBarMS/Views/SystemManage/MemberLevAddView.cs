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

namespace NetBarMS.Views.SystemManage
{
    public partial class MemberLevAddView : RootUserControlView
    {
        private StructDictItem item = null;

        public MemberLevAddView(StructDictItem tem)
        {
            InitializeComponent();
            this.titleLabel.Text = "会员等级增改";
            this.item = tem;
            InitUI();
        }

        public MemberLevAddView()
        {
            InitializeComponent();
            this.titleLabel.Text = "会员等级增改";
        }
        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            this.typeTextEdit.Text = this.item.GetItem(0);
            this.rechargeTextEdit.Text = this.item.GetItem(1);
            this.integralTextEdit.Text = this.item.GetItem(2);
        }
        #endregion

        #region 保存信息
        //保存等级信息
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //保存
            //等级名称
            string memberType = this.typeTextEdit.Text;
            string recharge = this.rechargeTextEdit.Text;
            string integral = this.integralTextEdit.Text;
            if(memberType.Equals("")|| recharge.Equals("") || integral.Equals("") )
            {
                return;
            }
            if(this.item == null)
            {
                StructDictItem.Builder temitem = new StructDictItem.Builder()
                {
                    Id = 0,
                    Code = 0,
                };
                temitem.AddItem(memberType);
                temitem.AddItem(recharge);
                temitem.AddItem(integral);
                SystemManageNetOperation.AddMemberLv(AddMemberLvResult, temitem.Build());
            }
            else
            {
                StructDictItem.Builder temitem = new StructDictItem.Builder(this.item);
                temitem.ClearItem();
                temitem.AddItem(memberType);
                temitem.AddItem(recharge);
                temitem.AddItem(integral);
                SystemManageNetOperation.UpdateMemberLvSetting(UpdateMemberLvResult, temitem.Build());
            }

            //更新

        }
        //保存会员信息回调
        private void AddMemberLvResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_ADD)
            {

                return;
            }

            NetMessageManage.Manage().RemoveResultBlock(AddMemberLvResult);
            System.Console.WriteLine("AddMemberLvResult:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {

                    MessageBox.Show("添加成功");
                }));
            }
           
        }
        //修改会员信息回调
        private void UpdateMemberLvResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_SYS_UPDATE)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(UpdateMemberLvResult);
            System.Console.WriteLine("UpdateMemberLvResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    MessageBox.Show("修改成功");
                }));

            }
        }
        #endregion
    }
}
