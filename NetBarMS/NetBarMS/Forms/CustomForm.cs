using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Views;
using NetBarMS.Codes.Tools;

namespace NetBarMS.Forms
{
    public partial class CustomForm : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        #region 初始化窗体

         /// <summary>
        /// 进行数据初始化
        /// </summary>
        /// <param name="control">显示的视图</param>
        /// <param name="showInTaskbar">是否显示在任务栏上</param>
        /// <param name="movePanel">拖得Panel</param>
        private void CommonInit(UserControl control, bool showInTaskbar,Panel movePanel)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;

            control.BackColor = Color.White;
            control.Location = new Point(2, 2);
            if(movePanel != null)
            {
                movePanel.MouseDown += panel1_MouseDown;
            }
            this.Controls.Add(control);


            //newForm.TopMost = true;           //是否显示最前面
            //newForm.Focus();
            this.Size = new Size(control.Size.Width + 4, control.Size.Height + 4);
            control.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.BackColor = Color.Wheat;
            this.ShowInTaskbar = showInTaskbar;      //是否在任务栏显示
            this.FormClosed += CustomForm_FormClosed;

            this.MinimumSize = this.Size;
        }
        #endregion

        #region 监听窗体关闭
        private void CustomForm_FormClosed(object sender, FormClosedEventArgs e)
        {


       
        }
        #endregion

        #region 声明窗体的方法
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="control">添加的视图</param>
        /// <param name="showInTaskbar"></param>
        /// <param name="close">关闭的回调</param>

        public CustomForm(UserControl control, bool showInTaskbar, CloseFormHandle close)
        {
            if(control.GetType().IsSubclassOf(typeof(RootUserControlView)))
            {
                RootUserControlView view = control as RootUserControlView;
                if (close != null)
                {
                    view.CloseForm += close;
                }
                CommonInit(control, showInTaskbar, view.titlePanel);
            }
            else if (control.GetType().IsSubclassOf(typeof(RootFormView)))
            {
                RootFormView view = control as RootFormView;
                if (close != null)
                {
                    view.CloseForm += close;
                }
                CommonInit(control, showInTaskbar, view.titlePanel);
            }
            else
            {
                CommonInit(control, showInTaskbar, null);
            }
        }
        #endregion

        #region 拖动标题进行窗体移动
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion

        #region 进行边框拖动的扩大缩小
        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;
       protected override void WndProc(ref Message m)
       {
            switch (m.Msg)
             {
                 case 0x0084:
                     base.WndProc(ref m);
                     Point vPoint = new Point((int)m.LParam & 0xFFFF,(int)m.LParam >> 16 & 0xFFFF);
                     vPoint = PointToClient(vPoint);
                     if (vPoint.X <= 5)
                         if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                         else if (vPoint.Y >= ClientSize.Height - 5)
                             m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                         else m.Result = (IntPtr)Guying_HTLEFT;
                     else if (vPoint.X >= ClientSize.Width - 5)
                         if (vPoint.Y <= 5)
                             m.Result = (IntPtr)Guying_HTTOPRIGHT;
                         else if (vPoint.Y >= ClientSize.Height - 5)
                             m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                         else m.Result = (IntPtr)Guying_HTRIGHT;
                     else if (vPoint.Y <= 5)
                         m.Result = (IntPtr)Guying_HTTOP;
                     else if (vPoint.Y >= ClientSize.Height - 5)
                         m.Result = (IntPtr)Guying_HTBOTTOM;
                     break;
                 case 0x0201:                //鼠标左键按下的消息 
                     m.Msg = 0x00A1;         //更改消息为非客户区按下鼠标 
                     m.LParam = IntPtr.Zero; //默认值 
                     m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                     base.WndProc(ref m);
                     break;
                 default:
                     base.WndProc(ref m);
                     break;
             }
         }
        #endregion
    }

}
