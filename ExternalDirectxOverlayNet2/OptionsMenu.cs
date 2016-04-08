using System;
using System.Windows.Forms;
using System.Xml;

namespace ExternalDirectxOverlayNet2
{
    public partial class OptionsMenu : Form
    {
        public OptionsMenu()
        {
            InitializeComponent();
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            if (cdTextColor.ShowDialog() == DialogResult.OK)
            {
                btnTextColor.ForeColor = cdTextColor.Color;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveOptions();

            DialogResult = DialogResult.OK;
            Close();
        }

        void SaveOptions()
        {
            Settings1.Default.textColor = btnTextColor.ForeColor;
        }
    }
}
