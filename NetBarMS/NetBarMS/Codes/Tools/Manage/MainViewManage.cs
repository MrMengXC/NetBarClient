using NetBarMS.Views.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Codes.Tools.Manage
{
    /// <summary>
    /// 管理首页视图的Manage
    /// </summary>
    class MainViewManage
    {

        private static MainViewManage manage = null;
        private UserControl showView = null;
        private Panel mainView = null;
       
        #region 单例方法
        private static MainViewManage Manage()
        {
            if(manage == null)
            {
                manage = new MainViewManage();
            }
            return manage;
        }
        #endregion

        #region 显示视图
        public static void ShowView(UserControl view)
        {
            List<UserControl> removes = new List<UserControl>();
            foreach (UserControl control in Manage().mainView.Controls)
            {
                if (!control.GetType().Equals(typeof(HomePageView)))
                {
                    removes.Add(control);
                }
            }
            foreach(UserControl control in removes)
            {
                Manage().mainView.Controls.Remove(control);
                control.Dispose();
            }


            if (view != null)
            {
                Manage().showView = view;
                view.Dock = DockStyle.Fill;
                Manage().mainView.Controls.Add(view);
                view.BringToFront();
            }
        }
        #endregion

        #region 显示二级视图（不循环删除子控件）
        public static void ShowSecondView(UserControl view)
        {
            if (view != null)
            {
                Manage().showView = view;
                view.Dock = DockStyle.Fill;
                Manage().mainView.Controls.Add(view);
                view.BringToFront();
            }
        }
        #endregion

        #region 移除当前显示视图
        public static void RemoveView()
        {
            Manage().mainView.Controls.Remove(Manage().showView);
            Manage().showView.Dispose();
            Manage().showView = null;
        }
        #endregion
        public static Panel MainView
        {
            set
            {
                Manage().mainView = value;
            }

        }


    }
}
