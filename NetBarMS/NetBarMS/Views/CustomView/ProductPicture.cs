using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools.Manage;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools;
using System.IO;
using System.Net;

namespace NetBarMS.Views.CustomView
{
    public partial class ProductPicture : UserControl
    {
        private string netPath = "";
        private const string UPLOD = "上传中...";
        private const string LOAD = "加载图片中...";

        public ProductPicture()
        {
            InitializeComponent();
            this.simpleButton1.Hide();
            this.label1.Hide();
        }

        #region 显示本地图片
        /// <summary>
        /// 显示本地图片
        /// </summary>
        /// <param name="filePath">本地路径</param>
        private void ShowFilePath(string filePath)
        {
            try
            {
                this.pictureEdit2.Image = Image.FromFile(filePath);
            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        #region 显示网络图片
        /// <summary>
        /// 显示网络图片
        /// </summary>
        /// <param name="filePath">网络路径</param>
        private void ShowNetPath(string path)
        {
            try
            {
                //利用 WebClient 来下载图片
                using (WebClient wc = new WebClient())
                {
                    this.label1.Text = ProductPicture.LOAD;
                    this.label1.Show();
                    ////WebClient 下载完毕的响应事件绑定
                    wc.DownloadDataCompleted += Wc_DownloadDataCompleted;                    
                    ////开始异步下载，图片URL路径请根据实际情况自己去指定
                    wc.DownloadDataAsync(new Uri(path), path);
                }
            }
            catch (Exception exc)
            {
                 
                //System.Console.WriteLine("链接异常");
                this.label1.Hide();
            }
          

        }
        //网络下载图片反馈
        private void Wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            ////如果下载过程未发生错误，并且未被中途取消
            if (e.Error == null && !e.Cancelled)
            {

                System.IO.MemoryStream stream = new System.IO.MemoryStream(e.Result, true);
                this.pictureEdit2.Image = Image.FromStream(stream);
                this.netPath = (string)e.UserState;
                this.simpleButton1.Show();
                this.label1.Hide();
            }
            else
            {
                this.label1.Hide();
            }


        }
        #endregion

        #region 去除图片
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.netPath = "";
            this.simpleButton1.Hide();
            this.pictureEdit2.Image = null;
        }
        #endregion

        #region 选择图片进行上传
        private void UploadPicture_Click(object sender, EventArgs e)
        {
            string filePath = "";
            //获取选择的图片
            string pictureData = CommonOperation.SelectPicture(out filePath);
            
            //显示
            if (!filePath.Equals(""))
            {
                this.pictureEdit2.Image = Image.FromFile(filePath);
            }
            //上传
            if (!pictureData.Equals(""))
            {
                this.label1.Text = UPLOD;
                this.label1.Show();
                string md5 = ToolsManage.MD5Encoding(DateTime.Now.ToString());

                CommonNetOperation.UploadPicture(UploadPictureResult, md5, pictureData);
            }
        }
        //上传图片
        private void UploadPictureResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_UPLOAD_PICTURE)
            {
                return;
            }
            System.Console.WriteLine("UploadPictureResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(UploadPictureResult);

            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {
                    SCUploadPicture upload = result.pack.Content.ScUpload;
                    this.netPath = upload.Url;
                    this.simpleButton1.Show();
                    this.label1.Hide();
                }));
            }



        }
        #endregion

        #region NetPath
        /// <summary>
        /// get/set 网络路径
        /// </summary>
        public string NetPath
        {
            get
            {
                return this.netPath;
            }
            set
            {
                ShowNetPath(value);
            }
        }
        #endregion
    }
}
