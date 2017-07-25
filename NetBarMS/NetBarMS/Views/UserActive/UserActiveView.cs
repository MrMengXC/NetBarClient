#define PRODUCT
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
using NetBarMS.Codes.Tools.FlowManage;
using NetBarMS.Views.HomePage;
using NetBarMS.Views.NetUserManage;
using NetBarMS.Codes.Tools.Manage;
using System.Diagnostics;
using System.IO;

namespace NetBarMS.Views.UserUseCp
{

    public partial class UserActiveView : RootFormView
    {
        //private string cardNumber;
        private StructCard activeCard;

        #region 声明
        public UserActiveView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户上机";

            simpleButton2.Enabled = simpleButton3.Enabled = simpleButton1.Enabled = false;
            StructCard.Builder card = new StructCard.Builder()
            {
                Name = "xx22",
                Gender = 1,
                Nation = "2112",
                Number = ToolsManage.RandomCard,
                Birthday = "2012-09-01",
                Address = "海南省",
                Organization = "海南",
                Head = "#dasdasd#",
                Vld = "",
            };
            Bitmap b = Imgs.test;
            string inputString = ToolsManage.BitmapToDataSring(b);
            card.Head = inputString;

            InitUI(card.Build());
                 //  MemberNetOperation.MemberInfo(MemberInfoResult, card);
        }
        public UserActiveView(StructCard readCard)
        {
            InitializeComponent();
            this.titleLabel.Text = "用户上机";
            simpleButton2.Enabled = simpleButton3.Enabled = simpleButton1.Enabled = false;
            IdCardReaderManage.ReadCard(ReadCardResult, null, null);
            InitUI(readCard);
        }
        #endregion

        #region 初始化UI
        private void InitUI(StructCard showcard)
        {
            this.activeCard = new StructCard.Builder(showcard).Build();

            char[] sp = { ':', '：' };
            simpleButton3.Enabled = simpleButton2.Enabled = simpleButton1.Enabled = true;

            label1.Text = string.Format("{0}:{1}", label1.Text.Split(sp)[0], showcard.Number);
            label2.Text = string.Format("{0}:{1}", label2.Text.Split(sp)[0], showcard.Name);
            MemoryStream ms = new MemoryStream(System.Convert.FromBase64String(showcard.Head));
            this.pictureEdit1.Image = Image.FromStream(ms);
        }
        #endregion

        #region 关闭重写
#if PRODUCT
        public override void RootUserControlView_Disposed(object sender, EventArgs e)
        {
            IdCardReaderManage.OffCardReader(ReadCardResult, null, null);
            base.RootUserControlView_Disposed(sender, e);
        }
#endif
        #endregion

        #region 查询会员信息结果反馈
        private void MemberInfoResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_EMK_USERINFO)
            {
                return;
            }
            System.Console.WriteLine("MemberInfoResult" + result.pack);
            NetMessageManage.RemoveResultBlock(MemberInfoResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate ()
                {
                   

                    //如果是临时会员提醒是否添加会员
                    StructMember member = result.pack.Content.ScEmkUserInfo.Member;
                    //if(member.Membertype == IdTools.TEM_MEMBER_ID)
                    //{
                    //    RemindIsOpenMember();
                    //}
                }));
            }
            else
            {
               // AddCardInfo();
            }

        }
        #endregion

        #region 激活
        //激活
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!this.textEdit1.Text.Equals(""))
            {
                StructCard.Builder newCard = new StructCard.Builder(this.activeCard);
                newCard.Number = this.textEdit1.Text;
                ActiveFlowManage.ActiveFlow().CardCheckIn(newCard.Build());

            }
            else
            {
                ActiveFlowManage.ActiveFlow().CardCheckIn(this.activeCard);

            }
        }
        #endregion
        
        #region 充值
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!this.textEdit1.Text.Equals(""))
            {
                StructCard.Builder newCard = new StructCard.Builder(this.activeCard);
                newCard.Number = this.textEdit1.Text;
                UserScanCodeView view = new UserScanCodeView(newCard.Build(), 100, PRECHARGE_TYPE.NOT_MEMBER);
                ToolsManage.ShowForm(view, false);
            }
            else
            {
                UserScanCodeView view = new UserScanCodeView(activeCard, 100, PRECHARGE_TYPE.NOT_MEMBER);
                ToolsManage.ShowForm(view, false);
            }
        

        }
        #endregion

        #region 下机
        private void simpleButton3_Click(object sender, EventArgs e)
        {


            if (!this.textEdit1.Text.Equals(""))
            {
                StructCard.Builder newCard = new StructCard.Builder(this.activeCard);
                newCard.Number = this.textEdit1.Text;
                HomePageNetOperation.CardCheckOut(CardCheckOutResult, newCard.Number);

            }
            else
            {
                HomePageNetOperation.CardCheckOut(CardCheckOutResult, this.activeCard.Number);

            }
        }
        private void CardCheckOutResult(ResultModel result)
        {

            if(result.pack.Cmd != Cmd.CMD_EMK_CHECKOUT)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(CardCheckOutResult);
#if DEBUG
            System.Console.WriteLine("CardCheckOutResult:" + result.pack);
#endif
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle (delegate {
                    this.CloseFormClick();
                    UserCloseCpView view = new UserCloseCpView();
                    ToolsManage.ShowForm(view, false);
                    
                }));
            }

        }
        #endregion

        #region 读取身份证结果回调
        private void ReadCardResult(StructCard readCard,bool isSuccess)
        {
            if(readCard != null && isSuccess)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new RefreshUIHandle(delegate {
                        InitUI(readCard);
                    }));
                }
                else
                    InitUI(readCard);
            }
        }
        #endregion

    }
}
