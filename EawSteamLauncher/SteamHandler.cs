using System.IO;
using System.Text.RegularExpressions;

namespace EawSteamLauncher
{
    internal class SteamHandler
    {
        public static string SteamAppsPath
        {
            get
            {
                if (IsSteamInstalled())
                {
                    string[] lines = File.ReadAllLines(SteamPath + @"\config\config.vdf");
                    string regexMatch = "BaseInstallFolder_1";

                    foreach (string x in lines)
                    {
                        if (Regex.IsMatch(x, regexMatch))
                        {
                            int index = x.IndexOf("\"", 25);

                            return x.Substring(index).Replace("\"", "").Replace("\\\\", "\\") + "\\steamapps";
                        }
                    }
                }

                return null;
            }
        }

        public static string SteamExePath
        {
            get
            {
                if (IsSteamInstalled())
                    return RegistryHandler.GetValue(@"Software\Valve\Steam", "SteamExe");

                return null;
            }
        }

        public static string SteamPath
        {
            get
            {
                if (IsSteamInstalled())
                    return RegistryHandler.GetValue(@"Software\Valve\Steam", "SteamPath");

                return null;
            }
        }

        public static bool IsGameInstalled()
        {
            return RegistryHandler.GetValue(@"Software\Valve\Steam\Apps\32470", "Installed") == "1";
        }

        public static bool IsGameRunning()
        {
            return RegistryHandler.GetValue(@"Software\Valve\Steam\Apps\32470", "Running") == "1";
        }

        public static bool IsSteamAppsPathValid(string path)
        {
            return Directory.Exists(path + @"\common\Star Wars Empire at War") != false;
        }

        public static bool IsSteamInstalled()
        {
            return RegistryHandler.GetValue(@"Software\Valve\Steam", "SteamExe") != null;
        }

        public static bool IsSteamRunning()
        {
            try
            {
                return RegistryHandler.GetValue(@"Software\Valve\Steam\ActiveProcess", "pid") != "0";
            }
            catch (System.ArgumentException)
            {
                return false;
            }
        }
    }
}