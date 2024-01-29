using MCLauncher.classes.jsons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MCLauncher.forms
{
    public partial class NewInstance : Form
    {
        public NewInstance()
        {
            InitializeComponent();

            //TODO load lang

            //fill in stuff
            populateLists();
        }

        private void populateLists()
        {
            //vanilla list
            if (tabControl1.SelectedTab.Text == "Vanilla")
            {
                //clear list
                vanillaList.Items.Clear();
                vanillaList.Columns.Clear();

                //add columns
                vanillaList.Columns.Add(Strings.rowName);
                vanillaList.Columns.Add(Strings.rowType);
                vanillaList.Columns.Add(Strings.rowReleased);

                //add items
                string manifest = Globals.client.DownloadString(Globals.javaManifest);
                List<JavaManifest> jm = JsonConvert.DeserializeObject<List<JavaManifest>>(manifest);
                foreach(JavaManifest ver in jm)
                {
                    string[] row = { ver.type, ver.released.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss") };

                    if (vanillaPreclassic.Checked && row[0] == "pre-classic")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                    if (vanillaClassic.Checked && row[0] == "classic")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                    if (vanillaIndev.Checked && row[0] == "indev")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                    if (vanillaInfdev.Checked && row[0] == "infdev")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                    if (vanillaAlpha.Checked && row[0] == "alpha")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                    if (vanillaBeta.Checked && row[0] == "beta")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                    if (vanillaRelease.Checked && row[0] == "release")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                    if (vanillaSnapshot.Checked && row[0] == "snapshot")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);

                    if (vanillaExperimental.Checked && row[0] == "experimental")
                        vanillaList.Items.Add(ver.id + ver.alt).SubItems.AddRange(row);
                }

                //set width after adding items
                vanillaList.Columns[0].Width = -1;
                vanillaList.Columns[1].Width = -1;
                vanillaList.Columns[2].Width = -2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO (hell)
            if(tabControl1.SelectedTab.Text == "Vanilla")
            {

            }
        }

        private void vanillaBoxes_CheckedChanged(object sender, EventArgs e)
        {
            populateLists();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateLists();
        }

        private void vanillaList_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = vanillaList.Columns[e.ColumnIndex].Width;
        }
    }
}
