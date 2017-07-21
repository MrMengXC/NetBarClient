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
            width = this.panel1.Width / 2;
            height = this.panel1.Height / 2;
            InitUI();
        }

        #region 初始化UI
        private void InitUI()
        {
            this.panel1.Controls.Clear();
            //获取数据字典
            areaComsDict = HomePageMessageManage.GetAreaComsDict();
            //获取过滤数据数组
            if (HomePageMessageManage.IsFilter)
            {
                this.filterComs = HomePageMessageManage.FilterComputers;
            }
            else
            {
                this.filterComs = new List<StructRealTime>();
            }

            int i = 0;
            foreach (string area in areaComsDict.Keys)
            {
                AddAreaComsPanel(area, i);
                i++;
            }

        }

        
        //添加区域电脑Panel
        private void AddAreaComsPanel(string areaId, int index)
        {
           
            AreaComsView areaComsView = new AreaComsView(areaComsDict[areaId], SysManage.GetAreaName(areaId),ComLabel_Paint);
            areaComsView.Location = new Point(20 * (index % 2 + 1) + index % 2 * width, 20 * (index / 2 + 1) + index / 2 * height);
            areaComsView.Size = new Size(width, height);
            this.panel1.Controls.Add(areaComsView);

        }
        
        //电脑Label重绘
        private void ComLabel_Paint(object sender, PaintEventArgs e)
        {
            char[] sp = { '_' };
            //电脑id
            string cid = ((Label)sender).Name.Split(sp)[1];
            DrawComLabelBorder(int.Parse(cid), e.Graphics, e.ClipRectangle);
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
                Control[] res = this.panel1.Controls.Find(string.Format("name_{0}", com.Computerid), true);
                if(res.Count()>0)
                {
                    coms[comIndex] = com;
                    Label updateComLabel = res.First() as Label;
                    COMPUTERSTATUS status = COMPUTERSTATUS.无;
                    Enum.TryParse<COMPUTERSTATUS>(com.Status, out status);
                    switch (status)
                    {
                        case COMPUTERSTATUS.空闲:
                            updateComLabel.BackColor = IDLE_COLOR;
                            break;
                        case COMPUTERSTATUS.在线:
                            updateComLabel.BackColor = ONLINE_COLOR;
                            break;
                        default:
                            break;
                    }
                }
                //修改过滤数组的值
                int comindex = HomePageMessageManage.GetComputerIndex(com.Computerid, this.filterComs);
                if (comindex < 0)
                {
                    return;
                }
                this.filterComs[comindex] = com;

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
                this.panel1.Refresh();
                
            }));

        }
        #endregion

        #region 重绘LableBorder
        private void DrawComLabelBorder(int comId,Graphics gra,Rectangle rec)
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
    }

}
