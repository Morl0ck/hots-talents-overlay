using System;
using System.Collections.Generic;
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

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t != null)
            {
                if (t.Text.Length >= 2)
                {
                    string[] arr = SuggestStrings(t.Text);

                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    collection.AddRange(arr);

                    this.textBox1.AutoCompleteCustomSource = collection;
                }
            }
        }

        public string[] SuggestStrings(string str)
        {
            var heroList = new List<string> { "Anub'arak", "Artanis", "Arthas", "Chen", "Cho", "Diablo", "E.T.C.", "Johanna", "Leoric", "Muradin", "Rexxar", "Sonya", "Stitches", "Tyrael", "Falstad", "Gall", "Greymane", "Illidan", "Jaina", "Kael'thas", "Kerrigan", "Le-Ming", "Lunara", "Nova", "Raynor", "The Butcher", "Thrall", "Tychus", "Valla", "Zeratul", "Brightwing", "Li Li", "Lt. Morales", "Malfurion", "Rehgar", "Tassadar", "Tyrande", "Uther", "Abarthur", "Azmodan", "Gazlowe", "Murky", "Nazeebo", "Sgt. Hammer", "Sylvanas", "Xul", "Zagara" };
            var filteredHeroList = new List<string>();
            
            foreach( string hero in heroList)
            {
                if (hero.Substring(0, (str.Length > hero.Length ? hero.Length : str.Length)).Trim().ToLower() == str.Trim().ToLower())
                    filteredHeroList.Add(hero.ToString());
            }

            var results = filteredHeroList.ToArray();

            return results;
        }
    }
}
