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
using NetBarMS.Codes.Tools.Manage;
using DevExpress.XtraEditors;

namespace NetBarMS.Views
{
    public partial class RootFormView : UserControl
    {
        public event CloseFormHandle CloseForm;
        protected DataTable mainDataTable;     //
        protected bool isShowBottom = true;

        public RootFormView()
        {
            InitializeComponent();
            this.closeBtn.Click += CloseFormClick;
            this.Disposed += RootUserControlView_Disposed;
        }

        public virtual void RootUserControlView_Disposed(object sender, EventArgs e)
        {
            //System.Console.WriteLine("RootUserControlView_Disposed");
        }
        #region 设置是否显示底部
        [Browsable(true)]
        [Description("是否显示底部栏"), DefaultValue(true)]
        public bool ShowBottom
        {
            set
            {
                this.isShowBottom = value;
                if (this.isShowBottom)
                {
                    this.bottomPanel.Show();
                }
                else
                {
                    this.bottomPanel.Hide();
                }

            }
            get
            {
                return this.isShowBottom;
            }
        }
        #endregion
        #region 从父视图移除
        protected virtual void CloseFormClick(object sender, EventArgs e)
        {
            this.CloseFormClick();
        }
        #endregion

        #region 关闭窗体方法
        public void CloseFormClick()
        {
            if (this.CloseForm != null)
            {
                this.CloseForm();
            }
            this.FindForm().Close();
        }
        #endregion

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
