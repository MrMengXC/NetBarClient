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
using NetBarMS.Views.HomePage;

namespace NetBarMS.Views
{
    public partial class ComputerDetailView : RootFormView
    {
        private StructRealTime currentCom;

        public ComputerDetailView(StructRealTime com)
        {
            InitializeComponent();
            currentCom = com;
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {
            COMPUTERSTATUS status = COMPUTERSTATUS.空闲;
            Enum.TryParse<COMPUTERSTATUS>(currentCom.Status, out status);
            if (status == COMPUTERSTATUS.异常 || status == COMPUTERSTATUS.空闲)
            {
                this.simpleButton1.Enabled = this.simpleButton2.Enabled = false;
            }
            char[] sp = { ':', '：' };

            //姓名
            this.label1.Text = string.Format("{0}：{1}", this.label1.Text.Split(sp)[0], currentCom.Name);
            //卡号
            this.label3.Text = string.Format("{0}：{1}", this.label3.Text.Split(sp)[0], currentCom.Cardnumber);
            //会员等级
            this.label4.Text = string.Format("{0}：{1}", this.label4.Text.Split(sp)[0], SysManage.GetMemberTypeName(currentCom.Usertype));
            //上网开始时间
            this.label5.Text = string.Format("{0}：{1}", this.label5.Text.Split(sp)[0], currentCom.Starttime);
            //上网时长
            this.label6.Text = string.Format("{0}：{1}", this.label6.Text.Split(sp)[0], currentCom.Usedtime);
            //账户余额
            this.label7.Text = string.Format("{0}：{1}", this.label7.Text.Split(sp)[0], currentCom.Balance);

            //状态
            this.label8.Text = string.Format("{0}：{1}", this.label8.Text.Split(sp)[0], Enum.GetName(typeof(COMPUTERSTATUS), status));
            //区域
            this.label9.Text = string.Format("{0}：{1}", this.label9.Text.Split(sp)[0], SysManage.GetAreaName(currentCom.Area));
            //ip
            this.label10.Text = string.Format("{0}：{1}", this.label10.Text.Split(sp)[0], currentCom.Ip);
            //mac
            this.label11.Text = string.Format("{0}：{1}", this.label11.Text.Split(sp)[0], currentCom.Mac);

            
           
        }
        //强制下机
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<string> cards = new List<string>() { currentCom.Cardnumber };
            HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.TICKOFF, cards);
        }

        //管理员操作结果回调
        private void ManagerCommandOperationResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_COMMAND)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(ManagerCommandOperationResult);
            System.Console.WriteLine("ManagerCommandOperationResult:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {
                    this.CloseFormClick();
                }));
            }

        }

        //封禁账户
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            UserLockView view = new UserLockView(currentCom.Cardnumber);
            ToolsManage.ShowForm(view, false);
        }
    }
}
