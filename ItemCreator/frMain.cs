using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace ItemCreator
{
    public partial class frMain : Form
    {
        private ProjectControlPanel projectControlPanel = new ProjectControlPanel();
        private string projectPath;
        private Panel pnLatestProjects;
        private Label lbLatestProjects;
        private Button btClear;
        private Button btNewSimpleProject;
        private Button btNewProProject;
        private Button btNewAISProject;
        private Button btOpenProject;
        private Panel pnBrowserPanel;
        private ChromiumWebBrowser wbBrowser;

        public frMain(string[] args)
        {
            var settings = new Properties.Settings();
            this.BackColor = Color.Black;
            this.ClientSize = new Size(settings.Width, settings.Height);
            this.MinimumSize = new Size(800, 600);
            this.Text = "Item Creator " + settings.Version;
            this.Icon = Properties.Resources.ico;
            this.Load += new System.EventHandler(frMain_Load);

            if (settings.LatestProjects == null)
            {
                settings.LatestProjects = new System.Collections.Specialized.StringCollection();
            }
            settings.Save();

            InitializeComponent();
            InitializeChromium();
            projectControlPanel.Changed = false;
            projectControlPanel.Parent = this;
            projectControlPanel.Visible = false;
            projectControlPanel.Left = 0;
            projectControlPanel.Top = msMain.Height;
            projectControlPanel.Width = this.ClientSize.Width;
            projectControlPanel.Height = this.ClientSize.Height - msMain.Height;
            projectControlPanel.ProjectCnanged += projectControlPanel_ProjectCnanged;
            projectControlPanel.ProjectSaved += projectControlPanel_ProjectSaved;

            pnBrowserPanel = new Panel
            {
                Width = this.ClientSize.Width / 4 * 2 - 10,
                Height = this.ClientSize.Height / 3,
                Left = this.ClientSize.Width / 4 / 2,
                Top = msMain.Height + this.ClientSize.Height / 3 / 3 * 2,
                Parent = this
            };
            wbBrowser = new ChromiumWebBrowser("https://stv233.pro/en/GameGuru-Scripts/");
            wbBrowser.Parent = pnBrowserPanel;
            

            pnLatestProjects = new Panel
            {
                AutoScroll = true,
                Width = this.ClientSize.Width / 4,
                Height = pnBrowserPanel.Height,
                Left = pnBrowserPanel.Left + pnBrowserPanel.Width + 20,
                Top = pnBrowserPanel.Top,
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                BorderStyle = BorderStyle.Fixed3D,
                Parent = this
            };

            btClear = new Button
            {
                AutoSize = true,
                Text = "Clear",
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Popup,
                BackColor = Color.FromArgb(64, 64, 64),
                ForeColor = Color.White,
                Parent = this
            };
            btClear.Left = pnLatestProjects.Left + pnLatestProjects.Width - btClear.Width;
            btClear.Top = pnLatestProjects.Top - btClear.Height - 5;
            btClear.Click += (s, e) =>
            {
                var setting = new Properties.Settings();
                setting.LatestProjects.Clear();
                setting.Save();
                LoadLatestProjects();
            };

            lbLatestProjects = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 10),
                Text = "Latest projects",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Parent = this
            };
            lbLatestProjects.Left = pnLatestProjects.Left + pnLatestProjects.Width / 2 - lbLatestProjects.Width / 2;
            lbLatestProjects.Top = btClear.Top;

            btNewProProject = new Button
            {
                Text = "New inventory system PRO project",
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                Width = this.Width / 4 - 10,
                Height = 50,
                Left = 5,
                Parent = this
            };
            btNewProProject.Top = this.ClientSize.Height / 2 - btNewProProject.Height - 10;
            btNewProProject.Click += proToolStripMenuItem_Click;

            btNewSimpleProject = new Button
            {
                Text = "New simple inventory system project",
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                Width = this.Width / 4 - 10,
                Height = 50,
                Left = 5,
                Parent = this
            };
            btNewSimpleProject.Top = btNewProProject.Top - btNewSimpleProject.Height - 20;
            btNewSimpleProject.Click += simpleToolStripMenuItem_Click;

            btNewAISProject = new Button
            {
                Text = "New advanced inventory system project",
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                Width = this.Width / 4 - 10,
                Height = 50,
                Left = 5,
                Parent = this
            };
            btNewAISProject.Top = this.ClientSize.Height / 2 + 10;
            btNewAISProject.Click += aIsToolStripMenuItem_Click;

            btOpenProject = new Button
            {
                Text = "Open project",
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                Width = this.Width / 4 - 10,
                Height = 50,
                Left = 5,
                Parent = this
            };
            btOpenProject.Top = btNewAISProject.Top + btNewAISProject.Height + 20;
            btOpenProject.Click += openToolStripMenuItem_Click;

            this.Resize += (s, e) =>
            {
                projectControlPanel.Left = 0;
                projectControlPanel.Top = msMain.Height;
                projectControlPanel.Width = this.ClientSize.Width;
                projectControlPanel.Height = this.ClientSize.Height - msMain.Height;
                pnBrowserPanel.Width = this.ClientSize.Width / 4 * 2 - 10;
                pnBrowserPanel.Height = this.ClientSize.Height / 3;
                pnBrowserPanel.Left = this.ClientSize.Width / 4 / 2;
                pnBrowserPanel.Top = msMain.Height + this.ClientSize.Height / 3 / 3 * 2;
                pnLatestProjects.Width = this.ClientSize.Width / 4;
                pnLatestProjects.Height = pnBrowserPanel.Height;
                pnLatestProjects.Left = pnBrowserPanel.Left + pnBrowserPanel.Width + 20;
                pnLatestProjects.Top = pnBrowserPanel.Top;
                btClear.Left = pnLatestProjects.Left + pnLatestProjects.Width - btClear.Width;
                btClear.Top = pnLatestProjects.Top - btClear.Height - 5;
                lbLatestProjects.Left = pnLatestProjects.Left;
                lbLatestProjects.Top = btClear.Top;
                btNewSimpleProject.Width = ((pnLatestProjects.Left + pnLatestProjects.Width) - pnBrowserPanel.Left) / 5 * 1 + 15;
                btNewSimpleProject.Height = 50;
                btNewSimpleProject.Top = pnBrowserPanel.Top + pnBrowserPanel.Height + 10;
                btNewSimpleProject.Left = pnBrowserPanel.Left;
                btNewProProject.Width = btNewSimpleProject.Width;
                btNewProProject.Height = 50;
                btNewProProject.Top = btNewSimpleProject.Top;
                btNewProProject.Left = btNewSimpleProject.Left + btNewSimpleProject.Width + ((pnLatestProjects.Left + pnLatestProjects.Width) - pnBrowserPanel.Left) / 5 / 3 - 20;
                btNewAISProject.Width = btNewProProject.Width;
                btNewAISProject.Height = 50;
                btNewAISProject.Top = btNewProProject.Top;
                btNewAISProject.Left = btNewProProject.Left + btNewProProject.Width + ((pnLatestProjects.Left + pnLatestProjects.Width) - pnBrowserPanel.Left) / 5 / 3 - 20;
                btOpenProject.Width = btNewAISProject.Width;
                btOpenProject.Height = 50;
                btOpenProject.Top = btNewAISProject.Top;
                btOpenProject.Left = btNewAISProject.Left + btNewAISProject.Width + ((pnLatestProjects.Left + pnLatestProjects.Width) - pnBrowserPanel.Left) / 5 / 3 - 20;
                LoadLatestProjects();
                settings = new Properties.Settings();
                settings.Width = this.ClientSize.Width;
                settings.Height = this.ClientSize.Height;
                settings.Save();
            };
            this.FormClosing += (s, e) =>
            {
                if (projectControlPanel.Changed == true)
                {
                    if (MessageBox.Show("There are unsaved changes in the project. If you continue, they will be lost. Do you want to continue?",
                        "Close project?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            };

            OnResize(new EventArgs());

            if (args.Length > 0)
            {
                projectPath = args[0];
                projectControlPanel.Project.Open(args[0]);
                projectControlPanel.ReloadItems();
                saveAsToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                projectControlPanel.Visible = true;
                projectControlPanel.BringToFront();

                var setting = new Properties.Settings();
                setting.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                setting.Save();
                LoadLatestProjects();
                this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);

                
            }

            musicDiscsToolStripMenuItem.Checked = new Properties.Addons().MusicDiscs;
        }

        private async void frMain_Load(object sender,EventArgs e)
        {
            string page = await downloadStringAsync("https://github.com/stv233/ItemCreator/blob/master/ItemCreator/Page.txt?raw=true");
            if (!String.IsNullOrEmpty(page))
            {
                wbBrowser.Load(page);
            }
            else
            {
                wbBrowser.Load("https://stv233.pro/en/GameGuru-Scripts/");
            }
        }

        private void InitializeChromium()
        {
            //Инициализировать настройки
            CefSettings settings = new CefSettings();
            Cef.EnableHighDPISupport();

            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Stv233\ItemCreator\Page";
            settings.ProductVersion = "Chrome/75 Chrome/85.0.4183.83";
            settings.UserAgent = "Mozilla/5.0 (" + Environment.OSVersion + "; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) " + settings.ProductVersion;

            //settings.CefCommandLineArgs.Add

            Cef.Initialize(settings);


        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.Changed == true)
            {
                if (MessageBox.Show("There are unsaved changes in the project. If you continue, they will be lost. Do you want to continue?",
                    "Open project?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            projectControlPanel.Dispose();
            projectControlPanel = new ProjectControlPanel();
            projectControlPanel.Parent = this;
            projectControlPanel.Visible = false;
            projectControlPanel.Left = 0;
            projectControlPanel.Top = msMain.Height;
            projectControlPanel.Width = this.ClientSize.Width;
            projectControlPanel.Height = this.ClientSize.Height - msMain.Height;
            projectControlPanel.Project.Type = Project.Types.Simple;
            projectControlPanel.Changed = false;
            projectControlPanel.ProjectCnanged += projectControlPanel_ProjectCnanged;
            projectControlPanel.ProjectSaved += projectControlPanel_ProjectSaved;
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;

            using (var sfd = new SaveFileDialog
            {
                Filter = "ItemCreator project (*.ICP)|*.icp|All files (*.*)|*.*"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    projectPath = sfd.FileName;
                    projectControlPanel.Project.Save(sfd.FileName);
                    projectControlPanel.Project.Open(sfd.FileName);
                    saveAsToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    closeToolStripMenuItem.Enabled = true;
                    projectControlPanel.Visible = true;
                    projectControlPanel.BringToFront();

                    var settings = new Properties.Settings();
                    settings.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                    settings.Save();
                    this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);
                    projectControlPanel.Changed = true;
                    LoadLatestProjects();
                }
                else
                {
                    var settings = new Properties.Settings();
                    this.Text = "Item Creator " + settings.Version;
                }
            }
        }

        private void proToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.Changed == true)
            {
                if (MessageBox.Show("There are unsaved changes in the project. If you continue, they will be lost. Do you want to continue?",
                    "Open project?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            projectControlPanel.Dispose();
            projectControlPanel = new ProjectControlPanel();
            projectControlPanel.Parent = this;
            projectControlPanel.Visible = false;
            projectControlPanel.Left = 0;
            projectControlPanel.Top = msMain.Height;
            projectControlPanel.Width = this.ClientSize.Width;
            projectControlPanel.Height = this.ClientSize.Height - msMain.Height;
            projectControlPanel.Project.Type = Project.Types.Pro;
            projectControlPanel.Changed = false;
            projectControlPanel.ProjectCnanged += projectControlPanel_ProjectCnanged;
            projectControlPanel.ProjectSaved += projectControlPanel_ProjectSaved;
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;

            using (var sfd = new SaveFileDialog
            {
                Filter = "ItemCreator project (*.ICP)|*.icp|All files (*.*)|*.*"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    projectPath = sfd.FileName;
                    projectControlPanel.Project.Save(sfd.FileName);
                    projectControlPanel.Project.Open(sfd.FileName);
                    saveAsToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    closeToolStripMenuItem.Enabled = true;
                    projectControlPanel.Visible = true;
                    projectControlPanel.BringToFront();

                    var settings = new Properties.Settings();
                    settings.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                    settings.Save();
                    this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);
                    projectControlPanel.Changed = true;
                    LoadLatestProjects();
                }
                else
                {
                    var settings = new Properties.Settings();
                    this.Text = "Item Creator " + settings.Version;
                }
            }
        }

        private void aIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.Changed == true)
            {
                if (MessageBox.Show("There are unsaved changes in the project. If you continue, they will be lost. Do you want to continue?",
                    "Open project?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            projectControlPanel.Dispose();
            projectControlPanel = new ProjectControlPanel();
            projectControlPanel.Parent = this;
            projectControlPanel.Visible = false;
            projectControlPanel.Left = 0;
            projectControlPanel.Top = msMain.Height;
            projectControlPanel.Width = this.ClientSize.Width;
            projectControlPanel.Height = this.ClientSize.Height - msMain.Height;
            projectControlPanel.Project.Type = Project.Types.AIS;
            projectControlPanel.Changed = false;
            projectControlPanel.ProjectCnanged += projectControlPanel_ProjectCnanged;
            projectControlPanel.ProjectSaved += projectControlPanel_ProjectSaved;
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;

            using (var sfd = new SaveFileDialog
            {
                Filter = "ItemCreator project (*.ICP)|*.icp|All files (*.*)|*.*"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    projectPath = sfd.FileName;
                    projectControlPanel.Project.Save(sfd.FileName);
                    projectControlPanel.Project.Open(sfd.FileName);
                    saveAsToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    closeToolStripMenuItem.Enabled = true;
                    projectControlPanel.Visible = true;
                    projectControlPanel.BringToFront();

                    var settings = new Properties.Settings();
                    settings.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                    settings.Save();
                    this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);
                    projectControlPanel.Changed = true;
                    LoadLatestProjects();
                }
                else
                {
                    var settings = new Properties.Settings();
                    this.Text = "Item Creator " + settings.Version;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.Changed == true)
            {
                if (MessageBox.Show("There are unsaved changes in the project. If you continue, they will be lost. Do you want to continue?",
                    "Open project?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            using (var ofd = new OpenFileDialog
            {
                Filter = "ItemCreator project (*.ICP)|*.icp|All files (*.*)|*.*"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    projectPath = ofd.FileName;
                    projectControlPanel.Project.Open(ofd.FileName);
                    projectControlPanel.ReloadItems();
                    saveAsToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    closeToolStripMenuItem.Enabled = true;
                    projectControlPanel.Visible = true;
                    projectControlPanel.BringToFront();

                    var setting = new Properties.Settings();
                    setting.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                    setting.Save();
                    LoadLatestProjects();

                    var settings = new Properties.Settings();
                    this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((projectPath != "") && (projectPath != null))
            {
                projectControlPanel.Project.Save(projectPath);
                projectControlPanel.Changed = false;
            }
            else
            {
                saveAsToolStripMenuItem_Click(saveAsToolStripMenuItem, new EventArgs());
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog
            {
                Filter = "ItemCreator project (*.ICP)|*.icp|All files (*.*)|*.*"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    projectPath = sfd.FileName;
                    projectControlPanel.Project.Save(sfd.FileName);
                    projectControlPanel.Project.Open(sfd.FileName);
                    saveAsToolStripMenuItem.Enabled = true;
                    saveToolStripMenuItem.Enabled = true;
                    closeToolStripMenuItem.Enabled = true;
                    projectControlPanel.Visible = true;
                    projectControlPanel.Changed = false;
                    projectControlPanel.BringToFront();

                    var setting = new Properties.Settings();
                    if (!setting.LatestProjects.Contains(projectControlPanel.Name + "|" + projectPath))
                    {
                        setting.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                    }
                    setting.Save();
                    LoadLatestProjects();
                }
            }
        }

        /// <summary>
        /// Loads the interfaces of the last open projects.
        /// </summary>
        private void LoadLatestProjects()
        {
            try
            {
                pnLatestProjects.Controls.Clear();
                var settings = new Properties.Settings();

                var i = 0;
                foreach (string project in settings.LatestProjects)
                {
                    var pnProjectPanel = new Panel
                    {
                        BackColor = Color.Black,
                        ForeColor = Color.White,
                        Cursor = Cursors.Hand,
                        Width = pnLatestProjects.ClientSize.Width,
                        Height = 50,
                        Left = 0,
                        Top = 50 * i,
                        Parent = pnLatestProjects
                    };

                    var lbName = new Label
                    {
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = true,
                        Text = project.Split('|')[0],
                        Font = new Font("Arial", 12),
                        Top = 10,
                        Parent = pnProjectPanel
                    };
                    lbName.Left = pnProjectPanel.Width / 2 - lbName.Width / 2;

                    var lbPath = new Label
                    {
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = true,
                        Text = project.Split('|')[1],
                        Font = new Font("Arial", 8),
                        Parent = pnProjectPanel
                    };
                    lbPath.Left = pnProjectPanel.Width / 2 - lbPath.Width / 2;
                    lbPath.Top = lbName.Top + lbName.Height;

                    pnProjectPanel.Click += (s, e) =>
                    {
                        projectPath = lbPath.Text;
                        projectControlPanel.Project.Open(lbPath.Text);
                        projectControlPanel.ReloadItems();
                        saveAsToolStripMenuItem.Enabled = true;
                        saveToolStripMenuItem.Enabled = true;
                        closeToolStripMenuItem.Enabled = true;
                        projectControlPanel.Visible = true;
                        projectControlPanel.BringToFront();
                        this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);
                    };
                    lbName.Click += (s, e) =>
                    {
                        projectPath = lbPath.Text;
                        projectControlPanel.Project.Open(lbPath.Text);
                        projectControlPanel.ReloadItems();
                        saveAsToolStripMenuItem.Enabled = true;
                        saveToolStripMenuItem.Enabled = true;
                        closeToolStripMenuItem.Enabled = true;
                        projectControlPanel.Visible = true;
                        projectControlPanel.BringToFront();
                        this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);
                    };
                    lbPath.Click += (s, e) =>
                    {
                        projectPath = lbPath.Text;
                        projectControlPanel.Project.Open(lbPath.Text);
                        projectControlPanel.ReloadItems();
                        saveAsToolStripMenuItem.Enabled = true;
                        saveToolStripMenuItem.Enabled = true;
                        closeToolStripMenuItem.Enabled = true;
                        projectControlPanel.Visible = true;
                        projectControlPanel.BringToFront();
                        this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);
                    };

                    i++;
                }
            }
            catch
            {
                return;
            }
        }

        private void projectControlPanel_ProjectCnanged(object sender,EventArgs e)
        {
                this.Text += "*";
        }

        private void projectControlPanel_ProjectSaved(object sendser, EventArgs e)
        {
            this.Text = this.Text.Replace("*", "");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.Changed == true)
            {
                if (MessageBox.Show("There are unsaved changes in the project. If you continue, they will be lost. Do you want to continue?",
                    "Close project?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            projectControlPanel.Visible = false;
            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            var settings = new Properties.Settings();
            this.Text = "Item Creator " + settings.Version;
        }

        private void musicDiscsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addons = new Properties.Addons();
            addons.MusicDiscs = !addons.MusicDiscs;
            addons.Save();
            musicDiscsToolStripMenuItem.Checked = Addons.Enabled("MusicDiscs");
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://stv233.pro/en/me/");
        }

        private async Task<string> downloadStringAsync(string url)
        {
            return await Task.Run(() =>
            {
                string result;
                using (var wc = new WebClient())
                {
                    try
                    {
                        result = wc.DownloadString(url);
                    }
                    catch
                    {
                        result = "";
                    }
                    return result;
                }
            });
            
        }
    }
}
