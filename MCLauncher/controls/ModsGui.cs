using MCLauncher.classes.jsons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCLauncher.controls
{
    public partial class ModsGui : UserControl
    {
        String instanceName = "";

        public ModsGui(String instName)
        {
            InitializeComponent();
            instanceName = instName;
            loadModList();
        }

        public void loadModList()
        {
            modView.Items.Clear();

            string json = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\mods.json");
            ModJson mj = JsonConvert.DeserializeObject<ModJson>(json);

            foreach (ModJsonEntry mje in mj.items)
            {
                ListViewItem item = new ListViewItem(new[] { mje.file, mje.type, mje.json });
                item.Checked = !mje.disabled;
                modView.Items.Add(item);
            }

            modView.Columns[0].Width = -1;
            modView.Columns[1].Width = -1;
            modView.Columns[2].Width = -2;
        }
    }
}
