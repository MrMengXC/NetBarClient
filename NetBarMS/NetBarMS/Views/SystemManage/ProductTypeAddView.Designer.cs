namespace NetBarMS.Views.SystemManage
{
    partial class ProductTypeAddView
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.typeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.titlePanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(77, 12);
            this.titleLabel.Text = "商品类别增改";
            // 
            // closeBtn
            // 
            this.closeBtn.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Appearance.Options.UseBackColor = true;
            this.closeBtn.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.closeBtn.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.simpleButton1);
            this.bottomPanel.Location = new System.Drawing.Point(0, 182);
            this.bottomPanel.Size = new System.Drawing.Size(480, 40);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.typeTextEdit);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(72, 86);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(330, 34);
            this.flowLayoutPanel2.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品类别名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeTextEdit
            // 
            this.typeTextEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.typeTextEdit.Location = new System.Drawing.Point(100, 3);
            this.typeTextEdit.Name = "typeTextEdit";
            this.typeTextEdit.Properties.AutoHeight = false;
            this.typeTextEdit.Size = new System.Drawing.Size(221, 28);
            this.typeTextEdit.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButton1.Location = new System.Drawing.Point(194, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(92, 29);
            this.simpleButton1.TabIndex = 64;
            this.simpleButton1.Text = "保存";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ProductTypeAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel2);
            this.Name = "ProductTypeAddView";
            this.Size = new System.Drawing.Size(480, 222);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.bottomPanel, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel2, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.typeTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit typeTextEdit;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
