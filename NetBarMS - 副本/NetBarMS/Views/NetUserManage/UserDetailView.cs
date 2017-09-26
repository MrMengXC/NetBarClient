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
            //初始化Label
            char[] sp = { ':', '：' };
            this.nameLabel.Text = string.Format("{0}：{1}", this.nameLabel.Text.Split(sp)[0], card.Name);
            this.genderLabel.Text = string.Format("{0}：{1}", this.genderLabel.Text.Split(sp)[0], card.Gender);
            this.nationLabel.Text = string.Format("{0}：{1}", this.nationLabel.Text.Split(sp)[0], card.Nation);
            this.cardTypeLabel.Text = string.Format("{0}：{1}", this.cardTypeLabel.Text.Split(sp)[0], "身份证");
            this.cardNumLabel.Text = string.Format("{0}：{1}", this.cardNumLabel.Text.Split(sp)[0], card.Number);
            this.addressLabel.Text = string.Format("{0}：{1}", this.addressLabel.Text.Split(sp)[0], card.Address);
            this.organLabel.Text = string.Format("{0}：{1}", this.organLabel.Text.Split(sp)[0], card.Organization);
            this.countryLabel.Text = string.Format("{0}：{1}", this.countryLabel.Text.Split(sp)[0], "中国");
            this.birthdayLabel.Text = string.Format("{0}：{1}", this.birthdayLabel.Text.Split(sp)[0], card.Birthday);
            this.cardValidityLabel.Text = string.Format("{0}：{1}", this.cardValidityLabel.Text.Split(sp)[0], card.Vld);
 
            try
            {
                //利用 WebClient 来下载图片
                using (WebClient wc = new WebClient())
                {
                    ////WebClient 下载完毕的响应事件绑定
                    wc.DownloadDataCompleted += Wc_DownloadDataCompleted;
                    ////开始异步下载，图片URL路径请根据实际情况自己去指定
                    wc.DownloadDataAsync(new Uri(card.Head));
                }
            }
            catch (Exception exc)
            {

              
            }
        }

        private void Wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {

            ////如果下载过程未发生错误，并且未被中途取消
            if (e.Error == null && !e.Cancelled)
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(e.Result, true);
                this.pictureEdit1.Image = Image.FromStream(stream);
            }
            else
            {
            }
        }
        #endregion

    }
}
