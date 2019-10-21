using Microsoft.Win32;

namespace EawSteamLauncher
{
    internal class RegistryHandler
    {
        public static string GetValue(string keyName, string valueName)
        {
            try
            {
                string value = Registry.CurrentUser.OpenSubKey(keyName).GetValue(valueName).ToString();

                if (value != null)
                    return value;
            }
            catch (System.NullReferenceException)
            {
                return null;
            }

            return null;
        }

        public static void SetValue(string keyName, string valueName, string value)
        {
            if (Registry.CurrentUser.OpenSubKey(keyName) != null)
            {
                Registry.CurrentUser.OpenSubKey(keyName, true).SetValue(valueName, value);
            }
        }

        public static void CreateKey(string keyName)
        {
            Registry.CurrentUser.CreateSubKey(keyName, true);
        }
    }
}