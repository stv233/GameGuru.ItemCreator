namespace ItemCreator
{
    partial class frMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicDiscsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aisHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aisDocHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicDicsHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.supportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(284, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.projectToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "&Project";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleToolStripMenuItem,
            this.proToolStripMenuItem,
            this.aIsToolStripMenuItem});
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.newToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N;
            this.newToolStripMenuItem.Click += (s, e) => { this.newToolStripMenuItem.ShowDropDown(); };
            // 
            // simpleToolStripMenuItem
            // 
            this.simpleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.simpleToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.simpleToolStripMenuItem.Name = "simpleToolStripMenuItem";
            this.simpleToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.simpleToolStripMenuItem.Text = "Simple inventory system project...";
            this.simpleToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N, S";
            this.simpleToolStripMenuItem.Click += new System.EventHandler(this.simpleToolStripMenuItem_Click);
            // 
            // proToolStripMenuItem
            // 
            this.proToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.proToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.proToolStripMenuItem.Name = "proToolStripMenuItem";
            this.proToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.proToolStripMenuItem.Text = "Inventory system P&RO project...";
            this.proToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N, R";
            this.proToolStripMenuItem.Click += new System.EventHandler(this.proToolStripMenuItem_Click);
            // 
            // aIsToolStripMenuItem
            // 
            this.aIsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aIsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.aIsToolStripMenuItem.Name = "aIsToolStripMenuItem";
            this.aIsToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.aIsToolStripMenuItem.Text = "Advanced inventory system project...";
            this.aIsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N, A";
            this.aIsToolStripMenuItem.Click += new System.EventHandler(this.aIsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.openToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.saveAsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.S;
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addonsToolStripMenuItem});
            this.settingToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // addonsToolStripMenuItem
            // 
            this.addonsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addonsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musicDiscsToolStripMenuItem});
            this.addonsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.addonsToolStripMenuItem.Name = "addonsToolStripMenuItem";
            this.addonsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addonsToolStripMenuItem.Text = "Addons";
            // 
            // musicDiscsToolStripMenuItem
            // 
            this.musicDiscsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.musicDiscsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.musicDiscsToolStripMenuItem.Name = "musicDiscsToolStripMenuItem";
            this.musicDiscsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.musicDiscsToolStripMenuItem.Text = "Music Discs";
            this.musicDiscsToolStripMenuItem.Click += new System.EventHandler(this.musicDiscsToolStripMenuItem_Click);
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.supportToolStripMenuItem.Text = "Support";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.supportToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem});
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aisHelpToolStripMenuItem,
            this.proHelpToolStripMenuItem});
            this.documentationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.documentationToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // proHelpToolStripMenuItem
            // 
            this.proHelpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.proHelpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.proHelpToolStripMenuItem.Name = "proHelpToolStripMenuItem";
            this.proHelpToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.proHelpToolStripMenuItem.Text = "Inventory system PRO";
            this.proHelpToolStripMenuItem.Click += (s, e) => {var fr = new System.Windows.Forms.Form(); fr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; fr.Width = 800; fr.Height = 600; fr.Controls.Add(new CefSharp.WinForms.ChromiumWebBrowser(@"file:\\\Resources\Inventory system PRO Documentation.pdf")); fr.Show(); };
            // 
            // aisHelpToolStripMenuItem
            // 
            this.aisHelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aisDocHelpToolStripMenuItem,
            this.musicDicsHelpToolStripMenuItem});
            this.aisHelpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aisHelpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.aisHelpToolStripMenuItem.Name = "aisHelpToolStripMenuItem";
            this.aisHelpToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.aisHelpToolStripMenuItem.Text = "AIS";
            // 
            // aisDocHelpToolStripMenuItem
            // 
            this.aisDocHelpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aisDocHelpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.aisDocHelpToolStripMenuItem.Name = "aisDocHelpToolStripMenuItem";
            this.aisDocHelpToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.aisDocHelpToolStripMenuItem.Text = "Advanced inventory system";
            this.aisDocHelpToolStripMenuItem.Click += (s, e) => { var fr = new System.Windows.Forms.Form(); fr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; fr.Width = 800; fr.Height = 600; fr.Controls.Add(new CefSharp.WinForms.ChromiumWebBrowser(@"file:\\\Resources\AIS Documentation.pdf")); fr.Show(); };
            // 
            // musicDicsHelpToolStripMenuItem
            // 
            this.musicDicsHelpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.musicDicsHelpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.musicDicsHelpToolStripMenuItem.Name = "musicDicsHelpToolStripMenuItem";
            this.musicDicsHelpToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.musicDicsHelpToolStripMenuItem.Text = "Advanced inventory system: Music Discs add-on";
            this.musicDicsHelpToolStripMenuItem.Click += (s, e) => { var fr = new System.Windows.Forms.Form(); fr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; fr.Width = 800; fr.Height = 600; fr.Controls.Add(new CefSharp.WinForms.ChromiumWebBrowser(@"file:\\\Resources\Music Discs Documentation.pdf")); fr.Show(); };
            // 
            // frMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "frMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicDiscsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aisHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aisDocHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicDicsHelpToolStripMenuItem;
    }
}

