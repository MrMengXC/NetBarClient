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
        public delegate void CloseFormHandle();
        public event CloseFormHandle CloseForm;

        public DataTable mainDataTable;     //


        public RootUserControlView()
        {
            InitializeComponent();
            this.closeButton.Click += CloseFormClick;
        }
        private void CloseFormClick(object sender, EventArgs e)
        {
            this.CloseFormClick();
        }

        public void CloseFormClick()
        {
            if (this.CloseForm != null)
            {
                this.CloseForm();
            }
            this.FindForm().Close();

        }

        private void topView1_Load(object sender, EventArgs e)
        {

        }
    }
}
