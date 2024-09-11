using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace MCLauncher.launchers
{
    internal class LaunchJava
    {
        //launches java edition
        //TODO
        public static (string, string, string) launchGame(String instanceName)
        {
            //create directories
            Directory.CreateDirectory($"{Globals.dataPath}\\versions\\java\\");

            return ("", "", "");
        }







        //Splits IP and port, if no port specified -> :25565
        //also translates domains into IPs
        public static String[] splitIpPort(String input)
        {
            String[] ipPort = new String[2];

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
                IPAddress[] IPs = Dns.GetHostAddresses(split[0]);
                ipPort[0] = IPs[0].ToString();
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

            return ipPort;
        }
    }
}
