using System.IO;
using System.Collections.Generic;


namespace EawSteamLauncher
{
    internal class ModHandler
    {
        public class Mod
        {
            public bool IsWorkshopMod { get; set;}

            public string ModName { get; set; }

            public string ModPath { get; set; }

            public string ModWorkshopID { get; set; }
        }

        public static Mod[] CurrentMods { get; private set; }

        public static void UpdateMods()
        
        {
            CurrentMods = GetMods();
        }

        public static Mod[] GetMods()
        {
            var modList = new List<Mod>();

            if (Directory.Exists(RegistryHandler.GetValue(@"Software\Frechdax\EAW Steam Launcher", "SteamPath") + @"\common\Star Wars Empire at War\corruption\Mods"))
            {
                var directories = Directory.GetDirectories(RegistryHandler.GetValue(@"Software\Frechdax\EAW Steam Launcher", "SteamPath") + @"\common\Star Wars Empire at War\corruption\Mods");

                foreach(string x in directories)
                {
                    modList.Add(new Mod() {ModPath = x ,ModName = Path.GetFileName(x), IsWorkshopMod = false });
                }
            }

            if (Directory.Exists(RegistryHandler.GetValue(@"Software\Frechdax\EAW Steam Launcher", "SteamPath") + @"\workshop\content\32470"))
            {
                var directories = Directory.GetDirectories(RegistryHandler.GetValue(@"Software\Frechdax\EAW Steam Launcher", "SteamPath") + @"\workshop\content\32470");

                foreach (string x in directories)
                {
                    modList.Add(new Mod() { ModPath = x, ModName = Path.GetFileName(x), ModWorkshopID = Path.GetFileName(x), IsWorkshopMod = true });
                }
            }

            return modList.ToArray();
        }
    }
}