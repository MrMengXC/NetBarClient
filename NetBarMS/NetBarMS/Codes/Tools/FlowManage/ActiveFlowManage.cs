﻿using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBarMS.Views.HomePage.Message;
using NetBarMS.Views.HomePage;

namespace NetBarMS.Codes.Tools.FlowManage
{
    /// <summary>
    /// 用户激活流程
    /// </summary>
    class ActiveFlowManage
    {

        private static ActiveFlowManage _manage = null;
        public string card = "";
       

        public static ActiveFlowManage ActiveFlow()
        {
            if(_manage == null)
            {

                _manage = new ActiveFlowManage();
            }
        
            return _manage;

        }
        public void CardCheckIn(string tem)
        {
            this.card = tem;
            HomePageNetOperation.CardCheckIn(_manage.ActiveFlowResult,this.card);
        }


        const int NEED_RECHARGE = 7;          //需要充值
        const int NEED_REGIST = 6;          //需要注册
        private void ActiveFlowResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_EMK_CHECKIN)
            {
                return;
            }
            System.Console.WriteLine("CardCheckInResult:" + result.pack);
            NetMessageManage.Manager().RemoveResultBlock(ActiveFlowResult);
            if (result.pack.Content.MessageType != 1)
            {

                int tem = int.Parse(result.pack.Content.ErrorTip.Key);

                switch (tem)
                {
                    case NEED_RECHARGE:
                        System.Console.WriteLine("需要充值");
                        UserScanCodeView codeView = new UserScanCodeView(this.card,50);
                        ToolsManage.ShowForm(codeView, false);

                        break;
                    case NEED_REGIST:
                        ReminderOpenMemberView view = new ReminderOpenMemberView();
                        ToolsManage.ShowForm(view, false);

                        break;
                }


                return;
            }
            
            

        }

        //会员注册成功
        public void MemberRegistSuccess()
        {


            this.CardCheckIn(this.card);
        }

    }
}
