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

namespace NetBarMS.Views.SystemSearch
{
    /// <summary>
    /// 用户退款记录视图
    /// </summary>
    public partial class UserDrawBackRecordView : RootUserControlView
    {
        public UserDrawBackRecordView()
        {
            InitializeComponent();
            InitUI();
        }
        #region 初始化UI
        // 初始化UI
        private void InitUI()
        {
            ////初始化ComboBoxEdit
            //DevExpress.XtraEditors.ComboBoxEdit[] edits = {
            //    this.comboBoxEdit1,
            //    this.comboBoxEdit2
            //};
            //SetupCombox(edits, false);
            //this.staffs = SysManage.Staffs;
            //this.comboBoxEdit1.Properties.Items.Add("无");
            //foreach (StructAccount staff in this.staffs)
            //{
            //    this.comboBoxEdit1.Properties.Items.Add(staff.Nickname);
            //}

            //this.memberTypes = SysManage.MemberTypes;
            //this.comboBoxEdit2.Properties.Items.Add("无");
            //foreach (MemberTypeModel model in this.memberTypes)
            //{
            //    this.comboBoxEdit2.Properties.Items.Add(model.typeName);
            //}

            //初始化GridControl
            ToolsManage.SetGridView(this.gridView1, GridControlType.DrawBackRecord, out this.mainDataTable, null, null);
            this.gridControl1.DataSource = this.mainDataTable;

        }
        #endregion
    }
}
