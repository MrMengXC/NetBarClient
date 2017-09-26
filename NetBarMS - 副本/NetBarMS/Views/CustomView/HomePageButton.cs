using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Views.CustomView
{
    public partial class HomePageButton : UserControl
    {
        private bool IsShowNum = true;
        public event EventHandler TitleButtonClick;

        public HomePageButton()
        {
            InitializeComponent();
            this.simpleButton1.Click += SimpleButton1_Click;


        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if(this.TitleButtonClick != null)
            {
                this.TitleButtonClick(sender,e);
            }

        }

        [Browsable(true)]
        [Description("设置img") DefaultValue(null)]
        public Image ButtonImage
        {
            get
            {
                return this.simpleButton1.Image;
            }
            set
            {
                this.simpleButton1.Image = value;
            }
        }

        [Browsable(true)]
        [Description("设置名称") DefaultValue("")]
        public string TitleText
        {
            get
            {
                return this.simpleButton1.Text;
            }
            set
            {
                this.simpleButton1.Text = value;
            }
        }

        [Browsable(true)]
        [Description("设置数量Label是否显示") DefaultValue(true)]
        public bool ShowNumLabel
        {
            get
            {
                return this.IsShowNum;
            }
            set
            {
                this.IsShowNum = value;
                if(this.IsShowNum)
                {
                    this.numLabel.Show();
                }
                else
                {
                    this.numLabel.Hide();
                }
            }
        }

        [Browsable(true)]
        [Description("设置数量Label坐标") ]
        public Point NumLabelLocation
        {
            get
            {
                return this.numLabel.Location;
            }
            set
            {
                this.numLabel.Location = value;
            }
        }

        [Browsable(true)]
        [Description("设置数量Label尺寸")]
        public Size NumLabelSize
        {
            get
            {
                return this.numLabel.Size;
            }
            set
            {
                this.numLabel.Size = value;
            }
        }

        public int Num
        {
            get
            {
                return int.Parse(this.numLabel.Text);
            }
            set
            {
                this.numLabel.Text = value + "";
            }
        }

       
    }
}
