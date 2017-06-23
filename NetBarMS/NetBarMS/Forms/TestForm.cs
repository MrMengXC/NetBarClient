using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Codes.Tools;
using NetBarMS.Codes;

namespace NetBarMS.Forms
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            AddData();

            //DataGridViewColumn
        }
        private void AddData()
        {

            //ToolsManage.SetGridView(this.gridView1, GridControlType.ProductSellRecord, out this.mainDataTable);
            //DataRow row = this.mainDataTable.NewRow();
            //this.mainDataTable.Rows.Add(row);
            //row["column_0"] = "dasdasd";
            //this.gridControl1.DataSource = this.mainDataTable;
        }
        void Test()
        {
            
            
           

        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }
    }
}
