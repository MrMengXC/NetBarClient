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
using DevExpress.XtraEditors;

namespace NetBarMS.Forms
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            InitUI();
            //DataGridViewColumn
        }
       private void InitUI()
       {
            this.panel1.AutoSize = true;
            this.panel1.MaximumSize = new Size(this.panel2.Width, this.panel2.Height - this.simpleButton1.Height);
            for (int i = 0; i < 9; i++)
            {
                SimpleButton button = new SimpleButton();
                button.AutoSize = false;
                button.Size = new Size(this.panel1.Size.Width, 40);
                button.Dock = DockStyle.Top;
                button.Appearance.BackColor = Color.White;
                button.Text = i+"";
                // button.BorderStyle = BorderStyle.FixedSingle;
                this.panel1.Controls.Add(button);
                button.Margin = new Padding(0);
                button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;

            }
        }
    }
}
