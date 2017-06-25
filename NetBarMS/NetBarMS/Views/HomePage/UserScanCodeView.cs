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

namespace NetBarMS.Views.HomePage
{
    /// <summary>
    /// 用户充值页面
    /// </summary>
    public partial class UserScanCodeView : RootUserControlView
    {

        private string cardNum = "";
        int recharge;
        
        public UserScanCodeView(string card,int money)
        {
            InitializeComponent();
            this.titleLabel.Text = "用户充值";
            cardNum = card;
            recharge = money;
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {

            HomePageNetOperation.GetRechargeCode(GetRechargeCode, cardNum, recharge);


        }

        private void GetRechargeCode(ResultModel result)
        {
            System.Console.WriteLine("GetRechargeCode:"+result.pack);

        }
    }
}
