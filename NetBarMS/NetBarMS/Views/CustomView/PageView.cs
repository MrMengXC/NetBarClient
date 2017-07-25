using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools;

namespace NetBarMS.Views.CustomView
{
    public partial class PageView : UserControl
    {
        //当前页书，总页数
        private int showPage = 0, allPage = 0, currentPage = 0;

        public PageView()
        {
            InitializeComponent();
            
        }

        //刷新PageView
        public void RefreshPageView(int allPage)
        {
            this.showPage = currentPage + 1;
            this.allPage = allPage;

            this.currentLabel.Text = this.showPage + "";
            this.allLabel.Text = this.allPage + "";
            RefrshPageUI();

        }

        
        #region 刷新按钮状态
        private void RefrshPageUI()
        {
            this.lastBtn.Enabled = showPage >1;
            this.nextBtn.Enabled = showPage < allPage;

        }
        #endregion

        #region 上下页的操作
        //上一页
        private void LastButton_Click(object sender, EventArgs e)
        {
            int page = currentPage - 1;
            currentPage = Math.Max(0, page);
            if(this.PageChangedEvent != null)
            {
                this.PageChangedEvent(currentPage);
            }
        }
        //下一页
        private void NextButton_Click(object sender, EventArgs e)
        {
            int page = currentPage + 1;
            currentPage = Math.Min(page, allPage-1);
            if (this.PageChangedEvent != null)
            {
                this.PageChangedEvent(currentPage);
            }
        }
        #endregion

        #region 当前页
        /// <summary>
        /// 当前页
        /// </summary>
    
        [Browsable(false)]
        public int Page
        {
            get
            {
                return this.currentPage;
            }
        }
        #endregion

        #region 每页Size
        /// <summary>
        /// 页数size
        /// </summary>
        [Browsable(false)]
        public int PageSize
        {
            get
            {
                return 15;
            }
        }
        #endregion

        #region 搜索起始页
        /// <summary>
        /// 搜索起始页
        /// </summary>
        [Browsable(false)]
        public int PageBegin
        {
            get
            {
                return this.Page * this.PageSize;
            }
        }
        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitPageViewData()
        {
            currentPage = 0;
        }
        #endregion

    }
}
