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
        public delegate void ReadCardHandle(StructCard readCard,bool isSuccess);
        /// <summary>
        /// 结果委托
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        public delegate void ResultHandle(bool isSuccess);

        private static IdCardReaderManage manage = null;
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
        private ResultHandle ConnectReaderEvent;

        /// <summary>
        /// 定时器
        /// </summary>
        private System.Timers.Timer timer = null;

        /// <summary>
        /// 是否连接设备中
        /// </summary>
        private bool IsConnected = false;
        /// <summary>
        /// 是否已经读取到内容
        /// </summary>
        private bool IsReadCard = false;

        //机器设备端口号
        private int port = 0;
        private const int cbDataSize = 128;
        private const int GphotoSize = 256 * 1024;
        private StructCard currentCard = null;
        


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
        private void ConnectReader()
        {

            //连接设备，成功返回端口号
            int readport = InitCommExt();

            Manage().IsConnected = readport > 0;

            //进行连接读卡器结果回调
            if (Manage().ConnectReaderEvent != null)
            {
                Manage().ConnectReaderEvent(Manage().IsConnected);
            }
        }
        /// <summary>
        /// 读取身份证
        /// </summary>
        public static void ReadCard(ReadCardHandle readCard, 
            ResultHandle connectReader,
            ResultHandle authenticateCard)
        {
            if(readCard != null)
            {
                Manage().ReadCardEvent += readCard;
            }
            if(connectReader != null)
            {
                Manage().ConnectReaderEvent += connectReader;
            }
            if(authenticateCard != null)
            {
                Manage().AuthenticateCardEvent += authenticateCard;
            }


            if(Manage().IsConnected)
            {
                return;
            }
            //连接读卡器
            Manage().ConnectReader();

            //进行身份证确认
            if (Manage().IsConnected)
            {
                Manage().AuthenticateCard();
            }

        }

        /// <summary>
        /// 确认身份证是否重新放置
        /// </summary>
        private void AuthenticateCard()
        {
           
            //卡认证，本函数用于读卡器和卡片之间的合法身份确认
            int res = Authenticate();
            // 1  成功
            //- 1  寻卡失败
            // - 2  选卡失败
            //0  其他错误
            if (Manage().AuthenticateCardEvent != null)
            {
                Manage().AuthenticateCardEvent(res == 1);
            }
            //读取内容
            if (res == 1)
            {
                ReadContent();
            }

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
            //读取内容
            int rs = Read_Content(1);
            //1  成功
            //- 11  无效参数
            // - 101  写入文件失败，可以调用接口获取文字信息(如getName)
            //0  其他错误

            if (rs != 1)
            {
                Manage().ReadCardEvent(null, false);
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

            for (int i = 0; i < 9; i++)
            {
                GetCardInfo(i, sb);
                switch (i)
                {
                    case 0: card.Name = sb.ToString(); break;
                    case 1: card.Gender = sb.ToString().Equals("男")?1:0; break;
                    case 2: card.Nation = sb.ToString(); break;
                    case 3:
                        {
                            string res = sb.ToString();
                            card.Birthday = string.Format("{0}-{1}-{2}", res.Substring(0, 4), res.Substring(4, 2), res.Substring(6, 2));
                        }

                        break;
                    case 4: card.Address = sb.ToString(); break;
                    case 5: card.Number = sb.ToString(); break;
                    case 6: card.Organization = sb.ToString(); break;
                    case 7:
                        {
                            string res = sb.ToString();
                            card.Vld = string.Format("{0}.{1}.{2}", res.Substring(0, 4), res.Substring(4, 2), res.Substring(6, 2));
                        }
                       break;
                    case 8:
                        {
                            string res = sb.ToString();
                            card.Vld = string.Format("{0}-{1}.{2}.{3}",card.Vld ,res.Substring(0, 4), res.Substring(4, 2), res.Substring(6, 2));
                        }
                        break;

                    default:
                        break;
                }
            }
            //获取头像
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

            //
            if (timer == null)
            {
                timer = new System.Timers.Timer();
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = 1000;
                timer.Enabled = true;
                timer.Start();
            }
            if (Manage().ReadCardEvent != null )
            {
                //如果没有读到卡或者读到卡了为不同的卡
                if(IsReadCard == false
                    || (IsReadCard && !currentCard.Number.Equals(card.Number)))
                {
                    IsReadCard = true;
                    Manage().currentCard = card.Build();
                    Manage().ReadCardEvent(Manage().currentCard,true);
                }
            }
          
        }
        //时间间隔达到1000s
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //System.Console.WriteLine("Timer_Elapsed");
            AuthenticateCard();

        }
        /// <summary>
        /// 关闭读卡设备，清除设置
        /// </summary>
        /// <param name="readCard"></param>
        /// <param name="connectIDM"></param>
        /// <param name="authenticateCard"></param>
        public static void OffCardReader(ReadCardHandle readCard,
            ResultHandle connectReader,
            ResultHandle authenticateCard)
        {
            RemoveEvent(readCard, connectReader, authenticateCard);

            if (Manage().timer != null)
            {
                Manage().timer.Dispose();
            }
            Manage().timer = null;
            Manage().currentCard = null;
            Manage().IsConnected = Manage().IsReadCard = false;
            //关闭IDM连接
            CloseComm();
        }
        /// <summary>
        /// 移除委托的回调事件
        /// </summary>
        /// <param name="readCard"></param>
        /// <param name="connectIDM"></param>
        /// <param name="authenticateCard"></param>
        public static void RemoveEvent(
            ReadCardHandle readCard,
            ResultHandle connectReader,
            ResultHandle authenticateCard)
        {
            if (readCard != null)
            {
                Manage().ReadCardEvent -= readCard;
            }
            if (connectReader != null)
            {
                Manage().ConnectReaderEvent -= connectReader;
            }
            if (authenticateCard != null)
            {
                Manage().AuthenticateCardEvent -= authenticateCard;
            }

          

        }


    }
}
