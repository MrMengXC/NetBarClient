namespace NetBarMS.Forms
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SimpleContextButton simpleContextButton3 = new DevExpress.Utils.SimpleContextButton();
            DevExpress.Utils.SimpleContextButton simpleContextButton4 = new DevExpress.Utils.SimpleContextButton();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.AllowDrop = true;
            this.comboBoxEdit1.Location = new System.Drawing.Point(491, 283);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.comboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.comboBoxEdit1.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(15)));
            this.comboBoxEdit1.Properties.AppearanceDropDown.Options.UseFont = true;
            this.comboBoxEdit1.Properties.AutoHeight = false;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.White;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::NetBarMS.Imgs.icon_jiantou, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            simpleContextButton3.Id = new System.Guid("b1d2647a-674d-493a-be5c-0dd4bd4387a3");
            simpleContextButton3.Name = "SimpleContextButton";
            simpleContextButton4.Id = new System.Guid("7bd10361-b4a4-4600-b7ad-2658759ea02a");
            simpleContextButton4.Name = "SimpleContextButton";
            this.comboBoxEdit1.Properties.ContextButtons.Add(simpleContextButton3);
            this.comboBoxEdit1.Properties.ContextButtons.Add(simpleContextButton4);
            this.comboBoxEdit1.Properties.DropDownItemHeight = 40;
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "test1",
            "test2"});
            this.comboBoxEdit1.Properties.PopupFormSize = new System.Drawing.Size(0, 30);
            this.comboBoxEdit1.Size = new System.Drawing.Size(305, 35);
            this.comboBoxEdit1.TabIndex = 0;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.dateNavigator);
            this.popupContainerControl1.Location = new System.Drawing.Point(203, 261);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(269, 259);
            this.popupContainerControl1.TabIndex = 82;
            // 
            // dateNavigator
            // 
            this.dateNavigator.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator.DateTime = new System.DateTime(2017, 7, 18, 14, 14, 3, 58);
            this.dateNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateNavigator.EditValue = new System.DateTime(2017, 7, 18, 14, 14, 3, 58);
            this.dateNavigator.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateNavigator.Location = new System.Drawing.Point(0, 0);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.Size = new System.Drawing.Size(269, 259);
            this.dateNavigator.SyncSelectionWithEditValue = false;
            this.dateNavigator.TabIndex = 0;
            this.dateNavigator.UpdateDateTimeWhenNavigating = false;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1360, 708);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.comboBoxEdit1);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "255";
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
    }
}