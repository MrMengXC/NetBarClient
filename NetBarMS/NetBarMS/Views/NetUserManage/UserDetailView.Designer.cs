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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nationLabel = new System.Windows.Forms.Label();
            this.cardTypeLabel = new System.Windows.Forms.Label();
            this.cardNumberLabel = new System.Windows.Forms.Label();
            this.birthDateLabel = new System.Windows.Forms.Label();
            this.cardTermLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.lssAuthLabel = new System.Windows.Forms.Label();
            this.nationalLabel = new System.Windows.Forms.Label();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.genderLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.titlePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Size = new System.Drawing.Size(450, 50);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 50);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "上网用户身份信息";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 10;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // nationLabel
            // 
            this.nationLabel.Location = new System.Drawing.Point(3, 27);
            this.nationLabel.Name = "nationLabel";
            this.nationLabel.Size = new System.Drawing.Size(168, 25);
            this.nationLabel.TabIndex = 67;
            this.nationLabel.Text = "民族：";
            this.nationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cardTypeLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cardTypeLabel, 2);
            this.cardTypeLabel.Location = new System.Drawing.Point(3, 54);
            this.cardTypeLabel.Name = "cardTypeLabel";
            this.cardTypeLabel.Size = new System.Drawing.Size(302, 25);
            this.cardTypeLabel.TabIndex = 66;
            this.cardTypeLabel.Text = "证件类型：";
            this.cardTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cardNumberLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cardNumberLabel, 2);
            this.cardNumberLabel.Location = new System.Drawing.Point(3, 81);
            this.cardNumberLabel.Name = "cardNumberLabel";
            this.cardNumberLabel.Size = new System.Drawing.Size(302, 25);
            this.cardNumberLabel.TabIndex = 65;
            this.cardNumberLabel.Text = "证件号码：";
            this.cardNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // birthDateLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.birthDateLabel, 2);
            this.birthDateLabel.Location = new System.Drawing.Point(3, 108);
            this.birthDateLabel.Name = "birthDateLabel";
            this.birthDateLabel.Size = new System.Drawing.Size(302, 25);
            this.birthDateLabel.TabIndex = 64;
            this.birthDateLabel.Text = "出生日期：";
            this.birthDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cardTermLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cardTermLabel, 2);
            this.cardTermLabel.Location = new System.Drawing.Point(3, 135);
            this.cardTermLabel.Name = "cardTermLabel";
            this.cardTermLabel.Size = new System.Drawing.Size(302, 25);
            this.cardTermLabel.TabIndex = 63;
            this.cardTermLabel.Text = "证件有效期：";
            this.cardTermLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addressLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.addressLabel, 2);
            this.addressLabel.Location = new System.Drawing.Point(3, 162);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(302, 25);
            this.addressLabel.TabIndex = 68;
            this.addressLabel.Text = "地址：";
            this.addressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lssAuthLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lssAuthLabel, 2);
            this.lssAuthLabel.Location = new System.Drawing.Point(3, 189);
            this.lssAuthLabel.Name = "lssAuthLabel";
            this.lssAuthLabel.Size = new System.Drawing.Size(302, 25);
            this.lssAuthLabel.TabIndex = 69;
            this.lssAuthLabel.Text = "发证机关：";
            this.lssAuthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nationalLabel
            // 
            this.nationalLabel.Location = new System.Drawing.Point(177, 27);
            this.nationalLabel.Name = "nationalLabel";
            this.nationalLabel.Size = new System.Drawing.Size(128, 25);
            this.nationalLabel.TabIndex = 71;
            this.nationalLabel.Text = "国籍：";
            this.nationalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(325, 56);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(100, 142);
            this.pictureEdit1.TabIndex = 72;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.64063F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.35938F));
            this.tableLayoutPanel1.Controls.Add(this.nationalLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.genderLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nationLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lssAuthLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.birthDateLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.addressLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cardTypeLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cardNumberLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cardTermLabel, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 219);
            this.tableLayoutPanel1.TabIndex = 75;
            // 
            // genderLabel
            // 
            this.genderLabel.Location = new System.Drawing.Point(177, 0);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.Size = new System.Drawing.Size(128, 25);
            this.genderLabel.TabIndex = 71;
            this.genderLabel.Text = "性别：";
            this.genderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(168, 25);
            this.nameLabel.TabIndex = 63;
            this.nameLabel.Text = "姓名：";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserIdDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.panel1);
            this.Name = "UserIdDetailView";
            this.Size = new System.Drawing.Size(450, 269);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pictureEdit1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label nationLabel;
        private System.Windows.Forms.Label cardTypeLabel;
        private System.Windows.Forms.Label cardNumberLabel;
        private System.Windows.Forms.Label birthDateLabel;
        private System.Windows.Forms.Label cardTermLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label lssAuthLabel;
        private System.Windows.Forms.Label nationalLabel;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label nameLabel;
    }
}
