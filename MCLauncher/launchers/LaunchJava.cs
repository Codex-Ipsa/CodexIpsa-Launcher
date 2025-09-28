using MCLauncher.json.launcher;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MCLauncher.launchers
{
    internal class LaunchJava
    {
        public static string runID = "";

        //WIP

        //launches java edition
        public static void launchGame(String instanceName)
        {
            //create directories
            Directory.CreateDirectory($"{Globals.dataPath}\\versions\\java\\");

            //check if instance is already running, ask user if they want to launch
            if (Globals.running.ContainsValue(instanceName))
            {
                DialogResult result = MessageBox.Show(Strings.sj.wrnRunning.Replace("{profileName}", instanceName), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            runID = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
            Globals.running.Add(runID, instanceName);


            //TODO get all required JSONs and create objects

            //TODO ask for multiplayer if wanted

            //TODO authenticate

            //TODO start building command itself

            //TODO launch game
        }







        //Splits IP and port, if no port specified -> :25565
        //also translates domains into IPs
        public static String[] splitIpPort(String input)
        {
            String[] ipPort = new String[3];

            //bool hasPort = input.Contains(":");
            String[] split = input.Split(':');

            string validIPs = "^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
            string validHosts = "^(([a-zA-Z]|[a-zA-Z][a-zA-Z0-9\\-]*[a-zA-Z0-9])\\.)*([A-Za-z]|[A-Za-z][A-Za-z0-9\\-]*[A-Za-z0-9])$";

            //check if valid IP
            if (Regex.IsMatch(split[0], validIPs))
            {
                ipPort[0] = split[0];
            }
            //check if valid host -> translate to IP
            else if (Regex.IsMatch(split[0], validHosts))
            {
                try
                {
                    IPAddress[] IPs = Dns.GetHostAddresses(split[0]);
                    ipPort[0] = IPs[0].ToString();
                }
                catch (Exception e) //if invalid ip just return null 
                {
                    Logger.Error("splitIpPort", $"invalid IP {input}");
                    //TODO: error popup here
                    return null;
                }
            }
            //if all fails, just skip
            else
            {
                return null;
            }

            //set port
            if (split.Length == 2)
            {
                ipPort[1] = split[1];
            }
            else
            {
                ipPort[1] = "25565";
            }

            ipPort[2] = split[0]; //and save the original domain/ip for modern (1.6+) versions
            return ipPort;
        }
    }
}
