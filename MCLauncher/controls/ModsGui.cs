using MCLauncher.forms;
using MCLauncher.json.api;
using MCLauncher.json.launcher;
using MCLauncher.launchers.fabric;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MCLauncher.controls
{
    public partial class ModsGui : UserControl
    {
        public String instanceName = "";

        public String version;

        public ModJson mj;
        public List<ModJsonEntry> entries;
        public ModloadersJson mm;

        public ModsGui(String instName)
        {
            InitializeComponent();
            instanceName = instName;

            //load lang
            btnMoveUp.Text = Strings.sj.btnMoveUp;
            btnMoveDown.Text = Strings.sj.btnMoveDown;
            btnRemove.Text = Strings.sj.btnRemove;
            btnForge.Text = Strings.sj.btnForge;
            btnFabric.Text = Strings.sj.btnFabric;
            btnMLoader.Text = Strings.sj.btnMLoader;
            btnRepos.Text = Strings.sj.btnRepos;
            btnAddToJar.Text = Strings.sj.btnAddToJar;
            btnReplaceJar.Text = Strings.sj.btnReplaceJar;
            btnOpenDotMc.Text = Strings.sj.btnOpenDotMc;

            btnMoveUp.Enabled = false;
            btnMoveDown.Enabled = false;
            btnRemove.Enabled = false;

            btnForge.Enabled = false;
            btnFabric.Enabled = false;
            btnMLoader.Enabled = false;

            reloadModList();
        }

        public void reloadModList()
        {
            modView.Items.Clear();

            string json = File.ReadAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\mods.json");
            mj = JsonConvert.DeserializeObject<ModJson>(json);

            foreach (ModJsonEntry mje in mj.items)
            {
                ListViewItem item = new ListViewItem(new[] { mje.file, mje.type, mje.json });
                item.Checked = !mje.disabled;
                modView.Items.Add(item);
            }

            entries = new List<ModJsonEntry>();
            foreach (ModJsonEntry ent in mj.items)
            {
                entries.Add(ent);
            }

            modView.Columns[0].Width = -1;
            modView.Columns[1].Width = -1;
            modView.Columns[2].Width = -2;
        }

        public void loadModloaderButtons(String version)
        {
            this.version = version;

            if (FabricWorker.isAvailable(version))
                btnFabric.Enabled = true;
            else
                btnFabric.Enabled = false;

            try
            {
                //download manifest
                WebClient client = new WebClient();
                String loaderManifest = client.DownloadString($"https://codex-ipsa.dejvoss.cz/launcher/modloaders/{version}.json");
                client.Dispose();

                Logger.Info("[ModsGui/loadModloaderButtons]", $"got manifest for {version}");

                //deserialize
                mm = JsonConvert.DeserializeObject<ModloadersJson>(loaderManifest);

                //enable/disable buttons
                if (mm.risugami != null)
                    btnMLoader.Enabled = true;
                else
                    btnMLoader.Enabled = false;

                if (mm.forge != null)
                    btnForge.Enabled = true;
                else
                    btnForge.Enabled = false;

                if (mm.neoforge != null)
                    btnNeoforge.Enabled = true;
                else
                    btnNeoforge.Enabled = false;

                if (mm.quilt != null)
                    btnQuilt.Enabled = true;
                else
                    btnQuilt.Enabled = false;

                if (mm.liteloader != null)
                    btnLiteloader.Enabled = true;
                else
                    btnLiteloader.Enabled = false;
            }
            catch (WebException ex)
            {
                //if manifest no existo
                Logger.Info("[ModsGui/loadModloaderButtons]", $"no modloader manifest at {version}");

                btnMLoader.Enabled = false;
                btnForge.Enabled = false;
                btnNeoforge.Enabled = false;
                btnQuilt.Enabled = false;
                btnLiteloader.Enabled = false;
            }
        }

        public void saveModList()
        {
            mj = new ModJson();
            mj.items = entries.ToArray();

            String toSave = JsonConvert.SerializeObject(mj);
            File.WriteAllText($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\mods.json", toSave);
        }

        public void selectInModList(int index)
        {
            modView.Items[index].Selected = true;
        }

        public void moveUpModList(int selectedIndex)
        {
            ModJsonEntry item = mj.items[selectedIndex];

            bool worked = false;
            if (selectedIndex > 0)
            {
                entries.RemoveAt(selectedIndex);
                entries.Insert(selectedIndex - 1, item);

                worked = true;
            }

            saveModList();
            reloadModList();

            if (worked)
                selectInModList(selectedIndex - 1);
            else
                selectInModList(selectedIndex);
        }

        public void moveDownModList(int selectedIndex)
        {
            ModJsonEntry item = mj.items[selectedIndex];

            bool worked = false;
            if (selectedIndex + 1 < entries.Count)
            {
                entries.RemoveAt(selectedIndex);
                entries.Insert(selectedIndex + 1, item);

                worked = true;
            }

            saveModList();
            reloadModList();

            if (worked)
                selectInModList(selectedIndex + 1);
            else
                selectInModList(selectedIndex);
        }

        public void removeModList(int selectedIndex)
        {
            entries.RemoveAt(selectedIndex);

            saveModList();
            reloadModList();

            if (modView.Items.Count > 0)
                selectInModList(0);
        }

        public void removeModList(String fileName)
        {
            int i = 0;
            foreach (ModJsonEntry ent in mj.items)
            {
                if (ent.file == fileName)
                {
                    break;
                }
                i++;
            }
            entries.RemoveAt(i);

            saveModList();
            reloadModList();

            if (modView.Items.Count > 0)
                selectInModList(0);
        }

        public void addModList(String name, String version, String fileName, String type, String json)
        {
            ModJsonEntry newEntry = new ModJsonEntry();
            newEntry.name = name;
            newEntry.version = version;
            newEntry.file = fileName;
            newEntry.type = type;
            newEntry.json = json;
            newEntry.disabled = false;
            entries.Add(newEntry);

            saveModList();
            reloadModList();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
                moveUpModList(modView.SelectedItems[0].Index);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
                moveDownModList(modView.SelectedItems[0].Index);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                File.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{modView.SelectedItems[0].Text}");
                removeModList(modView.SelectedItems[0].Index);
            }
        }

        private void btnForge_Click(object sender, EventArgs e)
        {
            ModLoaders ml = new ModLoaders(version, "forge", instanceName, mm, this);
            ml.ShowDialog();
        }

        private void btnFabric_Click(object sender, EventArgs e)
        {
            ModLoaders ml = new ModLoaders(version, "fabric", instanceName, mm, this);
            ml.ShowDialog();
        }

        private void btnMLoader_Click(object sender, EventArgs e)
        {
            ModLoaders ml = new ModLoaders(version, "risugami", instanceName, mm, this);
            ml.ShowDialog();
        }

        private void btnNeoforge_Click(object sender, EventArgs e)
        {
            ModLoaders ml = new ModLoaders(version, "neoforge", instanceName, mm, this);
            ml.ShowDialog();
        }

        private void btnQuilt_Click(object sender, EventArgs e)
        {
            ModLoaders ml = new ModLoaders(version, "quilt", instanceName, mm, this);
            ml.ShowDialog();
        }

        private void btnLiteloader_Click(object sender, EventArgs e)
        {
            ModLoaders ml = new ModLoaders(version, "liteloader", instanceName, mm, this);
            ml.ShowDialog();
        }

        private void btnRepos_Click(object sender, EventArgs e)
        {
            PallasRepo pr = new PallasRepo(this);
            pr.ShowDialog();
        }

        private void btnAddToJar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.zip, *.jar)|*.zip;*.jar";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string safeFileName = openFileDialog.SafeFileName;
                    string fileType = safeFileName.Substring(safeFileName.LastIndexOf('.') + 1);
                    safeFileName = safeFileName.Replace("." + fileType, "");

                    //checks if exists and adds a _<int> at the end
                    if (File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{safeFileName}.{fileType}"))
                    {
                        int iter = 1;
                        do
                        {
                            if (safeFileName.Contains("_"))
                                safeFileName = safeFileName.Substring(0, safeFileName.LastIndexOf("_")) + "_" + iter;
                            else
                                safeFileName = safeFileName + "_" + iter;
                            iter++;

                            Console.WriteLine($"{safeFileName}.{fileType}   {iter}");
                        }
                        while (File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{safeFileName}.{fileType}"));
                    }

                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{safeFileName}.{fileType}");
                    addModList("", "", $"{safeFileName}.{fileType}", "jarmod", "");
                }
            }
        }

        private void btnReplaceJar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.zip, *.jar)|*.zip;*.jar";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string safeFileName = openFileDialog.SafeFileName;
                    string fileType = safeFileName.Substring(safeFileName.LastIndexOf('.') + 1);
                    safeFileName = safeFileName.Replace("." + fileType, "");

                    //checks if exists and adds a _<int> at the end
                    if (File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{safeFileName}.{fileType}"))
                    {
                        int iter = 1;
                        do
                        {
                            if (safeFileName.Contains("_"))
                                safeFileName = safeFileName.Substring(0, safeFileName.LastIndexOf("_")) + "_" + iter;
                            else
                                safeFileName = safeFileName + "_" + iter;
                            iter++;

                            Console.WriteLine($"{safeFileName}.{fileType}   {iter}");
                        }
                        while (File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{safeFileName}.{fileType}"));
                    }

                    File.Copy(openFileDialog.FileName, $"{Globals.dataPath}\\instance\\{instanceName}\\jarmods\\{safeFileName}.{fileType}");
                    addModList("", "", $"{safeFileName}.{fileType}", "cusjar", "");
                }
            }
        }

        private void btnOpenDotMc_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\.minecraft\\");
            Process.Start($"{Globals.dataPath}\\instance\\{instanceName}\\.minecraft\\");
        }

        private void modView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modView.SelectedItems.Count > 0)
            {
                btnMoveUp.Enabled = true;
                btnMoveDown.Enabled = true;
                btnRemove.Enabled = true;
            }
            else
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void modView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            for (int i = 0; i < modView.Items.Count; i++)
            {
                mj.items[i].disabled = !modView.Items[i].Checked;

                saveModList();
            }
        }
    }
}
