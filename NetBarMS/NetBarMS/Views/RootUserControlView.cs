using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools;
using DevExpress.XtraEditors.Controls;

namespace NetBarMS.Views
{
    public partial class RootUserControlView : UserControl
    {
        public event CloseFormHandle CloseForm;
        protected DataTable mainDataTable;     //

        public RootUserControlView()
        {
            InitializeComponent();
            this.rootCloseButton.Click += CloseFormClick;
            this.Disposed += RootUserControlView_Disposed;
        }

        public virtual void RootUserControlView_Disposed(object sender, EventArgs e)
        {

        }
        #region 按钮关闭窗体
        private void CloseFormClick(object sender, EventArgs e)
        {
            this.CloseFormClick();
        }
        #endregion

        #region 关闭窗体方法
        public void CloseFormClick()
        {
            if (this.CloseForm != null)
            {
                this.CloseForm();
            }
            this.FindForm().Close();
        }
        #endregion

    }
}
