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
        private Version version = new Version(new Properties.Settings().Version);

        private readonly Updater.Updater updater;

        public frСheckingForUpdates(string[] args)
        {
            this.InitializeComponent();
            if (args.Length == 2)
            {
                Version version = null;
                string fileLink = string.Empty;
                try
                {
                    version = new Version(args[0]);
                    fileLink = args[1];
                }
                catch (Exception)
                {
                    Application.Exit();
                }
                this.updater = new Updater.Updater(version, fileLink);
            }
        }

        private async Task CheckForUpdates()
        {
            try
            {
                await this.updater.CheckForUpdates();
            }
            finally
            {
                Application.Exit();
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
            this.ClientSize = new System.Drawing.Size(426, 331);
            this.Name = "frСheckingForUpdates";
            this.Load += new System.EventHandler(this.frChekingForUpdates_Load);
            this.ResumeLayout(false);

        }
    }
}
