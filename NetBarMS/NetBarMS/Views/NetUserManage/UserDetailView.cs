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

namespace NetBarMS.Views
{
    public partial class UserIdDetailView : RootUserControlView
    {
        public UserIdDetailView(int mid)
        {
            InitializeComponent();
            this.titleLabel.Text = "上网用户信息";
            System.Console.WriteLine("Mid:" + mid);
            MemberNetOperation.MemberInfo(MemberInfoResult, mid);
        }
        //会员信息查询结果
        private void MemberInfoResult(ResultModel result)
        {
            System.Console.WriteLine("MemberInfoResult:" + result.pack);

            if (result.pack.Cmd == Cmd.CMD_MEMBER_CARD_INFO && result.pack.Content.MessageType == 1)
            {
                NetMessageManage.Manage().RemoveResultBlock(MemberInfoResult);
                System.Console.WriteLine("MemberInfoResult:" + result.pack);

                //赋值
                this.Invoke(new UIHandleBlock(delegate{
                    StructCard card = result.pack.Content.ScMemberCardInfo.Cardinfo;

                    this.nameLabel.Text += card.Name;
                    this.nationLabel.Text += card.Nation;
                    this.cardTypeLabel.Text += "身份证";
                    this.cardNumberLabel.Text += card.Number;
                    this.birthDateLabel.Text += card.Birthday;
                    this.cardTermLabel.Text += card.Vld;
                    this.addressLabel.Text += card.Address;
                    this.lssAuthLabel.Text += card.Organization;
                    this.genderLabel.Text += card.Gender;
                    this.nationalLabel.Text += "中国";

                }));



            }
        }



    }
}
