using System;
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
using DevExpress.XtraEditors.Controls;


namespace NetBarMS.Views.NetUserManage
{
   
    public partial class MemberConsumeRecordView : RootUserControlView
    {
        #region Title ENUM
        private enum TitleList
        {
            None,

            IndentNumber = 0,        //订单号
            IdNumber,               //身份证号
            Name,                   //姓名
            Area,                   //位置
            Use,                    //手用途
            Money,                  //消费金额
            Time,                   //时间
            PayChannel,             //付款渠道


        }
        #endregion
        private Int32 mid;
        private DateTime lastDate = DateTime.MinValue;
        private string startTime = "", endTime = "";

        public MemberConsumeRecordView(int temmid)
        {
            InitializeComponent();
            this.titleLabel.Text = "会员消费记录查询";
            this.mid = temmid;
            InitUI();
            MemberConsumeRecord();

        }

       
        #region 初始化UI
        //初始化UI数据    
        private void InitUI()
        {
            //            支付宝1 财付通（微信）2 积分兑换 3 现金4
            //购物1 充值2
            //初始化ComboBoxEdit

            //string[] uses = {"无","购物","充值"};
            //string[] paychannels = { "无", "支付宝", "微信", "积分兑换", "现金" };
            foreach(string use in Enum.GetNames(typeof(CONSUMEUSE)))
            {
                this.useComboBoxEdit.Properties.Items.Add(use);
            }
            foreach (string pay in Enum.GetNames(typeof(PAYCHANNEL)))
            {
                this.payChannelComboBoxEdit.Properties.Items.Add(pay);
            }
            // 设置 comboBox的文本值不能被编辑
            this.useComboBoxEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.payChannelComboBoxEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.UpdateSelectionWhenNavigating = false;
            this.dateNavigator.SyncSelectionWithEditValue = false;


            ToolsManage.SetGridView(this.gridView1, GridControlType.UserConsumeRecord, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;

           
        }
        #endregion

        #region 会员消费记录查询/过滤
        //会员消费记录查询
        private void MemberConsumeRecord()
        {
        
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagesize = 15,
                Pagebegin = 0,
                Fieldname = 0,
                Order = 0,
            };
            MemberNetOperation.MemberConsumeRecord(MemberConsumeRecordResult, this.mid,page.Build());

        }
        //会员消费记录查询过滤
        private void MemberConsumeFilterRecord()
        {
            
            int use = 0, pay = 0;
            CONSUMEUSE consume;
            if(Enum.TryParse<CONSUMEUSE>(this.useComboBoxEdit.Text, out consume))
            {
                use = (int)consume;
            }
            PAYCHANNEL paychannel;
            if (Enum.TryParse<PAYCHANNEL>(this.payChannelComboBoxEdit.Text, out paychannel))
            {
                pay = (int)paychannel;
            }


            StructPage.Builder page = new StructPage.Builder() {
                Pagesize = 15,
                Pagebegin = 0,
                Fieldname = 0,
                Order = 0,
            };
            MemberNetOperation.MemberConsumeRecordFilter(MemberConsumeRecordResult, page.Build(),mid,startTime, endTime, use, pay);

        }

        //会员消费记录查询结果
        private void MemberConsumeRecordResult(ResultModel result)
        {
            if(result.pack.Content.MessageType != 1)
            {
                return;
            }
            if (result.pack.Cmd == Cmd.CMD_MEMBER_CONSUM_RECORD )
            {
                NetMessageManage.Manage().RemoveResultBlock(MemberConsumeRecordResult);
                System.Console.WriteLine(result.pack);
                this.Invoke(new UIHandleBlock(delegate {
                    UpdateGridControl(result.pack.Content.ScMemberConsumRecord.ConsuminfoList);

                }));        
            }else if(result.pack.Cmd == Cmd.CMD_MEMBER_CONSUM_FILTER)
            {
                NetMessageManage.Manage().RemoveResultBlock(MemberConsumeRecordResult);
                System.Console.WriteLine("MemberConsumeRecordFilterResult" + result.pack);
                this.Invoke(new UIHandleBlock(delegate {
                    this.mainDataTable.Clear();
                    UpdateGridControl(result.pack.Content.ScMemberConsumFilter.ConsuminfoList);

                }));
            }
        }
        #endregion

        #region 更新GridControl 数据
        //更新GridControl列表数据
        private void UpdateGridControl(IList<StructConsum> list)
        {
            foreach(StructConsum consum in list)
            {
                AddGridControlNewRow(consum);
            }
        }
        //添加新行
        private void AddGridControlNewRow(StructConsum consum)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);             
            row[TitleList.IndentNumber.ToString()] = consum.Consumid;
            row[TitleList.Name.ToString()] = consum.Username;
            row[TitleList.IdNumber.ToString()] = consum.Cardnumber;
            row[TitleList.Area.ToString()] = consum.Area;
            row[TitleList.Use.ToString()] = consum.Consumtype;
            row[TitleList.Money.ToString()] = consum.Money;
            row[TitleList.Time.ToString()] = consum.Time;
            row[TitleList.PayChannel.ToString()] = consum.Paymode;
           

        }
        #endregion

        #region 过滤条件搜索/日期/用途/付款渠道
        //关闭日期选择菜单
        private void PopupContainerEdit1_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            System.Console.WriteLine("PopupContainerEdit1_Closed");
            MemberConsumeFilterRecord();
        }

        //日期选择触发
        private void DateNavigator_EditValueChanged(object sender, System.EventArgs e)
        {
            lastDate = ToolsManage.GetDateNavigatorRangeTime(this.dateNavigator, lastDate, out this.startTime, out this.endTime);
        }

        //用途搜索
        private void useComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemberConsumeFilterRecord();
        }
        //支付渠道搜索
        private void payChannelComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemberConsumeFilterRecord();
        }
        #endregion
    }
}
