#define IDM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Forms;
using NetBarMS.Views;
using NetBarMS.Views.RateManage;
using NetBarMS.Codes.Tools;
using NetBarMS.Views.NetUserManage;
using NetBarMS.Views.ProductManage;
using NetBarMS.Views.InCome;
using NetBarMS.Views.ManagersManage;
using NetBarMS.Views.SystemManage;
using NetBarMS.Views.SystemSearch;
using NetBarMS.Views.EvaluateManage;
using NetBarMS.Views.OtherMain;

using NetBarMS.Codes;
using NetBarMS.Views.HomePage;

namespace NetBarMS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //初始化XML
            XMLDataManage.Init();

            //OpenMemberView newview2 = new OpenMemberView("");
            ////MainForm newForm2 = new MainForm
            ////DayInComeView newview2 = new DayInComeView();
            ////CustomForm newForm2 = new CustomForm(newview2, true, false);
            //ToolsManage.ShowForm(newview2, true);
            //MainView homePage1 = new MainView();
            //Application.Run(ToolsManage.ShowForm(homePage1));
            //return;

            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //this.TopMost = true;

            //Application.Run(new TestForm());
            //return;
            RootBgView root = new RootBgView();
            //设置全屏
            root.Size = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            Application.Run(ToolsManage.ShowForm(root));
        }

        
    }
}
