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
using NetBarMS.Codes;
using NetBarMS.Codes.Tools.NetOperation;
using System.Threading;
using DevExpress.XtraEditors.Controls;
using static NetBarMS.Codes.Tools.NetMessageManage;

namespace NetBarMS.Views.HomePage
{
    enum TitleList
    {
        None,
        EpNumber=0,         //设备编号
        Area,               //区域
        State,              //状态
        IdCard,             //身份证号
        CardType,           //卡类型
        MoneyType,          //计费方式
        VerifyType,         //验证状态
        ResMoney,           //剩余金钱
        ResTime,            //剩余时间
        BeginTime,          //开始时间
        UseTime,            //已用时间
        EndTime,            //结束时间
        MacLoc,             //Mac地址
        IpLoc,              //IP地址
        Operation           //操作（无用）

    }

    public partial class HomePageListView : UserControl
    {
        public DataTable mainDataTable;     //

        public HomePageListView()
        {
            InitializeComponent();

            InitUI();
            ManagerNetOperation.AccountInfo(AccountInfoBlock);
        }
        //初始化UI
        private void InitUI()
        {
     
            ToolsManage.SetGridView(this.gridView1, GridControlType.HomePageList, out this.mainDataTable, ButtonEdit_ButtonClick, GridView_CustomColumnSort);
            this.gridControl1.DataSource = this.mainDataTable;

        }
        #region 获取信息回调
        // 获取账户信息的回调
        public void AccountInfoBlock(ResultModel result)
        {
        
            if (result.pack.Cmd == Cmd.CMD_ACCOUNT_INFO && result.pack.Content.MessageType == 1)
            {
                NetMessageManage.Manager().RemoveResultBlock(AccountInfoBlock);
                //System.Console.WriteLine("AccountInfoBlock:" + result.pack);
                SysManage.Manage().RequestSysInfo(ResultEvent);

            }
        }
        //请求信息获取Event
        private void ResultEvent()
        {
            System.Console.WriteLine("刷新首页数据");
            //TODO:更新UI 判断数据返回的类型
            //HomePageNetOperation.HompageList(HomePageListBlock);
            this.Invoke(new UIHandleBlock(delegate ()
            {

                this.mainDataTable.Clear();
                IList<StructRealTime> coms = SysManage.Manage().computers;
                for (int i = 0; i < coms.Count; i++)
                {
                    StructRealTime computer = coms[i];
                    AddGridControRow(computer);
                }
            }));
           
        }
        #endregion

        #region 更新GridControl 的数据
        private void AddGridControRow(StructRealTime computer)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.EpNumber.ToString()] = computer.Computer;
            row[TitleList.Area.ToString()] = SysManage.Manage().GetArea(computer.Area);
            row[TitleList.State.ToString()] = computer.Status;
            row[TitleList.IdCard.ToString()] = computer.Cardnumber;
            row[TitleList.CardType.ToString()] = computer.Usertype;
            row[TitleList.MoneyType.ToString()] = computer.Billing;
            row[TitleList.VerifyType.ToString()] = computer.Verify;
            row[TitleList.ResMoney.ToString()] = computer.Balance;
            row[TitleList.ResTime.ToString()] = computer.Remaintime;
            row[TitleList.BeginTime.ToString()] = computer.Starttime;
            row[TitleList.UseTime.ToString()] = computer.Usedtime;
            row[TitleList.EndTime.ToString()] = computer.Stoptime;
            row[TitleList.MacLoc.ToString()] = computer.Mac;
            row[TitleList.IpLoc.ToString()] = computer.Ip;

        }


        #endregion


        #region 按钮列点击事件
        private void ButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            DataRow row = this.gridView1.GetDataRow(rowhandle);
            char[] splites = { '_' };
            string [] btnparams = ((string)e.Button.Tag).Split(splites);

            //锁定
            if(btnparams[1].Equals("1"))
            {
                UserLockView view = new UserLockView();
                ToolsManage.ShowForm(view, false);
            }
            System.Console.WriteLine("ButtonEdit_ButtonClick" + row[TitleList.EpNumber.ToString()]);
        }
        #endregion
        private void GridView_CustomColumnSort(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
      
        {

            System.Console.WriteLine("d点击了猎头");
            //GridView view = sender as GridView;
            //if (view == null) return;
            //try
            //{
            //    if (e.Column.FieldName == "ItemFolderDescription")
            //    {
            //        object val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, "IsEmptyRow");
            //        object val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, "IsEmptyRow");
            //        e.Handled = true;
            //        e.Result = System.Collections.Comparer.Default.Compare(val1, val2);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    //...
            //}
        }
    }
}
