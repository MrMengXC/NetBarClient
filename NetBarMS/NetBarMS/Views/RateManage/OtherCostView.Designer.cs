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
            this.memberCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.temCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.saveButton = new DevExpress.XtraEditors.SimpleButton();
            this.memberMinuteTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.temMinuteTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberMinuteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temMinuteTextEdit.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Size = new System.Drawing.Size(524, 50);
            // 
            // memberCheckEdit
            // 
            this.memberCheckEdit.Location = new System.Drawing.Point(3, 3);
            this.memberCheckEdit.Name = "memberCheckEdit";
            this.memberCheckEdit.Properties.Caption = "会员用户上机第一个小时超过";
            this.memberCheckEdit.Size = new System.Drawing.Size(178, 19);
            this.memberCheckEdit.TabIndex = 62;
            // 
            // temCheckEdit
            // 
            this.temCheckEdit.Location = new System.Drawing.Point(3, 3);
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
            // memberMinuteTextEdit
            // 
            this.memberMinuteTextEdit.Location = new System.Drawing.Point(187, 3);
            this.memberMinuteTextEdit.Name = "memberMinuteTextEdit";
            this.memberMinuteTextEdit.Properties.Mask.EditMask = "[0-9]*";
            this.memberMinuteTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.memberMinuteTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.memberMinuteTextEdit.Size = new System.Drawing.Size(27, 20);
            this.memberMinuteTextEdit.TabIndex = 65;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(220, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 14);
            this.labelControl1.TabIndex = 67;
            this.labelControl1.Text = "分钟按正常费率收费";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(244, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(108, 14);
            this.labelControl2.TabIndex = 68;
            this.labelControl2.Text = "分钟按正常费率收费";
            // 
            // temMinuteTextEdit
            // 
            this.temMinuteTextEdit.Location = new System.Drawing.Point(211, 3);
            this.temMinuteTextEdit.Name = "temMinuteTextEdit";
            this.temMinuteTextEdit.Size = new System.Drawing.Size(27, 20);
            this.temMinuteTextEdit.TabIndex = 69;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelControl24);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 56);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(510, 106);
            this.flowLayoutPanel1.TabIndex = 117;
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(3, 3);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(48, 14);
            this.labelControl24.TabIndex = 89;
            this.labelControl24.Text = "活动配置";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.memberCheckEdit);
            this.flowLayoutPanel2.Controls.Add(this.memberMinuteTextEdit);
            this.flowLayoutPanel2.Controls.Add(this.labelControl1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(380, 28);
            this.flowLayoutPanel2.TabIndex = 90;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.temCheckEdit);
            this.flowLayoutPanel4.Controls.Add(this.temMinuteTextEdit);
            this.flowLayoutPanel4.Controls.Add(this.labelControl2);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 57);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(495, 28);
            this.flowLayoutPanel4.TabIndex = 91;
            // 
            // OtherCostView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.saveButton);
            this.Name = "OtherCostView";
            this.Size = new System.Drawing.Size(524, 193);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberMinuteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temMinuteTextEdit.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit memberCheckEdit;
        private DevExpress.XtraEditors.CheckEdit temCheckEdit;
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private DevExpress.XtraEditors.TextEdit memberMinuteTextEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit temMinuteTextEdit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    }
}
