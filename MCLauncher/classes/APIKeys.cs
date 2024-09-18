namespace MCLauncher.classes
{
    public static partial class APIKeys
    {
        //these are not here on purpose, so I don't leak any private key shit
        //create APIKeysLocal.cs and make a constructor like this
        /*public static partial class APIKeys
        {
            static APIKeys()
            {
                DiscordClientID = "KEY GOES HERE";
            }
        }*/

        public static readonly string DiscordClientID = "";
    }
}
