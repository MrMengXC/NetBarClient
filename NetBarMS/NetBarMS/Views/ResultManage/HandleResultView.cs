using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.ResultManage
{
    public partial class HandleResultView : RootFormView

    {
        public HandleResultView(Image img,string msg)
        {
            InitializeComponent();
            this.simpleButton1.Image = img;
            this.label1.Text = msg;
        }
    }
}
