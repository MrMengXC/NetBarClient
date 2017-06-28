using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.CustomView
{
    public partial class PageView : UserControl
    {
        public int page = 1;
        public int allPage = 0;

        public PageView()
        {
            InitializeComponent();
        }

        //上一页
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
        //下一页
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
