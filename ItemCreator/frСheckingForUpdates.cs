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
            this.SuspendLayout();
            // 
            // frСheckingForUpdates
            // 
            this.BackgroundImage = global::ItemCreator.Properties.Resources.Loading;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(379, 222);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frСheckingForUpdates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frChekingForUpdates_Load);
            this.ResumeLayout(false);

        }
    }
}
