using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPTable.Models;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes.Tools.NetOperation;
using DevExpress.XtraEditors.Controls;
using NetBarMS.Views.OtherMain;
using DevExpress.XtraEditors;
using NetBarMS.Codes.Model;
using System.Drawing.Drawing2D;

namespace NetBarMS.Views.NetUserManage
{
    
    public partial class MemberManageView : RootUserControlView
    {
        private enum TitleList
        {
            None,

            Check = 0,              //勾选
            IdNumber,               //身份证号
            Gender,                 //性别
            Name,                   //姓名
            MemberType,             //会员类型
            PhoneNumber,            //手机号
            OpenCardTime,           //开卡时间
            LastUseTime,            //上次使用时间
            RemMoney,               //剩余金额
            AccRcMoney,             //累积充值金额
            AccGvMoney,             //累积赠送金额
            Integral,               //积分
            UseIntegral,            //已用积分
            LoopsStatus,            //指纹状态
            Status,                 //状态
            Verify,                 //验证
            UserMsg,                //用户信息
            CsRecord,               //消费记录
            NetRecord,              //上网记录


        }
        private Int32 pageBegin = 0,pageSize = 15;        //页面开始的页数,开始的Size
        private Int32 field = 0;            //需要按照排序的字段
        private Int32 order = 0;            //升序还是降序
        private IList<StructMember> members;
        private List<MemberTypeModel> memberTypes;

        public MemberManageView()
        {
            InitializeComponent();
            InitUI();
        }

        #region 初始化UI
        // 初始化UI
        private void InitUI()
        {
            this.statusComboBoxEdit.Paint += Control_Paint;
            this.memberTypeComboBoxEdit.Paint += Control_Paint;


            //初始化ComboBoxEdit
            //会员状态
            foreach (string status in Enum.GetNames(typeof(MEMBERSTATUS)))
            {
                this.statusComboBoxEdit.Properties.Items.Add(status);
            }

            //会员类型
            this.memberTypes = SysManage.MemberTypes;
            this.memberTypeComboBoxEdit.Properties.Items.Add("无");
            for (int i = 0; i < this.memberTypes.Count(); i++)
            {
                this.memberTypeComboBoxEdit.Properties.Items.Add(memberTypes[i].typeName);
            }
            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.MemberManage, out this.mainDataTable,ColumnButtonClick,null);
            this.gridControl1.DataSource = this.mainDataTable;

            GetMemberList();

        }

        //重绘控件
        private void Control_Paint(object sender, PaintEventArgs e)
        {



            //GraphicsPath path = new GraphicsPath();

            //int thisWidth = e.ClipRectangle.Width;
            //int thisHeight = e.ClipRectangle.Height;
            //int angle = 5;
            //Pen linePen = Pens.Blue;
            //int ArcWidth = angle;
            //int ArcHeight = angle;
            //int ArcX1 = 1;
            //int ArcX2 =  thisWidth - (ArcWidth + 1);
            //int ArcY1 = 1;
            //int ArcY2 = thisHeight - (ArcHeight + 1);
            if (e.ClipRectangle.X == 0)
            {

                //画出图形  
                //                4个int分别表示矩形的左上角X，Y坐标，矩形的宽和高，C#里面画的椭圆的大小是用矩形来定义的，你定义矩形后，绘制的就是矩形的内切椭圆，后面两个为起始角度和终止角度与起始角度的夹角。
                //考虑边线宽度
                //path.AddArc(ArcX1, ArcY1, angle, angle, 180, 90);
                //path.AddArc(ArcX2, ArcY1, angle, angle, 270, 90);
                //path.AddArc(ArcX2, ArcY2, angle, angle, 360, 90);
                //path.AddArc(ArcX1, ArcY2, angle, angle, 90, 90);
                //path.CloseAllFigures();
                //e.Graphics.DrawPath(linePen, path);
                //e.Graphics.pa(Brushes.White, path);

                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Blue, ButtonBorderStyle.Solid);


            }
            else
            {

                //oPath.AddArc(thisWidth - angle, y, angle, angle, 270, 90);                 // 右上角
                //oPath.AddArc(thisWidth - angle, thisHeight - angle, angle, angle, 0, 90);  // 右下角
                //oPath.CloseAllFigures();
                ////e.Graphics.DrawPath(Pens.Blue, oPath);
                //   e.Graphics.DrawArc(Brushes.Blue, oPath);

                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                    Color.Transparent, 0, ButtonBorderStyle.Solid,
                    Color.Blue, 1, ButtonBorderStyle.Solid,
                    Color.Blue, 1, ButtonBorderStyle.Solid,
                    Color.Blue, 1, ButtonBorderStyle.Solid);

            }

        }
        public static GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }
        #endregion

        #region 获取会员列表
        //获取会员列表
        private void GetMemberList()
        {
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pageBegin,
                Pagesize = this.pageSize,
                Fieldname = this.field,
                Order = this.order,      //
            };
            MemberNetOperation.GetMemberList(MemberListResult, page.Build());
        }
        
        // 获取所有会员列表数据的回调
        public void MemberListResult(ResultModel result)
        {

            if (result.pack.Cmd != Cmd.CMD_MEMBER_LIST)
            {
                return;
            }
            NetMessageManage.RemoveResultBlock(MemberListResult);
            //System.Console.WriteLine("MemberListBlock:" + result.pack);
            if (result.pack.Content.MessageType == 1)
            {           
                this.Invoke(new UIHandleBlock(delegate () {
                    this.members = result.pack.Content.ScMemberList.MembersList;
                   RefreshGridControl();
                }));
            }
        }
        #endregion

        #region 更新GridControl
        //更新GridControl
        private void RefreshGridControl()
        {
            this.mainDataTable.Clear();
            for (int i = 0; i < this.members.Count; i++)
            {
                StructMember member = this.members[i];
                AddNewRow(member);

            }
        }

        //添加新行数据
        private void AddNewRow(StructMember member)
        {

            DataRow row = this.mainDataTable.NewRow();
            this.mainDataTable.Rows.Add(row);
            row[TitleList.IdNumber.ToString()] = member.Cardnumber;
            row[TitleList.Gender.ToString()] = member.Gender;
            row[TitleList.Name.ToString()] = member.Name;
            row[TitleList.MemberType.ToString()] = SysManage.GetMemberTypeName(member.Membertype.ToString());
            row[TitleList.PhoneNumber.ToString()] = member.Phone;
            row[TitleList.OpenCardTime.ToString()] = member.Opentime;
            row[TitleList.LastUseTime.ToString()] = member.Lasttime;
            row[TitleList.RemMoney.ToString()] = member.Balance;
            row[TitleList.AccRcMoney.ToString()] = member.TotalRecharge;
            row[TitleList.AccGvMoney.ToString()] = member.TotalBonus;
            row[TitleList.Integral.ToString()] = member.Integal;
            row[TitleList.UseIntegral.ToString()] = member.UsedIntegal;
            row[TitleList.Status.ToString()] = Enum.GetName(typeof(MEMBERSTATUS), member.Status);
            row[TitleList.Verify.ToString()] = member.Verify == 0?"未验证":"已验证";

        }
        #endregion

  

        #region 会员删除以及回调
        //删除
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            List<int> ids = GetCheckIds();
            if(ids.Count <= 0)
            {
                return;
            }
            MemberNetOperation.DeleteMember(DeleteMemberResult,ids);

        }
        //删除会员回调
        private void DeleteMemberResult(ResultModel result)
        {
           
            if (result.pack.Cmd == Cmd.CMD_MEMBER_DEL && result.pack.Content.MessageType == 1)
            {
                NetMessageManage.RemoveResultBlock(DeleteMemberResult);
                System.Console.WriteLine("DeleteMemberResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    GetMemberList();
                }));
            

            }
        }
        #endregion
      

        #region 多条件查询会员
        //按照会员状态查询
        private void statusComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchMember();
        }

        //按照会员等级查询
        private void memberTypeComboBoxEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchMember();
        }
        //输入卡号或者姓名查询
        private void SearchButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SearchMember();
        }

        //通过条件查询会员
        private void SearchMember()
        {
            //会员类型
            int type = 0;
            if(this.memberTypeComboBoxEdit.SelectedIndex > 0)
            {
                MemberTypeModel item = this.memberTypes[this.memberTypeComboBoxEdit.SelectedIndex - 1];
                type = item.typeId;
            }

            MEMBERSTATUS status = MEMBERSTATUS.无;
            Enum.TryParse<MEMBERSTATUS>(this.statusComboBoxEdit.Text, out status);

            string key = "";
            if (!this.searchButtonEdit.Text.Equals(this.searchButtonEdit.Properties.NullText))
            {
                key = this.searchButtonEdit.Text;
            }

            //System.Console.WriteLine("type:" + type + "\nstatus:" + status + "\nkey:" + key);
            //测试多条件查询
            StructPage.Builder page = new StructPage.Builder()
            {
                Pagebegin = this.pageBegin,
                Pagesize = this.pageSize,
                Fieldname = field,
                Order = order,      //
            };

            MemberNetOperation.SearchConditionMember(SearchMemberResult, page.Build(), (int)status, type, key);
        }
        //按条件查询会员的回调
        private void SearchMemberResult(ResultModel result)
        {
            if (result.pack.Cmd != Cmd.CMD_MEMBER_FIND)
            {
                return;
            }
            if (result.pack.Content.MessageType == 1)
            {
                //锁定0 激活1 在线2 离线3
                NetMessageManage.RemoveResultBlock(SearchMemberResult);
                //System.Console.WriteLine("SearchMemberResult:" + result.pack);
                this.Invoke(new UIHandleBlock(delegate ()
                {
                    this.members = result.pack.Content.ScMemberFind.MembersList;

                    RefreshGridControl();
                }));

            }
        }
        #endregion

        #region 控件事件
        //获取所有勾选的id
        private List<int> GetCheckIds()
        {
            List<int> ids = new List<int>();

            //获取所有勾选的column
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                DataRow row = this.gridView1.GetDataRow(i);
                string value = row[TitleList.Check.ToString()].ToString();
                if (value.Equals("True"))
                {
                    StructMember member = members[i];
                    ids.Add(member.Memberid);
                }
            }
            return ids;
        }

     

        //按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            DataRow row = this.gridView1.GetDataRow(rowhandle);
            StructMember member = members[rowhandle];


            String tag = (String)e.Button.Tag;
            String[] param = tag.Split('_');
            //查看用户身份信息
            if(param[0].Equals(TitleList.UserMsg.ToString()))
            {
                UserIdDetailView view = new UserIdDetailView(member.Memberid);
                ToolsManage.ShowForm(view, false);
            }
            //消费记录
            else if(param[0].Equals(TitleList.CsRecord.ToString())) 
            {
                MemberConsumeRecordView view = new MemberConsumeRecordView(member.Memberid);
                ToolsManage.ShowForm(view, false);
            }
            //上网记录
            else if(param[0].Equals(TitleList.NetRecord.ToString()))
            {
                MemberNetRecordView view = new MemberNetRecordView(member.Memberid);
                ToolsManage.ShowForm(view, false);
            }
            System.Console.WriteLine("button.Tag:"+ e.Button.Tag);
          




        }
        #endregion



        private Region GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath oPath = new GraphicsPath();
           
            int x = 0;
            int y = 0;
            int thisWidth = rect.Width;
            int thisHeight = rect.Height;
            int angle = radius;
            System.Drawing.Graphics g = CreateGraphics();
            oPath.AddArc(x, y, angle, angle, 180, 90);                                 // 左上角
            oPath.AddArc(thisWidth - angle, y, angle, angle, 270, 90);                 // 右上角
            oPath.AddArc(thisWidth - angle, thisHeight - angle, angle, angle, 0, 90);  // 右下角
            oPath.AddArc(x, thisHeight - angle, angle, angle, 90, 90);                 // 左下角
            oPath.CloseAllFigures();
            Region region = new Region(oPath);
          
            return region;





            //int diameter = radius;

            //Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            //GraphicsPath path = new GraphicsPath();

            ////   左上角   

            //path.AddArc(arcRect, 180, 90);

            ////   右上角   

            //arcRect.X = rect.Right - diameter;

            //path.AddArc(arcRect, 270, 90);

            ////   右下角   

            //arcRect.Y = rect.Bottom - diameter;

            //path.AddArc(arcRect, 0, 90);


            ////   左下角   

            //arcRect.X = rect.Left;

            //path.AddArc(arcRect, 90, 90);

            //path.CloseFigure();




            //return path;

        }
    }

}
