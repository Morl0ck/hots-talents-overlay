namespace ExternalDirectxOverlayNet2
{
    partial class OptionsMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyBindsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbGeneralOptions = new System.Windows.Forms.GroupBox();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.hkcFindHero = new BondTech.HotkeyManagement.Win.HotKeyControl();
            this.hkcToggleVisibility = new BondTech.HotkeyManagement.Win.HotKeyControl();
            this.hkcCloseApplication = new BondTech.HotkeyManagement.Win.HotKeyControl();
            this.hkcOptionsMenu = new BondTech.HotkeyManagement.Win.HotKeyControl();
            this.hkcNextTalent = new BondTech.HotkeyManagement.Win.HotKeyControl();
            this.hkcPrevTalent = new BondTech.HotkeyManagement.Win.HotKeyControl();
            this.cdTextColor = new System.Windows.Forms.ColorDialog();
            this.gbKeyBindOptions = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.gbGeneralOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.keyBindsToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.generalToolStripMenuItem.Text = "General";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // keyBindsToolStripMenuItem
            // 
            this.keyBindsToolStripMenuItem.Name = "keyBindsToolStripMenuItem";
            this.keyBindsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.keyBindsToolStripMenuItem.Text = "Key Binds";
            this.keyBindsToolStripMenuItem.Click += new System.EventHandler(this.keyBindsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // gbGeneralOptions
            // 
            this.gbGeneralOptions.Controls.Add(this.btnTextColor);
            this.gbGeneralOptions.Location = new System.Drawing.Point(32, 40);
            this.gbGeneralOptions.Name = "gbGeneralOptions";
            this.gbGeneralOptions.Size = new System.Drawing.Size(516, 234);
            this.gbGeneralOptions.TabIndex = 1;
            this.gbGeneralOptions.TabStop = false;
            this.gbGeneralOptions.Text = "General Options";
            // 
            // btnTextColor
            // 
            this.btnTextColor.ForeColor = Properties.Settings.Default.TextColor;
            this.btnTextColor.Location = new System.Drawing.Point(59, 46);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(75, 23);
            this.btnTextColor.TabIndex = 2;
            this.btnTextColor.Text = "Text Color";
            this.btnTextColor.UseVisualStyleBackColor = true;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // gbKeyBindOptions
            // 
            this.gbKeyBindOptions.Controls.Add(this.hkcFindHero);
            this.gbKeyBindOptions.Controls.Add(this.hkcToggleVisibility);
            this.gbKeyBindOptions.Controls.Add(this.hkcCloseApplication);
            this.gbKeyBindOptions.Controls.Add(this.hkcOptionsMenu);
            this.gbKeyBindOptions.Controls.Add(this.hkcNextTalent);
            this.gbKeyBindOptions.Controls.Add(this.hkcPrevTalent);
            this.gbKeyBindOptions.Location = new System.Drawing.Point(32, 40);
            this.gbKeyBindOptions.Name = "gbKeyBindOptions";
            this.gbKeyBindOptions.Size = new System.Drawing.Size(516, 234);
            this.gbKeyBindOptions.TabIndex = 3;
            this.gbKeyBindOptions.TabStop = false;
            this.gbKeyBindOptions.Text = "Key Bind Options";
            // 
            // hkcFindHero
            // 
            this.hkcFindHero.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hkcFindHero.Location = new System.Drawing.Point(60, 45);
            this.hkcFindHero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hkcFindHero.Name = "hkcFindHero";
            this.hkcFindHero.Size = new System.Drawing.Size(150, 23);
            this.hkcFindHero.TabIndex = 3;
            this.hkcFindHero.ToolTip = null;
            this.hkcFindHero.Text = Properties.Settings.Default.ghkFindHeroBind.ToString();
            // hkcToggleVisibility
            // 
            this.hkcToggleVisibility.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hkcToggleVisibility.Location = new System.Drawing.Point(240, 45);
            this.hkcToggleVisibility.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hkcToggleVisibility.Name = "hkcToggleVisibility";
            this.hkcToggleVisibility.Size = new System.Drawing.Size(150, 23);
            this.hkcToggleVisibility.TabIndex = 3;
            this.hkcToggleVisibility.ToolTip = null;
            this.hkcToggleVisibility.Text = Properties.Settings.Default.ghkToggleVisibilityBind.ToString();
            // 
            // hkcCloseApplication
            // 
            this.hkcCloseApplication.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hkcCloseApplication.Location = new System.Drawing.Point(60, 100);
            this.hkcCloseApplication.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hkcCloseApplication.Name = "hkcCloseApplication";
            this.hkcCloseApplication.Size = new System.Drawing.Size(150, 23);
            this.hkcCloseApplication.TabIndex = 3;
            this.hkcCloseApplication.ToolTip = null;
            this.hkcCloseApplication.Text = Properties.Settings.Default.ghkCloseApplicationBind.ToString();
            // 
            // hkcOptionsMenu
            // 
            this.hkcOptionsMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hkcOptionsMenu.Location = new System.Drawing.Point(240, 100);
            this.hkcOptionsMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hkcOptionsMenu.Name = "hkcOptionsMenu";
            this.hkcOptionsMenu.Size = new System.Drawing.Size(150, 23);
            this.hkcOptionsMenu.TabIndex = 3;
            this.hkcOptionsMenu.ToolTip = null;
            this.hkcOptionsMenu.Text = Properties.Settings.Default.ghkOptionsMenuBind.ToString();
            // 
            // hkcNextTalent
            // 
            this.hkcNextTalent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hkcNextTalent.Location = new System.Drawing.Point(60, 155);
            this.hkcNextTalent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hkcNextTalent.Name = "hkcNextTalent";
            this.hkcNextTalent.Size = new System.Drawing.Size(150, 23);
            this.hkcNextTalent.TabIndex = 3;
            this.hkcNextTalent.ToolTip = null;
            this.hkcNextTalent.Text = Properties.Settings.Default.ghkNextTalentBind.ToString();
            // 
            // hkcPrevTalent
            // 
            this.hkcPrevTalent.BackColor = System.Drawing.SystemColors.ControlLight;
            this.hkcPrevTalent.Location = new System.Drawing.Point(240, 155);
            this.hkcPrevTalent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hkcPrevTalent.Name = "hkcPrevTalent";
            this.hkcPrevTalent.Size = new System.Drawing.Size(150, 23);
            this.hkcPrevTalent.TabIndex = 3;
            this.hkcPrevTalent.ToolTip = null;
            this.hkcPrevTalent.Text = Properties.Settings.Default.ghkPrevTalentBind.ToString();
            // 
            // OptionsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 299);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbGeneralOptions);
            this.Controls.Add(this.gbKeyBindOptions);
            this.Name = "OptionsMenu";
            this.Text = "HotS Options";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbGeneralOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyBindsToolStripMenuItem;
        public System.Windows.Forms.GroupBox gbGeneralOptions;
        private System.Windows.Forms.ColorDialog cdTextColor;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbKeyBindOptions;
        public BondTech.HotkeyManagement.Win.HotKeyControl hkcFindHero;
        public BondTech.HotkeyManagement.Win.HotKeyControl hkcToggleVisibility;
        public BondTech.HotkeyManagement.Win.HotKeyControl hkcCloseApplication;
        public BondTech.HotkeyManagement.Win.HotKeyControl hkcOptionsMenu;
        public BondTech.HotkeyManagement.Win.HotKeyControl hkcNextTalent;
        public BondTech.HotkeyManagement.Win.HotKeyControl hkcPrevTalent;
    }
}