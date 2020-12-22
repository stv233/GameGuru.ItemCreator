using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public frMain(string[] args)
        {
            var settings = new Properties.Settings();
            this.BackColor = Color.Black;
            this.ClientSize = new Size(settings.Width, settings.Height);
            this.MinimumSize = new Size(800, 600);
            this.Text = "Item Creator " + settings.Version;
            this.Icon = Properties.Resources.ico;

            if (settings.LatestProjects == null)
            {
                settings.LatestProjects = new System.Collections.Specialized.StringCollection();
            }
            settings.Save();

            InitializeComponent();
            projectControlPanel.ProjectChanged = false;
            projectControlPanel.Parent = this;
            projectControlPanel.Visible = false;
            projectControlPanel.Left = 0;
            projectControlPanel.Top = msMain.Height;
            projectControlPanel.Width = this.ClientSize.Width;
            projectControlPanel.Height = this.ClientSize.Height - msMain.Height;

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

            pnLatestProjects = new Panel
            {
                AutoScroll = true,
                Width = this.ClientSize.Width / 2 - 30,
                Height = (btOpenProject.Top + btOpenProject.Height) - btNewSimpleProject.Top + 140,
                Left = this.Width / 4 + 10,
                Top = btNewSimpleProject.Top  - 70,
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                Parent = this
            };

            lbLatestProjects = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 25),
                Text = "Latest projects",
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Parent = this
            };
            lbLatestProjects.Left = pnLatestProjects.Left + pnLatestProjects.Width / 2 - lbLatestProjects.Width / 2;
            lbLatestProjects.Top = pnLatestProjects.Top - lbLatestProjects.Height;

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

            this.Resize += (s, e) =>
            {
                projectControlPanel.Left = 0;
                projectControlPanel.Top = msMain.Height;
                projectControlPanel.Width = this.ClientSize.Width;
                projectControlPanel.Height = this.ClientSize.Height - msMain.Height;
                btNewProProject.Width = this.Width / 4 - 10;
                btNewProProject.Height = 50;
                btNewProProject.Top = Top = this.ClientSize.Height / 2 - btNewProProject.Height - 10 ;
                btNewSimpleProject.Width = this.Width / 4 - 10;
                btNewSimpleProject.Height = 50;
                btNewSimpleProject.Top = btNewProProject.Top - btNewSimpleProject.Height - 20 ;
                btNewAISProject.Width = this.Width / 4 - 10;
                btNewAISProject.Height = 50;
                btNewAISProject.Top = this.ClientSize.Height / 2 + 10 ;
                btOpenProject.Width = this.Width / 4 - 10;
                btOpenProject.Height = 50;
                btOpenProject.Top = btNewAISProject.Top + btNewAISProject.Height + 20 ;
                pnLatestProjects.Width = this.ClientSize.Width / 4 * 3 - 30;
                pnLatestProjects.Height = (btOpenProject.Top + btOpenProject.Height) - btNewSimpleProject.Top + 140;
                pnLatestProjects.Left = this.Width / 4 + 10;
                pnLatestProjects.Top = btNewSimpleProject.Top - 70;
                lbLatestProjects.Left = pnLatestProjects.Left + pnLatestProjects.Width / 2 - lbLatestProjects.Width / 2;
                lbLatestProjects.Top = pnLatestProjects.Top - lbLatestProjects.Height;
                btClear.Left = pnLatestProjects.Left + pnLatestProjects.Width - btClear.Width;
                btClear.Top = pnLatestProjects.Top - btClear.Height - 5;
                LoadLatestProjects();
                settings = new Properties.Settings();
                settings.Width = this.ClientSize.Width;
                settings.Height = this.ClientSize.Height;
                settings.Save();
            };
            this.FormClosing += (s, e) =>
            {
                if (projectControlPanel.ProjectChanged == true)
                {
                    if (MessageBox.Show("There are unsaved changes in the project. If you continue, they will be lost. Do you want to continue?",
                        "Open project?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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
                projectControlPanel.Visible = true;
                projectControlPanel.BringToFront();

                var setting = new Properties.Settings();
                setting.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                setting.Save();
                LoadLatestProjects();
                this.Text = "Item Creator " + settings.Version + " - " + System.IO.Path.GetFileNameWithoutExtension(projectPath);
            }
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.ProjectChanged == true)
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
                    projectControlPanel.Visible = true;
                    projectControlPanel.BringToFront();

                    var setting = new Properties.Settings();
                    setting.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                    setting.Save();
                    LoadLatestProjects();
                }
            }
        }

        private void proToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.ProjectChanged == true)
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
                    projectControlPanel.Visible = true;
                    projectControlPanel.BringToFront();

                    var setting = new Properties.Settings();
                    setting.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                    setting.Save();
                    LoadLatestProjects();
                }
            }
        }

        private void aIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.ProjectChanged == true)
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
                    projectControlPanel.Visible = true;
                    projectControlPanel.BringToFront();

                    var setting = new Properties.Settings();
                    setting.LatestProjects.Add(projectControlPanel.Project.Name + "|" + projectPath);
                    setting.Save();
                    LoadLatestProjects();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectControlPanel.ProjectChanged == true)
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
                projectControlPanel.ProjectChanged = false;
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
                    projectControlPanel.Visible = true;
                    projectControlPanel.ProjectChanged = false;
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
                        Width = pnLatestProjects.Width,
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

    }
}
