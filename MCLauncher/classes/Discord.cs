using DiscordRPC.Logging;
using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLauncher.classes
{
    internal class Discord
    {
        public static DiscordRpcClient client;
        public static bool work = true;

        public static async void Init()
        {
            try
            {
                client = new DiscordRpcClient(Globals.discordClient);
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
            catch
            {
                Logger.Error("[Discord]", "Could not initialize DiscordClient! Connect to the internet!");
            }
        }
        public static async Task ChangeMessage(string message)
        {
            if(client != null)
            {
                work = false;
                
                //todo
                //await Task.Delay(60000);
                UpdateTimer(message, 0);
            }
        }

        public static async Task UpdateTimer(string message, int minutes)
        {
            if(client != null)
            {
                minutes++;
                client.SetPresence(new RichPresence()
                {
                    Details = message,
                    State = $"for {minutes} minutes",
                    Assets = new Assets()
                    {
                        LargeImageKey = "discord",
                        LargeImageText = "Codex-Ipsa Launcher"
                    }
                });

                await Task.Delay(60000);
                if(work)
                    UpdateTimer(message, minutes);
            }
        }
    }
}
