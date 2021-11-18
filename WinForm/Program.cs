using System;
using System.Windows.Forms;
using WinForm.Forms;

namespace WinForm
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            bool check = true;
            while (check)
            {
                MainForm form = new MainForm();
                Application.Run(form);
                check = form.isLogOut;
            }
        }
    }
}
