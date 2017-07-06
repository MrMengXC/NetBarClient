using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Views.NetUserManage;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools.FlowManage;
using NetBarMS.Views.ResultManage;

namespace NetBarMS.Views.HomePage.Message
{

    /// <summary>
    /// 提醒是否开通会员
    /// </summary>
    public partial class ReminderOpenMemberView : RootUserControlView
    {
        public ReminderOpenMemberView()
        {
            InitializeComponent();

        }

        #region 开通会员（跳入开通会员界面）
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
            string cardNum = ActiveFlowManage.ActiveFlow().card;
            OpenMemberView view = new OpenMemberView(FLOW_STATUS.ACTIVE_STATUS, cardNum);
            ToolsManage.ShowForm(view,false);
        }
        #endregion

        #region 不开通（默认注册临时会员）
        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
            string cardNum = ActiveFlowManage.ActiveFlow().card;
            StructCard.Builder card = new StructCard.Builder()
            {
                Name = "xx22",
                Gender = 1,
                Nation = "2112",
                Number = cardNum,
                Birthday = "2012-09-01",
                Address = "海南省",
                Organization = "海南",
                HeadUrl = "#dasdasd#",
                Vld = "",

            };

            CSMemberAdd.Builder member = new CSMemberAdd.Builder()
            {
                Cardinfo = card.Build(),
                Membertype = IdTools.TEM_MEMBER_ID,
                Recharge = 0,
            };

            System.Console.WriteLine("AddMemeber："+member);
            MemberNetOperation.AddMember(this.AddMemberBlock, member);



        }
        //添加会员回调
         private void AddMemberBlock(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_MEMBER_ADD)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(AddMemberBlock);
            System.Console.WriteLine("AddMemberBlock:" + result.pack);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    //
                    this.FindForm().Close();
                    ActiveFlowManage.ActiveFlow().MemberRegistSuccess();
                }));
            }

        }
        #endregion

    }
}
