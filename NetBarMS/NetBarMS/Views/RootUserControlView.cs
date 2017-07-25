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
        }

        protected virtual void RootUserControlView_Disposed(object sender, EventArgs e)
        {
            //System.Console.WriteLine("RootUserControlView_Disposed");
        }
        #region 控件绘制时触发的方法
        protected virtual void Control_Paint(object sender, PaintEventArgs e)
        {
            //System.Console.WriteLine("sender:" + sender.GetType().ToString());

            if (sender.GetType().Equals(typeof(DevExpress.XtraEditors.TextEdit)))
            {
                BorderManage.DrawBorder(e.Graphics, e.ClipRectangle, BORDER_TYPE.TEXTEDIT_BORDER);
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
