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
                if (Settings.sj.discordRPC)
                {
                    client = new DiscordRpcClient(APIKeys.DiscordClientID);
                    client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
                    client.OnReady += (sender, e) =>
                    {
                        Logger.Discord("[Discord]", $"Received Ready from user {e.User.Username}");
                    };

                    client.OnPresenceUpdate += (sender, e) =>
                    {
                        Logger.Discord("[Discord]", $"Received Update! {e.Presence}");
                    };
                    client.Initialize();
                }
            }
            catch
            {
                Logger.Discord("[Discord]", "Could not initialize DiscordClient! Connect to the internet!");
            }
        }
        public static void ChangeMessage(string message)
        {
            if (client != null && Settings.sj.discordRPC)
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
