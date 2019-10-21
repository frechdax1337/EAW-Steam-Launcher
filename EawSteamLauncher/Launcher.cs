using System.Diagnostics;
using System.Windows;

namespace EawSteamLauncher
{
    class Launcher
    {
        /// <summary>
        /// Prepares the launcher and checks if stuff in registry exists and if not creates it.
        /// </summary>
        public static void Initialize()
        {
            RegistryHandler.CreateKey(@"Software\Frechdax\EAW Steam Launcher");

            if (SteamHandler.IsSteamInstalled())
            {
                if (SteamHandler.IsGameInstalled())
                {
                    if (RegistryHandler.GetValue(@"Software\Frechdax\EAW Steam Launcher", "SteamPath") != null)
                    {
                        if (SteamHandler.IsSteamAppsPathValid(RegistryHandler.GetValue(@"Software\Frechdax\EAW Steam Launcher", "SteamPath")))
                        {
                            return;
                        }
                        else
                        {
                            PathHandler.AutoSelectPath();
                            return;
                        }
                    }
                    else
                    {
                        PathHandler.AutoSelectPath();
                        return;
                    }
                }

                MessageBox.Show("Star Wars Empire at War: Gold Pack is not installed on this computer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MessageBox.Show("Steam is not installed on this computer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void Launch(ModHandler.Mod modToLaunchWith)
        {
            if (!SteamHandler.IsSteamRunning())
            {
                MessageBox.Show("Please start Steam in order to the game.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (SteamHandler.IsGameRunning())
            {
                MessageBox.Show("There is a running instance of the game already.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Process gameProcess = new Process();

            gameProcess.StartInfo.FileName = SteamHandler.SteamAppsPath + @"\common\Star Wars Empire at War\GameData\StarWarsG.exe";
            
            if (modToLaunchWith.IsWorkshopMod)
            {
                gameProcess.StartInfo.Arguments = "LANGUAGE=ENGLISH " + $"STEAMMOD={modToLaunchWith.ModName}";
            }
            else
            {
                gameProcess.StartInfo.Arguments = "LANGUAGE=ENGLISH " + $"MODPATH=Mods/{modToLaunchWith.ModName}";
            }

            gameProcess.Start();

            gameProcess.Dispose();
        }
    }
}
