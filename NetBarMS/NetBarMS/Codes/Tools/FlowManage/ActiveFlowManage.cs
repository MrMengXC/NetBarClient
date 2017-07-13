using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBarMS.Views.HomePage;
using NetBarMS.Views.UserActive;
namespace NetBarMS.Codes.Tools.FlowManage
{
    
    /// <summary>
    /// 用户激活流程
    /// </summary>
    class ActiveFlowManage
    {
       
        private static ActiveFlowManage _manage = null;
        public string card = "";                        //身份证号
       

        public static ActiveFlowManage ActiveFlow()
        {
            if(_manage == null)
            {
                _manage = new ActiveFlowManage();
                _manage.card = "";
            }
            return _manage;

        }

        #region 进行会员激活
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
            NetMessageManage.RemoveResultBlock(ActiveFlowResult);
            if (result.pack.Content.MessageType != 1)
            {

                int tem = int.Parse(result.pack.Content.ErrorTip.Key);
                switch (tem)
                {
                    //需要充值
                    case NEED_RECHARGE:
                        UserScanCodeView codeView = new UserScanCodeView(this.card,50,FLOW_STATUS.ACTIVE_STATUS,(int)PRECHARGE_TYPE.NOT_MEMBER);
                        ToolsManage.ShowForm(codeView, false);
                        break;
                    //需要注册
                    case NEED_REGIST:
                        //ReminderOpenMemberView view = new ReminderOpenMemberView();
                        //ToolsManage.ShowForm(view, false);
                        break;
                }
                return;
            }
            //激活成功后提示激活成功，将值设置成不激活状态
            else
            {
                //card = "";
                _manage = null;
                UserActivResultView view = new UserActivResultView();
                ToolsManage.ShowForm(view, false);
            }
            
        }
        #endregion
        
        #region 会员注册成功，返回继续激活
        //会员注册成功
        public void MemberRegistSuccess()
        {
            this.CardCheckIn(this.card);
        }
        #endregion

        #region 会员充值成功，返回继续激活
        //会员充值成功
        public void MemberPaySuccess()
        {
            this.CardCheckIn(this.card);
        }
        #endregion
    }
}
