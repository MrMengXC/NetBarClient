using NetBarMS.Codes.Tools;

namespace NetBarMS.Views.CustomView
{
    partial class PageView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public event PageChangedHandle PageChangedEvent;

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
            this.allLabel = new System.Windows.Forms.Label();
            this.nextBtn = new DevExpress.XtraEditors.SimpleButton();
            this.lastBtn = new DevExpress.XtraEditors.SimpleButton();
            this.currentLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // allLabel
            // 
            this.allLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.allLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.allLabel.Location = new System.Drawing.Point(287, 10);
            this.allLabel.Name = "allLabel";
            this.allLabel.Size = new System.Drawing.Size(84, 30);
            this.allLabel.TabIndex = 0;
            this.allLabel.Text = "共0页";
            this.allLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.nextBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nextBtn.Appearance.Options.UseBackColor = true;
            this.nextBtn.Appearance.Options.UseFont = true;
            this.nextBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.nextBtn.Location = new System.Drawing.Point(190, 5);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(91, 40);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = "下一页>";
            this.nextBtn.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // lastBtn
            // 
            this.lastBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lastBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.lastBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lastBtn.Appearance.Options.UseBackColor = true;
            this.lastBtn.Appearance.Options.UseFont = true;
            this.lastBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lastBtn.Location = new System.Drawing.Point(3, 5);
            this.lastBtn.Name = "lastBtn";
            this.lastBtn.Size = new System.Drawing.Size(91, 40);
            this.lastBtn.TabIndex = 2;
            this.lastBtn.Text = "<上一页";
            this.lastBtn.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // currentLabel
            // 
            this.currentLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentLabel.AutoSize = true;
            this.currentLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.currentLabel.Location = new System.Drawing.Point(133, 16);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(17, 18);
            this.currentLabel.TabIndex = 3;
            this.currentLabel.Text = "0";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.Controls.Add(this.lastBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.allLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.nextBtn, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(529, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 51);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // PageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PageView";
            this.Size = new System.Drawing.Size(903, 51);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label allLabel;
        private DevExpress.XtraEditors.SimpleButton nextBtn;
        private DevExpress.XtraEditors.SimpleButton lastBtn;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
