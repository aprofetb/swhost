using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security.AccessControl;

namespace swhost
{
    class HiddenContext : ApplicationContext
    {
        SettingsForm form;
        Mutex mutex;

        public HiddenContext(Mutex mutex)
        {
            this.mutex = mutex;
            form = new SettingsForm();
            form.Visible = false;
            form.FormClosed += new FormClosedEventHandler(form_FormClosed);
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            mutex.Close();
            this.ExitThread();
        }
    }
}
