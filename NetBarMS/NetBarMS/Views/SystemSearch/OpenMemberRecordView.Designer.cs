
namespace NetBarMS.Views.NetUserManage
{
    partial class OpenMemberRecordView
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pageView1 = new NetBarMS.Views.CustomView.PageView();
            this.titlePanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.flowLayoutPanel2);
            this.titlePanel.Size = new System.Drawing.Size(1183, 50);
            this.titlePanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.titlePanel.Controls.SetChildIndex(this.flowLayoutPanel2, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(110, 17);
            this.titleLabel.Text = "会员办理记录";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.popupContainerEdit1);
            this.flowLayoutPanel2.Controls.Add(this.comboBoxEdit1);
            this.flowLayoutPanel2.Controls.Add(this.comboBoxEdit2);
            this.flowLayoutPanel2.Controls.Add(this.buttonEdit1);
            this.flowLayoutPanel2.Controls.Add(this.popupContainerControl1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(138, 13);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(694, 34);
            this.flowLayoutPanel2.TabIndex = 79;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Location = new System.Drawing.Point(3, 3);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.NullText = "请选择时间段进行查询";
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(158, 20);
            this.popupContainerEdit1.TabIndex = 6;
            this.popupContainerEdit1.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.ComboBoxEdit1_Closed);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.dateNavigator);
            this.popupContainerControl1.Location = new System.Drawing.Point(3, 29);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(288, 261);
            this.popupContainerControl1.TabIndex = 80;
            // 
            // dateNavigator
            // 
            this.dateNavigator.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator.DateTime = new System.DateTime(2017, 7, 18, 14, 7, 54, 800);
            this.dateNavigator.EditValue = new System.DateTime(2017, 7, 18, 14, 7, 54, 800);
            this.dateNavigator.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator.Location = new System.Drawing.Point(3, 3);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.Size = new System.Drawing.Size(283, 258);
            this.dateNavigator.SyncSelectionWithEditValue = false;
            this.dateNavigator.TabIndex = 0;
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            this.dateNavigator.Click += new System.EventHandler(this.DateNavigator_Click);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(167, 3);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.NullText = "按当班人进行查询";
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(137, 20);
            this.comboBoxEdit1.TabIndex = 0;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(310, 3);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Properties.NullText = "按会员类型进行查询";
            this.comboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new System.Drawing.Size(137, 20);
            this.comboBoxEdit2.TabIndex = 1;
            this.comboBoxEdit2.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit2_SelectedIndexChanged);
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(453, 3);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.buttonEdit1.Properties.NullText = "输入会员名称、卡号进行查询";
            this.buttonEdit1.Size = new System.Drawing.Size(206, 20);
            this.buttonEdit1.TabIndex = 2;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SearchButton_ButtonClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(-3, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1183, 707);
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
            this.pageView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageView1.Location = new System.Drawing.Point(0, 775);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(1183, 30);
            this.pageView1.TabIndex = 80;
            // 
            // OpenMemberRecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageView1);
            this.Controls.Add(this.gridControl1);
            this.Name = "OpenMemberRecordView";
            this.Size = new System.Drawing.Size(1183, 805);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.pageView1, 0);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
        private CustomView.PageView pageView1;
    }
}
