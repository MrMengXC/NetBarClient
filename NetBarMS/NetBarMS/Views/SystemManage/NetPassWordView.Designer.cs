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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pwCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.pwTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.titlePanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pwCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Size = new System.Drawing.Size(450, 50);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(170, 104);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 65;
            this.saveButton.Text = "保存";
            this.saveButton.Click += new System.EventHandler(this.SaveSetting_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pwCheckEdit);
            this.flowLayoutPanel1.Controls.Add(this.pwTextEdit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(30, 68);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(356, 30);
            this.flowLayoutPanel1.TabIndex = 66;
            // 
            // pwCheckEdit
            // 
            this.pwCheckEdit.Location = new System.Drawing.Point(3, 3);
            this.pwCheckEdit.Name = "pwCheckEdit";
            this.pwCheckEdit.Properties.Caption = "使用默认密码    默认密码设置：";
            this.pwCheckEdit.Size = new System.Drawing.Size(195, 19);
            this.pwCheckEdit.TabIndex = 0;
            // 
            // pwTextEdit
            // 
            this.pwTextEdit.Location = new System.Drawing.Point(204, 3);
            this.pwTextEdit.Name = "pwTextEdit";
            this.pwTextEdit.Size = new System.Drawing.Size(100, 20);
            this.pwTextEdit.TabIndex = 1;
            // 
            // NetPassWordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.saveButton);
            this.Name = "NetPassWordView";
            this.Size = new System.Drawing.Size(450, 145);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pwCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pwTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton saveButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.CheckEdit pwCheckEdit;
        private DevExpress.XtraEditors.TextEdit pwTextEdit;
    }
}
