using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarMS.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;

using NetBarMS.Codes.Model;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Data;
using NetBarMS.Views;
using System.Text.RegularExpressions;
using System.IO;
using DevExpress.XtraScheduler;
using static NetBarMS.Views.RootUserControlView;
using System.Resources;

namespace NetBarMS.Codes.Tools
{
    //流程状态（充值，注册会员）
    public enum FLOW_STATUS
    {
        NONE_STATUS,        //无状态
        NORMAL_STATUS,      //正常状态，不需要其他操作
        ACTIVE_STATUS,      //激活状态，返回激活页面，再次激活
    }
    //充值类型
    public enum PRECHARGE_TYPE
    {
        NOT_MEMBER = 0,        //不开通会员
        OPEN_MEMBER,      //开通会员
    }
    class ToolsManage
    {
        #region 显示自定义窗体
        //显示自定义窗体
        public static void ShowForm(RootUserControlView control,bool showInTaskbar)
        {
            CustomForm newForm = new CustomForm(control,showInTaskbar);
        }
        public static void ShowForm(RootUserControlView control, bool showInTaskbar,CloseFormHandle close)
        {
            if (close != null)
            {
                control.CloseForm += close;
            }
            CustomForm newForm = new CustomForm(control, showInTaskbar);

        }
        public static void ShowMessageView(RootUserControlView control, bool showInTaskbar, CloseFormHandle close)
        {
            //添加背景图片，显示中间输入
            if (close != null)
            {
                control.CloseForm += close;
            }
            CustomForm newForm = new CustomForm(control, showInTaskbar);

        }
        #endregion

        #region 设置GridControl ，创建标题
        /// <summary>
        /// 设置GridControl下的GridView
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="type"></param>
        /// <param name="table"></param>
        /// <param name="buttonclik"></param>
        public static void SetGridView(GridView gridView, 
            GridControlType type,
            out DataTable table
            ,ButtonPressedEventHandler buttonclik,
            DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler titleHandler)
        {
   

            GridControlModel model = XMLDataManage.GetGridControlModel(type.ToString());
            table = new DataTable();

            int i = 0;
            foreach (ColumnModel columnModel in model.columns)
            {
               
                string fieldname = "column_" + i;
                if(columnModel.field != "None")
                {
                    fieldname = columnModel.field;
                }
                
                GridColumn column = gridView.Columns.AddVisible(fieldname, columnModel.name);                
                column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.OptionsColumn.AllowEdit = false;
            
                switch (columnModel.type)
                {
                   
                    case ColumnType.C_Custom:
                        {
                            RepositoryItemHyperLinkEdit link = new RepositoryItemHyperLinkEdit();
                            link.LinkColor = Color.Gray;
                       
                            //link.Buttons.Add()
                            link.Caption = fieldname;

                            column.ColumnEdit = link;
                            column.OptionsColumn.AllowEdit = true;
                            DataColumn dataColumn = new DataColumn(fieldname);
                            table.Columns.Add(dataColumn);
                        }
                       

                        break;
                    #region 添加复选框
                    case ColumnType.C_Check:        //添加复选框
                        {
                            RepositoryItemCheckEdit check = new RepositoryItemCheckEdit();
                            check.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                            column.ColumnEdit = check;
                            column.OptionsColumn.AllowEdit = true;
                            column.Width = 40;

                            DataColumn dataColumn = new DataColumn(fieldname);
                            table.Columns.Add(dataColumn);
                            dataColumn.DataType = typeof(bool);
                        }
                   

                        break;
                    #endregion

                    #region 添加按钮
                    case ColumnType.C_Button:        //添加按钮
                        {
                            RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                            buttonEdit.Buttons.Clear();
                            buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                            buttonEdit.AppearanceFocused.BackColor = Color.Green;
                            buttonEdit.AppearanceFocused.ForeColor = Color.Green;
                            buttonEdit.Appearance.ForeColor = Color.Green;

                            //buttonEdit.ButtonsStyle = BorderStyles.NoBorder;
                            //buttonEdit.BorderStyle = BorderStyles.NoBorder;
                            //buttonEdit.AutoHeight = false;
                            if (buttonclik != null)
                            {
                                buttonEdit.ButtonClick += buttonclik;
                            }
                           
                            #region 添加按钮
                            int num = 0;
                            int width = 8;
                            foreach (string name in columnModel.buttonNames)
                            {

                                char[] splits = { '.' };
                                string[] names = name.Split(splits);

                                EditorButton button = new EditorButton();
                                button.Kind = ButtonPredefines.Glyph;
                                button.Appearance.ForeColor = Color.Blue;
                                
                                //按钮显示
                                button.Visible = true;
                                button.Tag = fieldname + "_" + num;
                                //button.Appearance.BackColor = Color.Red;
                               // Image btnImg = (System.Drawing.Bitmap)Imgs.ResourceManager.GetObject(names[1]);
                                button.Caption = names[0];

                                //if (btnImg != null)
                                //{
                                //    button.Image =btnImg;
                                //    width += btnImg.Width+8;
                                //}
                                //else
                                //{
                                //    button.Caption = names[0];
                                //    width += 50;
                                //}
                                width += 50;

                                //button.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
                                button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                buttonEdit.Buttons.Add(button);
                                num++;
                            }
                            #endregion
                            column.ColumnEdit = buttonEdit;
                            column.Width = width;
                            column.MinWidth = width;
                            column.OptionsColumn.AllowEdit = true;
                            column.UnboundType = DevExpress.Data.UnboundColumnType.String;
                        }
                        break;
                    #endregion
                    default:
                        {
                            column.SortMode = ColumnSortMode.Custom;
                            column.Width = 100;//columnModel.width;

                            DataColumn dataColumn = new DataColumn(fieldname);
                            table.Columns.Add(dataColumn);
                        }
                    
                        break;
                }
                i++;

            }

            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
            gridView.RowHeight = 40;
            //关闭最左侧
            gridView.OptionsView.ShowIndicator = false;
            //关闭表头右键快捷键
            gridView.OptionsMenu.EnableColumnMenu = false;
            if (titleHandler!=null)
            {
                gridView.CustomColumnSort += titleHandler;
            }


        }

        
       





        /// <summary>
        ///  设置GridControl下的GridView
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="type"></param>
        /// <param name="table"></param>
        public static void SetGridView(GridView gridView, GridControlType type, out DataTable table)
        {
     
            ToolsManage.SetGridView(gridView, type, out table, null,null);
        }

        #endregion

        #region 判断身份证是否符合标准
        /// <summary>
        /// 判断身份证号是否合格
        /// </summary>
        /// <param name="idnumber"></param>
        /// <returns></returns>
        public static bool JudgeIdNumber(string idnumber)
        {
            return Regex.IsMatch(idnumber, "(\\d{14}[0-9a-zA-Z])|(\\d{17}[0-9a-zA-Z])");
        }
        #endregion

        #region 将GridControl 导出成文件
        /// <summary>
        /// 将GridControl导出成文件
        /// </summary>
        /// <param name="gridControl1"></param>
        public static void ExportGridControl(GridControl gridControl1)
        {


            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControl1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControl1.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            if (DialogResult.Yes == MessageBox.Show("文件已成功导出，是否打开文件?", "提示", MessageBoxButtons.YesNo))
                            {
                                System.Diagnostics.Process.Start(exportFilePath);
                            }
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region 获取日期选单的时间范围
        public static DateTime GetDateNavigatorRangeTime(DateNavigator dateNavigator,DateTime lastDate, out string startTime, out string endTime)
        {
            DateTime current = dateNavigator.SelectionStart;
            DateTime start = DateTime.Now, end = DateTime.Now;
            if (lastDate == DateTime.MinValue)
            {
                start = current;
                end = current;
            }
            else
            {
                int res = current.CompareTo(lastDate);

                if (res < 0)     //小于
                {
                    start = current;
                    end = lastDate;

                }
                else if (res == 0)
                {
                    System.Console.WriteLine("是同一天");
                    start = current;
                    end = current;
                }
                else
                {
                    start = lastDate;
                    end = current;
                }


            }
            
            DateRange range = new DateRange(start, end.AddDays(1));
            dateNavigator.SelectedRanges.Add(range);
            startTime = start.ToString("yyyy-MM-dd");
            endTime = end.ToString("yyyy-MM-dd");

            return current;
        }

        internal static void SetGridView(object gridView1, GridControlType productIndent, out DataTable mainDataTable)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 利用BigInteger对权限进行2的权的和计算
        public static BigInteger SumRights(List<int> rights)
        {

            BigInteger big = new BigInteger();

            for (int i = 0; i < rights.Count; i++)
            {
                //System.Console.WriteLine("(uint)rights[i]:"+(uint)rights[i]);
                big.setBit((uint)rights[i]);
            }
            return big;
        }
        #endregion

        #region 测试是否具有指定编码的权限
        public static bool TestRights(string sum, int targetRights)
        {
            if(sum.Equals(""))
            {
                return false;
            }
            BigInteger big = new BigInteger(sum, 10);
            big.setBit((uint)targetRights);
            return big.ToString().Equals(sum);
        }
        #endregion
    }
}
