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
        public Label Message;
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
            catch
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
            this.Message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.BackColor = System.Drawing.Color.Green;
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Message.ForeColor = System.Drawing.Color.Lime;
            this.Message.Location = new System.Drawing.Point(237, 150);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(142, 15);
            this.Message.TabIndex = 1;
            this.Message.Text = "Checking for updates";
            // 
            // frСheckingForUpdates
            // 
            this.BackgroundImage = global::ItemCreator.Properties.Resources.Loading;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(379, 222);
            this.Controls.Add(this.Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frСheckingForUpdates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frChekingForUpdates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
