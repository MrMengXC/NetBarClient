using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.ManagerManage
{
    public partial class StaffAddView : RootUserControlView
    {
        public StaffAddView()
        {
            InitializeComponent();
            this.titleLabel.Text = "员工管理";
        }
    }
}
