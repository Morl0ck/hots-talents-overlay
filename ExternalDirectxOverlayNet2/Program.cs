using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace ExternalDirectxOverlayNet2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                var name = new AssemblyName(Assembly.GetExecutingAssembly().FullName).Name + ".lib." + new AssemblyName(args.Name).Name + ".dll";
                using (var assemblyStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
                {
                    byte[] assemblyBuffer = new byte[assemblyStream.Length];
                    assemblyStream.Read(assemblyBuffer, 0, assemblyBuffer.Length);
                    return Assembly.Load(assemblyBuffer);
                }
            };

            //For Debugging Purposes
            string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
