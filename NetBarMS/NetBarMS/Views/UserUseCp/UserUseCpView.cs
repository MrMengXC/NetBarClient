﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.UserUseCp
{
    public partial class UserUseCpView : RootUserControlView
    {
        public UserUseCpView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户上机";
        }
    }
}
