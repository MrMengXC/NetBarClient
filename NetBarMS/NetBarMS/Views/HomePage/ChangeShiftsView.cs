using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.HomePage
{
    public partial class ChangeShiftsView : RootUserControlView
    {
        public ChangeShiftsView()
        {
            InitializeComponent();
            this.titleLabel.Text = "交接班";
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
