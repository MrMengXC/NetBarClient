using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools.NetOperation;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Tools.FlowManage;

namespace NetBarMS.Views.UserUseCp
{



    public partial class UserActiveView : RootUserControlView
    {

        public UserActiveView()
        {
            InitializeComponent();
            this.titleLabel.Text = "用户上机";
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {

            


        }
        //激活
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if(this.textEdit1.Text.Equals(""))
            {
                return;

            }
            ActiveFlowManage.ActiveFlow().CardCheckIn(this.textEdit1.Text);
        }

     

        //充值
        private void simpleButton2_Click(object sender, EventArgs e)
        {
           
        }

        //下机
        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
