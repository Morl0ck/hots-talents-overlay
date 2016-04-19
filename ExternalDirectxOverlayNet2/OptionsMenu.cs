using System;
using System.Windows.Forms;
using System.Xml;
//Hotkey Management
using BondTech.HotkeyManagement.Win;

namespace ExternalDirectxOverlayNet2
{
    public partial class OptionsMenu : Form
    {
        public OptionsMenu()
        {
            InitializeComponent();            

            //General Options should be defaulted visible
            MakeOptionGroupVisible(gbGeneralOptions);
            
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

        new void Close()
        {
            //Reset to the General Options Page
            MakeOptionGroupVisible(gbGeneralOptions);

            base.Close();
        }

        void SaveOptions()
        {
            Properties.Settings.Default.TextColor = btnTextColor.ForeColor;

            if (hkcFindHero.UserModifier != Modifiers.None)
                Properties.Settings.Default.ghkFindHeroBind = hkcFindHero.UserModifier.ToString() + ", " + hkcFindHero.UserKey.ToString();
            if (hkcToggleVisibility.UserModifier != Modifiers.None)
                Properties.Settings.Default.ghkToggleVisibilityBind = hkcToggleVisibility.UserModifier.ToString() + ", " + hkcToggleVisibility.UserKey.ToString();
            if (hkcCloseApplication.UserModifier != Modifiers.None)
                Properties.Settings.Default.ghkCloseApplicationBind = hkcCloseApplication.UserModifier.ToString() + ", " + hkcCloseApplication.UserKey.ToString();
            if (hkcOptionsMenu.UserModifier != Modifiers.None)
                Properties.Settings.Default.ghkOptionsMenuBind = hkcOptionsMenu.UserModifier.ToString() + ", " + hkcOptionsMenu.UserKey.ToString();
            if (hkcNextTalent.UserModifier != Modifiers.None)
                Properties.Settings.Default.ghkNextTalentBind = hkcNextTalent.UserModifier.ToString() + ", " + hkcNextTalent.UserKey.ToString();
            if (hkcPrevTalent.UserModifier != Modifiers.None)
                Properties.Settings.Default.ghkPrevTalentBind = hkcPrevTalent.UserModifier.ToString() + ", " + hkcPrevTalent.UserKey.ToString();

            Properties.Settings.Default.Save();
        }

        private void keyBindsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeOptionGroupVisible(gbKeyBindOptions);
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeOptionGroupVisible(gbGeneralOptions);
        }

        public void MakeOptionGroupVisible(GroupBox gb)
        {
            if (gbGeneralOptions.Visible)
                gbGeneralOptions.Visible = false;
            if (gbKeyBindOptions.Visible)
                gbKeyBindOptions.Visible = false;

            gb.Visible = true;
        }
    }
}
