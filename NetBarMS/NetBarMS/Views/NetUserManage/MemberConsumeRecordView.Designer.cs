namespace NetBarMS.Views.NetUserManage
{
    partial class MemberConsumeRecordView
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.closeButton = new System.Windows.Forms.Button();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.useComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.payChannelComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pageView1 = new NetBarMS.Views.CustomView.PageView();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.useComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payChannelComboBoxEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.payChannelComboBoxEdit);
            this.titlePanel.Controls.Add(this.popupContainerEdit1);
            this.titlePanel.Controls.Add(this.useComboBoxEdit);
            this.titlePanel.Size = new System.Drawing.Size(1241, 40);
            this.titlePanel.Controls.SetChildIndex(this.useComboBoxEdit, 0);
            this.titlePanel.Controls.SetChildIndex(this.popupContainerEdit1, 0);
            this.titlePanel.Controls.SetChildIndex(this.payChannelComboBoxEdit, 0);
            this.titlePanel.Controls.SetChildIndex(this.titleLabel, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(97, 14);
            this.titleLabel.Text = "用户消费记录";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 46);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1241, 723);
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
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(1077, 15);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 20);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Location = new System.Drawing.Point(127, 8);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.popupContainerEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.popupContainerEdit1.Properties.Appearance.Options.UseFont = true;
            this.popupContainerEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.popupContainerEdit1.Properties.AutoHeight = false;
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::NetBarMS.Imgs.icon_jiantou, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.popupContainerEdit1.Properties.NullText = "请选择时间段进行查询";
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(180, 25);
            this.popupContainerEdit1.TabIndex = 3;
            this.popupContainerEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.PopupContainerEdit1_Closed);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.dateNavigator);
            this.popupContainerControl1.Location = new System.Drawing.Point(691, 166);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(288, 261);
            this.popupContainerControl1.TabIndex = 4;
            // 
            // dateNavigator
            // 
            this.dateNavigator.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator.DateTime = new System.DateTime(2017, 6, 18, 9, 13, 50, 738);
            this.dateNavigator.EditValue = new System.DateTime(2017, 6, 18, 9, 13, 50, 738);
            this.dateNavigator.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateNavigator.Location = new System.Drawing.Point(3, 3);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.Size = new System.Drawing.Size(283, 258);
            this.dateNavigator.TabIndex = 0;
            this.dateNavigator.DateTimeChanged += new System.EventHandler(this.DateNavigator_EditValueChanged);
            // 
            // useComboBoxEdit
            // 
            this.useComboBoxEdit.Location = new System.Drawing.Point(323, 8);
            this.useComboBoxEdit.Name = "useComboBoxEdit";
            this.useComboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.useComboBoxEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.useComboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.useComboBoxEdit.Properties.Appearance.Options.UseForeColor = true;
            this.useComboBoxEdit.Properties.AutoHeight = false;
            this.useComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.useComboBoxEdit.Properties.NullText = "按用途进行筛选";
            this.useComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.useComboBoxEdit.Size = new System.Drawing.Size(180, 25);
            this.useComboBoxEdit.TabIndex = 1;
            this.useComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.useComboBoxEdit_SelectedIndexChanged);
            // 
            // payChannelComboBoxEdit
            // 
            this.payChannelComboBoxEdit.Location = new System.Drawing.Point(519, 8);
            this.payChannelComboBoxEdit.Name = "payChannelComboBoxEdit";
            this.payChannelComboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.payChannelComboBoxEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.payChannelComboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.payChannelComboBoxEdit.Properties.Appearance.Options.UseForeColor = true;
            this.payChannelComboBoxEdit.Properties.AutoHeight = false;
            this.payChannelComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.payChannelComboBoxEdit.Properties.NullText = "按付款渠道进行筛选";
            this.payChannelComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.payChannelComboBoxEdit.Size = new System.Drawing.Size(180, 25);
            this.payChannelComboBoxEdit.TabIndex = 2;
            this.payChannelComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.payChannelComboBoxEdit_SelectedIndexChanged);
            // 
            // pageView1
            // 
            this.pageView1.BackColor = System.Drawing.Color.Transparent;
            this.pageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageView1.Location = new System.Drawing.Point(0, 775);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(1241, 30);
            this.pageView1.TabIndex = 80;
            this.pageView1.PageChangedEvent += new NetBarMS.Codes.Tools.PageChangedHandle(this.PageView_PageChanged);
            // 
            // MemberConsumeRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.pageView1);
            this.Controls.Add(this.gridControl1);
            this.Name = "MemberConsumeRecordView";
            this.Size = new System.Drawing.Size(1241, 805);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.pageView1, 0);
            this.Controls.SetChildIndex(this.popupContainerControl1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.useComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payChannelComboBoxEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }




        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.Button closeButton;
        private DevExpress.XtraEditors.ComboBoxEdit useComboBoxEdit;
        private DevExpress.XtraEditors.ComboBoxEdit payChannelComboBoxEdit;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
        private CustomView.PageView pageView1;
    }
}
