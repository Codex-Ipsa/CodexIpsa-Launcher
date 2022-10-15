using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MCLauncher
{
    public partial class InstanceManager : Form
    {
        public static InstanceManager This;
        public static List<string> editionNames = new List<string>() { "Java Edition", "MinecraftEdu" }; //Xbox 360 Edition, Playstation 3 Edition, MinecraftEdu

        public static List<string> varNames;
        public static List<string> varValues;

        public static string name;
        public static string edition;
        public static string version;
        public static string type;
        public static string url;

        public static string directory;
        public static string resolutionX;
        public static string resolutionY;
        public static string ramMin;
        public static string ramMax;

        public static string customJava;
        public static bool useCustomJava = false;
        public static string jvmArgs;
        public static bool useJvmArgs = false;
        public static string launchMethod;
        public static bool useLaunchMethod = false;
        public static bool offlineMode;

        public static string tempName;
        public static int tempInt = 1;

        /// <summary>
        /// OLD SHIT BELOW!!!
        /// </summary>

        /*public static string selectedInstance = "Default";
        public static string createName;
        public static string tempName;
        public static int instanceInt = 1;
        public static int cfgVer = 1;
        public static string mode;

        public static string cfgInstName;
        public static string cfgGameVer;
        public static string cfgTypeVer;
        public static string cfgLinkVer;
        public static string instGameDir = "";
        public static string instResWidth = "854";
        public static string instResHeight = "480";
        public static int instRamMin = 1024;
        public static int instRamMax = 1024;
        public static string instCustJava = "";
        public static bool useCustJava = false;
        public static string instCustJvm = "";
        public static bool useCustJvm = false;
        public static string instCustMethod = "";
        public static bool useCustMethod = false;
        public static string instCustJar = "";
        public static bool useCustJar = false;
        public static bool useOfflineMode = false;*/

        public InstanceManager(string instanceName, string mode)
        {
            This = this;
            InitializeComponent();

            tempName = instanceName;
            Start(instanceName, mode);
        }

        public static void Start(string instanceName, string mode)
        {
            if (mode == "initial")
            {
                loadDefault("Default", "new");
            }
            else if (mode == "new")
            {
                Logger.logError("[InstanceManager]", $"{tempName}_{tempInt}");
                //this throws a stackoverflow for some reason
                if (File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg"))
                {
                    Start($"{tempName}_{tempInt}", "new");
                    tempInt++;
                }
                else
                {
                    loadDefault(instanceName, "new");
                    tempInt = 1;
                    tempName = "";
                }
            }
            else if (mode == "edit")
            {
                loadDefault(instanceName, "edit");
            }

            setData();
        }



        public static void loadDefault(string instanceName, string mode)
        {
            //this sets default stuff
            if (mode == "new")
            {
                Logger.logError("[InstanceManager]", instanceName);
                name = instanceName;
                This.nameBox.Text = instanceName;

                edition = editionNames[0];
                version = "";
                type = "";
                url = "";
                directory = "";
                resolutionX = "";
                resolutionY = "";
                ramMin = "";
                ramMax = "";
                customJava = "";
                useCustomJava = false;
                jvmArgs = "";
                useJvmArgs = false;
                launchMethod = "";
                useLaunchMethod = false;
                offlineMode = false;
            }
            else if(mode == "edit")
            {
                name = instanceName;
                This.nameBox.Text = instanceName;

                edition = "";
                version = "";
                type = "";
                url = "";
                directory = "";
                resolutionX = "";
                resolutionY = "";
                ramMin = "";
                ramMax = "";
                customJava = "";
                useCustomJava = false;
                jvmArgs = "";
                useJvmArgs = false;
                launchMethod = "";
                useLaunchMethod = false;
                offlineMode = false;
            }
        }

        public static void setData()
        {
            varNames = new List<string>() { "name", "edition", "version", "type", "url", "directory", "resolutionX", "resolutionY", "ramMin", "ramMax", "customJava", "useCustomJava", "jvmArgs", "useJvmArgs", "launchMethod", "useLaunchMethod", "offlineMode" };
            varValues = new List<string>() { $"{name}", $"{edition}", $"{version}", $"{type}", $"{url}", $"{directory}", $"{resolutionX}", $"{resolutionY}", $"{ramMin}", $"{ramMax}", $"{customJava}", $"{useCustomJava}", $"{jvmArgs}", $"{useJvmArgs}", $"{launchMethod}", $"{useLaunchMethod}", $"{offlineMode}" };
        }

        public static void saveInstance(string instanceName)
        {
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}");
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\jarmods");
            Directory.CreateDirectory($"{Globals.dataPath}\\instance\\{instanceName}\\.minecraft");

            if (File.Exists($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg"))
                File.Delete($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg");
            
            using (FileStream fs = File.Create($"{Globals.dataPath}\\instance\\{instanceName}\\instance.cfg"))
            {
                string final = $"[\n{{\n";
                int i = 0;
                foreach(var varname in varNames)
                {
                    final += $"\"{varname}\":\"{varValues[i]}\",\n";
                    i++;
                }
                i = 0;
                final += $"\n}}\n]";
                byte[] config = new UTF8Encoding(true).GetBytes(final);
                fs.Write(config, 0, config.Length);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveInstance(nameBox.Text);
            this.Close();
        }
    }
}
