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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageView));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComViewButton = new DevExpress.XtraEditors.SimpleButton();
            this.ListViewButton = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.onlineLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.idleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanelView1
            // 
            this.titlePanelView1.ShowCloseButton = false;
            this.titlePanelView1.ShowTitle = false;
            this.titlePanelView1.Size = new System.Drawing.Size(1312, 78);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 346);
            this.panel1.TabIndex = 62;
            // 
            // ComViewButton
            // 
            this.ComViewButton.AllowFocus = false;
            this.ComViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComViewButton.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(174)))), ((int)(((byte)(238)))));
            this.ComViewButton.Appearance.Options.UseForeColor = true;
            this.ComViewButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ComViewButton.Image = global::NetBarMS.Imgs.icon_shitu1;
            this.ComViewButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ComViewButton.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.ComViewButton.Location = new System.Drawing.Point(1057, 19);
            this.ComViewButton.Margin = new System.Windows.Forms.Padding(0);
            this.ComViewButton.Name = "ComViewButton";
            this.ComViewButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.ComViewButton.Size = new System.Drawing.Size(108, 40);
            this.ComViewButton.TabIndex = 7;
            this.ComViewButton.Text = "电脑视图";
            this.ComViewButton.Click += new System.EventHandler(this.ChangeView_ButtonClick);
            this.ComViewButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // ListViewButton
            // 
            this.ListViewButton.AllowFocus = false;
            this.ListViewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewButton.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(174)))), ((int)(((byte)(238)))));
            this.ListViewButton.Appearance.Options.UseForeColor = true;
            this.ListViewButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ListViewButton.Image = global::NetBarMS.Imgs.icon_shitu2;
            this.ListViewButton.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ListViewButton.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.ListViewButton.Location = new System.Drawing.Point(1165, 19);
            this.ListViewButton.Margin = new System.Windows.Forms.Padding(0);
            this.ListViewButton.Name = "ListViewButton";
            this.ListViewButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.ListViewButton.Size = new System.Drawing.Size(108, 40);
            this.ListViewButton.TabIndex = 8;
            this.ListViewButton.Text = "列表视图";
            this.ListViewButton.Click += new System.EventHandler(this.ChangeView_ButtonClick);
            this.ListViewButton.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(19, 19);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.comboBoxEdit2.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxEdit2.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxEdit2.Properties.AppearanceDropDown.Options.UseFont = true;
            this.comboBoxEdit2.Properties.AutoHeight = false;
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("comboBoxEdit2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.comboBoxEdit2.Properties.DropDownItemHeight = 25;
            this.comboBoxEdit2.Properties.NullText = "按区域查询";
            this.comboBoxEdit2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit2.Size = new System.Drawing.Size(272, 40);
            this.comboBoxEdit2.TabIndex = 4;
            this.comboBoxEdit2.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(313, 19);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.comboBoxEdit1.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.comboBoxEdit1.Properties.AutoHeight = false;
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("comboBoxEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.comboBoxEdit1.Properties.DropDownItemHeight = 25;
            this.comboBoxEdit1.Properties.NullText = "按设备状态查询";
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(272, 40);
            this.comboBoxEdit1.TabIndex = 3;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            this.comboBoxEdit1.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(605, 19);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.buttonEdit1.Properties.Appearance.Options.UseFont = true;
            this.buttonEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.buttonEdit1.Properties.AutoHeight = false;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(229)))), ((int)(((byte)(248)))));
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::NetBarMS.Imgs.icon_sousuo, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.buttonEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.buttonEdit1.Properties.NullText = "按设备号、mac、ip查询";
            this.buttonEdit1.Size = new System.Drawing.Size(272, 40);
            this.buttonEdit1.TabIndex = 5;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.SearchButton_ButtonClick);
            this.buttonEdit1.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Paint);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.onlineLabel);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Controls.Add(this.label8);
            this.flowLayoutPanel2.Controls.Add(this.idleLabel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 430);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1312, 75);
            this.flowLayoutPanel2.TabIndex = 63;
            // 
            // onlineLabel
            // 
            this.onlineLabel.BackColor = System.Drawing.Color.White;
            this.onlineLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.onlineLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(151)))), ((int)(((byte)(0)))));
            this.onlineLabel.Location = new System.Drawing.Point(3, 0);
            this.onlineLabel.Name = "onlineLabel";
            this.onlineLabel.Size = new System.Drawing.Size(163, 50);
            this.onlineLabel.TabIndex = 47;
            this.onlineLabel.Text = "当前在线客户端：100";
            this.onlineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(178)))), ((int)(((byte)(250)))));
            this.label9.Location = new System.Drawing.Point(172, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 50);
            this.label9.TabIndex = 50;
            this.label9.Text = "当前挂机客户端：100";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(102)))), ((int)(((byte)(99)))));
            this.label8.Location = new System.Drawing.Point(341, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 50);
            this.label8.TabIndex = 49;
            this.label8.Text = "当前异常客户端：100";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // idleLabel
            // 
            this.idleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.idleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(151)))), ((int)(((byte)(0)))));
            this.idleLabel.Location = new System.Drawing.Point(510, 0);
            this.idleLabel.Name = "idleLabel";
            this.idleLabel.Size = new System.Drawing.Size(163, 50);
            this.idleLabel.TabIndex = 48;
            this.idleLabel.Text = "当前空闲客户端：100";
            this.idleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HomePageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListViewButton);
            this.Controls.Add(this.ComViewButton);
            this.Controls.Add(this.buttonEdit1);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.comboBoxEdit2);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Name = "HomePageView";
            this.Size = new System.Drawing.Size(1312, 505);
            this.Controls.SetChildIndex(this.titlePanelView1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.comboBoxEdit2, 0);
            this.Controls.SetChildIndex(this.comboBoxEdit1, 0);
            this.Controls.SetChildIndex(this.buttonEdit1, 0);
            this.Controls.SetChildIndex(this.ComViewButton, 0);
            this.Controls.SetChildIndex(this.ListViewButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.SimpleButton ComViewButton;
        private DevExpress.XtraEditors.SimpleButton ListViewButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label onlineLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label idleLabel;
    }
}
