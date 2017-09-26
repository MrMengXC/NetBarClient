namespace NetBarMS.Views.RateManage
{
    partial class OtherCostView
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
            this.temCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.memberMinuteText = new DevExpress.XtraEditors.TextEdit();
            this.memberCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.temMinuteText = new DevExpress.XtraEditors.TextEdit();
            this.label24 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.temCheckEdit.Properties)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberMinuteText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberCheckEdit.Properties)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temMinuteText.Properties)).BeginInit();
            this.SuspendLayout();
           
            // 
            // temCheckEdit
            // 
            this.temCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.temCheckEdit.Location = new System.Drawing.Point(3, 13);
            this.temCheckEdit.Name = "temCheckEdit";
            this.temCheckEdit.Properties.Appearance.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.temCheckEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.temCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.temCheckEdit.Properties.Appearance.Options.UseForeColor = true;
            this.temCheckEdit.Properties.Caption = "临时会员用户上机第一个小时超过";
            this.temCheckEdit.Size = new System.Drawing.Size(297, 22);
            this.temCheckEdit.TabIndex = 63;
            // 
            // saveButton
            // 
            this.saveButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(248)))));
            this.saveButton.Appearance.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.saveButton.Appearance.ForeColor = System.Drawing.Color.White;
            this.saveButton.Appearance.Options.UseBackColor = true;
            this.saveButton.Appearance.Options.UseFont = true;
            this.saveButton.Appearance.Options.UseForeColor = true;
            this.saveButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.saveButton.Location = new System.Drawing.Point(16, 234);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(158, 56);
            this.saveButton.TabIndex = 64;
            this.saveButton.Text = "保存";
            this.saveButton.Click += new System.EventHandler(this.SaveSetting_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.tableLayoutPanel8);
            this.flowLayoutPanel3.Controls.Add(this.tableLayoutPanel13);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(10, 88);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(852, 108);
            this.flowLayoutPanel3.TabIndex = 118;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.memberMinuteText, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.memberCheckEdit, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(510, 48);
            this.tableLayoutPanel8.TabIndex = 118;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.label14.Location = new System.Drawing.Point(319, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(188, 18);
            this.label14.TabIndex = 5;
            this.label14.Text = "分钟按正常费率收费。";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // memberMinuteText
            // 
            this.memberMinuteText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.memberMinuteText.Location = new System.Drawing.Point(271, 3);
            this.memberMinuteText.Name = "memberMinuteText";
            this.memberMinuteText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.memberMinuteText.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.memberMinuteText.Properties.Appearance.Options.UseFont = true;
            this.memberMinuteText.Properties.Appearance.Options.UseForeColor = true;
            this.memberMinuteText.Properties.Appearance.Options.UseTextOptions = true;
            this.memberMinuteText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.memberMinuteText.Properties.AutoHeight = false;
            this.memberMinuteText.Size = new System.Drawing.Size(42, 42);
            this.memberMinuteText.TabIndex = 63;
            this.memberMinuteText.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // memberCheckEdit
            // 
            this.memberCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.memberCheckEdit.Location = new System.Drawing.Point(3, 13);
            this.memberCheckEdit.Name = "memberCheckEdit";
            this.memberCheckEdit.Properties.Appearance.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.memberCheckEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.memberCheckEdit.Properties.Appearance.Options.UseFont = true;
            this.memberCheckEdit.Properties.Appearance.Options.UseForeColor = true;
            this.memberCheckEdit.Properties.Caption = "会员用户上机第一个小时超过";
            this.memberCheckEdit.Size = new System.Drawing.Size(262, 22);
            this.memberCheckEdit.TabIndex = 62;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.AutoSize = true;
            this.tableLayoutPanel13.ColumnCount = 3;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Controls.Add(this.temMinuteText, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.temCheckEdit, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.label24, 2, 0);
            this.tableLayoutPanel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 57);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(545, 48);
            this.tableLayoutPanel13.TabIndex = 120;
            // 
            // temMinuteText
            // 
            this.temMinuteText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.temMinuteText.Location = new System.Drawing.Point(306, 3);
            this.temMinuteText.Name = "temMinuteText";
            this.temMinuteText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.temMinuteText.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.temMinuteText.Properties.Appearance.Options.UseFont = true;
            this.temMinuteText.Properties.Appearance.Options.UseForeColor = true;
            this.temMinuteText.Properties.Appearance.Options.UseTextOptions = true;
            this.temMinuteText.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.temMinuteText.Properties.AutoHeight = false;
            this.temMinuteText.Size = new System.Drawing.Size(42, 42);
            this.temMinuteText.TabIndex = 64;
            this.temMinuteText.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.label24.Location = new System.Drawing.Point(354, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(188, 18);
            this.label24.TabIndex = 7;
            this.label24.Text = "分钟按正常费率收费。";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OtherCostView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.saveButton);
            this.Name = "OtherCostView";
            this.Size = new System.Drawing.Size(862, 456);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.temCheckEdit.Properties)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberMinuteText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberCheckEdit.Properties)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temMinuteText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.CheckEdit temCheckEdit;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label label24;
        private DevExpress.XtraEditors.CheckEdit memberCheckEdit;
        private DevExpress.XtraEditors.TextEdit memberMinuteText;
        private DevExpress.XtraEditors.TextEdit temMinuteText;
    }
}
