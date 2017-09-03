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
using DevExpress.XtraEditors;
using NetBarMS.Codes.Tools.Manage;

namespace NetBarMS.Views
{
    public partial class RootUserControlView : UserControl
    {
        protected DataTable mainDataTable;     //

        public RootUserControlView()
        {
            InitializeComponent();
            this.Disposed += RootUserControlView_Disposed;
            //双缓冲
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

        }

        protected virtual void RootUserControlView_Disposed(object sender, EventArgs e)
        {
            //System.Console.WriteLine("RootUserControlView_Disposed");
        }
        #region 控件绘制时触发的方法
        protected virtual void Control_Paint(object sender, PaintEventArgs e)
        {
            //System.Console.WriteLine("sender:" + sender.GetType().ToString());
            Graphics gr = e.Graphics;
            //这是输入框
            if (sender.GetType().Equals(typeof(TextEdit)))
            {
                BorderManage.DrawBorder(e.Graphics, e.ClipRectangle, BORDER_TYPE.TEXTEDIT_BORDER);
            }
            //这是下拉菜单
            else if(sender.GetType().Equals(typeof(ComboBoxEdit)))
            {
                Rectangle rect = (sender as ComboBoxEdit).ClientRectangle;
                ControlPaint.DrawBorder(e.Graphics, rect, ControlColor.EDITBOX_BORDCOLOR, ButtonBorderStyle.Solid);

            }
            //这是搜索框
            else if (sender.GetType().Equals(typeof(ButtonEdit))&& !sender.GetType().Equals(typeof(SimpleButton)))
            {
                Rectangle rect = (sender as ButtonEdit).ClientRectangle;
                ControlPaint.DrawBorder(e.Graphics, rect, ControlColor.EDITBOX_BORDCOLOR, ButtonBorderStyle.Solid);
            }
        }
        #endregion
        #region 设置Combox的图标和下拉高度字体
        /// <summary>
        /// 设置Combox下拉箭头
        /// </summary>
        /// <param name="coms">combox 数组</param>
        /// <param name="isDate">是否是日期</param>
        protected void SetupCombox(ComboBoxEdit[] coms,bool isDate)
        {
            foreach (ComboBoxEdit combox in coms)
            {


                combox.Properties.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                combox.Properties.Buttons[0].Image = Imgs.icon_jiantou;
                if(!isDate)
                {
                    combox.Properties.AppearanceDropDown.Font = new Font("Tahoma", 15, GraphicsUnit.Pixel);
                    combox.Properties.DropDownItemHeight = 25;
                }
            }
        }

        #endregion


        #region 初始化TextEdit
        /// <summary>
        /// 初始化TextEdit，使其只能进行数字输入
        /// </summary>
        /// <param name="textEdits"></param>
        protected void InitTextEdit(TextEdit[] textEdits)
        {
            foreach (TextEdit textEdit in textEdits)
            {
                textEdit.LostFocus += DRechargeText_LostFocus;
                textEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                textEdit.Properties.Mask.EditMask = "[0-9]*";
                textEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            }
        }
        #endregion

        #region TextEdit 失去光标焦点
        protected void DRechargeText_LostFocus(object sender, EventArgs e)
        {
            if (sender.GetType().Equals(typeof(TextEdit)))
            {
                TextEdit text = sender as TextEdit;
                if (!text.Equals(""))
                {
                    text.Text = string.Format("{0}", int.Parse(text.Text));
                }
            }
        }
        #endregion
    }
}
