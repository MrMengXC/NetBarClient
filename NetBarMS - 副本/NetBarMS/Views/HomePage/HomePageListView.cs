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
using NetBarMS.Codes.Tools.Manage;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using NetBarMS.Codes.Model;

namespace NetBarMS.Views.HomePage
{
    

    public partial class HomePageListView : UserControl
    {
        #region Enum
        private enum TitleList
        {
            None,
            EpNumber = 0,         //设备编号
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

        private enum BTN_NAME
        {
            强制下机 = 1,
            锁定,
            验证,
            已验证,

        }
        #endregion

        #region property
        //数据源DataTable
        private DataTable mainDataTable;
        //电脑列表
        private List<StructRealTime> coms;
        //GridControl 的正常Edit列 和 已 验证列
        private RepositoryItemButtonEdit normalEdit, verietyEdit;
        #endregion

        #region 初始化
        public HomePageListView()
        {
            InitializeComponent();
            InitUI();
        }
        #endregion

        #region 初始化UI
        private void InitUI()
        {
            //获取两种不同状态的RepositoryItemButtonEdit
            string[] nor = { BTN_NAME.强制下机.ToString(), BTN_NAME.锁定.ToString(), BTN_NAME.验证.ToString() };
            string[] ver = { BTN_NAME.强制下机.ToString(), BTN_NAME.锁定.ToString(), BTN_NAME.已验证.ToString() };
            SetButtonItem(out normalEdit, nor);
            SetButtonItem(out verietyEdit, ver);

            //设置GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.HomePageList, out this.mainDataTable, ButtonEdit_ButtonClick);
            this.gridControl1.DataSource = this.mainDataTable;
            this.gridView1.CustomRowCellEdit += GridView1_CustomRowCellEdit;
   
        }
        //设置RepositoryItemButtonEdit
        private void SetButtonItem(out RepositoryItemButtonEdit buttonEdit,string[] buttonNames)
        {
            buttonEdit = new RepositoryItemButtonEdit();
            buttonEdit.Buttons.Clear();
            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            buttonEdit.ButtonClick += ButtonEdit_ButtonClick;

            int num = 0;
            //int width = 8;
            foreach (string name in buttonNames)
            {
             
                EditorButton button = new EditorButton();
                button.Kind = ButtonPredefines.Glyph;
                button.Enabled = true;

                BTN_NAME btnname = (BTN_NAME)Enum.Parse(typeof(BTN_NAME), name);
                switch (btnname)
                {
                    case BTN_NAME.已验证:
                        {
                            button.Appearance.ForeColor = Color.Gray;
                            button.Enabled = false;
                        }
                        break;
                    case BTN_NAME.验证:
                        {
                            button.Appearance.ForeColor = Color.Blue;

                        }
                        break;
                    case BTN_NAME.强制下机:
                        button.Appearance.ForeColor = Color.FromArgb(255, 192, 128);

                        break;
                    case BTN_NAME.锁定:
                        button.Appearance.ForeColor = Color.FromArgb(255, 128, 128);

                        break;

                    default:
                        break;
                }


                //按钮显示
                button.Visible = true;
                button.Tag = TitleList.Operation.ToString() + "_" + num;
                button.Caption = name;
                //width += 50;

                button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                buttonEdit.Buttons.Add(button);
                num++;
            }
        }
        //监听CustomRowCellEdit
        private void GridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (!e.Column.FieldName.Equals(TitleList.Operation.ToString()))
            {
                return;
            }
            //System.Console.WriteLine("GridView1_CustomDrawCell:" + e.RowHandle);
            StructRealTime com = this.coms[e.RowHandle];
            //是否认证
            if (com.Verify.Equals("1"))
            {
                e.RepositoryItem = verietyEdit;
            }
            else
            {
                e.RepositoryItem = normalEdit;
            }
        }       
        #endregion

        #region 更新首页数据
        //更新电脑显示数据
        public void UpdateHomePageData(StructRealTime com)
        {
            
            this.Invoke(new RefreshUIHandle(delegate {
                int index = HomePageMessageManage.GetComputerIndex(com.Computerid, this.coms);
                if(index < 0)
                {
                    return;
                }
                this.coms[index] = com;
                DataRow row = this.mainDataTable.Rows[index];
                AddNewRow(com, row);
            }));
           
        }
        //更新单个电脑区域数据
        public void UpdateHomePageArea(StructRealTime com)
        {
            this.Invoke(new RefreshUIHandle(delegate {
                int index = HomePageMessageManage.GetComputerIndex(com.Computerid, this.coms);
                if (index < 0)
                {
                    return;
                }
                //判断一下区域id和获取的名称是否相同
                StructRealTime ori = this.coms[index];
                DataRow row = this.mainDataTable.Rows[index];
                string areaName = row[TitleList.Area.ToString()] as string;
                string newAreaName = SysManage.GetAreaName(com.Area);

                if (com.Area.Equals(ori.Area) && newAreaName.Equals(areaName))
                {
                    System.Console.WriteLine ("更新的电脑没有改变");
                    return;
                }
                this.coms[index] = com;
                row[TitleList.Area.ToString()] = newAreaName;
            }));

        }
        #endregion

        #region 获取过滤数据
        public void FilterComputers()
        {
            this.Invoke(new RefreshUIHandle(delegate {
                RefreshGridControl();
            }));
  
        }
        #endregion

        #region 更新GridControl 的数据
        private void RefreshGridControl()
        {
            this.coms = HomePageMessageManage.FilterComputers;
            this.mainDataTable.Rows.Clear();
            for (int i = 0; i < this.coms.Count; i++)
            {
                StructRealTime computer = coms[i];
                AddNewRow(computer,null);
            }
        }
        //添加新行
        private void AddNewRow(StructRealTime computer, DataRow row)
        {
            //this.gridView1.RefreshRow
            
            if (row == null)
            {
                row = this.mainDataTable.NewRow();
                this.mainDataTable.Rows.Add(row);
            }
            else
            {
                int index = this.mainDataTable.Rows.IndexOf(row);
                this.mainDataTable.Rows.Remove(row);
                row = this.mainDataTable.NewRow();
                this.mainDataTable.Rows.InsertAt(row, index);
            }

            row[TitleList.EpNumber.ToString()] = computer.Computer;
            row[TitleList.Area.ToString()] = SysManage.GetAreaName(computer.Area);

            COMPUTERSTATUS status = COMPUTERSTATUS.在线;
            Enum.TryParse<COMPUTERSTATUS>(computer.Status, out status);
            //TODO:状态需要判断
            row[TitleList.State.ToString()] = Enum.GetName(typeof(COMPUTERSTATUS),status);
            row[TitleList.IdCard.ToString()] = computer.Cardnumber;
            row[TitleList.CardType.ToString()] = SysManage.GetMemberTypeName(computer.Usertype);
            row[TitleList.MoneyType.ToString()] = computer.Billing;
         
            if(computer.Verify.Equals(""))
            {
                row[TitleList.VerifyType.ToString()] = "";
            }
            else
            {
                row[TitleList.VerifyType.ToString()] = computer.Verify.Equals("1") ? "已验证" : "未验证";
            }
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
            StructRealTime computer = coms[rowhandle];
            if(computer.Cardnumber.Equals(""))
            {
                return;
            }

            DataRow row = this.gridView1.GetDataRow(rowhandle);
            char[] splites = { '_' };
            string [] btnparams = ((string)e.Button.Tag).Split(splites);
            //锁定
            if(btnparams[1].Equals("1"))
            {
                UserLockView view = new UserLockView(computer.Cardnumber);
                ToolsManage.ShowForm(view, false);
            }
            //强制下机
            else if (btnparams[1].Equals("0"))
            {
                List<string> cards = new List<string>() { computer.Cardnumber};
                HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.TICKOFF, cards);       
            }
            //验证
            else if (btnparams[1].Equals("2"))
            {
                List<string> cards = new List<string>() { computer.Cardnumber };
                HomePageNetOperation.ManagerCommandOperation(ManagerCommandOperationResult, COMMAND_TYPE.VERIFY, cards);
            }

        }
        //管理员操作结果回调
        private void ManagerCommandOperationResult(ResultModel result)
        {
            if(result.pack.Cmd != Cmd.CMD_COMMAND)
            {
                return;
            }

            NetMessageManage.RemoveResultBlock(ManagerCommandOperationResult);
            System.Console.WriteLine("ManagerCommandOperationResult:"+result.pack);
            if(result.pack.Content.MessageType == 1)
            {
                this.Invoke(new RefreshUIHandle(delegate {

                    //MessageBox.Show("验证成功");
                }));
            }

        }


        #endregion

    }
}
