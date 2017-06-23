using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.SystemSearch
{
    public partial class AttendanceSearchView : RootUserControlView
    {
        public AttendanceSearchView()
        {
            InitializeComponent();
            this.titleLabel.Text = "上座率查询";
        }
    }
}
