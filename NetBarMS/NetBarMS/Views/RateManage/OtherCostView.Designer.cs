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
            this.memberMinuteText = new DevExpress.XtraEditors.TextEdit();
            this.memberCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.temMinuteText = new DevExpress.XtraEditors.TextEdit();
            this.label24 = new System.Windows.Forms.Label();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temCheckEdit.Properties)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberMinuteText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberCheckEdit.Properties)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temMinuteText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Size = new System.Drawing.Size(524, 50);
            // 
            // temCheckEdit
            // 
            this.temCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.temCheckEdit.Location = new System.Drawing.Point(3, 6);
            this.temCheckEdit.Name = "temCheckEdit";
            this.temCheckEdit.Properties.Caption = "临时会员用户上机第一个小时超过";
            this.temCheckEdit.Size = new System.Drawing.Size(202, 19);
            this.temCheckEdit.TabIndex = 63;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(209, 167);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 64;
            this.saveButton.Text = "保存";
            this.saveButton.Click += new System.EventHandler(this.SaveSetting_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.tableLayoutPanel8);
            this.flowLayoutPanel3.Controls.Add(this.tableLayoutPanel13);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(13, 56);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(500, 94);
            this.flowLayoutPanel3.TabIndex = 118;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.memberMinuteText, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.memberCheckEdit, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(346, 31);
            this.tableLayoutPanel8.TabIndex = 118;
            // 
            // memberMinuteText
            // 
            this.memberMinuteText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.memberMinuteText.Location = new System.Drawing.Point(187, 3);
            this.memberMinuteText.Name = "memberMinuteText";
            this.memberMinuteText.Properties.AutoHeight = false;
            this.memberMinuteText.Size = new System.Drawing.Size(25, 25);
            this.memberMinuteText.TabIndex = 63;
            this.memberMinuteText.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // memberCheckEdit
            // 
            this.memberCheckEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.memberCheckEdit.Location = new System.Drawing.Point(3, 6);
            this.memberCheckEdit.Name = "memberCheckEdit";
            this.memberCheckEdit.Properties.Caption = "会员用户上机第一个小时超过";
            this.memberCheckEdit.Size = new System.Drawing.Size(178, 19);
            this.memberCheckEdit.TabIndex = 62;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(218, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 12);
            this.label14.TabIndex = 5;
            this.label14.Text = "分钟按正常费率收费。";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 40);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(370, 31);
            this.tableLayoutPanel13.TabIndex = 120;
            // 
            // temMinuteText
            // 
            this.temMinuteText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.temMinuteText.Location = new System.Drawing.Point(211, 3);
            this.temMinuteText.Name = "temMinuteText";
            this.temMinuteText.Properties.AutoHeight = false;
            this.temMinuteText.Size = new System.Drawing.Size(25, 25);
            this.temMinuteText.TabIndex = 64;
            this.temMinuteText.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(242, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(125, 12);
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
            this.Size = new System.Drawing.Size(524, 222);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel3, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
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
