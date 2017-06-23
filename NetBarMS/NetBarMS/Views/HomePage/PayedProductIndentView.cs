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
using DevExpress.XtraEditors.Controls;

namespace NetBarMS.Views.HomePage
{
    public partial class PayedProductIndentView : RootUserControlView
    {
        public PayedProductIndentView()
        {
            InitializeComponent();
            this.titleLabel.Text = "已付款商品订单管理";
            InitUI();
        }
        //初始化UI
        private void InitUI()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.PayedProductIndent, out this.mainDataTable);
            this.gridControl1.DataSource = this.mainDataTable;
        }
        //按钮列的点击事件
        public void ColumnButtonClick(object sender, ButtonPressedEventArgs e)
        {
            int rowhandle = this.gridView1.FocusedRowHandle;
            DataRow row = this.gridView1.GetDataRow(rowhandle);

            String tag = (String)e.Button.Tag;
            String[] param = tag.Split('_');
            

        }

    }
}
