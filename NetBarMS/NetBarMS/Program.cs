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
using NetBarMS.Views.ManagerManage;
using NetBarMS.Views.SystemManage;
using NetBarMS.Views.SystemSearch;
using NetBarMS.Views.EvaluateManage;
using NetBarMS.Views.OtherMain;

using NetBarMS.Codes;

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
            XMLDataManage.Instance();


            MemberManageView newview2 = new MemberManageView();
            CustomForm newForm2 = new CustomForm(newview2, true, false);
           // MainForm newForm2 = new MainForm();


            Application.Run(newForm2);

            return;

            ManagerLoginView view = new ManagerLoginView();
            CustomForm newForm = new CustomForm(view, true);
            if (newForm.DialogResult == DialogResult.OK)
            {
                MainForm form = new MainForm();
                Application.Run(form);
            }
            else
            {

            }
        }

        
    }
}
