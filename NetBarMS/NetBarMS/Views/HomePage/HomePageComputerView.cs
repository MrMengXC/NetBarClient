using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools.Manage;
using NetBarMS.Codes.Tools;
using NetBarMS.Views.CustomView;

namespace NetBarMS.Views.HomePage
{
    public partial class HomePageComputerView : UserControl
    {
        /// <summary>
        /// 空闲机子颜色
        /// </summary>
        private Color IDLE_COLOR = Color.Gray;
        /// <summary>
        /// 在线机子颜色
        /// </summary>
        private Color ONLINE_COLOR = Color.Orange;
      
        //显示的数据字典
        private Dictionary<string, List<StructRealTime>> areaComsDict;
        private List<StructRealTime> filterComs;
        private Dictionary<string, Label> LabelDict = new Dictionary<string, Label>();

        private int width = 0, height = 0;

        public HomePageComputerView()
        {
            InitializeComponent();
            width = this.comsBg.Width / 2;
            height = this.comsBg.Height / 2;
            InitUI();
        }

        #region 初始化UI
        private void InitUI()
        {
            this.tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.ColumnStyles.Clear();
            this.tableLayoutPanel1.RowStyles.Clear();

            //获取过滤数据数组
            if (HomePageMessageManage.IsFilter)
            {
                this.filterComs = HomePageMessageManage.FilterComputers;
            }
            else
            {
                this.filterComs = new List<StructRealTime>();
            }

            //初始化列表视图
            InitTableView();
            //int i = 0;
            //foreach (string area in areaComsDict.Keys)
            //{
            //    AddAreaComsPanel(area, i);
            //    i++;
            //}

        }
        const int COLUMN_NUM = 2;
        private void InitTableView ()
        {

            //获取数据字典
            areaComsDict = HomePageMessageManage.GetAreaComsDict();
            int num = areaComsDict.Count();

            this.tableLayoutPanel1.RowCount = num % COLUMN_NUM == 0 ? num / COLUMN_NUM : num / COLUMN_NUM + 1;
            this.tableLayoutPanel1.ColumnCount = COLUMN_NUM;

            this.tableLayoutPanel1.Height = this.tableLayoutPanel1.RowCount * this.comsBg.Height / 2;

            //创建行
            for (int row = 0; row < this.tableLayoutPanel1.RowCount; row++)
            {
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, this.comsBg.Height / 2));
            }
            for (int column = 0; column < this.tableLayoutPanel1.ColumnCount; column++)
            {
                this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, this.tableLayoutPanel1.Width / 2));

            }

            int i = 0;
            foreach (string areaId in areaComsDict.Keys)
            {
                AreaComsView areaComsView = new AreaComsView(areaComsDict[areaId], SysManage.GetAreaName(areaId), ComView_Paint);
                areaComsView.Dock = DockStyle.Fill;
                areaComsView.Name = string.Format("area_{0}", areaId);
                this.tableLayoutPanel1.Controls.Add(areaComsView);
                this.tableLayoutPanel1.SetRow(areaComsView, i / COLUMN_NUM);
                this.tableLayoutPanel1.SetColumn(areaComsView, i % COLUMN_NUM);
                i++;
            }
          

        }    
        //电脑视图重绘
        private void ComView_Paint(object sender, PaintEventArgs e)
        {
            char[] sp = { '_' };
            //电脑id
            string cid = (sender as AreaComView).Name.Split(sp)[1];
            DrawComViewBorder(int.Parse(cid), e.Graphics, e.ClipRectangle);
        }
        #endregion

        #region 刷新电脑数据
        // 刷新电脑状态（开机。下机。认证）
        public void UpdateHomePageData(StructRealTime com)
        {
            this.Invoke(new RefreshUIHandle(delegate {
                
                //获取所对应的电脑
                List<StructRealTime> coms = new List<StructRealTime>();
                if (areaComsDict.Keys.Contains(com.Area))
                {
                    coms = areaComsDict[com.Area];                    
                }
                else
                {
                    coms = areaComsDict["-1"];
                }
                //获取电脑所在数组的索引
                int comIndex = -1;
                try
                {
                    comIndex = coms.Select((StructRealTime tem, int
                  index) => new { tem, index }).Where(a => a.tem.Computerid == com.Computerid).First().index;
                }
                catch (Exception exc)
                {
                    comIndex = -1;
                }

                //通过索引获取电脑
                if(comIndex < 0)
                {
                    return;
                }
                Control[] res = this.comsBg.Controls.Find(string.Format("name_{0}", com.Computerid), true);
                if(res.Count()>0)
                {
                    coms[comIndex] = com;
                    AreaComView updateComView = res.First() as AreaComView;
                    updateComView.Tag = com;
                    COMPUTERSTATUS status = COMPUTERSTATUS.无;
                    Enum.TryParse<COMPUTERSTATUS>(com.Status, out status);
                    updateComView.ComStatus = status;
                }
                //修改过滤数组的值
                int comindex = HomePageMessageManage.GetComputerIndex(com.Computerid, this.filterComs);
                if (comindex < 0)
                {
                    return;
                }
                this.filterComs[comindex] = com;
                this.comsBg.Refresh();

            }));

        }


        #endregion

        #region（修改区域后）重新获取电脑数据进行排列
        public void UpdateHomePageArea()
        {

            this.Invoke(new RefreshUIHandle(delegate {
                InitUI();
            }));

        }
        #endregion

        #region 获取过滤数据
        public void FilterComputers()
        {
            this.Invoke(new RefreshUIHandle(delegate {

                //获取过滤数据数组
                if (HomePageMessageManage.IsFilter)
                {
                    this.filterComs = HomePageMessageManage.FilterComputers;
                }
                else
                {
                    this.filterComs = new List<StructRealTime>();
                }
                this.comsBg.Refresh();
                
            }));

        }

     
        #endregion

        #region 重绘LableBorder
        private void DrawComViewBorder(int comId,Graphics gra,Rectangle rec)
        {

            if (this.filterComs.Where(com => com.Computerid == comId).Count() > 0 && HomePageMessageManage.IsFilter)
            {
                ControlPaint.DrawBorder(gra, rec,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                     Color.Transparent, 0, ButtonBorderStyle.None,
                      Color.Transparent, 0, ButtonBorderStyle.None,
                       Color.Blue, 2, ButtonBorderStyle.Solid);
            }
            else
            {
               
                ControlPaint.DrawBorder(gra,rec,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                     Color.Transparent, 0, ButtonBorderStyle.None,
                      Color.Transparent, 0, ButtonBorderStyle.None,
                       Color.Transparent, 0, ButtonBorderStyle.None);
            }
        }
        #endregion

        //背景板尺寸改变
        private void comsBg_SizeChanged(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Height = this.tableLayoutPanel1.RowCount * this.comsBg.Height / 2;
            for (int row = 0; row < this.tableLayoutPanel1.RowCount; row++)
            {
                RowStyle rowStyle = this.tableLayoutPanel1.RowStyles[row];
                rowStyle.Height = this.comsBg.Height / 2;
            }
            for (int column = 0; column < this.tableLayoutPanel1.ColumnCount; column++)
            {
                ColumnStyle columnStyle = this.tableLayoutPanel1.ColumnStyles[column];
                columnStyle.Width = this.tableLayoutPanel1.Width / 2;

            }
        }
    }

}
