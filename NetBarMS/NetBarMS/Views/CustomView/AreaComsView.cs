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

        #region 初始化视图
        public AreaComsView(List<StructRealTime> coms,string areaName, PaintEventHandler paint)
        {
            InitializeComponent();
            this.label1.Text = areaName;
            SetComs(coms,paint);           
        }
        #endregion

        #region 设置电脑
        /// <summary>
        /// 设置电脑
        /// </summary>
        public void SetComs(List<StructRealTime> coms,PaintEventHandler paint)
        {

            
            for (int i = 0;i<coms.Count;i++)
            {
                StructRealTime com = coms[i];
                AreaComView view = new AreaComView();
                view.Tag = com;
                view.Name = string.Format("name_{0}", com.Computerid);
                view.Title = com.Computer;
                view.Click += ComLabel_Click;
                view.Paint += paint;
                this.flowLayoutPanel1.Controls.Add(view);



                COMPUTERSTATUS status = COMPUTERSTATUS.无;
                Enum.TryParse<COMPUTERSTATUS>(com.Status, out status);
                view.ComStatus = status;


            }
        }

        //点击进行修改
        private void ComLabel_Click(object sender, EventArgs e)
        {

            StructRealTime com = (StructRealTime)(sender as AreaComView ).Tag;
            ComputerDetailView view = new ComputerDetailView(com);
            ToolsManage.ShowForm(view, false);
        }

        #endregion

    }
}
