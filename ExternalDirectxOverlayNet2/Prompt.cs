using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExternalDirectxOverlayNet2
{
    public partial class Prompt : Form
    {
        public TextBox txtHero { get { return textBox1; } }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public Prompt()
        {
            InitializeComponent();

            #region Hero List
            var heroList = new string[] {
                //Tanks
                "Anub'arak",
                "Artanis",
                "Arthas",
                "Chen",
                "Cho",
                "Diablo",
                "E.T.C.",
                "Johanna",
                "Leoric",
                "Muradin",
                "Rexxar",
                "Sonya",
                "Stitches",
                "Tyrael",
                //Assassins
                "Falstad",
                "Gall",
                "Greymane",
                "Illidan",
                "Jaina",
                "Kael'thas",
                "Kerrigan",
                "Li-Ming",
                "Lunara",
                "Nova",
                "Raynor",
                "The Butcher",
                "Thrall",
                "Tychus",
                "Valla",
                "Zeratul",
                //Support
                "Brightwing",
                "Li Li",
                "Lt. Morales",
                "Malfurion",
                "Rehgar",
                "Tassadar",
                "Tyrande",
                "Uther",
                //Specialist
                "Abarthur",
                "Azmodan",
                "Gazlowe",
                "Murky",
                "Nazeebo",
                "Sgt. Hammer",
                "Sylvanas",
                "Xul",
                "Zagara"
            };
            #endregion

            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(heroList);

            this.textBox1.AutoCompleteCustomSource = collection;

        }

        private void close_Form(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Prompt_Load(object sender, EventArgs e)
        {
            //Set the window to be topmost
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            this.textBox1.Select();
        }
    }
}
