using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MCLauncher.controls
{
    public partial class CreditsScreen : UserControl
    {
        public static CreditsScreen Instance;

        public CreditsScreen()
        {
            InitializeComponent();
            Instance = this;

            //Seasonal background
            if (File.Exists($"{Globals.dataPath}\\data\\seasonalStone.png"))
            {
                this.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\data\\seasonalStone.png");
            }

            //Center the panel
            pnlCenter.Location = new Point(
                this.ClientSize.Width / 2 - pnlCenter.Size.Width / 2,
                this.ClientSize.Height / 2 - pnlCenter.Size.Height / 2);
            pnlCenter.Anchor = AnchorStyles.None;
        }

        private void lblDejvossIpsa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://dejvoss.cz") { UseShellExecute = true });
        }
    }
}
