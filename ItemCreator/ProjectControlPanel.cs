using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItemCreator
{
    class ProjectControlPanel : Panel
    {
        /// <summary>
        /// Current project.
        /// </summary>
        public Project Project { get; protected set; }

        public bool ProjectChanged { get; set; }

        /// <summary>
        /// Panel for displaying items.
        /// </summary>
        private Panel pnItemPanel;

        /// <summary>
        /// Item creation button.
        /// </summary>
        private Button btCreateItem;

        /// <summary>
        /// Import item button.
        /// </summary>
        private Button btImportItem;

        /// <summary>
        /// Export button for all items.
        /// </summary>
        private Button btExportAllItems;

        public ProjectControlPanel()
        {
            Project = new Project("New");
            this.BackColor = System.Drawing.Color.Black;
            ProjectChanged = true;

            pnItemPanel = new Panel
            {
                AutoScroll = true,
                Width = this.Width / 4 * 3 - 5,
                Height = this.Height - 10,
                Left = this.Width / 4,
                Top = 5,
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                Parent = this
            };

            btCreateItem = new Button
            {
                Text = "Create new item",
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                Width = this.Width / 4 - 10,
                Height = 50,
                Left = 5,
                Top = pnItemPanel.Top,
                Parent = this
            };
            btCreateItem.Click += (s, e) =>
            {
                if (Project.Type == Project.Types.AIS)
                {
                    AISItem item = new AISItem("My new item");
                    AISItemCreationDialog creationDialog = new AISItemCreationDialog(item);



                    while (true)
                    {
                        DialogResult result = creationDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            if (!Project.ListOfItems.ContainsKey(creationDialog.Item.Name))
                            {
                                Project.AddItem(creationDialog.Item);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("An item with the given name already exists.",
                                    "Item creation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                }

                ReloadItems();
                ProjectChanged = true;
            };

            btImportItem = new Button
            {
                Text = "Import item",
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                Width = this.Width / 4 - 10,
                Height = 50,
                Left = 5,
                Top = btCreateItem.Top + btCreateItem.Height + 5,
                Parent = this
            };
            btImportItem.Click += (s, e) =>
            {
                try
                {
                    IItem item;
                    if (Project.Type == Project.Types.AIS)
                    {
                         item = new AISItem("My new item");
                    }
                    else
                    {
                         item = new AISItem("My new item");
                    }

                    using (var fbs = new FolderBrowserDialog())
                    {
                        if (fbs.ShowDialog() == DialogResult.OK)
                        {
                            item.Import(fbs.SelectedPath);

                            if (Project.ListOfItems.ContainsKey(item.Name))
                            {
                                if (MessageBox.Show("The project already contains an item with that name. Overwrite the item?",
                                    "Import item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    Project.AddItem(item);
                                }
                            }
                            else
                            {
                                Project.AddItem(item);
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Failed to import item.\n" + err.Message,
                        "Import error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ReloadItems();
                ProjectChanged = true;
            };

            btExportAllItems = new Button
            {
                Text = "Export all items",
                BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Popup,
                Cursor = Cursors.Hand,
                Width = this.Width / 4 - 10,
                Height = 50,
                Left = 5,
                Top = btImportItem.Top + btImportItem.Height + 5,
                Parent = this
            };
            btExportAllItems.Click += (s, e) =>
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        Project.ExportAllItems(fbd.SelectedPath);
                    }
                }
            };

            this.Resize += (s, e) =>
            {
                pnItemPanel.Width = this.Width / 4 * 3 - 5;
                pnItemPanel.Height = this.Height - 10;
                pnItemPanel.Left = this.Width / 4;
                pnItemPanel.Top = 5;
                btCreateItem.Width = this.Width / 4 - 10;
                btCreateItem.Height = 50;
                btCreateItem.Left = 5;
                btCreateItem.Top = pnItemPanel.Top;
                btImportItem.Width = this.Width / 4 - 10;
                btImportItem.Height = 50;
                btImportItem.Left = 5;
                btImportItem.Top = btCreateItem.Top + btCreateItem.Height + 5;
                btExportAllItems.Width = this.Width / 4 - 10;
                btExportAllItems.Height = 50;
                btExportAllItems.Left = 5;
                btExportAllItems.Top = btImportItem.Top + btImportItem.Height + 5;
                ReloadItems();
            };

            ReloadItems();
        }

        /// <summary>
        /// Project dashboard.
        /// </summary>
        /// <param name="project"></param>
        public ProjectControlPanel(Project project) : this ()
        {
            Project = project;
        }

        /// <summary>
        /// Reloads the interfaces of all items associated with the project.
        /// </summary>
        public void ReloadItems()
        {
            pnItemPanel.Controls.Clear();

            var i = -1;
            foreach (IItem item in Project.ListOfItems.Values)
            {
                i++;
                var pnItem = new Panel
                {
                    BackColor = System.Drawing.Color.Black,
                    ForeColor = System.Drawing.Color.White,
                    Parent = pnItemPanel,
                    Height = 50,
                    Left = 0,
                    Top = 50 * i
                };
                pnItem.Width = pnItem.Parent.Width;

                var lbItem = new Label
                {
                    AutoSize = true,
                    Text = item.Name,
                    Left = 2,
                    Parent = pnItem
                };
                lbItem.Top = lbItem.Parent.Height / 2 - lbItem.Height / 2;

                var btDelete = new Button
                {
                    AutoSize = true,
                    BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                    FlatStyle = FlatStyle.Popup,
                    Text = "Delete",
                    Cursor = Cursors.Hand,
                    Parent = pnItem
                };
                btDelete.Left = btDelete.Parent.ClientSize.Width - btDelete.Width - 5;
                btDelete.Top = btDelete.Parent.Height / 2 - btDelete.Height / 2;
                btDelete.Click += (s, e) =>
                {
                    if (MessageBox.Show("Are you sure you want to delete the item? This action cannot be undone.",
                        "Delete item.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Project.ListOfItems.Remove(item.Name);
                        ProjectChanged = true;
                        ReloadItems();
                        return;
                    }
                };

                var btEdit = new Button
                {
                    AutoSize = true,
                    BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                    FlatStyle = FlatStyle.Popup,
                    Text = "Edit",
                    Cursor = Cursors.Hand,
                    Parent = pnItem
                };
                btEdit.Left = btDelete.Left - btEdit.Width - 5;
                btEdit.Top = btDelete.Top;
                btEdit.Click += (s, e) =>
                {

                    if (Project.Type == Project.Types.AIS)
                    {
                        var dialog = new AISItemCreationDialog((AISItem)item);
                        dialog.CanChangeName = false;


                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            Project.ListOfItems[dialog.Item.Name] = dialog.Item;
                            ProjectChanged = true;
                            ReloadItems();
                            return;
                        }
                    }
                };

                var btExport = new Button
                {
                    AutoSize = true,
                    BackColor = System.Drawing.Color.FromArgb(64, 64, 64),
                    FlatStyle = FlatStyle.Popup,
                    Text = "Export",
                    Cursor = Cursors.Hand,
                    Parent = pnItem
                };
                btExport.Left = btEdit.Left - btExport.Width - 5;
                btExport.Top = btEdit.Top;
                btExport.Click += (s, e) =>
                {
                    using (var fbd = new FolderBrowserDialog())
                    {
                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            item.Export(fbd.SelectedPath);
                        }
                    }
                };
            }
        }
    }
}
