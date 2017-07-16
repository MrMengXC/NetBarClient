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
using System.IO;
using System.Net;

namespace NetBarMS.Views
{
    public partial class UserIdDetailView : RootFormView
    {
        public UserIdDetailView(int mid)
        {
            InitializeComponent();
            MemberNetOperation.MemberInfo(MemberInfoResult, mid);
        }
        //会员信息查询结果
        private void MemberInfoResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_MEMBER_CARD_INFO)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(MemberInfoResult);
            System.Console.WriteLine("MemberInfoResult:" + result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                //赋值
                this.Invoke(new RefreshUIHandle(delegate {
                    StructCard card = result.pack.Content.ScMemberCardInfo.Cardinfo;
                    InitUI(card);
                }));
            }
           
        }

        #region 初始化UI
        private void InitUI(StructCard card)
        {
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
            using (Stream stream = WebRequest.Create(card.Head).GetResponse().GetResponseStream())
            {
                this.pictureEdit1.Image = Image.FromStream(stream);               
            }

            //try
            //{
            //    //利用 WebClient 来下载图片
            //    using (WebClient wc = new WebClient())
            //    {
            //        this.label1.Text = ProductPicture.LOAD;
            //        this.label1.Show();
            //        ////WebClient 下载完毕的响应事件绑定
            //        wc.DownloadDataCompleted += Wc_DownloadDataCompleted;
            //        ////开始异步下载，图片URL路径请根据实际情况自己去指定
            //        wc.DownloadDataAsync(new Uri(path), path);
            //    }
            //}
            //catch (Exception exc)
            //{

            //    //System.Console.WriteLine("链接异常");
            //    this.label1.Hide();
            //}
        }
        #endregion

    }
}
