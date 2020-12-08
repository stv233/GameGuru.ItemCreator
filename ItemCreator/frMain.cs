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

        public frMain()
        {
            InitializeComponent();
            projectControlPanel.ProjectChanged = false;
            projectControlPanel.Parent = this;
            projectControlPanel.Visible = false;
            projectControlPanel.Left = 0;
            projectControlPanel.Top = msMain.Height;
            projectControlPanel.Width = this.ClientSize.Width;
            projectControlPanel.Height = this.ClientSize.Height - msMain.Height;
            this.Resize += (s, e) =>
            {
                projectControlPanel.Left = 0;
                projectControlPanel.Top = msMain.Height;
                projectControlPanel.Width = this.ClientSize.Width;
                projectControlPanel.Height = this.ClientSize.Height - msMain.Height;
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
                }
            }
        }

    }
}
