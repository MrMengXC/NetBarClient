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
    public partial class CustomMonthDate : UserControl
    {
        private DateTime startTime = DateTime.MinValue;
        private DateTime endTime = DateTime.MinValue;
        private DateTime currentTime = DateTime.MinValue;



        public CustomMonthDate()
        {
            InitializeComponent();
           
            DateTime time = DateTime.Now;
            int year = time.Year;
            this.YearLabel.Text = year + "";

            //显示当年月份
            ShowCurrentYearMonths();

        }

        #region 显示当年月份
        //显示当前年的月份
        private void ShowCurrentYearMonths()
        {
            DateTime time = DateTime.Now;
            int year = time.Year;
            int month = time.Month;

            int currentYear = int.Parse(this.YearLabel.Text);
            foreach (Label control in this.tableLayoutPanel1.Controls)
            {
                if(control.GetType().Equals(typeof(Label)))
                {
                    string tag = (string)control.Tag;
                    DateTime temTime = TagToDate(tag, currentYear);

                    if (year == temTime.Year && month == temTime.Month)
                    {
                        control.BackColor = Color.Wheat;
                    }
                    else
                    {
                        control.BackColor = Color.White;
                    }

                    if (!currentTime.Equals(DateTime.MinValue))
                    {
                        //if(temTime.CompareTo(startTime)>=0 && temTime.CompareTo(endTime) <= 0)
                        //{
                        //    control.BackColor = Color.Blue;
                        //}
                        if(temTime.CompareTo(currentTime) == 0)
                        {
                            control.BackColor = Color.Blue;
                        }
                    }
                }
            }

        }

        #endregion

        #region 点击日期
        //选择日期
        private void Control_Click(object sender, EventArgs e)
        {



            int currentYear = int.Parse(this.YearLabel.Text);
            string tag = (string)((Label)sender).Tag;


            DateTime temTime = TagToDate(tag, currentYear);


            //这是不连续的方法
            currentTime = temTime;
            ShowCurrentYearMonths();

            //关闭




            return;
            if (currentTime.Equals(DateTime.MinValue))
            {
                startTime = temTime;
                endTime = temTime;
            }
            else
            {
                int res = temTime.CompareTo(currentTime);

                if(res < 0)
                {
                    startTime = temTime;
                    endTime = currentTime;
                }else if(res == 0)
                {
                    startTime = temTime;
                    endTime = temTime;
                }
                else
                {
                    startTime = currentTime;
                    endTime = temTime;
                }


            }
            currentTime = temTime;
            // System.Console.WriteLine("start:" + startTime + "end:" + endTime);// (");
            //this.durLabel.Text = startTime.ToString("yyyy-MM") + " 至 " + endTime.ToString("yyyy-MM");
            ShowCurrentYearMonths();


        }

        #endregion

        #region String->DateTime
        //tag值转DateTime
        private DateTime TagToDate(string tag,int year)
        {
            int month = int.Parse(tag);
            string date = year.ToString() + "-" + string.Format("{0:D2}", month);

           DateTime time = DateTime.ParseExact(date, "yyyy-MM", System.Globalization.CultureInfo.CurrentCulture);

            return time;
        }
        #endregion

        #region 下一年
        //下一年
        private void NextButton_Click(object sender, EventArgs e)
        {
            this.YearLabel.Text = int.Parse(this.YearLabel.Text) + 1 + "";
            ShowCurrentYearMonths();
        }

        //上一年
        private void lastButton_Click(object sender, EventArgs e)
        {
            this.YearLabel.Text = int.Parse(this.YearLabel.Text) - 1 + "";
            ShowCurrentYearMonths();
        }
        #endregion

        #region 获取当前区间时间
        public void GetCurrentTimeDur(out String start,out string end,string format)
        {

            if(currentTime.Equals(DateTime.MinValue))
            {
                start = null;
                end = null;
            }else
            {
                start = this.startTime.ToString(format);
                end = this.endTime.ToString(format);
            }
        }
        #endregion

        #region 获取当前年月
        public void GetCurrentTimeDur(out int year, out int month)
        {

            if (currentTime.Equals(DateTime.MinValue))
            {
                DateTime current = DateTime.Now;
                current = current.AddMonths(-1);
                year = current.Year;
                month = current.Month;


            }
            else
            {
                year = this.currentTime.Year;
                month = this.currentTime.Month;

            }
        }
        #endregion


    }
}
