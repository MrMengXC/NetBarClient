namespace NetBarMS.Views
{
    partial class RootUserControlView
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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.rightFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.closeButton = new System.Windows.Forms.Button();
            this.titlePanel.SuspendLayout();
            this.rightFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Controls.Add(this.rightFlowLayoutPanel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(637, 50);
            this.titlePanel.TabIndex = 61;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(0, 17);
            this.titleLabel.TabIndex = 1;
            // 
            // rightFlowLayoutPanel
            // 
            this.rightFlowLayoutPanel.Controls.Add(this.closeButton);
            this.rightFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.rightFlowLayoutPanel.Location = new System.Drawing.Point(438, 0);
            this.rightFlowLayoutPanel.Name = "rightFlowLayoutPanel";
            this.rightFlowLayoutPanel.Size = new System.Drawing.Size(199, 50);
            this.rightFlowLayoutPanel.TabIndex = 4;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(166, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // RootUserControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titlePanel);
            this.Name = "RootUserControlView";
            this.Size = new System.Drawing.Size(637, 399);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.rightFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel titlePanel;
        protected System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Label titleLabel;
        public System.Windows.Forms.FlowLayoutPanel rightFlowLayoutPanel;
    }
}
