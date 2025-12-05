using FFArchive.GUI;

using System;
using System.Windows.Forms;

namespace FFArchive
{
    internal static class FanFictionArchive
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}