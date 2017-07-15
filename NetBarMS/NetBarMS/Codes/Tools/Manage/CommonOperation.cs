using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Codes.Tools.Manage
{
    /// <summary>
    /// 公共操作
    /// </summary>
    class CommonOperation
    {

        #region 选择图片
        //选择图片
        public static String SelectPicture(out string picture)
        {
            //C:\Users\Administrator\Pictures\图片4.png
            picture = "";
            //创建一个对话框对象
            OpenFileDialog ofd = new OpenFileDialog();
            //为对话框设置标题
            ofd.Title = "请选择上传的图片";
            //设置筛选的图片格式
            ofd.Filter = "图片格式|*.png";

            // openFi.Filter = "图像文件(JPeg, Gif, Bmp, etc.)|*.jpg;*.jpeg;*.gif;*.bmp;*.tif; *.tiff; *.png| JPeg 图像文件(*.jpg;*.jpeg)"
            //+ "|*.jpg;*.jpeg |GIF 图像文件(*.gif)|*.gif |BMP图像文件(*.bmp)|*.bmp|Tiff图像文件(*.tif;*.tiff)|*.tif;*.tiff|Png图像文件(*.png)"
            //+ "| *.png |所有文件(*.*)|*.*";

            //设置是否允许多选
            ofd.Multiselect = false;
            //如果你点了“确定”按钮
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //获得文件的完整路径（包括名字后后缀）
                string filePath = ofd.FileName;
                picture = ofd.FileName;

                //将文件路径显示在文本框中
                //txtImgUrl.Text = filePath;
               // System.Console.WriteLine("filePath:" + filePath);
                //找到文件名比如“1.jpg”前面的那个“\”的位置
                //int position = filePath.LastIndexOf("\\");
                //从完整路径中截取出来文件名“1.jpg”
                //string fileName = filePath.Substring(position + 1);
                //读取选择的文件，返回一个流
                string inputString = "";
                using (Stream stream = ofd.OpenFile())
                {

                    byte[] bytes = new byte[stream.Length];

                    stream.Read(bytes, 0, bytes.Length);

                    // 设置当前流的位置为流的开始 

                    stream.Seek(0, SeekOrigin.Begin);
                    inputString = System.Convert.ToBase64String(bytes);
                    // System.Console.WriteLine("inputString:"+ inputString);
                }
                return inputString;
            }
            else
            {

                return "";
            }
        }

        #endregion

        #region 添加身份证信息
        public static void AddCardInfo(DataResultBlock result,StructCard.Builder card)
        {
            Bitmap b = Imgs.test;
            string inputString = ToolsManage.BitmapToDataSring(b);
            card.HeadUrl = inputString;
            MemberNetOperation.AddCardInfo(result, card.Build());
        }
        #endregion
    }
}
