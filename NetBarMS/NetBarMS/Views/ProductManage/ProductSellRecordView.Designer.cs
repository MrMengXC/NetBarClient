namespace NetBarMS.Views.ProductManage
{
    partial class ProductSellRecordView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.pageView1 = new NetBarMS.Views.CustomView.PageView();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.popupContainerEdit1);
            this.titlePanel.Size = new System.Drawing.Size(990, 50);
            this.titlePanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.titlePanel.Controls.SetChildIndex(this.popupContainerEdit1, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(144, 17);
            this.titleLabel.Text = "商品销售记录查询";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(11, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(974, 682);
            this.gridControl1.TabIndex = 78;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 50);
            this.panel1.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "商品销售记录查询";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(967, 15);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 20);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Location = new System.Drawing.Point(158, 15);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.NullText = "请选择时间段进行查询";
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(146, 20);
            this.popupContainerEdit1.TabIndex = 0;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.dateNavigator1);
            this.popupContainerControl1.Location = new System.Drawing.Point(261, 145);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(258, 220);
            this.popupContainerControl1.TabIndex = 1;
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator1.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator1.Location = new System.Drawing.Point(0, 3);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.Size = new System.Drawing.Size(255, 214);
            this.dateNavigator1.TabIndex = 0;
            // 
            // pageView1
            // 
            this.pageView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageView1.Location = new System.Drawing.Point(0, 744);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(990, 30);
            this.pageView1.TabIndex = 79;
            // 
            // ProductSellRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageView1);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ProductSellRecordView";
            this.Size = new System.Drawing.Size(990, 774);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.popupContainerControl1, 0);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.pageView1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            this.ResumeLayout(false);

        }

      

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private CustomView.PageView pageView1;
    }
}
