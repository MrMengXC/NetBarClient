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

namespace NetBarMS.Views.SystemManage
{
    public partial class StaffMoneyView : RootUserControlView
    {
        public StaffMoneyView()
        {
            InitializeComponent();
            this.titleLabel.Text = "员工提成设置";
        }

       
    }
}
