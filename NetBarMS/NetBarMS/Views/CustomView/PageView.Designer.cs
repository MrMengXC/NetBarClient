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
            this.allLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allLabel.Location = new System.Drawing.Point(184, 0);
            this.allLabel.Name = "allLabel";
            this.allLabel.Size = new System.Drawing.Size(86, 30);
            this.allLabel.TabIndex = 0;
            this.allLabel.Text = "0";
            this.allLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(127, 3);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(51, 24);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = "下一页>";
            this.nextBtn.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // lastBtn
            // 
            this.lastBtn.Location = new System.Drawing.Point(3, 3);
            this.lastBtn.Name = "lastBtn";
            this.lastBtn.Size = new System.Drawing.Size(57, 24);
            this.lastBtn.TabIndex = 2;
            this.lastBtn.Text = "<上一页";
            this.lastBtn.Click += new System.EventHandler(this.LastButton_Click);
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentLabel.Location = new System.Drawing.Point(66, 0);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(55, 30);
            this.currentLabel.TabIndex = 3;
            this.currentLabel.Text = "0";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.1811F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.8189F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.Controls.Add(this.lastBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nextBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.allLabel, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(380, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 30);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // PageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PageView";
            this.Size = new System.Drawing.Size(653, 30);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label allLabel;
        private DevExpress.XtraEditors.SimpleButton nextBtn;
        private DevExpress.XtraEditors.SimpleButton lastBtn;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
