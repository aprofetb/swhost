using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Security.AccessControl;
using System.Security.Principal;

namespace swhost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                /*Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                    MessageBox.Show("You must run this application as administrator", "swhost", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);*/

                Mutex mutex = Mutex.OpenExisting("swhost", MutexRights.FullControl);
                MessageBox.Show(Application.ProductName + " is already open in taskbar", "swhost", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            catch
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new HiddenContext(new Mutex(true, "swhost")));
            }
        }
    }
}
