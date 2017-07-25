using NetBarMS.Codes.Tools.NetOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetBarMS.Views.HomePage;
using NetBarMS.Views.UserActive;
using System.Windows.Forms;
using NetBarMS.Views.NetUserManage;
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS.Codes.Tools.FlowManage
{
    
    /// <summary>
    /// 用户激活流程
    /// </summary>
    class ActiveFlowManage
    {
       
        private static ActiveFlowManage _manage = null;
        private StructCard activeCard = null;                        //身份证

        #region 单例方法
        public static ActiveFlowManage ActiveFlow()
        {
            if(_manage == null)
            {
                _manage = new ActiveFlowManage();
                _manage.activeCard = null;
            }
            return _manage;

        }
        #endregion

        #region 进行会员激活
        public void CardCheckIn(StructCard card)
        {
            this.activeCard = new StructCard.Builder(card).Build();
            HomePageNetOperation.CardCheckIn(_manage.ActiveFlowResult, this.activeCard.Number);
        }
        //激活结果回调
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
                FLOW_ERROR error = FLOW_ERROR.OTHER;
                Enum.TryParse<FLOW_ERROR>(result.pack.Content.ErrorTip.Key, out error);
                switch (error)
                {
                    
                    //需要充值
                    case FLOW_ERROR.NEED_RECHARGE:
                        UserScanCodeView codeView = new UserScanCodeView(this.activeCard,100,FLOW_STATUS.ACTIVE_STATUS,(int)PRECHARGE_TYPE.NOT_MEMBER);
                        ToolsManage.ShowForm(codeView, false);
                        break;
                    //提醒是否开通会员
                    case FLOW_ERROR.NEED_ADD_CARD:
                        {
                            AddCardInfo();
                        }
                        break;
                    //用户锁定
                    case FLOW_ERROR.USER_LOCK:
                        {
                            MessageBox.Show("该用户已经被锁");

                        }
                        break;
                }
                return;
            }
            //激活成功后提示激活成功，将值设置成不激活状态
            else
            {
                _manage = null;
                activeCard = null;
                UserActivResultView view = new UserActivResultView();
                ToolsManage.ShowForm(view, false);
            }
            
        }
        #endregion

        #region 添加身份证信息（添加临时会员）
        private void AddCardInfo()
        {             
            MemberNetOperation.AddCardInfo(AddCardInfoResult, this.activeCard);
        }
        //添加身份证信息回调
        private void AddCardInfoResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_EMK_ADD_CARDINFO)
            {
                return;
            }
            //System.Console.WriteLine("AddCardInfoResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(AddCardInfoResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.CardCheckIn(this.activeCard);
            }
        }
        #endregion

        #region 会员注册成功，返回继续激活
        //会员注册成功
        public void MemberRegistSuccess()
        {
            this.CardCheckIn(this.activeCard);
        }
        #endregion

        #region 会员充值成功，返回继续激活
        //会员充值成功
        public void MemberPaySuccess()
        {
            this.CardCheckIn(this.activeCard);
        }
        #endregion
    }
}
