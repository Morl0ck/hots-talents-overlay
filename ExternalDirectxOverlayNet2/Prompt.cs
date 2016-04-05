using System;
using System.Windows.Forms;

namespace ExternalDirectxOverlayNet2
{
    public partial class Prompt : Form
    {
        public Prompt()
        {
            InitializeComponent();
        }

        public string ShowDialog(string text, string caption, IWin32Window owner)
        {
            return this.ShowDialog(owner) == DialogResult.OK ? textBox1.Text : "";
        }

        private void close_Form(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
                
        }
    }
}
