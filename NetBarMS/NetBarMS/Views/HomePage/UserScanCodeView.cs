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

            //获取二维码
            HomePageNetOperation.GetRechargeCode(GetRechargeCode, cardNum, recharge,0);
            HomePageNetOperation.GetRecharge(GetRechargeResult);

        }
        //获取充值二维码
        private void GetRechargeCode(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_PRECHARGE)
            {
                return;
            }

            System.Console.WriteLine("GetRechargeCode:" + result.pack);
            NetMessageManage.Manager().RemoveResultBlock(GetRechargeCode);
            if (result.pack.Content.MessageType == 1)
            {

            }

        }
        //获取充值结果
        private void GetRechargeResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_PREBUY)
            {
                return;
            }

            System.Console.WriteLine("GetRechargeResult:" + result.pack);
            NetMessageManage.Manager().RemoveResultBlock(GetRechargeResult);
            if (result.pack.Content.MessageType == 1)
            {

            }
        }
    }
}
