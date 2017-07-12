﻿using System;
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

            //HomePageListView newview2 = new HomePageListView();
            //CustomForm newForm2 = new CustomForm(newview2, true);
            ////MainForm newForm2 = new MainForm
            ////DayInComeView newview2 = new DayInComeView();
            ////CustomForm newForm2 = new CustomForm(newview2, true, false);
            //Application.Run(newForm2);

            //return;

            ManagerLoginView view = new ManagerLoginView();
            CustomForm newForm = new CustomForm(view, true);
            newForm.ShowDialog();
            //等待点击关闭
            if (newForm.DialogResult == DialogResult.OK)
            {
                MainForm form = new MainForm();
                //HomePageView homePage = new HomePageView();
                //CustomForm form = new CustomForm(homePage, true);
                Application.Run(form);
            }
            else
            {

            }
        }

        
    }
}
