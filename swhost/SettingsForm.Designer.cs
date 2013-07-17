using System.Windows.Forms;

namespace swhost
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHostsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.setDevelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setProdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aliasLb = new System.Windows.Forms.ListView();
            this.dnsCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.currIpCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.develIpCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.testIpCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prodIpCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.aliasContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.develIPtxt = new System.Windows.Forms.TextBox();
            this.prodIPtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dnstxt = new System.Windows.Forms.TextBox();
            this.okBut = new System.Windows.Forms.Button();
            this.applyBut = new System.Windows.Forms.Button();
            this.cancelBut = new System.Windows.Forms.Button();
            this.newBut = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.statusCb = new System.Windows.Forms.ComboBox();
            this.fsWatcher = new System.IO.FileSystemWatcher();
            this.runAtStartupCk = new System.Windows.Forms.CheckBox();
            this.aboutLabel = new System.Windows.Forms.LinkLabel();
            this.notepadProcess = new System.Diagnostics.Process();
            this.label5 = new System.Windows.Forms.Label();
            this.testIPtxt = new System.Windows.Forms.TextBox();
            this.iconContextMenu.SuspendLayout();
            this.aliasContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.iconContextMenu;
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // iconContextMenu
            // 
            this.iconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.openHostsMenuItem,
            this.toolStripSeparator2,
            this.setDevelMenuItem,
            this.setTestMenuItem,
            this.setProdMenuItem,
            this.toolStripSeparator1,
            this.aboutMenuItem,
            this.toolStripMenuItem1,
            this.exitMenuItem});
            this.iconContextMenu.Name = "contextMenu";
            this.iconContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.iconContextMenu.Size = new System.Drawing.Size(153, 198);
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsMenuItem.Text = "settings";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // openHostsMenuItem
            // 
            this.openHostsMenuItem.Name = "openHostsMenuItem";
            this.openHostsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openHostsMenuItem.Text = "open hosts file";
            this.openHostsMenuItem.Click += new System.EventHandler(this.openHostsMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // setDevelMenuItem
            // 
            this.setDevelMenuItem.Name = "setDevelMenuItem";
            this.setDevelMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setDevelMenuItem.Text = "devel";
            this.setDevelMenuItem.Click += new System.EventHandler(this.setMenuItem_Click);
            // 
            // setTestMenuItem
            // 
            this.setTestMenuItem.Name = "setTestMenuItem";
            this.setTestMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setTestMenuItem.Text = "test";
            this.setTestMenuItem.Click += new System.EventHandler(this.setMenuItem_Click);
            // 
            // setProdMenuItem
            // 
            this.setProdMenuItem.Name = "setProdMenuItem";
            this.setProdMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setProdMenuItem.Text = "prod";
            this.setProdMenuItem.Click += new System.EventHandler(this.setMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutMenuItem.Text = "about";
            this.aboutMenuItem.Click += new System.EventHandler(this.about_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // aliasLb
            // 
            this.aliasLb.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dnsCol,
            this.currIpCol,
            this.develIpCol,
            this.testIpCol,
            this.prodIpCol,
            this.statusCol});
            this.aliasLb.ContextMenuStrip = this.aliasContextMenu;
            this.aliasLb.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliasLb.FullRowSelect = true;
            this.aliasLb.GridLines = true;
            this.aliasLb.Location = new System.Drawing.Point(12, 7);
            this.aliasLb.MultiSelect = false;
            this.aliasLb.Name = "aliasLb";
            this.aliasLb.Size = new System.Drawing.Size(747, 286);
            this.aliasLb.TabIndex = 0;
            this.aliasLb.UseCompatibleStateImageBehavior = false;
            this.aliasLb.View = System.Windows.Forms.View.Details;
            this.aliasLb.SelectedIndexChanged += new System.EventHandler(this.aliaslv_SelectedIndexChanged);
            // 
            // dnsCol
            // 
            this.dnsCol.Text = "dns";
            // 
            // currIpCol
            // 
            this.currIpCol.Text = "current ip";
            // 
            // develIpCol
            // 
            this.develIpCol.Text = "devel ip";
            // 
            // testIpCol
            // 
            this.testIpCol.Text = "test ip";
            // 
            // prodIpCol
            // 
            this.prodIpCol.Text = "prod ip";
            // 
            // statusCol
            // 
            this.statusCol.Text = "status";
            this.statusCol.Width = 80;
            // 
            // aliasContextMenu
            // 
            this.aliasContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMenuItem});
            this.aliasContextMenu.Name = "aliasContextMenu";
            this.aliasContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.aliasContextMenu.ShowImageMargin = false;
            this.aliasContextMenu.Size = new System.Drawing.Size(80, 26);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(79, 22);
            this.deleteMenuItem.Text = "delete";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteMenuItem_Click);
            // 
            // develIPtxt
            // 
            this.develIPtxt.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.develIPtxt.Location = new System.Drawing.Point(215, 314);
            this.develIPtxt.Name = "develIPtxt";
            this.develIPtxt.Size = new System.Drawing.Size(132, 21);
            this.develIPtxt.TabIndex = 3;
            // 
            // prodIPtxt
            // 
            this.prodIPtxt.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodIPtxt.Location = new System.Drawing.Point(491, 314);
            this.prodIPtxt.Name = "prodIPtxt";
            this.prodIPtxt.Size = new System.Drawing.Size(119, 21);
            this.prodIPtxt.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "devel ip:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(488, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "prod ip:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "dns:";
            // 
            // dnstxt
            // 
            this.dnstxt.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dnstxt.Location = new System.Drawing.Point(60, 314);
            this.dnstxt.Name = "dnstxt";
            this.dnstxt.Size = new System.Drawing.Size(149, 21);
            this.dnstxt.TabIndex = 2;
            // 
            // okBut
            // 
            this.okBut.Location = new System.Drawing.Point(717, 314);
            this.okBut.Name = "okBut";
            this.okBut.Size = new System.Drawing.Size(42, 21);
            this.okBut.TabIndex = 7;
            this.okBut.Text = "ok";
            this.okBut.UseVisualStyleBackColor = true;
            this.okBut.Click += new System.EventHandler(this.okbut_Click);
            // 
            // applyBut
            // 
            this.applyBut.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.applyBut.Enabled = false;
            this.applyBut.Location = new System.Drawing.Point(272, 368);
            this.applyBut.Name = "applyBut";
            this.applyBut.Size = new System.Drawing.Size(75, 23);
            this.applyBut.TabIndex = 9;
            this.applyBut.Text = "apply";
            this.applyBut.UseVisualStyleBackColor = true;
            this.applyBut.Click += new System.EventHandler(this.applybut_Click);
            // 
            // cancelBut
            // 
            this.cancelBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBut.Location = new System.Drawing.Point(420, 368);
            this.cancelBut.Name = "cancelBut";
            this.cancelBut.Size = new System.Drawing.Size(75, 23);
            this.cancelBut.TabIndex = 10;
            this.cancelBut.Text = "hide";
            this.cancelBut.UseVisualStyleBackColor = true;
            this.cancelBut.Click += new System.EventHandler(this.cancelbut_Click);
            // 
            // newBut
            // 
            this.newBut.Location = new System.Drawing.Point(12, 314);
            this.newBut.Name = "newBut";
            this.newBut.Size = new System.Drawing.Size(42, 21);
            this.newBut.TabIndex = 1;
            this.newBut.Text = "new";
            this.newBut.UseVisualStyleBackColor = true;
            this.newBut.Click += new System.EventHandler(this.newbut_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "status:";
            // 
            // statusCb
            // 
            this.statusCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCb.FormattingEnabled = true;
            this.statusCb.Items.AddRange(new object[] {
            "devel",
            "test",
            "prod"});
            this.statusCb.Location = new System.Drawing.Point(616, 314);
            this.statusCb.Name = "statusCb";
            this.statusCb.Size = new System.Drawing.Size(95, 21);
            this.statusCb.TabIndex = 6;
            // 
            // fsWatcher
            // 
            this.fsWatcher.EnableRaisingEvents = true;
            this.fsWatcher.SynchronizingObject = this;
            this.fsWatcher.Changed += new System.IO.FileSystemEventHandler(this.fsWatcher_Changed);
            // 
            // runAtStartupCk
            // 
            this.runAtStartupCk.AutoSize = true;
            this.runAtStartupCk.Location = new System.Drawing.Point(12, 350);
            this.runAtStartupCk.Name = "runAtStartupCk";
            this.runAtStartupCk.Size = new System.Drawing.Size(123, 17);
            this.runAtStartupCk.TabIndex = 8;
            this.runAtStartupCk.Text = "run at system startup";
            this.runAtStartupCk.UseVisualStyleBackColor = true;
            this.runAtStartupCk.Click += new System.EventHandler(this.runAtStartupCk_Click);
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Location = new System.Drawing.Point(725, 378);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(34, 13);
            this.aboutLabel.TabIndex = 11;
            this.aboutLabel.TabStop = true;
            this.aboutLabel.Text = "about";
            this.aboutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLabel_LinkClicked);
            // 
            // notepadProcess
            // 
            this.notepadProcess.StartInfo.Domain = "";
            this.notepadProcess.StartInfo.FileName = "notepad.exe";
            this.notepadProcess.StartInfo.LoadUserProfile = false;
            this.notepadProcess.StartInfo.Password = null;
            this.notepadProcess.StartInfo.StandardErrorEncoding = null;
            this.notepadProcess.StartInfo.StandardOutputEncoding = null;
            this.notepadProcess.StartInfo.UserName = "";
            this.notepadProcess.StartInfo.Verb = "open";
            this.notepadProcess.SynchronizingObject = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "test ip:";
            // 
            // testIPtxt
            // 
            this.testIPtxt.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testIPtxt.Location = new System.Drawing.Point(353, 314);
            this.testIPtxt.Name = "testIPtxt";
            this.testIPtxt.Size = new System.Drawing.Size(132, 21);
            this.testIPtxt.TabIndex = 4;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.applyBut;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBut;
            this.ClientSize = new System.Drawing.Size(771, 403);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.testIPtxt);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.runAtStartupCk);
            this.Controls.Add(this.newBut);
            this.Controls.Add(this.cancelBut);
            this.Controls.Add(this.applyBut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusCb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dnstxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.develIPtxt);
            this.Controls.Add(this.okBut);
            this.Controls.Add(this.aliasLb);
            this.Controls.Add(this.prodIPtxt);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "swhost - settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.iconContextMenu.ResumeLayout(false);
            this.aliasContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fsWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ListView aliasLb;
        private System.Windows.Forms.ColumnHeader dnsCol;
        private System.Windows.Forms.ColumnHeader develIpCol;
        private System.Windows.Forms.ColumnHeader prodIpCol;
        private System.Windows.Forms.ColumnHeader currIpCol;
        private System.Windows.Forms.TextBox develIPtxt;
        private System.Windows.Forms.TextBox prodIPtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dnstxt;
        private System.Windows.Forms.Button okBut;
        private System.Windows.Forms.Button applyBut;
        private System.Windows.Forms.Button cancelBut;
        private System.Windows.Forms.Button newBut;
        private System.Windows.Forms.ContextMenuStrip iconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDevelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setProdMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ColumnHeader statusCol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox statusCb;
        private System.Windows.Forms.ContextMenuStrip aliasContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.IO.FileSystemWatcher fsWatcher;
        private CheckBox runAtStartupCk;
        private LinkLabel aboutLabel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem aboutMenuItem;
        private ToolStripMenuItem openHostsMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private System.Diagnostics.Process notepadProcess;
        private ToolStripMenuItem setTestMenuItem;
        private Label label5;
        private TextBox testIPtxt;
        private ColumnHeader testIpCol;
    }
}

