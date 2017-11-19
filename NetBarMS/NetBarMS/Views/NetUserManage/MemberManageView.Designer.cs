namespace NetBarMS.Views.NetUserManage
{
    partial class MemberManageView
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.DoughnutSeriesView doughnutSeriesView1 = new DevExpress.XtraCharts.DoughnutSeriesView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.statusComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.memberTypeComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.searchButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.pageView1 = new NetBarMS.Views.CustomView.PageView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartControl3 = new DevExpress.XtraCharts.ChartControl();
            this.chartControl2 = new DevExpress.XtraCharts.ChartControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberTypeComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButtonEdit.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.simpleButton2);
            this.titlePanel.Controls.Add(this.searchButtonEdit);
            this.titlePanel.Controls.Add(this.memberTypeComboBoxEdit);
            this.titlePanel.Controls.Add(this.statusComboBoxEdit);
            this.titlePanel.Size = new System.Drawing.Size(1160, 40);
            this.titlePanel.Controls.SetChildIndex(this.statusComboBoxEdit, 0);
            this.titlePanel.Controls.SetChildIndex(this.memberTypeComboBoxEdit, 0);
            this.titlePanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.titlePanel.Controls.SetChildIndex(this.searchButtonEdit, 0);
            this.titlePanel.Controls.SetChildIndex(this.simpleButton2, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(67, 14);
            this.titleLabel.Text = "会员管理";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(5, 5);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1150, 469);
            this.gridControl1.TabIndex = 48;
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
            // statusComboBoxEdit
            // 
            this.statusComboBoxEdit.Location = new System.Drawing.Point(97, 6);
            this.statusComboBoxEdit.Name = "statusComboBoxEdit";
            this.statusComboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.statusComboBoxEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.statusComboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.statusComboBoxEdit.Properties.Appearance.Options.UseForeColor = true;
            this.statusComboBoxEdit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11F);
            this.statusComboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.statusComboBoxEdit.Properties.AutoHeight = false;
            this.statusComboBoxEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.statusComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.statusComboBoxEdit.Properties.DropDownItemHeight = 23;
            this.statusComboBoxEdit.Properties.NullText = "按状态查询";
            this.statusComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.statusComboBoxEdit.Size = new System.Drawing.Size(180, 25);
            this.statusComboBoxEdit.TabIndex = 0;
            this.statusComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.statusComboBoxEdit_SelectedIndexChanged);
            this.statusComboBoxEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // memberTypeComboBoxEdit
            // 
            this.memberTypeComboBoxEdit.Location = new System.Drawing.Point(293, 6);
            this.memberTypeComboBoxEdit.Name = "memberTypeComboBoxEdit";
            this.memberTypeComboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.memberTypeComboBoxEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.memberTypeComboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.memberTypeComboBoxEdit.Properties.Appearance.Options.UseForeColor = true;
            this.memberTypeComboBoxEdit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11F);
            this.memberTypeComboBoxEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.memberTypeComboBoxEdit.Properties.AutoHeight = false;
            this.memberTypeComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.memberTypeComboBoxEdit.Properties.DropDownItemHeight = 23;
            this.memberTypeComboBoxEdit.Properties.NullText = "按会员等级查询";
            this.memberTypeComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.memberTypeComboBoxEdit.Size = new System.Drawing.Size(180, 25);
            this.memberTypeComboBoxEdit.TabIndex = 1;
            this.memberTypeComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.memberTypeComboBoxEdit_SelectedIndexChanged);
            this.memberTypeComboBoxEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // searchButtonEdit
            // 
            this.searchButtonEdit.Location = new System.Drawing.Point(489, 6);
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
            this.searchButtonEdit.Properties.NullText = "按卡号、姓名查询";
            this.searchButtonEdit.Size = new System.Drawing.Size(180, 25);
            this.searchButtonEdit.TabIndex = 2;
            this.searchButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SearchButtonEdit_ButtonClick);
            this.searchButtonEdit.Click += new System.EventHandler(this.DeleteButton_ButtonClick);
            this.searchButtonEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // pageView1
            // 
            this.pageView1.BackColor = System.Drawing.Color.Transparent;
            this.pageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageView1.Location = new System.Drawing.Point(0, 477);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(1160, 30);
            this.pageView1.TabIndex = 62;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1160, 780);
            this.tableLayoutPanel2.TabIndex = 64;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pageView1);
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 507);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 507);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1160, 273);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1160, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = " 会员汇总信息";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.chartControl3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartControl1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1157, 227);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chartControl3
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.Rotated = true;
            this.chartControl3.Diagram = xyDiagram1;
            this.chartControl3.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl3.Location = new System.Drawing.Point(754, 3);
            this.chartControl3.Name = "chartControl3";
            series1.Name = "Series 1";
            this.chartControl3.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl3.Size = new System.Drawing.Size(300, 200);
            this.chartControl3.TabIndex = 1;
            // 
            // chartControl2
            // 
            this.chartControl2.Location = new System.Drawing.Point(407, 3);
            this.chartControl2.Name = "chartControl2";
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series2.Name = "Series 1";
            series2.View = pieSeriesView1;
            this.chartControl2.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControl2.Size = new System.Drawing.Size(300, 200);
            this.chartControl2.TabIndex = 0;
            // 
            // chartControl1
            // 
            this.chartControl1.Location = new System.Drawing.Point(3, 3);
            this.chartControl1.Name = "chartControl1";
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series3.Name = "Series 1";
            series3.View = doughnutSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.chartControl1.Size = new System.Drawing.Size(300, 200);
            this.chartControl1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(229)))), ((int)(((byte)(248)))));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(146)))), ((int)(((byte)(194)))));
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.Image = global::NetBarMS.Imgs.icon_shanchu;
            this.simpleButton2.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.simpleButton2.Location = new System.Drawing.Point(1100, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(55, 25);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "删除";
            this.simpleButton2.Click += new System.EventHandler(this.DeleteButton_ButtonClick);
            // 
            // MemberManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "MemberManageView";
            this.Size = new System.Drawing.Size(1160, 820);
            this.Load += new System.EventHandler(this.MemberManageView_Load);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberTypeComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButtonEdit.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnutSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.ComboBoxEdit memberTypeComboBoxEdit;
        private DevExpress.XtraEditors.ButtonEdit searchButtonEdit;
        private DevExpress.XtraEditors.ComboBoxEdit statusComboBoxEdit;
        private CustomView.PageView pageView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraCharts.ChartControl chartControl3;
        private DevExpress.XtraCharts.ChartControl chartControl2;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
