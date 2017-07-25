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

namespace NetBarMS.Views.CustomView
{
    public partial class AreaComsView : UserControl
    {
        /// <summary>
        /// 空闲机子颜色
        /// </summary>
        private Color IDLE_COLOR = Color.Gray;
        /// <summary>
        /// 在线机子颜色
        /// </summary>
        private Color ONLINE_COLOR = Color.Orange;

        #region 初始化视图
        public AreaComsView(List<StructRealTime> coms,string areaName, PaintEventHandler paint)
        {
            InitializeComponent();
            this.ComsTableLayoutPanel.SizeChanged += ComsTableLayoutPanel_SizeChanged;
            this.label1.Text = areaName;
            SetComs(coms,paint);           
        }
        #endregion

        const int COLUMN_NUM = 5;
        const int ROW_NUM = 3;

        #region TableLayoutPanel 尺寸改变触发回调
        private void ComsTableLayoutPanel_SizeChanged(object sender, EventArgs e)
        {
            for (int row = 0; row < this.ComsTableLayoutPanel.RowCount; row++)
            {
                RowStyle rowStyle = this.ComsTableLayoutPanel.RowStyles[row];
                rowStyle.Height = this.ComsTableLayoutPanel.Height / ROW_NUM;
            }
            for (int column = 0; column < this.ComsTableLayoutPanel.ColumnCount; column++)
            {
                ColumnStyle columnStyle = this.ComsTableLayoutPanel.ColumnStyles[column];
                columnStyle.Width = this.ComsTableLayoutPanel.Width / COLUMN_NUM;

            }
        }
        #endregion

        #region 设置电脑
        /// <summary>
        /// 设置电脑
        /// </summary>
        public void SetComs(List<StructRealTime> coms,PaintEventHandler paint)
        {

            this.ComsTableLayoutPanel.RowCount = coms.Count() % COLUMN_NUM == 0?coms.Count/ COLUMN_NUM : coms.Count / COLUMN_NUM + 1;
            this.ComsTableLayoutPanel.RowCount = Math.Max(this.ComsTableLayoutPanel.RowCount, ROW_NUM);

            this.ComsTableLayoutPanel.ColumnCount = COLUMN_NUM;
            for(int row = 0;row < this.ComsTableLayoutPanel.RowCount;row++)
            {
                this.ComsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, this.ComsTableLayoutPanel.Height / ROW_NUM));
            }
            for (int column = 0; column < this.ComsTableLayoutPanel.ColumnCount; column++)
            {
                this.ComsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, this.ComsTableLayoutPanel.Width / COLUMN_NUM));

            }
            for (int i = 0;i<coms.Count;i++)
            {
                StructRealTime com = coms[i];

                //创建显示的Label
                Label comLabel = new Label();
                comLabel.Text = com.Computer;
                comLabel.AutoSize = false;
                comLabel.Dock = DockStyle.Fill;
                comLabel.TextAlign = ContentAlignment.MiddleCenter;
                comLabel.ForeColor = Color.White;
                comLabel.Padding = new Padding(0);
                comLabel.Margin = new Padding(10);
                comLabel.Name = string.Format("name_{0}", com.Computerid);
                comLabel.Paint += paint;
                comLabel.Click += ComLabel_Click;
                comLabel.Tag = com;
                this.ComsTableLayoutPanel.Controls.Add(comLabel);
                this.ComsTableLayoutPanel.SetRow(comLabel, i / COLUMN_NUM);
                this.ComsTableLayoutPanel.SetColumn(comLabel, i % COLUMN_NUM);
                //System.Console.WriteLine(string.Format("row：{0} colunn:{1}", i / COLUMN_NUM, i % COLUMN_NUM));
                COMPUTERSTATUS status = COMPUTERSTATUS.无;
                Enum.TryParse<COMPUTERSTATUS>(com.Status, out status);
                switch (status)
                {
                    case COMPUTERSTATUS.空闲:
                        comLabel.BackColor = IDLE_COLOR;
                        break;
                    case COMPUTERSTATUS.在线:
                        comLabel.BackColor = ONLINE_COLOR;
                        break;
                    default:
                        break;
                }


            }
        }

        //点击进行修改
        private void ComLabel_Click(object sender, EventArgs e)
        {

            StructRealTime com = (StructRealTime)((Label)sender).Tag;
            ComputerDetailView view = new ComputerDetailView(com);
            ToolsManage.ShowForm(view, false);
        }

        #endregion

    }
}
