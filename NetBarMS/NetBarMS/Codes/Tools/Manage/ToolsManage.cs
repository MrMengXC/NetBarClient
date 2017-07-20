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
using DevExpress.XtraGrid.Views.Base;

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
using System.Resources;
using DevExpress.XtraPrinting;
using System.Security.Cryptography;
using System.Web.Security;

namespace NetBarMS.Codes.Tools
{
    
    class ToolsManage
    {


        #region 显示自定义窗体
        /// <summary>
        /// 显示自定义窗体
        /// </summary>
        /// <param name="control">显示的视图</param>
        /// <param name="showInTaskbar">是否在任务栏上显示图标</param>
        /// <returns>返回DialogResult</returns>
        public static DialogResult ShowForm(UserControl control, bool showInTaskbar)
        {
            DialogResult res = ToolsManage.ShowForm(control,showInTaskbar,null);
            return res;
        }
        /// <summary>
        /// 显示自定义窗体
        /// </summary>
        /// <param name="control">显示的视图</param>
        /// <param name="showInTaskbar">是否在任务栏上显示图标</param>
        /// <param name="close">关闭窗口的回调</param>
        /// <returns>返回DialogResult</returns>
        public static DialogResult ShowForm(UserControl control, bool showInTaskbar,CloseFormHandle close)
        {
            using (CustomForm newForm = new CustomForm(control, showInTaskbar, close))
            {
                DialogResult res = newForm.ShowDialog();
                ////如过关闭窗口释放资源
                //if (res == DialogResult.Cancel)
                //{
                //    newForm.Dispose();
                //}
                return res;
            }
        }
       
        /// <summary>
        /// 显示自定义窗体
        /// </summary>
        /// <param name="control">显示的视图</param>
        /// <returns>返回窗口</returns>
        public static CustomForm ShowForm(UserControl control)
        {
            CustomForm newForm = new CustomForm(control, true, null);
            return newForm;
        }
        #endregion

        #region 设置GridControl ，创建标题
        /// <summary>
        ///  设置GridControl下的GridView
        /// </summary>
        /// <param name="gridView">被设置的GridView</param>
        /// <param name="type">GridControl 的类型</param>
        /// <param name="table">数据源DataTable</param>
        public static void SetGridView(GridView gridView, GridControlType type, out DataTable table)
        {
     
            ToolsManage.SetGridView(gridView, type, out table, null,null);
        }
        /// <summary>
        /// 设置GridControl下的GridView
        /// </summary>
        /// <param name="gridView">被设置的GridView</param>
        /// <param name="type">GridControl 的类型</param>
        /// <param name="table">数据源DataTable</param>
        /// <param name="buttonclik">按钮列按钮点击事件</param>
        public static void SetGridView(GridView gridView,
            GridControlType type,
            out DataTable table
            , ButtonPressedEventHandler buttonclik)
        {
            ToolsManage.SetGridView(gridView, type, out table, buttonclik, null);

        }
        /// <summary>
        ///  设置GridControl下的GridView
        /// </summary>
        /// <param name="gridView">被设置的GridView</param>
        /// <param name="type">GridControl 的类型</param>
        /// <param name="table">数据源DataTable</param>
        /// <param name="buttonclik">按钮列按钮点击事件</param>
        /// <param name="titleHandler">点击标题列点击事件</param>
        public static void SetGridView(GridView gridView,
            GridControlType type,
            out DataTable table
            , ButtonPressedEventHandler buttonclik,
            DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler titleHandler)
        {
            GridControlModel model = XMLDataManage.GetGridControlModel(type.ToString());
            table = new DataTable();

            int i = 0;
            foreach (ColumnModel columnModel in model.columns)
            {

                string fieldname = "column_" + i;
                if (columnModel.field != "None")
                {
                    fieldname = columnModel.field;
                }

                GridColumn column = gridView.Columns.AddVisible(fieldname, columnModel.name);
                //表头文本水平位置
                column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //表头文本自动换行
                column.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
              
             
              
                column.OptionsColumn.AllowEdit = false;

                switch (columnModel.type)
                {
                    #region 添加链接
                    case ColumnType.C_LineLink:
                        {
                            RepositoryItemHyperLinkEdit link = new RepositoryItemHyperLinkEdit();
                            link.LinkColor = Color.Blue;

                            column.ColumnEdit = link;
                            column.OptionsColumn.AllowEdit = true;

                            DataColumn dataColumn = new DataColumn(fieldname);
                            table.Columns.Add(dataColumn);
                           // dataColumn.DataType = typeof(string);

                        }


                        break;

                    #endregion

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

                                char[] splits = { '(',')' };
                                string[] names = name.Split(splits);

                                EditorButton button = new EditorButton();
                                button.Kind = ButtonPredefines.Glyph;

                                //按钮显示
                                button.Visible = true;
                                button.Tag = fieldname + "_" + num;
                               
                                if(names.Count() > 1)
                                {
                                    char[] color_sp = { ','};
                                    string[] colors = names[1].Split(color_sp);
                                    button.Appearance.ForeColor = Color.FromArgb(int.Parse(colors[0]), int.Parse(colors[1]), int.Parse(colors[2]));
                                }
                                else
                                {
                                    button.Appearance.ForeColor = Color.Blue;

                                }
                                button.Caption = names[0];
                                width += 50;

                                //button.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
                                button.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                buttonEdit.Buttons.Add(button);
                                num++;
                            }
                            #endregion
                            column.ColumnEdit = buttonEdit;
                            column.Width = width;
                            //column.MinWidth = width;
                            column.OptionsColumn.AllowEdit = true;
                            column.UnboundType = DevExpress.Data.UnboundColumnType.String;


                            DataColumn dataColumn = new DataColumn(fieldname);
                            table.Columns.Add(dataColumn);
                            //dataColumn.DataType = typeof(RepositoryItemButtonEdit);
                        }
                        break;
                    #endregion
                    default:
                        {

                            RepositoryItemMemoEdit edit = new RepositoryItemMemoEdit();
                            column.SortMode = ColumnSortMode.Custom;
                            column.Width = 100;//columnModel.width;
                            column.ColumnEdit = edit;
                            //表头下文本自动换行
                            column.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                            //表头下文本书平内容
                            column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                            column.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

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
          
            //表头高度
            gridView.ColumnPanelRowHeight = 50;
          
            //关闭最左侧
            gridView.OptionsView.ShowIndicator = false;
            //关闭表头右键快捷键
            gridView.OptionsMenu.EnableColumnMenu = false;
            if (titleHandler != null)
            {
                gridView.CustomColumnSort += titleHandler;
            }

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

        #region 打印GridControl
        /// <summary>
        /// 打印GridControl
        /// </summary>
        /// <param name="control">需要被打印的GridControl</param>
        public static void PrintGridControl(GridControl control)
        {
            DevExpress.XtraPrintingLinks.CompositeLink compositeLink = new DevExpress.XtraPrintingLinks.CompositeLink();
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();

            compositeLink.PrintingSystem = ps;
            compositeLink.Landscape = true;
            compositeLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
           
            DevExpress.XtraPrinting.PrintableComponentLink link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            ps.PageSettings.Landscape = true;


         //   PageHeaderFooter phf = compositeLink.PageHeaderFooter as PageHeaderFooter;

            //设置页眉 
            //phf.Header.Content.Clear();
            //phf.Header.Content.AddRange(new string[] { "", _PrintHeader, "" });
            //phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
            //phf.Header.LineAlignment = BrickAlignment.Center;

            //设置页脚 
            //phf.Footer.Content.Clear();
            //phf.Footer.Content.AddRange(new string[] { "", "", "1" });
            //phf.Footer.Font = new System.Drawing.Font("宋体", 9, System.Drawing.FontStyle.Regular);
            //phf.Footer.LineAlignment = BrickAlignment.Center;


            link.Component = control;
        
            compositeLink.Links.Add(link);

            link.CreateDocument();  //建立文档
            ps.PreviewFormEx.Show();//进行预览  
        }
        #endregion

        #region 随机获取身份证号
        /// <summary>
        /// 获取随机身份证号
        /// </summary>
        public static string RandomCard
        {
            get
            {
                string card = "1";
                Random random = new Random();
                for(int i = 0;i<17;i++)
                {
                    string idNum = (random.Next() % 10).ToString();
                    
                    card += idNum;
                }
                return card;
            }
        }
        #endregion

        #region 字符串MD5加密
        /// <summary>  
        /// MD5 加密字符串  
        /// </summary>  
        /// <param name="rawPass">源字符串</param>  
        /// <returns>加密后字符串</returns>  
        public static string MD5Encoding(string rawPass)
        {
            // 创建MD5类的默认实例：MD5CryptoServiceProvider  
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(rawPass);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                // 以十六进制格式格式化  
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion

        #region Bitmap To String
        /// <summary>
        /// BitMap 转 DataString
        /// </summary>
        /// <param name="bit">BitMap</param>
        /// <returns></returns>
        public static string BitmapToDataSring(Bitmap bit)
        {


            
            MemoryStream ms = new MemoryStream();
            bit.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释
            ms.Close();
            string inputString = System.Convert.ToBase64String(bytes);
            return inputString;

        }
        #endregion
    }
}
