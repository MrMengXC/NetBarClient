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

namespace NetBarMS.Views.SystemManage
{
    public partial class BackUpManageView : RootUserControlView
    {
        public BackUpManageView()
        {
            InitializeComponent();
            this.titleLabel.Text = "备份设置";
            AddData();
        }
        /// <summary>
        /// 添加ListView数据
        /// </summary>
        private void AddData()
        {
            ToolsManage.SetGridView(this.gridView1, GridControlType.ClientManage, out this.mainDataTable);
            //DataRow row = this.mainDataTable.NewRow();
            //this.mainDataTable.Rows.Add(row);
            //row["column_0"] = "dasdasd";
            this.gridControl1.DataSource = this.mainDataTable;

        }
       
        /// <summary>
        /// 备份路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                System.Console.WriteLine("选择的路径："+ foldPath);

            }
        }

        private void checkButton4_CheckedChanged(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
           if(file.ShowDialog()==DialogResult.OK)
           {
                System.Console.WriteLine("选择的路径："+file.FileName);

           }

        }
    }
}
