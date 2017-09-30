//
// FILE     : Program.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2017-05-23
// 

using System;
using System.Windows.Forms;

namespace AruaROSELoginManager
{
    /// <summary>
    /// Main entry point for the application
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AccountManagerWindow());
        }
    }
}
