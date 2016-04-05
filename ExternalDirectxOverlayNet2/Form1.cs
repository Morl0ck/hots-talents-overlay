using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using System.Threading;
//add Namespaces
using Microsoft.DirectX;
using D3D = Microsoft.DirectX.Direct3D;
//Fizzler
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
//Hotkey Management
using BondTech.HotkeyManagement.Win;
using System.Collections.Generic;

namespace ExternalDirectxOverlayNet2
{
    public partial class Form1 : Form
    {

        #region Variables

        internal HotKeyManager MyHotKeyManager;
        GlobalHotKey ghkCustom = new GlobalHotKey("ghkCustom", Modifiers.Shift | Modifiers.Control, Keys.F);
        GlobalHotKey ghkToggleVisibility = new GlobalHotKey("ghkToggleVisibility", Modifiers.Shift | Modifiers.Control, Keys.V);

        private Margins marg;

        //this is used to specify the boundaries of the transparent area
        internal struct Margins
        {
            public int Left, Right, Top, Bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("dwmapi.dll")]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMargins);

        private D3D.Device device = null;
        private static D3D.Font font;
        private static D3D.Line line;
        private static D3D.Sprite sprite;
        private static D3D.Texture texture;

        private string hero = "";
        private List<Build> builds;
        private bool displayTalents = true;

        #endregion

        public Form1()
        {

            InitializeComponent();

            //Make the window's border completely transparant
            SetWindowLong(this.Handle, GWL_EXSTYLE, (IntPtr)(GetWindowLong(this.Handle, GWL_EXSTYLE) ^ WS_EX_LAYERED ^ WS_EX_TRANSPARENT));

            //Set the Alpha on the Whole Window to 255 (solid)
            SetLayeredWindowAttributes(this.Handle, 0, 255, LWA_ALPHA);

            //Set the window to be topmost
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            MyHotKeyManager = new HotKeyManager(this);
            MyHotKeyManager.GlobalHotKeyPressed += new GlobalHotKeyEventHandler(MyHotKeyManager_GlobalHotKeyPressed);
            RegisterHotKeys();
            MyHotKeyManager.DisableOnManagerFormInactive = true;

            //Get the resolution of the monitor
            Rectangle resolution = Screen.PrimaryScreen.Bounds;

            //Init DirectX
            //This initializes the DirectX device. It needs to be done once.
            //The alpha channel in the backbuffer is critical.
            D3D.PresentParameters presentParameters = new D3D.PresentParameters();
            presentParameters.Windowed = true;
            presentParameters.SwapEffect = D3D.SwapEffect.Discard;
            presentParameters.BackBufferFormat = D3D.Format.A8R8G8B8;
            presentParameters.BackBufferHeight = resolution.Height;
            presentParameters.BackBufferWidth = resolution.Width;

            this.device = new D3D.Device(0, D3D.DeviceType.Hardware, this.Handle, D3D.CreateFlags.HardwareVertexProcessing, presentParameters);
            font = new D3D.Font(device, new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Regular));
            line = new D3D.Line(this.device);

            sprite = new D3D.Sprite(this.device);
            texture = D3D.TextureLoader.FromFile(this.device, "banana_transparent.png");

            GetTalentInfo(hero);

            Thread dx = new Thread(new ThreadStart(this.dxThread));
            dx.IsBackground = true;
            dx.Start();
        }

        private void GetTalentInfo(string hero)
        {
            hero = hero.Trim();
            if (hero.Length == 0)
                return;

            if (hero == "rengar")
            {
                MessageBox.Show("It's Rehgar Biv. Get it right.");
                return;
            }

            this.builds = new List<Build>();

            if (hero.Substring(hero.Length - 1, 1).Equals("."))
                hero = hero.Substring(0, hero.Length - 1);

            hero = hero.ToLower().Replace(' ', '-').Replace('.', '-');

            //get the page
            var web = new HtmlWeb();
            var document = web.Load("http://www.icy-veins.com/heroes/" + hero + "-build-guide");
            var body = document.DocumentNode.SelectSingleNode("//body");

            //loop through all div tags with item css class
            foreach (var item in body.QuerySelectorAll("div.heroes_tldr_talents"))
            {
                Build build = new Build();

                var thisItem = item;

                thisItem = thisItem.PreviousSibling;

                while (thisItem.Name != "p")
                {
                    thisItem = thisItem.PreviousSibling;
                }

                var title = thisItem.InnerText;
                Console.WriteLine(title);

                build.name = title;

                foreach (var talentNode in item.QuerySelectorAll("a.heroes_tldr_talent_tier"))
                {
                    Talent talent = new Talent();

                    var talentLevel = talentNode.QuerySelector("span.heroes_tldr_talent_tier_subtitle").InnerText;
                    Console.WriteLine(talentLevel);

                    talent.name = talentLevel;

                    int selection = 0;
                    int total = 0;
                    var talentVisual = talentNode.QuerySelector("span.heroes_tldr_talent_tier_visual").QuerySelectorAll("[class^=heroes_tldr_talent_tier_]");
                    foreach (var visual in talentVisual)
                    {
                        total++;

                        if (visual.Attributes["class"].Value.ToString().Contains("yes"))
                            selection = total;
                    }

                    Console.WriteLine(selection + "/" + total);

                    talent.total = total;
                    talent.selection = selection;

                    build.talents.Add(talent);
                }

                builds.Add(build);
            }
        }

        #region HotKey Methods

        void RegisterHotKeys()
        {
            ghkCustom.Enabled = true;
            ghkToggleVisibility.Enabled = true;

            MyHotKeyManager.AddGlobalHotKey(ghkCustom);
            MyHotKeyManager.AddGlobalHotKey(ghkToggleVisibility);
        }

        void MyHotKeyManager_GlobalHotKeyPressed(object sender, GlobalHotKeyEventArgs e)
        {
            if (e.HotKey.Name.ToLower() == "ghkcustom")
            {
                HandleCustomHotKey();
                return;
            }
            else if (e.HotKey.Name.ToLower() == "ghktogglevisibility")
            {
                ToggleVisibility();
                return;
            }
        }

        void HandleCustomHotKey()
        {
            Prompt prompt = new Prompt();

            string promptValue = prompt.ShowDialog("", "", this);
            GetTalentInfo(promptValue);
        }

        void ToggleVisibility()
        {
            displayTalents = !displayTalents;
        }

        #endregion

        #region FPS Methods

        int _frames = 0;
        int _lastTickCount = 0;
        float _lastFrameRate = 0;

        public void Frame()
        {
            _frames++;
            if (Math.Abs(Environment.TickCount - _lastTickCount) > 1000)
            {
                _lastFrameRate = (float)_frames * 1000 / Math.Abs(Environment.TickCount - _lastTickCount);
                _lastTickCount = Environment.TickCount;
                _frames = 0;
            }
        }

        public float GetFPS()
        {
            return _lastFrameRate;
        }

        #endregion

        private void dxThread()
        {
            while (true)
            {
                //Place your update logic here
                Frame();
                device.Clear(D3D.ClearFlags.Target, Color.FromArgb(0, 0, 0, 0), 1.0f, 0);
                device.RenderState.ZBufferEnable = false;
                device.RenderState.Lighting = false;
                device.RenderState.CullMode = D3D.Cull.None;
                device.Transform.Projection = Matrix.OrthoOffCenterLH(0, this.Width, this.Height, 0, 0, 1);
                device.BeginScene();

                //Place your rendering logic here
                string dateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                Size textSize = TextRenderer.MeasureText(dateTime, new Font(new FontFamily("Arial"), 10, FontStyle.Regular));
                DrawShadowText(dateTime, new Point(this.Width - textSize.Width, 10), Color.Red);
                //DrawLine(0, 0, this.Width, this.Height, 1, Color.Red);
                //DrawCircle(500, 500, 100, Color.Red);

                //DrawTalentBoxes(500, 500, 4, 3);
                if (displayTalents && builds != null && builds.Count > 0)
                    DrawBuilds(builds);

                //Draw Sprite
                //sprite.Begin(D3D.SpriteFlags.AlphaBlend);
                //sprite.Draw2D(texture, Rectangle.Empty, new Rectangle(0, 0, 100, 100), new Point(0, 0), 0, new Point(0, 0), Color.White);
                //sprite.End();

                //Draw frames per second
                DrawShadowText(GetFPS().ToString(), new Point(10, 10), Color.Red);

                device.EndScene();
                device.Present();
            }

            this.device.Dispose();
            Application.Exit();
        }

        #region Drawing Methods

        public static void DrawShadowText(string text, Point position, Color color)
        {
            font.DrawText(null, text, new Point(position.X + 1, position.Y + 1), Color.Black);
            font.DrawText(null, text, position, color);
        }

        public static void DrawFilledBox(float x, float y, float w, float h, System.Drawing.Color Color)
        {
            Vector2[] vLine = new Vector2[2];

            line.GlLines = true;
            line.Antialias = false;
            line.Width = w;

            vLine[0].X = x + w / 2;
            vLine[0].Y = y;
            vLine[1].X = x + w / 2;
            vLine[1].Y = y + h;

            line.Begin();
            line.Draw(vLine, Color.ToArgb());
            line.End();
        }

        public static void DrawBox(float x, float y, float w, float h, float px, System.Drawing.Color Color)
        {
            DrawFilledBox(x, y + h, w, px, Color);
            DrawFilledBox(x - px, y, px, h, Color);
            DrawFilledBox(x, y - px, w, px, Color);
            DrawFilledBox(x + w, y, px, h, Color);
        }

        private static void DrawCircle(float x, float y, float r, System.Drawing.Color Color)
        {
            int circleResolution = 100;

            Vector2[] gCircleData = new Vector2[circleResolution + 1];

            for (int i = 0; i <= circleResolution; ++i)
            {
                gCircleData[i].X = (float)Math.Cos(2 * Math.PI * i / circleResolution) * r + x;
                gCircleData[i].Y = (float)Math.Sin(2 * Math.PI * i / circleResolution) * r + y;
            }

            line.Begin();
            line.Draw(gCircleData, Color.ToArgb());
            line.End();
        }

        public static void DrawLine(float x1, float y1, float x2, float y2, float w, Color Color)
        {
            Vector2[] vLine = new Vector2[2] { new Vector2(x1, y1), new Vector2(x2, y2) };

            line.GlLines = true;
            line.Antialias = false;
            line.Width = w;

            line.Begin();
            line.Draw(vLine, Color.ToArgb());
            line.End();

        }

        public static void DrawTalentBoxes(float x, float y, int total, int selection)
        {
            for (int i = 1; i <= total; i++)
            {
                DrawBox(x + i*20, y, 10, 10, 1, Color.Red);
                if (i == selection)
                    DrawFilledBox(x + i * 20, y, 10, 10, Color.Red);
            }
            
        }

        public static void DrawBuilds(List<Build> builds)
        {
            var yDistance = 50;

            foreach (var build in builds)
            {
                DrawShadowText(build.name, new Point(10, yDistance), Color.Red);
                yDistance = yDistance + 20;
                foreach (var talent in build.talents)
                {
                    DrawShadowText(talent.name, new Point(10, yDistance), Color.Red);
                    DrawTalentBoxes(70, yDistance + 3, talent.total, talent.selection);
                    yDistance = yDistance + 20;
                }
                yDistance = yDistance + 20;
            }
        }

        #endregion

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Create a margin (the whole form)
            marg.Left = 0;
            marg.Top = 0;
            marg.Right = this.Width;
            marg.Bottom = this.Height;

            //Expand the Aero Glass Effect Border to the WHOLE form.
            // since we have already had the border invisible we now
            // have a completely invisible window - apart from the DirectX
            // renders NOT in black.
            DwmExtendFrameIntoClientArea(this.Handle, ref marg);
        }
    }
}
