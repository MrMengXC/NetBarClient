namespace NetBarMS.Views.HomePage
{
    partial class HomePageView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ComViewButton = new DevExpress.XtraEditors.SimpleButton();
            this.ListViewButton = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.idleLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanelView1
            // 
            this.titlePanelView1.ShowCloseButton = false;
            this.titlePanelView1.Size = new System.Drawing.Size(1069, 50);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 455);
            this.panel1.TabIndex = 62;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ComViewButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ListViewButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(859, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(196, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ComViewButton
            // 
            this.ComViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComViewButton.Location = new System.Drawing.Point(0, 0);
            this.ComViewButton.Margin = new System.Windows.Forms.Padding(0);
            this.ComViewButton.Name = "ComViewButton";
            this.ComViewButton.Size = new System.Drawing.Size(98, 30);
            this.ComViewButton.TabIndex = 7;
            this.ComViewButton.Text = "电脑视图";
            this.ComViewButton.Click += new System.EventHandler(this.ChangeView_ButtonClick);
            // 
            // ListViewButton
            // 
            this.ListViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewButton.Location = new System.Drawing.Point(98, 0);
            this.ListViewButton.Margin = new System.Windows.Forms.Padding(0);
            this.ListViewButton.Name = "ListViewButton";
            this.ListViewButton.Size = new System.Drawing.Size(98, 30);
            this.ListViewButton.TabIndex = 8;
            this.ListViewButton.Text = "列表视图";
            this.ListViewButton.Click += new System.EventHandler(this.ChangeView_ButtonClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.comboBoxEdit1);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxEdit2);
            this.flowLayoutPanel1.Controls.Add(this.buttonEdit1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 14);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(438, 30);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(3, 3);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.NullText = "按设备状态查询";
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(129, 20);
            this.comboBoxEdit1.TabIndex = 3;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(138, 3);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Properties.NullText = "按区域查询";
            this.comboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new System.Drawing.Size(124, 20);
            this.comboBoxEdit2.TabIndex = 4;
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(268, 3);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.buttonEdit1.Properties.NullText = "按设备号、mac、ip查询";
            this.buttonEdit1.Size = new System.Drawing.Size(163, 20);
            this.buttonEdit1.TabIndex = 5;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SearchButton_ButtonClick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.onlineLabel);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.idleLabel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 445);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1069, 60);
            this.flowLayoutPanel2.TabIndex = 63;
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
            // HomePageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "HomePageView";
            this.Size = new System.Drawing.Size(1069, 505);
            this.Controls.SetChildIndex(this.titlePanelView1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton ComViewButton;
        private DevExpress.XtraEditors.SimpleButton ListViewButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label idleLabel;
    }
}
