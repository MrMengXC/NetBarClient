using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NetBarMS.Codes.Tools
{
    public class RepositoryItemMyEdit: RepositoryItemTextEdit
    {
        static RepositoryItemMyEdit()
        {
            Register();
        }
        public RepositoryItemMyEdit() {

        }

        internal const string EditorName = "MyEdit";

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(SimpleButton),
                typeof(RepositoryItemMyEdit),
                typeof(DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo),
                new DevExpress.XtraEditors.Drawing.ButtonEditPainter(),
                true,
                null,
                typeof(DevExpress.Accessibility.ButtonEditAccessible)));

            

        }
        public override string EditorTypeName
        {
            get { return EditorName; }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
    public class MyEdit : TextEdit
    {
        static MyEdit()
        {
            RepositoryItemMyEdit.Register();
        }
        public MyEdit() { }

        public string DisplayText { set; get; }

        public override string EditorTypeName
        {
            get { return RepositoryItemMyEdit.EditorName; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyEdit Properties
        {
            get { return base.Properties as RepositoryItemMyEdit; }
        }

        //protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)  
        //{  
        //    ShowPopupForm();  
        //    base.OnClickButton(buttonInfo);  
        //}  
        //protected virtual void ShowPopupForm()  
        //{  
        //    using (Form form = new Form())  
        //    {  
        //        form.StartPosition = FormStartPosition.Manual;  
        //        form.Location = this.PointToScreen(new Point(0, Height));  
        //        form.ShowDialog();  
        //    }  
        //}  
    }
}  

