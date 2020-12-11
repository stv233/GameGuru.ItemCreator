using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCreator
{
    class frСheckingForUpdates : Form
    {
        private Label label2;
        private readonly Updater.Updater updater;

        public frСheckingForUpdates()
        {
            this.Icon = Properties.Resources.ico;
            this.InitializeComponent();

            Version version = null;
            string fileLink = string.Empty;
            try
            {
                version = new Version(new Properties.Settings().Version);
                fileLink = "https://github.com/stv233/ItemCreator/blob/master/ItemCreator/Version.txt?raw=true";
            }
            catch (Exception e)
            {
                Application.Exit();
            }
            this.updater = new Updater.Updater(version, fileLink);

        }

        private async Task CheckForUpdates()
        {
            try
            {
                await this.updater.CheckForUpdates();
            }
            finally
            {
                if (updater.Update)
                {
                    Application.Exit();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private async void frChekingForUpdates_Load(object sender, EventArgs e)
        {
            await this.CheckForUpdates();
        }

        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(237, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Checking for updates";
            // 
            // frСheckingForUpdates
            // 
            this.BackgroundImage = global::ItemCreator.Properties.Resources.Loading;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(379, 222);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frСheckingForUpdates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frChekingForUpdates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
