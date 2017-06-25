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
using DevExpress.XtraEditors.Controls;
using static NetBarMS.Codes.Tools.NetMessageManage;
using NetBarMS.Views.ResultManage;
using NetBarMS.Forms;
using NetBarMS.Views.HomePage;

namespace NetBarMS.Views.NetUserManage
{
    public partial class OpenMemberView : RootUserControlView
    {
        private enum TitleList{
            None = 0,
            Type,
            PayMoney,
            GiveMoney,

        }
        private int memberType = -1;
        private bool isTem = false;     //  是否是临时会员
        private string[] memberTypes;
        public OpenMemberView()
        {
            InitializeComponent();
            this.titleLabel.Text = "会员办理";
            memberTypes = new string[]{
            "临时会员", "普通会员", "黄金会员", "钻石会员",
            };

            InitUI();
        }
        #region 初始化UI
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.OpenMember, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;

        }
        #endregion
        #region 添加会员以及回调方法
        //保存
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //显示提示
            if (this.memberType == -1)
            {
                MessageBox.Show("请选择会员类型");
                return;
            }
            string idNum = new Random().Next(1000, 90000000).ToString();

            StructCard.Builder card = new StructCard.Builder()
            {
                Name = "xx22",
                Gender = 1,
                Nation = "2112",
                Number = idNum,
                Birthday = "1212",
                Address = "海南省",
                Organization = "海南",
                HeadUrl = "#dasdasd#",
            };
            int money = int.Parse(this.moneyTextEdit.Text);

            CSMemberAdd.Builder member = new CSMemberAdd.Builder()
            {
                Cardinfo = card.Build(),
                Membertype = this.memberType+1,
                Recharge = money,
                Phone = this.phoneTextEdit.Text,

            };

            MemberNetOperation.AddMember(AddMemberBlock, member);



        }

        //添加会员回调
        private void AddMemberBlock(ResultModel result)
        {

            if (result.pack.Cmd == Cmd.CMD_MEMBER_ADD && result.pack.Content.MessageType == 1)
            {
                NetMessageManage.Manager().RemoveResultBlock(AddMemberBlock);
                System.Console.WriteLine("AddMemberBlock:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    //显示提示
                    OpenMemberResultView view = new OpenMemberResultView();
                    ToolsManage.ShowForm(view, false, OpenMemberResultView_FormClose);
                }));
            }

        }
        //OpenMemberResultView 所在窗体关闭的回调
        public void OpenMemberResultView_FormClose()
        {
            this.CloseFormClick();
        }
        #endregion

        #region 控件的操作
        //金额的输入
        private void moneyTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //0 - 20元 普通 20 - 40元黄金 40元以上钻石 type 1，2，3，
            //0为临时
            SetMemberType();
        }

        //正式会员勾选
        private void memberCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            if(this.memberCheckEdit.Checked)
            {
                isTem = false;
                this.temCheckEdit.Checked = false;
                memberType = -1;
                this.memberTypeTextEdit.Text = null;
                SetMemberType();
            }
        }
        //临时会员勾选
        private void temCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
           
            if (this.temCheckEdit.Checked)
            {
                isTem = true;
                this.memberCheckEdit.Checked = false;
                memberType = 0;
                this.memberTypeTextEdit.Text = memberTypes[memberType];
                System.Console.WriteLine(memberTypes[memberType]);
            }
           

        }
        #endregion

        #region 金额与会员类型的判断
        private void SetMemberType()
        {
            if (isTem)       //如果是临时不判断
            {
                return;
            }

            //0为临时
            //通过输入的金额判断类新
            try
            {
                int money = int.Parse(this.moneyTextEdit.Text);
                if (money < 20)
                {
                    memberType = -1;
                }
                else if (money < 40)
                {
                    memberType = 1;
                }
                else if (money < 60)
                {
                    memberType = 2;
                }
                else
                {
                    memberType = 3;
                }
            }
            catch (Exception exp)
            {
                memberType = -1;
            }

            if (memberType == -1)
            {
                this.memberTypeTextEdit.Text = null;
            }
            else
            {
                this.memberTypeTextEdit.Text = memberTypes[memberType];
            }

        }
        #endregion

        //进行充值
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UserScanCodeView view = new UserScanCodeView();
            ToolsManage.ShowForm(view, false);
        }
    }
}
