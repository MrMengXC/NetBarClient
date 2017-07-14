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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.statusComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.memberTypeComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.searchButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.pageView1 = new NetBarMS.Views.CustomView.PageView();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberTypeComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButtonEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.flowLayoutPanel2);
            this.titlePanel.Size = new System.Drawing.Size(1160, 50);
            this.titlePanel.Controls.SetChildIndex(this.titleLabel, 0);
            this.titlePanel.Controls.SetChildIndex(this.flowLayoutPanel2, 0);
            // 
            // titleLabel
            // 
            this.titleLabel.Size = new System.Drawing.Size(76, 17);
            this.titleLabel.Text = "会员管理";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(8, 56);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1149, 728);
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
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.statusComboBoxEdit);
            this.flowLayoutPanel2.Controls.Add(this.memberTypeComboBoxEdit);
            this.flowLayoutPanel2.Controls.Add(this.searchButtonEdit);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(92, 13);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(603, 30);
            this.flowLayoutPanel2.TabIndex = 79;
            // 
            // statusComboBoxEdit
            // 
            this.statusComboBoxEdit.Location = new System.Drawing.Point(3, 3);
            this.statusComboBoxEdit.Name = "statusComboBoxEdit";
            this.statusComboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.statusComboBoxEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.statusComboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.statusComboBoxEdit.Properties.Appearance.Options.UseForeColor = true;
            this.statusComboBoxEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.statusComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.statusComboBoxEdit.Properties.NullText = "按状态查询";
            this.statusComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.statusComboBoxEdit.Size = new System.Drawing.Size(131, 22);
            this.statusComboBoxEdit.TabIndex = 0;
            this.statusComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.statusComboBoxEdit_SelectedIndexChanged);
            // 
            // memberTypeComboBoxEdit
            // 
            this.memberTypeComboBoxEdit.Location = new System.Drawing.Point(140, 3);
            this.memberTypeComboBoxEdit.Name = "memberTypeComboBoxEdit";
            this.memberTypeComboBoxEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.memberTypeComboBoxEdit.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.memberTypeComboBoxEdit.Properties.Appearance.Options.UseFont = true;
            this.memberTypeComboBoxEdit.Properties.Appearance.Options.UseForeColor = true;
            this.memberTypeComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.memberTypeComboBoxEdit.Properties.NullText = "按会员等级查询";
            this.memberTypeComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.memberTypeComboBoxEdit.Size = new System.Drawing.Size(131, 24);
            this.memberTypeComboBoxEdit.TabIndex = 1;
            this.memberTypeComboBoxEdit.SelectedIndexChanged += new System.EventHandler(this.memberTypeComboBoxEdit_SelectedIndexChanged);
            // 
            // searchButtonEdit
            // 
            this.searchButtonEdit.Location = new System.Drawing.Point(277, 3);
            this.searchButtonEdit.Name = "searchButtonEdit";
            this.searchButtonEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.searchButtonEdit.Properties.Appearance.Options.UseFont = true;
            this.searchButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.searchButtonEdit.Properties.NullText = "按卡号、姓名查询";
            this.searchButtonEdit.Size = new System.Drawing.Size(162, 24);
            this.searchButtonEdit.TabIndex = 2;
            this.searchButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SearchButtonEdit_ButtonClick);
            // 
            // pageView1
            // 
            this.pageView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pageView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageView1.Location = new System.Drawing.Point(0, 790);
            this.pageView1.Name = "pageView1";
            this.pageView1.Size = new System.Drawing.Size(1160, 30);
            this.pageView1.TabIndex = 62;
            // 
            // MemberManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pageView1);
            this.Controls.Add(this.gridControl1);
            this.Name = "MemberManageView";
            this.Size = new System.Drawing.Size(1160, 820);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            this.Controls.SetChildIndex(this.titlePanel, 0);
            this.Controls.SetChildIndex(this.pageView1, 0);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.statusComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberTypeComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchButtonEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DevExpress.XtraEditors.ComboBoxEdit memberTypeComboBoxEdit;
        private DevExpress.XtraEditors.ButtonEdit searchButtonEdit;
        private DevExpress.XtraEditors.ComboBoxEdit statusComboBoxEdit;
        private CustomView.PageView pageView1;
    }
}
