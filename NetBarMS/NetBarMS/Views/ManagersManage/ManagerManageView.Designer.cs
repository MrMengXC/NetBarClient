﻿namespace NetBarMS.Views.ManagersManage
{
    partial class ManagerManageView
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.addManagerButton = new DevExpress.XtraEditors.SimpleButton();
            this.deleteManagerButton = new DevExpress.XtraEditors.SimpleButton();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.deleteManagerButton);
            this.titlePanel.Controls.Add(this.addManagerButton);
            this.titlePanel.Size = new System.Drawing.Size(455, 40);
            this.titlePanel.Controls.SetChildIndex(this.addManagerButton, 0);
            this.titlePanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.titlePanel.Controls.SetChildIndex(this.deleteManagerButton, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(67, 14);
            this.titleLabel.Text = "角色管理";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 46);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(455, 756);
            this.gridControl1.TabIndex = 79;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl1;
            this.gridView.Name = "gridView";
            // 
            // addManagerButton
            // 
            this.addManagerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addManagerButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(229)))), ((int)(((byte)(248)))));
            this.addManagerButton.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addManagerButton.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(146)))), ((int)(((byte)(194)))));
            this.addManagerButton.Appearance.Options.UseBackColor = true;
            this.addManagerButton.Appearance.Options.UseFont = true;
            this.addManagerButton.Appearance.Options.UseForeColor = true;
            this.addManagerButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.addManagerButton.Image = global::NetBarMS.Imgs.icon_tianjia;
            this.addManagerButton.Location = new System.Drawing.Point(318, 7);
            this.addManagerButton.Name = "addManagerButton";
            this.addManagerButton.Size = new System.Drawing.Size(55, 25);
            this.addManagerButton.TabIndex = 80;
            this.addManagerButton.Text = "添加";
            this.addManagerButton.Click += new System.EventHandler(this.addManagerButton_Click);
            // 
            // deleteManagerButton
            // 
            this.deleteManagerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteManagerButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(229)))), ((int)(((byte)(248)))));
            this.deleteManagerButton.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.deleteManagerButton.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(146)))), ((int)(((byte)(194)))));
            this.deleteManagerButton.Appearance.Options.UseBackColor = true;
            this.deleteManagerButton.Appearance.Options.UseFont = true;
            this.deleteManagerButton.Appearance.Options.UseForeColor = true;
            this.deleteManagerButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.deleteManagerButton.Image = global::NetBarMS.Imgs.icon_shanchu;
            this.deleteManagerButton.Location = new System.Drawing.Point(388, 7);
            this.deleteManagerButton.Name = "deleteManagerButton";
            this.deleteManagerButton.Size = new System.Drawing.Size(55, 25);
            this.deleteManagerButton.TabIndex = 81;
            this.deleteManagerButton.Text = "删除";
            this.deleteManagerButton.Click += new System.EventHandler(this.deleteManagerButton_Click);
            // 
            // ManagerManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "ManagerManageView";
            this.Size = new System.Drawing.Size(455, 805);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.SimpleButton addManagerButton;
        private DevExpress.XtraEditors.SimpleButton deleteManagerButton;
    }
}
