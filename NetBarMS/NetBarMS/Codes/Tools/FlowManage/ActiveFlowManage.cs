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

namespace NetBarMS.Codes.Tools.FlowManage
{
    
    /// <summary>
    /// 用户激活流程
    /// </summary>
    class ActiveFlowManage
    {
       
        private static ActiveFlowManage _manage = null;
        public string card = "";                        //身份证号

        #region 单例方法
        public static ActiveFlowManage ActiveFlow()
        {
            if(_manage == null)
            {
                _manage = new ActiveFlowManage();
                _manage.card = "";
            }
            return _manage;

        }
        #endregion

        #region 进行会员激活
        public void CardCheckIn(string tem)
        {
            this.card = tem;
            HomePageNetOperation.CardCheckIn(_manage.ActiveFlowResult,this.card);

        }
     
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
                //int tem = int.Parse(result.pack.Content.ErrorTip.Key);
                switch (error)
                {
                    //需要充值
                    case FLOW_ERROR.NEED_RECHARGE:
                        UserScanCodeView codeView = new UserScanCodeView(this.card,50,FLOW_STATUS.ACTIVE_STATUS,(int)PRECHARGE_TYPE.NOT_MEMBER);
                        ToolsManage.ShowForm(codeView, false);
                        break;
                    //提醒是否开通会员
                    case FLOW_ERROR.NEED_ADD_CARD:
                        {
                            RemindIsOpenMember();
                        }
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

        #region 添加身份证信息（添加临时会员）
        private void AddCardInfo()
        {
            string cardNum = this.card;
            StructCard.Builder structcard = new StructCard.Builder()
            {
                Name = "xx22",
                Gender = 1,
                Nation = "2112",
                Number = cardNum,
                Birthday = "2012-09-01",
                Address = "海南省",
                Organization = "海南",
                HeadUrl = "#dasdasd#",
                Vld = "",
            };

            MemberNetOperation.AddCardInfo(AddCardInfoResult, structcard.Build());

        }
        //添加身份证信息回调
        private void AddCardInfoResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_EMK_ADD_CARDINFO)
            {
                return;
            }
            System.Console.WriteLine("AddCardInfoResult:" + result.pack);
            NetMessageManage.RemoveResultBlock(AddCardInfoResult);
            if (result.pack.Content.MessageType == 1)
            {
                this.CardCheckIn(this.card);
            }
        }
        #endregion

        #region 提醒是否开通会员
        private void RemindIsOpenMember()
        {
            DialogResult res = MessageBox.Show("询问用户是否开通会员！", "提醒", MessageBoxButtons.OKCancel);
            //进入开通会员界面
            if (res == DialogResult.OK)
            {
                OpenMemberView view = new OpenMemberView(FLOW_STATUS.ACTIVE_STATUS, this.card);
                ToolsManage.ShowForm(view, false);
            }
            //添加身份证信息然后进入激活
            else
            {
                AddCardInfo();
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
