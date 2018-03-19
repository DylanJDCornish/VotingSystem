using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConstituencyVotingSystem
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
            var IOhandler = new XMLConstituencyFileReader();

            // Pass IOhandler to form via its constructor and run the form
            Application.Run(new MainMenu(IOhandler));
        }
    }
}
