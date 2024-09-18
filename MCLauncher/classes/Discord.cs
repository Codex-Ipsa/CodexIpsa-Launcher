using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Diagnostics;

namespace MCLauncher.classes
{
    internal class Discord
    {
        public static DiscordRpcClient client;

        public static async void Init()
        {
            Process[] pname = Process.GetProcessesByName("discord");
            if (pname.Length == 0)
            {
                Logger.Discord("[Discord]", "Could not locate Discord! Skipping...");
                return;
            }

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
