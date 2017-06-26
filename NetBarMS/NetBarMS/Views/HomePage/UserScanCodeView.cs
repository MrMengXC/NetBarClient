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
using System.IO;
using static NetBarMS.Codes.Tools.NetMessageManage;
using NetBarMS.Codes.Tools.FlowManage;

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

            NetMessageManage.Manager().RemoveResultBlock(GetRechargeCode);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    try
                    {
                       // System.Console.WriteLine("GetRechargeCode:" + result.pack);
                        string wxCode = result.pack.Content.ScPreCharge.Qrcode;
                        //System.Console.WriteLine(charge.Qrcode);

                        // byte[] imagebytes = System.Text.Encoding.UTF8.GetString(charge.Qrcode);
                        //   string mgDataStr = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(charge.Qrcode));
                        byte[] imagebytes = Encoding.ASCII.GetBytes(wxCode);


                        ////imagebytes = Convert.FromBase64String(Convert.ToBase64String(imagebytes));//再将字符串分拆成字节数组
                        //MemoryStream ChangeAfterMS = new MemoryStream(imagebytes);//将字节数组保存到新的内存流上

                        //this.pictureEdit1.Image = Image.FromStream(ChangeAfterMS);//将内存流保存成一张图片
                    }
                    catch(System.ArgumentException exc)
                    {
                        System.Console.WriteLine("exc:"+exc.ToString());

                    }
            


                }));
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
                this.Invoke(new UIHandleBlock(delegate 
                {
                    ActiveFlowManage.ActiveFlow().MemberPaySuccess();
                }));
            }
        }
    }
}
