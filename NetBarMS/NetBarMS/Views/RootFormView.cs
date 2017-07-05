using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views
{
    public partial class RootFormView : UserControl
    {
        //关闭窗体代理
        public delegate void CloseFormHandle();
        public event CloseFormHandle CloseForm;

        public DataTable mainDataTable;     //


        public RootFormView()
        {
            InitializeComponent();
            this.closeButton.Click += CloseFormClick;
        }
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
    }
}
