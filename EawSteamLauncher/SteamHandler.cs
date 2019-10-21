using System.Collections.Generic;
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

        public static string[] InstalledLanguages
        {
            get
            {
                var languageList = new List<string>();

                if (Directory.Exists(SteamAppsPath + @"\common\Star Wars Empire at War\corruption\Data\Text"))
                {
                    string[] files = Directory.GetFiles(SteamAppsPath + @"\common\Star Wars Empire at War\corruption\Data\Text");

                    foreach(string file in files)
                    {
                        if(file.Contains("mastertextfile"))
                        {
                            if(file.Contains("chinese"))
                            {
                                languageList.Add("Chinese");
                            }
                            else if (file.Contains("english"))
                            {
                                languageList.Add("English");
                            }
                            else if (file.Contains("french"))
                            {
                                languageList.Add("French");
                            }
                            else if (file.Contains("german"))
                            {
                                languageList.Add("German");
                            }
                            else if (file.Contains("italian"))
                            {
                                languageList.Add("Italian");
                            }
                            else if (file.Contains("russian"))
                            {
                                languageList.Add("Russian");
                            }
                            else if (file.Contains("spanish"))
                            {
                                languageList.Add("Spanish");
                            }
                        }
                    }

                    return languageList.ToArray();
                }

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