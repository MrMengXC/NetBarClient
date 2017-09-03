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
    public partial class AreaComView : UserControl
    {

        public EventHandler Click;

        public AreaComView()
        {
            InitializeComponent();
            this.ComStatus = COMPUTERSTATUS.空闲;

        }
        /// <summary>
        /// 设置电脑状态
        /// </summary>
        public COMPUTERSTATUS ComStatus
        {

            set
            {
                switch (value)
                {
                    case COMPUTERSTATUS.无:
                        this.panel1.BackgroundImage = Imgs.img_kongxian;
                        break;
                    case COMPUTERSTATUS.空闲:
                        this.panel1.BackgroundImage = Imgs.img_kongxian;
                        break;
                    case COMPUTERSTATUS.在线:
                        this.panel1.BackgroundImage = Imgs.img_zaixian;
                        break;
                    case COMPUTERSTATUS.挂机:
                        this.panel1.BackgroundImage = Imgs.img_guaji;
                        break;
                    case COMPUTERSTATUS.异常:
                        this.panel1.BackgroundImage = Imgs.img_yichang;
                        break;
                    default:
                        break;
                }
            }
        }

        #region 设置标题
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set
            {
                this.label1.Text = value;
            }
           
        }
        #endregion

        #region 按钮点击
        private void panel1_Click(object sender, EventArgs e)
        {
            if (this.Click != null)
            {
                this.Click(this, e);
            }
        }
        #endregion
    }
}
