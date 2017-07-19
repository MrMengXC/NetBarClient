namespace NetBarMS.Views.OtherMain
{
    partial class JXInspectView
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
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.customMonthDate1 = new NetBarMS.Views.CustomView.CustomMonthDate();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.pageView1 = new NetBarMS.Views.CustomView.PageView();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.popupContainerEdit1);
            this.titlePanel.Size = new System.Drawing.Size(689, 50);
            this.titlePanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.titlePanel.Controls.SetChildIndex(this.popupContainerEdit1, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(76, 17);
            this.titleLabel.Text = "绩效考核";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(3, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(683, 539);
            this.gridControl1.TabIndex = 82;
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
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.customMonthDate1);
            this.popupContainerControl1.Location = new System.Drawing.Point(213, 171);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(258, 220);
            this.popupContainerControl1.TabIndex = 85;
            // 
            // customMonthDate1
            // 
            this.customMonthDate1.Dock = System.Windows.Forms.DockStyle.Top;
            this.customMonthDate1.Location = new System.Drawing.Point(0, 0);
            this.customMonthDate1.Name = "customMonthDate1";
            this.customMonthDate1.Size = new System.Drawing.Size(258, 200);
            this.customMonthDate1.TabIndex = 0;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Location = new System.Drawing.Point(103, 17);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.NullText = "请选择时间段进行查询";
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(146, 20);
            this.popupContainerEdit1.TabIndex = 76;
            this.popupContainerEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.PopupContainerEdit1_Closed);
            // 
            // pageView1
            // 
            this.pageView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageView1.Location = new System.Drawing.Point(0, 601);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(689, 30);
            this.pageView1.TabIndex = 86;
            // 
            // JXInspectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageView1);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "JXInspectView";
            this.Size = new System.Drawing.Size(689, 631);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.popupContainerControl1, 0);
            this.Controls.SetChildIndex(this.pageView1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private CustomView.CustomMonthDate customMonthDate1;
        private CustomView.PageView pageView1;
    }
}
