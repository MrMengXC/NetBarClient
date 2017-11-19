namespace NetBarMS.Views.SystemSearch
{
    partial class UserNetRecordView
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.searchButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pageView1 = new NetBarMS.Views.CustomView.PageView();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.searchButtonEdit);
            this.titlePanel.Controls.Add(this.popupContainerEdit1);
            this.titlePanel.Controls.Add(this.comboBoxEdit1);
            this.titlePanel.Size = new System.Drawing.Size(1386, 40);
            this.titlePanel.Controls.SetChildIndex(this.comboBoxEdit1, 0);
            this.titlePanel.Controls.SetChildIndex(this.popupContainerEdit1, 0);
            this.titlePanel.Controls.SetChildIndex(this.searchButtonEdit, 0);
            this.titlePanel.Controls.SetChildIndex(this.titleLabel, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(127, 14);
            this.titleLabel.Text = "用户上网记录查询";
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Location = new System.Drawing.Point(157, 8);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.popupContainerEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.popupContainerEdit1.Properties.Appearance.Options.UseFont = true;
            this.popupContainerEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.popupContainerEdit1.Properties.AutoHeight = false;
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::NetBarMS.Imgs.icon_jiantou, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.popupContainerEdit1.Properties.NullText = "请选择时间段进行查询";
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(180, 25);
            this.popupContainerEdit1.TabIndex = 4;
            this.popupContainerEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.PopupContainerEdit1_Closed);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.dateNavigator);
            this.popupContainerControl1.Location = new System.Drawing.Point(769, 241);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(282, 241);
            this.popupContainerControl1.TabIndex = 6;
            // 
            // dateNavigator
            // 
            this.dateNavigator.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator.DateTime = new System.DateTime(2017, 7, 18, 14, 12, 53, 211);
            this.dateNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator.EditValue = new System.DateTime(2017, 7, 18, 14, 12, 53, 211);
            this.dateNavigator.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.Size = new System.Drawing.Size(282, 241);
            this.dateNavigator.TabIndex = 0;
            this.dateNavigator.Click += new System.EventHandler(this.DateNavigator_Click);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(353, 8);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxEdit1.Properties.AutoHeight = false;
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.NullText = "请选择设备编号";
            this.comboBoxEdit1.Size = new System.Drawing.Size(180, 25);
            this.comboBoxEdit1.TabIndex = 7;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // searchButtonEdit
            // 
            this.searchButtonEdit.Location = new System.Drawing.Point(549, 8);
            this.searchButtonEdit.Name = "searchButtonEdit";
            this.searchButtonEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.searchButtonEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.searchButtonEdit.Properties.Appearance.Options.UseFont = true;
            this.searchButtonEdit.Properties.Appearance.Options.UseForeColor = true;
            this.searchButtonEdit.Properties.AutoHeight = false;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(229)))), ((int)(((byte)(248)))));
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.searchButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::NetBarMS.Imgs.icon_sousuo, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.searchButtonEdit.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.searchButtonEdit.Properties.NullText = "输入会员名称、设备编号、卡号、Mac、IP地址等关键词进行搜索";
            this.searchButtonEdit.Size = new System.Drawing.Size(180, 25);
            this.searchButtonEdit.TabIndex = 5;
            this.searchButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SearchButtonEdit_ButtonClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(5, 45);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1376, 692);
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
            // pageView1
            // 
            this.pageView1.BackColor = System.Drawing.Color.Transparent;
            this.pageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageView1.Location = new System.Drawing.Point(0, 743);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(1386, 30);
            this.pageView1.TabIndex = 80;
            this.pageView1.PageChangedEvent += new NetBarMS.Codes.Tools.PageChangedHandle(this.PageView_PageChanged);
            // 
            // UserNetRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.pageView1);
            this.Controls.Add(this.gridControl1);
            this.Name = "UserNetRecordView";
            this.Size = new System.Drawing.Size(1386, 773);
            this.Load += new System.EventHandler(this.UserNetRecordView_Load);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.pageView1, 0);
            this.Controls.SetChildIndex(this.popupContainerControl1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
        private DevExpress.XtraEditors.ButtonEdit searchButtonEdit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private CustomView.PageView pageView1;
    }
}
