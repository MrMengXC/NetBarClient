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

namespace NetBarMS.Views.HomePage
{
    public partial class HomePageComputerView : UserControl
    {

        private const int width = 580;
        private const int height = 301;




        public HomePageComputerView()
        {
            InitializeComponent();
            AddData();

        }
       
        private void AddData()
        {
            this.bgPanel.AutoScroll = true;
            //this.Location

            for(int i = 0;i<10;i++)
            {
                int x = 10 * (i % 2 + 1) + i%2 * width;
                int y = 10 * (i / 2 + 1) + i/2 * height;

                this.AddArea(new Point(x, y));

            }


        }
        private void AddArea(Point location)
        {

            Panel area = new Panel();
            area.Location = location;
            area.Size = new Size(width, height);
            this.bgPanel.Controls.Add(area);

            //添加电脑小图标
            Panel cpbg = new Panel();
            cpbg.BorderStyle = BorderStyle.FixedSingle;
            cpbg.Location = new Point(0,21);
            cpbg.Size = new Size(width, height - 21);
            cpbg.AutoScroll = true;
            area.Controls.Add(cpbg);

            for(int i = 0;i<50;i++)
            {
                Button cp = new Button();
                int cp_w = 60;
                int cp_h = 53;
                int x = 6 + 10 * (i % 8) + (i % 8) * cp_w;
                int y = 25 + (10 * i) / 8 + (i / 8) * cp_h;

                cp.Location = new Point(x,y);
                cp.Size = new Size(cp_w, cp_h);
                cp.BackColor = Color.Green;
                cpbg.Controls.Add(cp);



            }



        }


    }
}
