using MCLauncher.json.launcher;
using System;

namespace MCLauncher.launchers
{
    internal class ModWorker
    {
        //BEFORE the download of the client, this compiles mods and returns the path of the patched jar (or custom jar)
        //returns null if no mods used, launcher should just use default jar path

        //TODO 
        public static String getJarPath(InstanceJson ij, ModJson mj)
        {
            if (mj.items.Length == 0)
                return null;

            for (int i = 0; i < mj.items.Length; i++)
            {
                ModJsonEntry entry = mj.items[i];
                Console.WriteLine($"{entry.file}: {entry.json}");
            }

            return null; //temp
        }
    }
}
