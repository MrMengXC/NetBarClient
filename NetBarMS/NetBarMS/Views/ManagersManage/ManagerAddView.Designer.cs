namespace NetBarMS.Views.ManagersManage
{
    partial class ManagerAddView
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Size = new System.Drawing.Size(455, 50);
            // 
            // closeBtn
            // 
            this.closeBtn.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Appearance.Options.UseBackColor = true;
            this.closeBtn.Location = new System.Drawing.Point(408, 0);
            this.closeBtn.LookAndFeel.SkinMaskColor = System.Drawing.Color.Transparent;
            this.closeBtn.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 62;
            this.labelControl1.Text = "角色名称：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 138);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 63;
            this.labelControl2.Text = "功能权限：";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(69, 3);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(221, 20);
            this.textEdit1.TabIndex = 64;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(26, 159);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(398, 120);
            this.treeView1.TabIndex = 65;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelControl1);
            this.flowLayoutPanel1.Controls.Add(this.textEdit1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 73);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(299, 32);
            this.flowLayoutPanel1.TabIndex = 66;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(349, 296);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 67;
            this.simpleButton1.Text = "保存";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ManagerAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.labelControl2);
            this.Name = "ManagerAddView";
            this.Size = new System.Drawing.Size(455, 345);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.treeView1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.simpleButton1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
