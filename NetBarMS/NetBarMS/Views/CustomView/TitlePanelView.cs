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

namespace NetBarMS.Views.CustomView
{
    public partial class TitlePanelView : UserControl
    {
        private bool IsShowCloseButton = true;

        public TitlePanelView()
        {

            InitializeComponent();
        }

        #region 设置是否显示关闭按钮
        [Browsable(true)]
        [Description("是否显示关闭按钮"), DefaultValue(true)]
        public bool ShowCloseButton
        {
            set
            {
                this.IsShowCloseButton = value;
                if (this.IsShowCloseButton)
                {
                    this.closeButton.Show();
                }
                else
                {
                    this.closeButton.Hide();
                }

            }
            get
            {
                return this.IsShowCloseButton;
            }
        }
        #endregion

        #region 设置标题
        [Browsable(true)]
        [Description("设置标题"), DefaultValue("")]
        public string Title
        {
            set
            {
                this.titleLabel.Text = value;
            }
            get
            {
                return this.titleLabel.Text;
            }
        }
        #endregion

        //返回到上级视图
        private void closeButton_Click(object sender, EventArgs e)
        {
            MainViewManage.RemoveView();
        }
    }
}
