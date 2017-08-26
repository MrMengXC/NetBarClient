namespace NetBarMS.Views.SystemManage
{
    partial class NetPassWordView
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
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.pwCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.pwTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pwCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwTextEdit.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanelView1
            // 
            this.titlePanelView1.ShowCloseButton = false;
            this.titlePanelView1.Size = new System.Drawing.Size(803, 78);
            this.titlePanelView1.Title = "上网密码设置";
            // 
            // saveButton
            // 
            this.saveButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(248)))));
            this.saveButton.Appearance.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.saveButton.Appearance.ForeColor = System.Drawing.Color.White;
            this.saveButton.Appearance.Options.UseBackColor = true;
            this.saveButton.Appearance.Options.UseFont = true;
            this.saveButton.Appearance.Options.UseForeColor = true;
            this.saveButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.saveButton.Location = new System.Drawing.Point(10, 160);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(184, 56);
            this.saveButton.TabIndex = 65;
            this.saveButton.Text = "保存";
            this.saveButton.Click += new System.EventHandler(this.SaveSetting_Click);
            // 
            // pwCheckEdit
            // 
            this.pwCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pwCheckEdit.Location = new System.Drawing.Point(3, 11);
            this.pwCheckEdit.Name = "pwCheckEdit";
            this.pwCheckEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pwCheckEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.pwCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.pwCheckEdit.Properties.Appearance.Options.UseForeColor = true;
            this.pwCheckEdit.Properties.Caption = "使用默认密码    默认密码设置：";
            this.pwCheckEdit.Size = new System.Drawing.Size(274, 26);
            this.pwCheckEdit.TabIndex = 0;
            // 
            // pwTextEdit
            // 
            this.pwTextEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pwTextEdit.Location = new System.Drawing.Point(283, 3);
            this.pwTextEdit.Name = "pwTextEdit";
            this.pwTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.pwTextEdit.Properties.Appearance.Options.UseFont = true;
            this.pwTextEdit.Properties.AutoHeight = false;
            this.pwTextEdit.Properties.Mask.EditMask = "[0-9]*";
            this.pwTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.pwTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.pwTextEdit.Size = new System.Drawing.Size(182, 42);
            this.pwTextEdit.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pwTextEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pwCheckEdit, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 88);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(468, 48);
            this.tableLayoutPanel1.TabIndex = 67;
            // 
            // NetPassWordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.saveButton);
            this.Name = "NetPassWordView";
            this.Size = new System.Drawing.Size(803, 398);
            this.Controls.SetChildIndex(this.titlePanelView1, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pwCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwTextEdit.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.CheckEdit pwCheckEdit;
        private DevExpress.XtraEditors.TextEdit pwTextEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
