using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinLauncher.src;

namespace WinLauncher
{
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
            App app = new App();
            Application.Run(app.launcher);

            app.AppShutdown();
            Console.WriteLine("Exiting...");
        }
    }
}
