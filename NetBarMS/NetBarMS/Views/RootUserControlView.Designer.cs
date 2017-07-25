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
            this.titlePanelView1 = new NetBarMS.Views.CustomView.TitlePanelView();
            this.SuspendLayout();
            // 
            // titlePanelView1
            // 
            this.titlePanelView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanelView1.Location = new System.Drawing.Point(0, 0);
            this.titlePanelView1.Name = "titlePanelView1";
            this.titlePanelView1.Size = new System.Drawing.Size(417, 50);
            this.titlePanelView1.TabIndex = 0;
            // 
            // RootUserControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.titlePanelView1);
            this.Name = "RootUserControlView";
            this.Size = new System.Drawing.Size(417, 166);
            this.ResumeLayout(false);

        }

        #endregion

        public CustomView.TitlePanelView titlePanelView1;
    }
}
