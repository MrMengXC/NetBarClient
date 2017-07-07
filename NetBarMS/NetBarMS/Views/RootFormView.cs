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

namespace NetBarMS.Views
{
    public partial class RootFormView : UserControl
    {
        public event CloseFormHandle CloseForm;

        public DataTable mainDataTable;     //


        public RootFormView()
        {
            InitializeComponent();
            this.closeBtn.Click += CloseFormClick;
        }

        #region 关闭事件
        //按钮关闭窗体
        private void CloseFormClick(object sender, EventArgs e)
        {
            this.CloseFormClick();
        }

        //关闭窗体方法
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
