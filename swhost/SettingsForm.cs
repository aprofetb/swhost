using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Resources;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace swhost
{
    public partial class SettingsForm : Form
    {
        HostsFile hostsFile;
        Regex ipRE = new Regex(@"^(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})?$", RegexOptions.Compiled | RegexOptions.Singleline);
        Dictionary<string, Icon> icons = new Dictionary<string, Icon>();
        bool reloading = false;
        internal bool closing = false;
        Dictionary<Status, Color> statusColor = new Dictionary<Status,Color>();

        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCache")]
        private static extern UInt32 DnsFlushResolverCache();

        public SettingsForm()
        {
            InitializeComponent();
            ResourceManager resources = new ComponentResourceManager(typeof(IconResources));
            icons.Add("devel", (Icon)resources.GetObject("devel"));
            icons.Add("test", (Icon)resources.GetObject("test"));
            icons.Add("prod", (Icon)resources.GetObject("prod"));
            icons.Add("mixed", (Icon)resources.GetObject("mixed"));
            icons.Add("unknown", (Icon)resources.GetObject("unknown"));
            iconContextMenu.Items["setDevelMenuItem"].Image = icons["devel"].ToBitmap();
            iconContextMenu.Items["setTestMenuItem"].Image = icons["test"].ToBitmap();
            iconContextMenu.Items["setProdMenuItem"].Image = icons["prod"].ToBitmap();
            fsWatcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc";
            statusColor.Add(Status.devel, Color.LightPink);
            statusColor.Add(Status.test, Color.LightBlue);
            statusColor.Add(Status.prod, Color.LightGreen);
            statusColor.Add(Status.mixed, Color.LightYellow);
            statusColor.Add(Status.unknown, Color.LightGray);
            hostsFile = new HostsFile(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts");
            LoadSettings();
        }

        private void LoadSettings()
        {
            Status status = Status.unknown;
            try
            {
                lock (hostsFile)
                {
                    status = hostsFile.Load();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "An error ocurred when tried to load 'hosts' file.\r\n" + e.Message, "swhost - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Visible)
            {
                aliasLb.Items.Clear();
                ClearFields();
                okBut.Enabled = false;
                dnstxt.Enabled = false;
                develIPtxt.Enabled = false;
                testIPtxt.Enabled = false;
                prodIPtxt.Enabled = false;
                statusCb.Enabled = false;
                statusCb.SelectedIndex = -1;
                lock (hostsFile)
                {
                    foreach (Alias alias in hostsFile.Aliases)
                    {
                        ListViewItem item = new ListViewItem(alias.ListViewSubItems);
                        item.Tag = alias;
                        item.BackColor = statusColor[alias.Status];
                        aliasLb.Items.Add(item);
                    }
                }
                aliasLb.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                try
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    runAtStartupCk.Checked = (string)key.GetValue(Application.ProductName) == Application.ExecutablePath;
                    key.Close();
                }
                catch
                {
                }
            }
            this.Icon = notifyIcon.Icon = icons[status.ToString()];
            notifyIcon.Text = status.ToString();
        }

        private void SaveSettings()
        {
            SaveSettings(Status.unknown);
        }

        private void SaveSettings(Status status)
        {
            try
            {
                lock (hostsFile)
                {
                    Editing = false;
                    hostsFile.Save(status);
                    DnsFlushResolverCache();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "An error ocurred when tried to save 'hosts' file.\r\n" + e.Message, "swhost - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (runAtStartupCk.Checked)
                    key.SetValue(Application.ProductName, Application.ExecutablePath, RegistryValueKind.String);
                else
                    key.DeleteValue(Application.ProductName);
                key.Close();
            }
            catch
            {
            }
        }

        private void aliaslv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aliasLb.FocusedItem != null)
            {
                dnstxt.Text = aliasLb.FocusedItem.SubItems[0].Text;
                develIPtxt.Text = aliasLb.FocusedItem.SubItems[2].Text;
                testIPtxt.Text = aliasLb.FocusedItem.SubItems[3].Text;
                prodIPtxt.Text = aliasLb.FocusedItem.SubItems[4].Text;
                string status = aliasLb.FocusedItem.SubItems[5].Text;
                statusCb.SelectedIndex = status == "devel" ? 0 : status == "test" ? 1 : status == "prod" ? 2 : -1;
                okBut.Enabled = true;
                dnstxt.Enabled = true;
                develIPtxt.Enabled = true;
                testIPtxt.Enabled = true;
                prodIPtxt.Enabled = true;
                statusCb.Enabled = true;
            }
        }

        internal bool Editing
        {
            get { return applyBut.Enabled; }
            set
            {
                applyBut.Enabled = value;
                cancelBut.Text = value ? "cancel" : "hide";
            }
        }

        private void okbut_Click(object sender, EventArgs e)
        {
            if (dnstxt.Text.Length == 0)
            {
                MessageBox.Show(this, "The field 'dns' cannot be null", "swhost - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dnstxt.Focus();
                return;
            }
            Match m = ipRE.Match(develIPtxt.Text);
            if (!m.Success)
            {
                MessageBox.Show(this, "The field 'devel' must be an ip address", "swhost - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                develIPtxt.Focus();
                return;
            }
            m = ipRE.Match(testIPtxt.Text);
            if (!m.Success)
            {
                MessageBox.Show(this, "The field 'test' must be an ip address", "swhost - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                testIPtxt.Focus();
                return;
            }
            m = ipRE.Match(prodIPtxt.Text);
            if (!m.Success)
            {
                MessageBox.Show(this, "The field 'prod' must be an ip address", "swhost - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                prodIPtxt.Focus();
                return;
            }
            if (statusCb.SelectedIndex == -1)
            {
                MessageBox.Show(this, "You must select a status for the host [devel, test or prod]", "swhost - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusCb.Focus();
                return;
            }
            if (aliasLb.FocusedItem != null)
            {
                Alias alias = (Alias)aliasLb.FocusedItem.Tag;
                alias.Dns = dnstxt.Text;
                alias.DevelIp = develIPtxt.Text;
                alias.TestIp = testIPtxt.Text;
                alias.ProdIp = prodIPtxt.Text;
                alias.CurrIp = statusCb.SelectedIndex == 0 ? develIPtxt.Text : statusCb.SelectedIndex == 1 ? testIPtxt.Text : prodIPtxt.Text;
                aliasLb.FocusedItem.SubItems[0].Text = alias.Dns;
                aliasLb.FocusedItem.SubItems[2].Text = alias.DevelIp;
                aliasLb.FocusedItem.SubItems[3].Text = alias.TestIp;
                aliasLb.FocusedItem.SubItems[4].Text = alias.ProdIp;
                aliasLb.FocusedItem.SubItems[5].Text = alias.Status.ToString();
                aliasLb.FocusedItem.BackColor = statusColor[alias.Status];
                aliasLb.Focus();
                if (!aliasLb.FocusedItem.Selected)
                    aliasLb.FocusedItem.Selected = true;
            }
            else
            {
                lock (hostsFile)
                {
                    Alias alias = new Alias(dnstxt.Text, statusCb.SelectedIndex == 0 ? develIPtxt.Text : statusCb.SelectedIndex == 1 ? testIPtxt.Text : prodIPtxt.Text, develIPtxt.Text, testIPtxt.Text, prodIPtxt.Text, hostsFile.Lines.Count);
                    hostsFile.Aliases.Add(alias);
                    hostsFile.Lines.Add(alias.Line);
                    ListViewItem item = new ListViewItem(alias.ListViewSubItems);
                    item.Tag = alias;
                    item.BackColor = statusColor[alias.Status];
                    aliasLb.Items.Add(item);
                    item.Selected = true;
                    item.Focused = true;
                    aliasLb.Focus();
                }
            }
            aliasLb.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Editing = true;
        }

        private void ClearFields()
        {
            dnstxt.Text = "";
            develIPtxt.Text = "";
            testIPtxt.Text = "";
            prodIPtxt.Text = "";
            statusCb.SelectedIndex = -1;
        }

        private void newbut_Click(object sender, EventArgs e)
        {
            if (aliasLb.SelectedItems.Count > 0)
                aliasLb.SelectedItems[0].Selected = false;
            if (aliasLb.FocusedItem != null)
                aliasLb.FocusedItem.Focused = false;
            ClearFields();
            okBut.Enabled = true;
            dnstxt.Enabled = true;
            develIPtxt.Enabled = true;
            testIPtxt.Enabled = true;
            prodIPtxt.Enabled = true;
            statusCb.Enabled = true;
            dnstxt.Focus();
        }

        private void applybut_Click(object sender, EventArgs e)
        {
            Editing = false;
            SaveSettings();
            ClearFields();
            Hide();
        }

        private void cancelbut_Click(object sender, EventArgs e)
        {
            if (!Editing || MessageBox.Show(this, "If you cancel all changes will be lost.\r\nContinue anyway?", "swhost - info", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Editing = false;
                ClearFields();
                Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            LoadSettings();
            Activate();
        }

        private void settingsMenuItem_Click(object sender, EventArgs e)
        {
            if (!Visible)
            {
                Show();
                LoadSettings();
            }
            Activate();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            closing = true;
            Close();
            this.OnFormClosed(new FormClosedEventArgs(CloseReason.UserClosing));
            closing = false;
        }

        private void setMenuItem_Click(object sender, EventArgs e)
        {
            if (Editing && MessageBox.Show(this, "The 'hosts' file will be modified and all changes will be lost.\r\nContinue anyway?", "swhost - info", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;
            LoadSettings();
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            switch (menuItem.Name)
            {
                case "setDevelMenuItem":
                    SaveSettings(Status.devel);
                    break;
                case "setTestMenuItem":
                    SaveSettings(Status.test);
                    break;
                case "setProdMenuItem":
                    SaveSettings(Status.prod);
                    break;
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (aliasLb.SelectedItems.Count > 0)
            {
                ListViewItem item = aliasLb.SelectedItems[0];
                Alias alias = (Alias)item.Tag;
                alias.Deleted = true;
                item.Remove();
                ClearFields();
                Editing = true;
            }
        }

        private void fsWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed && !reloading)
            {
                reloading = true;
                if (!Editing || MessageBox.Show(this, "The 'hosts' file has been modified.\r\nDo you want to reload it?\r\n(notice that all changes will be lost)", "swhost - info", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    LoadSettings();
                reloading = false;
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (Editing && MessageBox.Show(this, "If you cancel all changes will be lost.\r\nContinue anyway?", "swhost - info", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No);
            if (!e.Cancel && !closing)
            {
                Editing = false;
                Hide();
                e.Cancel = true;
            }
        }

        private void runAtStartupCk_Click(object sender, EventArgs e)
        {
            Editing = true;
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, String.Format("{0} v{1} - 2013\r\nCreated by Alejandro Profet", Application.ProductName, Application.ProductVersion), "about");
        }

        private void aboutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            about_Click(sender, e);
        }

        private void openHostsMenuItem_Click(object sender, EventArgs e)
        {
            notepadProcess.StartInfo.Arguments = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts";
            notepadProcess.Start();
        }
    }
}
