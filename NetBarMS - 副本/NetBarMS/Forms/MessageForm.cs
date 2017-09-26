using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetBarMS.Forms
{
    public partial class MessageForm : Form
    {
        public MessageForm(string text)
        {
            InitializeComponent();
            this.textEdit1.Text = text;
            
        }

        public string InputText
        {
            get
            {
                return this.textEdit1.Text;
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
