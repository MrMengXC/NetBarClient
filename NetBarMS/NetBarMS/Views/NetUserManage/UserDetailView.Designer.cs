namespace NetBarMS.Views
{
    partial class UserIdDetailView
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
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.organLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.cardValidityLabel = new System.Windows.Forms.Label();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.cardNumLabel = new System.Windows.Forms.Label();
            this.cardTypeLabel = new System.Windows.Forms.Label();
            this.nationLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.genderLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Size = new System.Drawing.Size(560, 40);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(77, 12);
            this.titleLabel.Text = "上网用户信息";
            // 
            // closeBtn
            // 
            this.closeBtn.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Appearance.Options.UseBackColor = true;
            this.closeBtn.Location = new System.Drawing.Point(513, 0);
            this.closeBtn.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.closeBtn.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureEdit1.Location = new System.Drawing.Point(425, 56);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(119, 170);
            this.pictureEdit1.TabIndex = 72;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.94183F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.05817F));
            this.tableLayoutPanel2.Controls.Add(this.organLabel, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.addressLabel, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.cardValidityLabel, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.birthdayLabel, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cardNumLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cardTypeLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.nationLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.genderLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.countryLabel, 1, 1);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 56);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(395, 192);
            this.tableLayoutPanel2.TabIndex = 73;
            // 
            // organLabel
            // 
            this.organLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.organLabel, 2);
            this.organLabel.Location = new System.Drawing.Point(5, 173);
            this.organLabel.Margin = new System.Windows.Forms.Padding(5);
            this.organLabel.Name = "organLabel";
            this.organLabel.Size = new System.Drawing.Size(77, 14);
            this.organLabel.TabIndex = 17;
            this.organLabel.Text = "发证机关：";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.addressLabel, 2);
            this.addressLabel.Location = new System.Drawing.Point(5, 149);
            this.addressLabel.Margin = new System.Windows.Forms.Padding(5);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(49, 14);
            this.addressLabel.TabIndex = 16;
            this.addressLabel.Text = "地址：";
            // 
            // cardValidityLabel
            // 
            this.cardValidityLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.cardValidityLabel, 2);
            this.cardValidityLabel.Location = new System.Drawing.Point(5, 125);
            this.cardValidityLabel.Margin = new System.Windows.Forms.Padding(5);
            this.cardValidityLabel.Name = "cardValidityLabel";
            this.cardValidityLabel.Size = new System.Drawing.Size(91, 14);
            this.cardValidityLabel.TabIndex = 15;
            this.cardValidityLabel.Text = "证件有效期：";
            // 
            // birthdayLabel
            // 
            this.birthdayLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.birthdayLabel, 2);
            this.birthdayLabel.Location = new System.Drawing.Point(5, 101);
            this.birthdayLabel.Margin = new System.Windows.Forms.Padding(5);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.Size = new System.Drawing.Size(77, 14);
            this.birthdayLabel.TabIndex = 14;
            this.birthdayLabel.Text = "出生日期：";
            // 
            // cardNumLabel
            // 
            this.cardNumLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.cardNumLabel, 2);
            this.cardNumLabel.Location = new System.Drawing.Point(5, 77);
            this.cardNumLabel.Margin = new System.Windows.Forms.Padding(5);
            this.cardNumLabel.Name = "cardNumLabel";
            this.cardNumLabel.Size = new System.Drawing.Size(77, 14);
            this.cardNumLabel.TabIndex = 13;
            this.cardNumLabel.Text = "证件号码：";
            // 
            // cardTypeLabel
            // 
            this.cardTypeLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.cardTypeLabel, 2);
            this.cardTypeLabel.Location = new System.Drawing.Point(5, 53);
            this.cardTypeLabel.Margin = new System.Windows.Forms.Padding(5);
            this.cardTypeLabel.Name = "cardTypeLabel";
            this.cardTypeLabel.Size = new System.Drawing.Size(77, 14);
            this.cardTypeLabel.TabIndex = 12;
            this.cardTypeLabel.Text = "证件类型：";
            // 
            // nationLabel
            // 
            this.nationLabel.AutoSize = true;
            this.nationLabel.Location = new System.Drawing.Point(5, 29);
            this.nationLabel.Margin = new System.Windows.Forms.Padding(5);
            this.nationLabel.Name = "nationLabel";
            this.nationLabel.Size = new System.Drawing.Size(49, 14);
            this.nationLabel.TabIndex = 11;
            this.nationLabel.Text = "民族：";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(5, 5);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(5);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(49, 14);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "姓名：";
            // 
            // genderLabel
            // 
            this.genderLabel.AutoSize = true;
            this.genderLabel.Location = new System.Drawing.Point(245, 5);
            this.genderLabel.Margin = new System.Windows.Forms.Padding(5);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(49, 14);
            this.genderLabel.TabIndex = 19;
            this.genderLabel.Text = "性别：";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(245, 29);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(5);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(49, 14);
            this.countryLabel.TabIndex = 18;
            this.countryLabel.Text = "国籍：";
            // 
            // UserIdDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "UserIdDetailView";
            this.ShowBottom = false;
            this.Size = new System.Drawing.Size(560, 267);
            this.Controls.SetChildIndex(this.bottomPanel, 0);
            this.Controls.SetChildIndex(this.pictureEdit1, 0);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label organLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label cardValidityLabel;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.Label cardNumLabel;
        private System.Windows.Forms.Label cardTypeLabel;
        private System.Windows.Forms.Label nationLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label countryLabel;
    }
}
