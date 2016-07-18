using System;
using System.Windows.Forms;
using RockSatGraphIt.Forms;

namespace RockSatGraphIt
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
            Application.Run(new NewGraphitForm());

        }

        public static Version Version { get; } = new Version(Application.ProductVersion);
    }
}
