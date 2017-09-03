namespace NetBarMS.Views.SystemManage
{
    partial class AreaManageView
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
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.currentComsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.areaScrollPanel = new System.Windows.Forms.Panel();
            this.updateLabel = new System.Windows.Forms.Label();
            this.deleteAreaLabel = new System.Windows.Forms.Label();
            this.addAreaLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.areaBgPanel = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.areaScrollPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.areaBgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanelView1
            // 
            this.titlePanelView1.ShowCloseButton = false;
            this.titlePanelView1.Size = new System.Drawing.Size(1060, 78);
            this.titlePanelView1.Title = "区域设置";
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl1;
            this.gridView.Name = "gridView";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(585, 47);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(10);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(452, 453);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(575, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(472, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "设备列表";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(248)))));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.White;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.Location = new System.Drawing.Point(9, 705);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(184, 56);
            this.simpleButton2.TabIndex = 53;
            this.simpleButton2.Text = "保存";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(472, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "区域从属电脑";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentComsPanel
            // 
            this.currentComsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentComsPanel.Location = new System.Drawing.Point(1, 37);
            this.currentComsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.currentComsPanel.Name = "currentComsPanel";
            this.currentComsPanel.Size = new System.Drawing.Size(472, 473);
            this.currentComsPanel.TabIndex = 3;
            // 
            // areaScrollPanel
            // 
            this.areaScrollPanel.AutoSize = true;
            this.areaScrollPanel.BackColor = System.Drawing.Color.Transparent;
            this.areaScrollPanel.Controls.Add(this.updateLabel);
            this.areaScrollPanel.Controls.Add(this.deleteAreaLabel);
            this.areaScrollPanel.Controls.Add(this.addAreaLabel);
            this.areaScrollPanel.Controls.Add(this.panel1);
            this.areaScrollPanel.Location = new System.Drawing.Point(0, 0);
            this.areaScrollPanel.Margin = new System.Windows.Forms.Padding(0);
            this.areaScrollPanel.Name = "areaScrollPanel";
            this.areaScrollPanel.Size = new System.Drawing.Size(1015, 70);
            this.areaScrollPanel.TabIndex = 2;
            // 
            // updateLabel
            // 
            this.updateLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.updateLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.updateLabel.Location = new System.Drawing.Point(342, 0);
            this.updateLabel.Name = "updateLabel";
            this.updateLabel.Size = new System.Drawing.Size(121, 70);
            this.updateLabel.TabIndex = 6;
            this.updateLabel.Text = "更新区域";
            this.updateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.updateLabel.Click += new System.EventHandler(this.UpdateArea_ButtonClick);
            // 
            // deleteAreaLabel
            // 
            this.deleteAreaLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.deleteAreaLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.deleteAreaLabel.Location = new System.Drawing.Point(221, 0);
            this.deleteAreaLabel.Name = "deleteAreaLabel";
            this.deleteAreaLabel.Size = new System.Drawing.Size(121, 70);
            this.deleteAreaLabel.TabIndex = 5;
            this.deleteAreaLabel.Text = "-删除区域";
            this.deleteAreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteAreaLabel.Click += new System.EventHandler(this.DeleteArea_ButtonClick);
            // 
            // addAreaLabel
            // 
            this.addAreaLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.addAreaLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.addAreaLabel.Location = new System.Drawing.Point(100, 0);
            this.addAreaLabel.Name = "addAreaLabel";
            this.addAreaLabel.Size = new System.Drawing.Size(121, 70);
            this.addAreaLabel.TabIndex = 4;
            this.addAreaLabel.Text = "+添加区域";
            this.addAreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addAreaLabel.Click += new System.EventHandler(this.AddArea_ButtonClick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 70);
            this.panel1.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Location = new System.Drawing.Point(23, 241);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(55, 20);
            this.simpleButton1.TabIndex = 63;
            this.simpleButton1.Text = "<添加";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.simpleButton3.Location = new System.Drawing.Point(23, 285);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(55, 20);
            this.simpleButton3.TabIndex = 64;
            this.simpleButton3.Text = "移除>";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.simpleButton1);
            this.panel4.Controls.Add(this.simpleButton3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(474, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.tableLayoutPanel3.SetRowSpan(this.panel4, 2);
            this.panel4.Size = new System.Drawing.Size(100, 509);
            this.panel4.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.gridControl1, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.currentComsPanel, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(9, 173);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1048, 511);
            this.tableLayoutPanel3.TabIndex = 66;
            // 
            // areaBgPanel
            // 
            this.areaBgPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.areaBgPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.areaBgPanel.Controls.Add(this.areaScrollPanel);
            this.areaBgPanel.Location = new System.Drawing.Point(0, 78);
            this.areaBgPanel.Name = "areaBgPanel";
            this.areaBgPanel.Size = new System.Drawing.Size(1060, 70);
            this.areaBgPanel.TabIndex = 67;
            this.areaBgPanel.SizeChanged += new System.EventHandler(this.areaBgPanel_SizeChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Location = new System.Drawing.Point(0, 148);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1060, 17);
            this.hScrollBar1.TabIndex = 68;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // AreaManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.areaBgPanel);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.simpleButton2);
            this.Name = "AreaManageView";
            this.Size = new System.Drawing.Size(1060, 785);
            this.Controls.SetChildIndex(this.titlePanelView1, 0);
            this.Controls.SetChildIndex(this.simpleButton2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
            this.Controls.SetChildIndex(this.areaBgPanel, 0);
            this.Controls.SetChildIndex(this.hScrollBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.areaScrollPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.areaBgPanel.ResumeLayout(false);
            this.areaBgPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel areaScrollPanel;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.FlowLayoutPanel currentComsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label deleteAreaLabel;
        private System.Windows.Forms.Label addAreaLabel;
        private System.Windows.Forms.Label updateLabel;
        private System.Windows.Forms.Panel areaBgPanel;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}
