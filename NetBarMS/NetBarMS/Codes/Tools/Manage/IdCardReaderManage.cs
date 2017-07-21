using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NetBarMS.Codes.Tools.Manage
{
    class IdCardReaderManage
    {
        /// <summary>
        /// 读取身份证委托
        /// </summary>
        /// <param name="readCard">结果信息</param>
        public delegate void ReadCardHandle(StructCard readCard);
        /// <summary>
        /// 结果委托
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        public delegate void ResultHandle(bool isSuccess);

        


        private static IdCardReaderManage manage = null;

        private System.Timers.Timer timer = null;

        //是否连接中
        private bool IsConnected = false;
        //是否认证成功
        private bool IsAuthenticate = false;
        private bool IsRead_Content = false;
        //机器设备端口号
        private int port = 0;
        private const int cbDataSize = 128;
        private const int GphotoSize = 256 * 1024;
        private StructCard currentCard = null;
        /// <summary>
        /// 读取卡片结果
        /// </summary>
        private ReadCardHandle ReadCardEvent;
        /// <summary>
        /// 确认卡片是否放置
        /// </summary>
        private ResultHandle AuthenticateCardEvent;
        /// <summary>
        /// 连接读卡设备
        /// </summary>
        private ResultHandle ConnectIDMEvent;


        #region Termb.dll
        [DllImport("termb.dll")]
        static extern int InitCommExt();//自动搜索身份证阅读器并连接身份证阅读器 

        [DllImport("termb.dll")]
        static extern int CloseComm();//断开与身份证阅读器连接 

        [DllImport("termb.dll")]
        static extern int Authenticate();//判断是否有放卡，且是否身份证 

        [DllImport("termb.dll")]
        public static extern int Read_Content(int index);//读卡操作,信息文件存储在dll所在下

        [DllImport("termb.dll")]
        static extern int GetSAMID(StringBuilder SAMID);//获取SAM模块编号

        [DllImport("termb.dll")]
        static extern int GetSAMIDEx(StringBuilder SAMID);//获取SAM模块编号（10位编号）

        [DllImport("termb.dll")]
        static extern int GetBmpPhoto(string PhotoPath);//解析身份证照片

        [DllImport("termb.dll")]
        static extern int GetBmpPhotoExt();//解析身份证照片

        [DllImport("termb.dll")]
        static extern int Reset_SAM();//重置Sam模块

        [DllImport("termb.dll")]
        static extern int GetSAMStatus();//获取SAM模块状态 

        [DllImport("termb.dll")]
        static extern int GetCardInfo(int index, StringBuilder value);//解析身份证信息 

        [DllImport("termb.dll")]
        static extern int ExportCardImageV();//生成竖版身份证正反两面图片(输出目录：dll所在目录的cardv.jpg和SetCardJPGPathNameV指定路径)

        [DllImport("termb.dll")]
        static extern int ExportCardImageH();//生成横版身份证正反两面图片(输出目录：dll所在目录的cardh.jpg和SetCardJPGPathNameH指定路径) 

        [DllImport("termb.dll")]
        static extern int SetTempDir(string DirPath);//设置生成文件临时目录

        [DllImport("termb.dll")]
        static extern int GetTempDir(StringBuilder path, int cbPath);//获取文件生成临时目录

        [DllImport("termb.dll")]
        static extern void GetPhotoJPGPathName(StringBuilder path, int cbPath);//获取jpg头像全路径名 


        [DllImport("termb.dll")]
        static extern int SetPhotoJPGPathName(string path);//设置jpg头像全路径名

        [DllImport("termb.dll")]
        static extern int SetCardJPGPathNameV(string path);//设置竖版身份证正反两面图片全路径

        [DllImport("termb.dll")]
        static extern int GetCardJPGPathNameV(StringBuilder path, int cbPath);//获取竖版身份证正反两面图片全路径

        [DllImport("termb.dll")]
        static extern int SetCardJPGPathNameH(string path);//设置横版身份证正反两面图片全路径

        [DllImport("termb.dll")]
        static extern int GetCardJPGPathNameH(StringBuilder path, int cbPath);//获取横版身份证正反两面图片全路径

        [DllImport("termb.dll")]
        static extern int getName(StringBuilder data, int cbData);//获取姓名

        [DllImport("termb.dll")]
        static extern int getSex(StringBuilder data, int cbData);//获取性别

        [DllImport("termb.dll")]
        static extern int getNation(StringBuilder data, int cbData);//获取民族

        [DllImport("termb.dll")]
        static extern int getBirthdate(StringBuilder data, int cbData);//获取生日(YYYYMMDD)

        [DllImport("termb.dll")]
        static extern int getAddress(StringBuilder data, int cbData);//获取地址

        [DllImport("termb.dll")]
        static extern int getIDNum(StringBuilder data, int cbData);//获取身份证号

        [DllImport("termb.dll")]
        static extern int getIssue(StringBuilder data, int cbData);//获取签发机关

        [DllImport("termb.dll")]
        static extern int getEffectedDate(StringBuilder data, int cbData);//获取有效期起始日期(YYYYMMDD)

        [DllImport("termb.dll")]
        static extern int getExpiredDate(StringBuilder data, int cbData);//获取有效期截止日期(YYYYMMDD) 

        [DllImport("termb.dll")]
        static extern int getBMPPhotoBase64(StringBuilder data, int cbData);//获取BMP头像Base64编码 

        [DllImport("termb.dll")]
        static extern int getJPGPhotoBase64(StringBuilder data, int cbData);//获取JPG头像Base64编码

        [DllImport("termb.dll")]
        static extern int getJPGCardBase64V(StringBuilder data, int cbData);//获取竖版身份证正反两面JPG图像base64编码字符串

        [DllImport("termb.dll")]
        static extern int getJPGCardBase64H(StringBuilder data, int cbData);//获取横版身份证正反两面JPG图像base64编码字符串

        [DllImport("termb.dll")]
        static extern int HIDVoice(int nVoice);//语音提示。。仅适用于与带HID语音设备的身份证阅读器（如ID200）

        [DllImport("termb.dll")]
        static extern int IC_SetDevNum(int iPort, StringBuilder data, int cbdata);//设置发卡器序列号

        [DllImport("termb.dll")]
        static extern int IC_GetDevNum(int iPort, StringBuilder data, int cbdata);//获取发卡器序列号

        [DllImport("termb.dll")]
        static extern int IC_GetDevVersion(int iPort, StringBuilder data, int cbdata);//设置发卡器序列号 

        [DllImport("termb.dll")]
        static extern int IC_WriteData(int iPort, int keyMode, int sector, int idx, StringBuilder key, StringBuilder data, int cbdata, ref int snr);//写数据

        [DllImport("termb.dll")]
        static extern int IC_ReadData(int iPort, int keyMode, int sector, int idx, StringBuilder key, StringBuilder data, int cbdata, ref int snr);//du数据

        [DllImport("termb.dll")]
        static extern int IC_GetICSnr(int iPort, ref int snr);//读IC卡物理卡号 

        [DllImport("termb.dll")]
        static extern int IC_GetIDSnr(int iPort, StringBuilder data, int cbdata);//读身份证物理卡号 
        #endregion


        private static IdCardReaderManage Manage()
        {
            if(manage == null)
            {
                manage = new IdCardReaderManage();
            }
            return manage;
        }

        /// <summary>
        /// 连接读卡器
        /// </summary>
        private bool ConnectIDM()
        {
            this.port = -1;
            //连接设备，成功返回端口号
            int readport = InitCommExt();
            if (readport > 0)
            {
                this.port = readport;
                return true;
            }
            else
            {
                MessageBox.Show("连接读卡器出错");
                return false;
            }
        }
        /// <summary>
        /// 读取身份证
        /// </summary>
        public static void ReadCard(ReadCardHandle readCard, 
            ResultHandle connectIDM,
            ResultHandle authenticateCard)
        {
            if(readCard != null)
            {
                Manage().ReadCardEvent += readCard;
            }
            if(connectIDM != null)
            {
                Manage().ConnectIDMEvent += connectIDM;
            }
            if(authenticateCard != null)
            {
                Manage().AuthenticateCardEvent += authenticateCard;
            }

            if (!Manage().ConnectIDM())
            {
                if(Manage().ConnectIDMEvent != null)
                {
                    Manage().ConnectIDMEvent(false);
                }
                return;
            }
            if (Manage().ConnectIDMEvent != null)
            {
                Manage().ConnectIDMEvent(true);
                Manage().AuthenticateCard();
            }

        }

        /// <summary>
        /// 确认身份证是否重新放置
        /// </summary>
        private void AuthenticateCard()
        {
           
            //卡认证，本函数用于读卡器和卡片之间的合法身份确认
            int FindCard = Authenticate();
            switch (FindCard)
            {
                case 1:
                    {
                        if (AuthenticateCardEvent != null)
                        {
                            AuthenticateCardEvent(true);
                        }
                        //读取内容
                        ReadContent();
                    }
                    break;

                default:
                    {
                        if (Manage().AuthenticateCardEvent != null)
                        {
                            Manage().AuthenticateCardEvent(false);
                        }
                       
                       // MessageBox.Show("请放置身份证");
                    }
                    break;
            }
            ////读取成功
            //if (isRes)
            //{
                
            //}
            //else
            //{
               
            //    //CloseComm();
            //}
        }
        /// <summary>
        /// 自动读取内容
        /// </summary>
        private void ReadContent()
        {
            StringBuilder sb = new StringBuilder(cbDataSize);
            //1  读基本信息，形成文字信息文件WZ.TXT、相片文件XP.WLT、ZP.BMP，如果有指纹信息形成指纹信息文件FP.DAT
            //2  只读文字信息，形成文字信息文件WZ.TXT和相片文件XP.WLT
            //3  读最新住址信息，形成最新住址文件NEWADD.TXT
            int rs = Read_Content(1);
            if (rs == 1)
            {
               // Manage().IsRead_Content = true;
            }
            else
            {
              //  Manage().IsRead_Content = false;
               
                MessageBox.Show("读取内容失败");
                return;
            }

            //index(0)  获取姓名
            //index(1)  获取性别
            //index(2)  获取民族
            //index(3)  获取出生日期(YYYYMMDD)
            //index(4)  获取地址
            //index(5)  获取身份证号
            //index(6)  签发机关
            //index(7)  有效期起始日期(YYYYMMDD)
            //index(8)  有效期截止日期(YYYYMMDD)

            object[] message = new object[10];
            StructCard.Builder card = new StructCard.Builder();

            for (int i = 0; i < 8; i++)
            {
                GetCardInfo(i, sb);
                switch (i)
                {
                    case 0: card.Name = sb.ToString(); break;
                    case 1: card.Gender = sb.ToString().Equals("男")?1:0; break;
                    case 2: card.Nation = sb.ToString(); break;
                    case 3: card.Birthday = sb.ToString(); break;
                    case 4: card.Address = sb.ToString(); break;
                    case 5: card.Number = sb.ToString(); break;
                    case 6: card.Organization = sb.ToString(); break;
                    case 7: card.Vld = sb.ToString(); break;
                    case 8: card.Vld = sb.ToString(); break;

                    default:
                        break;
                }
            }
            GetBmpPhotoExt();
            string PhotoPath = "";
            if (File.Exists("zp.jpg"))
            {
                PhotoPath = "zp.jpg";
            }
            else if (File.Exists("zp.bmp"))
            {
                PhotoPath = "zp.bmp";
            }

            FileStream fs = new FileStream(PhotoPath, FileMode.Open);
            //把文件读取到字节数组 
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();
            string inputString = System.Convert.ToBase64String(data);
            card.Head = inputString;
            //CloseComm();

            if (Manage().ReadCardEvent != null )
            {
                if(currentCard == null || (currentCard != null && !currentCard.Number.Equals(card.Number)))
                {
                    Manage().currentCard = card.Build();
                    Manage().ReadCardEvent(Manage().currentCard);
                }
            }
            //
            if (timer == null)
            {
                timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Start();
            }
        }
        //时间间隔达到1000s
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            System.Console.WriteLine("Timer_Elapsed");
            AuthenticateCard();

        }

        //移除读卡
        public static void RemoveReadCard(
            ReadCardHandle readCard,
            ResultHandle connectIDM,
            ResultHandle authenticateCard)
        {
            if (readCard != null)
            {
                Manage().ReadCardEvent -= readCard;
            }
            if (connectIDM != null)
            {
                Manage().ConnectIDMEvent -= connectIDM;
            }
            if (authenticateCard != null)
            {
                Manage().AuthenticateCardEvent -= authenticateCard;
            }

            if(Manage().timer != null)
            {
                Manage().timer.Dispose();
            }
            Manage().timer = null;
            Manage().currentCard = null;
            //关闭IDM连接
            CloseComm();

        }


    }
}
