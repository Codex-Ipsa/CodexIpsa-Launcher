using DiscordRPC.Logging;
using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using MCLauncher.Properties;

namespace MCLauncher.classes
{
    internal class Discord
    {
        public static DiscordRpcClient client;

        public static async void Init()
        {
            try
            {
                if(Properties.Settings.Default.discordRpc)
                {
                    client = new DiscordRpcClient(APIKeys.DiscordClientID);
                    client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
                    client.OnReady += (sender, e) =>
                    {
                        Console.WriteLine("Received Ready from user {0}", e.User.Username);
                    };

                    client.OnPresenceUpdate += (sender, e) =>
                    {
                        Console.WriteLine("Received Update! {0}", e.Presence);
                    };
                    client.Initialize();
                }
            }
            catch
            {
                Logger.Error("[Discord]", "Could not initialize DiscordClient! Connect to the internet!");
            }
        }
        public static void ChangeMessage(string message)
        {
            if (client != null && Properties.Settings.Default.discordRpc)
            {
                client.SetPresence(new RichPresence()
                {
                    Details = message,
                    Assets = new Assets()
                    {
                        LargeImageKey = "discord",
                        LargeImageText = "Codex-Ipsa Launcher"
                    },
                    Timestamps = new Timestamps()
                    {
                        Start = DateTime.UtcNow
                    }

                });
            }
        }
    }
}
