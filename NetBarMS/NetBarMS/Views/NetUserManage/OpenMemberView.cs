#region using
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
using NetBarMS.Views.ResultManage;
using NetBarMS.Forms;
using NetBarMS.Views.HomePage;
using NetBarMS.Codes.Tools.FlowManage;
using NetBarMS.Codes.Model;
#endregion

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
       
        private List<MemberTypeModel> memberTypes;       //会员类别数组
        private int memberIndex = -1;                   //当前会员类别索引
        private FLOW_STATUS flowstatus = FLOW_STATUS.NONE_STATUS;                 //判断返回的状态
        private char[] sp = { '：', ':' };

        #region 初始化方法
        public OpenMemberView()
        {
            InitializeComponent();
            this.titleLabel.Text = "会员办理";
            string idNum = ToolsManage.RandomCard;

            InitUI(idNum);
        }
        //临时使用
        public OpenMemberView(FLOW_STATUS status,String card)
        {
            InitializeComponent();
            this.titleLabel.Text = "会员办理";
            this.flowstatus = status;
            InitUI(card);
        }
        #endregion

        #region 初始化UI
        //初始化UI
        private void InitUI(string card)
        {
            //先接受数据
            this.memberTypes = SysManage.MemberTypes;
            //初始化Label
            this.nameLabel.Text += "xx22";          //姓名
            this.genderLabel.Text += "男";        //性别
            this.nationLabel.Text += "2112";        //民族
            this.cardTypeLabel.Text += "";      //卡类型
            this.cardNumLabel.Text += card;       //卡号
            this.cardValidityLabel.Text += "1992-05-01";  //有效期
            this.addressLabel.Text += "海南省";           //地址
            this.organLabel.Text += "海南";             //发证机关
            this.countryLabel.Text += "";              //国籍
            this.birthdayLabel.Text += "1992-05-01";              //出生日期

            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.OpenMember, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
            RefreshGridControl();



            //隐藏按钮可点击
            this.simpleButton1.Enabled = this.flowstatus == FLOW_STATUS.ACTIVE_STATUS;
            this.simpleButton2.Enabled = this.flowstatus == FLOW_STATUS.ACTIVE_STATUS;
            if (this.flowstatus != FLOW_STATUS.ACTIVE_STATUS)
            {
                //判断会员信息。是否是会员。是的话进行
                MemberNetOperation.MemberInfo(MemberInfoResult, card);
            }

        }
        //查询会员信息结果反馈
        private void MemberInfoResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_EMK_USERINFO)
            {
                return;
            }
            System.Console.WriteLine("MemberInfoResult" + result.pack);
            NetMessageManage.RemoveResultBlock(MemberInfoResult);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    //将按钮回复可以点击
                    this.simpleButton1.Enabled = true;
                    this.simpleButton2.Enabled = true;
                }));
            }
            else
            {
                AddCardInfo();
            }
        }
        //添加临时会员
        private void AddCardInfo()
        {
            StructCard.Builder card = new StructCard.Builder()
            {
                Name = nameLabel.Text.Split(sp)[1],
                Gender = genderLabel.Text.Split(sp)[1].Equals("男") ? 1 : 0,
                Nation = nationLabel.Text.Split(sp)[1],
                Number = cardNumLabel.Text.Split(sp)[1],
                Birthday = birthdayLabel.Text.Split(sp)[1],
                Address = addressLabel.Text.Split(sp)[1],
                Organization = organLabel.Text.Split(sp)[1],
                HeadUrl = "#dasdasd#",
                Vld = cardValidityLabel.Text.Split(sp)[1],
            };
           
            MemberNetOperation.AddCardInfo(AddCardInfoResult, card.Build());

        }
        //添加身份证信息回调
        private void AddCardInfoResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_EMK_ADD_CARDINFO)
            {
                return;
            }
            System.Console.WriteLine("AddCardInfoResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(AddCardInfoResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    //将按钮回复可以点击
                    this.simpleButton1.Enabled = true;
                    this.simpleButton2.Enabled = true;
                }));
            }

        }

        //刷新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            foreach(MemberTypeModel model in this.memberTypes)
            {
                DataRow row = this.mainDataTable.NewRow();
                this.mainDataTable.Rows.Add(row);
                row[TitleList.Type.ToString()] = model.typeName;
                row[TitleList.PayMoney.ToString()] = model.payMoney;
            }
        }
        #endregion

        #region 添加会员以及回调方法
        //保存(更新会员)
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CloseFormHandle closeHandle = new CloseFormHandle(delegate
            {
                this.CloseFormClick();   
            });
            //显示提示
            OpenMemberResultView view = new OpenMemberResultView();
            ToolsManage.ShowForm(view, false, closeHandle);
        }
        #endregion

        #region 控件的操作
        //金额的输入
        private void moneyTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //通过输入的金额判断类新
            try
            {
                int money = int.Parse(this.moneyTextEdit.Text);
                int need = 0;

                memberIndex = -1;

                foreach(MemberTypeModel model in this.memberTypes)
                {
                    int tem = int.Parse(model.payMoney);

                    if (money >= tem && tem > need && model.typeId != IdTools.TEM_MEMBER_ID)
                    {
                        memberIndex = this.memberTypes.IndexOf(model);
                        need = tem;
                        //System.Console("");
                    }
                }
               
            }
            catch (Exception exp)
            {
                memberIndex = -1;
            }

            if (memberIndex == -1)
            {
                this.memberTypeTextEdit.Text = null;
            }
            else
            {
                this.memberTypeTextEdit.Text = memberTypes[memberIndex].typeName;
            }
        }
        #endregion

        #region 进行充值
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int money = int.Parse(this.moneyTextEdit.Text);
            UserScanCodeView view = new UserScanCodeView(cardNumLabel.Text.Split(sp)[1], money, (int)PRECHARGE_TYPE.OPEN_MEMBER);
            ToolsManage.ShowForm(view, false);
        }
        #endregion


    }
}
