namespace NetBarMS.Views.HomePage
{
    partial class HomePageListView
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.idleLabel = new System.Windows.Forms.Label();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(0, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1191, 560);
            this.gridControl1.TabIndex = 47;
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
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Blue;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(145, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 50);
            this.label9.TabIndex = 50;
            this.label9.Text = "当前挂机客户端：100";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Red;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(287, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 50);
            this.label8.TabIndex = 49;
            this.label8.Text = "当前异常客户端：100";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idleLabel
            // 
            this.idleLabel.BackColor = System.Drawing.Color.Yellow;
            this.idleLabel.ForeColor = System.Drawing.Color.Black;
            this.idleLabel.Location = new System.Drawing.Point(429, 0);
            this.idleLabel.Name = "idleLabel";
            this.idleLabel.Size = new System.Drawing.Size(136, 50);
            this.idleLabel.TabIndex = 48;
            this.idleLabel.Text = "当前空闲客户端：100";
            this.idleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // onlineLabel
            // 
            this.onlineLabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.onlineLabel.ForeColor = System.Drawing.Color.White;
            this.onlineLabel.Location = new System.Drawing.Point(3, 0);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(136, 50);
            this.onlineLabel.TabIndex = 47;
            this.onlineLabel.Text = "当前在线客户端：100";
            this.onlineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.onlineLabel);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.idleLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 569);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(883, 61);
            this.flowLayoutPanel1.TabIndex = 49;
            // 
            // HomePageListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gridControl1);
            this.Name = "HomePageListView";
            this.Size = new System.Drawing.Size(1191, 630);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label idleLabel;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
