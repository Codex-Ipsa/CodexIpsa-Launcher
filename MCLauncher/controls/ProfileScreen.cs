using MCLauncher.classes;
using MCLauncher.forms;
using MCLauncher.Properties;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MCLauncher.controls
{
    public partial class ProfileScreen : UserControl
    {
        public ProfileScreen()
        {
            InitializeComponent();

            reloadProfileList();

            int found = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Text == Settings.sj.instance)
                {
                    Logger.Info("[ProfileScreen]", "Latest found: " + listView1.Items[i].Text);
                    found = i;
                    break;
                }
            }

            listView1.Items[found].Selected = true;
        }

        public void reloadProfileList()
        {
            listView1.Items.Clear();

            ImageList iList = new ImageList();
            iList.ImageSize = new Size(32, 32);
            iList.ColorDepth = ColorDepth.Depth32Bit;
            listView1.LargeImageList = iList;

            iList.Images.Add(Resources.icon);

            string[] dirs = Directory.GetDirectories($"{Globals.dataPath}\\instance\\", "*");

            int i = 0;
            int images = 1;
            foreach (string dir in dirs)
            {
                var dirN = new DirectoryInfo(dir);
                var dirName = dirN.Name;
                if (File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\instance.json"))
                {
                    int img = 0;
                    if (File.Exists($"{Globals.dataPath}\\instance\\{dirName}\\icon.png"))
                    {
                        iList.Images.Add(Image.FromFile($"{Globals.dataPath}\\instance\\{dirName}\\icon.png"));
                        img = images;
                        images++;
                    }
                    listView1.Items.Add(new ListViewItem { ImageIndex = img, Text = dirName });
                }

                i++;

                if (i == 5)
                    i = 0;
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                JavaLauncher jl = new JavaLauncher();
                jl.Launch(listView1.SelectedItems[0].Text);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (File.Exists($"{Globals.dataPath}\\instance\\{listView1.SelectedItems[0].Text}\\icon.png"))
                {
                    iconPanel.BackgroundImage = Image.FromFile($"{Globals.dataPath}\\instance\\{listView1.SelectedItems[0].Text}\\icon.png");
                }
                else
                {
                    iconPanel.BackgroundImage = Resources.icon;
                }

                label1.Text = "Ready to play\n" + listView1.SelectedItems[0].Text;

                Settings.sj.instance = listView1.SelectedItems[0].Text;
                Settings.Save();

                HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(listView1.SelectedItems[0].Text);
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                JavaLauncher jl = new JavaLauncher();
                jl.Launch(listView1.SelectedItems[0].Text);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Profile pr = new Profile(listView1.SelectedItems[0].Text, "edit");
                pr.ShowDialog();
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            Profile pr = new Profile("New profile", "new");
            pr.ShowDialog();

            reloadProfileList();
            Settings.sj.instance = Profile.profileName;
            Settings.Save();

            HomeScreen.Instance.cmbInstaces.SelectedIndex = HomeScreen.Instance.cmbInstaces.FindString(Profile.profileName);
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".zip archives|*.zip";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (ZipArchive archive = ZipFile.OpenRead(ofd.FileName))
                {
                    bool found = false;
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName == "instance.json")
                        {
                            ImportProfile ip = new ImportProfile(ofd.FileName);
                            ip.ShowDialog();
                            found = true;
                            break;
                        }
                    }

                    if (found == false)
                    {
                        MessageBox.Show("Invalid or corrupt profile zip!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error("[Profile]", $"Invalid or corrupt profile zip!");
                    }
                }
            }
        }
    }
}
