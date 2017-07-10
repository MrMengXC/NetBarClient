﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Tools.NetOperation;

namespace NetBarMS.Views.HomePage
{
    public partial class ChangeShiftsView : RootUserControlView
    {
        private List<StructAccount> staffs;
        public ChangeShiftsView()
        {
            InitializeComponent();
            this.titleLabel.Text = "交接班";
            InitUI();
        }

        #region 初始化UI
        private void InitUI()
        {
            GetGiveStaffInfo();
            SysManage.Manage().GetStaffs(out staffs);
            foreach (StructAccount staff in this.staffs)
            {
                this.comboBoxEdit1.Properties.Items.Add(staff.Username);
            }

        }
        #endregion

        //获取交班人信息
        private void GetGiveStaffInfo()
        {
            HomePageNetOperation.GetGiveStaffInfo(GetGiveStaffInfoResult);
        }
        //获取交班人信息结果反馈
        private void GetGiveStaffInfoResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_SHIFT_DELIVEREDBY)
            {
                return;
            }
            NetMessageManage.Manage().RemoveResultBlock(GetGiveStaffInfoResult);
            System.Console.WriteLine("GetGiveStaffInfoResult:" + result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate {
                    SCShiftDeliveredBy give = result.pack.Content.ScShiftDeliveredBy;
                    this.changeLabel.Text += give.DeliveredBy;
                    this.payMoneyLabel.Text += give.ChargeAmount;
                    this.sellMoneyLabel.Text += give.SaleAmount;


                }));
            }

        }

        //登录（添加交接班记录）
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //接班人
            string receive = this.comboBoxEdit1.Text;
            string ps1 = this.textEdit1.Text;
            //交班人
            string ps2 = this.textEdit3.Text;

            if (receive.Equals("") || ps1.Equals("")  ||ps2.Equals("") ||(!this.checkEdit1.Checked && !this.checkEdit2.Checked))
            {
                MessageBox.Show("请将信息填写完整");
                return;
            }
            int ischecked = this.checkEdit1.Checked ? 1 : 0;
            string remark = this.textBox1.Text;
            HomePageNetOperation.AddChangeStaff(AddChangeStaffResult, ps2, receive, ps1, ischecked, remark);
        }

        //登录交班结果反馈
        private void AddChangeStaffResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_SHIFT_ADD)
            {
                return;
            }

            System.Console.WriteLine("AddChangeStaffResult:" + result.pack);
            NetMessageManage.Manage().RemoveResultBlock(AddChangeStaffResult);

            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new UIHandleBlock(delegate
                {
                    MessageBox.Show("交接班成功");
                    this.CloseFormClick();
                }));
            }


        }

        private void checkEdit_CheckedChanged(object sender, EventArgs e)
        {
            //选择正确
            if(sender.Equals(this.checkEdit1))
            {
                if(this.checkEdit2.Checked && this.checkEdit1.Checked)
                {
                    this.checkEdit2.Checked = false;
                }
            }
            //选择不正确
            else
            {
                if (this.checkEdit2.Checked && this.checkEdit1.Checked)
                {
                    this.checkEdit1.Checked = false;
                }
            }
        }

        //进行打印库存清单
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //TODO:
        }
    }
}
