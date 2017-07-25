namespace NetBarMS.Views
{
    partial class RootFormView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.titlePanel = new System.Windows.Forms.Panel();
            this.closeBtn = new DevExpress.XtraEditors.SimpleButton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.titlePanel.Controls.Add(this.closeBtn);
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(480, 52);
            this.titlePanel.TabIndex = 62;
            // 
            // closeBtn
            // 
            this.closeBtn.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Appearance.Options.UseBackColor = true;
            this.closeBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.Image = global::NetBarMS.Imgs.icon_close;
            this.closeBtn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.closeBtn.Location = new System.Drawing.Point(433, 0);
            this.closeBtn.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.closeBtn.LookAndFeel.UseDefaultLookAndFeel = false;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.closeBtn.Size = new System.Drawing.Size(47, 52);
            this.closeBtn.TabIndex = 3;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(0, 17);
            this.titleLabel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 317);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 64);
            this.panel1.TabIndex = 63;
            // 
            // RootFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titlePanel);
            this.Name = "RootFormView";
            this.Size = new System.Drawing.Size(480, 381);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel titlePanel;
        public System.Windows.Forms.Label titleLabel;
        public DevExpress.XtraEditors.SimpleButton closeBtn;
        private System.Windows.Forms.Panel panel1;
    }
}
