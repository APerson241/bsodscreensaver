using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSOD_Screensaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0, 2) == "/c")
                {
                    MessageBox.Show("No parameters are passed");
                }
                else if (args[0].ToLower() == "/s")
                {
                    for (int i = Screen.AllScreens.GetLowerBound(0); i <=
                            Screen.AllScreens.GetUpperBound(0); i++)
                        Application.Run(new ScreenSaverForm(i));
                }
            }
            else
            {
                for (int i = Screen.AllScreens.GetLowerBound(0); i <=
                        Screen.AllScreens.GetUpperBound(0); i++)
                    Application.Run(new ScreenSaverForm(i));
            }
        }
    }
}
