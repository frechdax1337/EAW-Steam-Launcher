using System.Windows;
using System.Windows.Forms;

namespace EawSteamLauncher
{
    internal class PathHandler
    {
        public static string GetPathByDialog(string dialogDescription)
        {
            var dialog = new FolderBrowserDialog()
            {
                Description = dialogDescription,
                ShowNewFolderButton = false
            };

            try
            {
                if (dialog.ShowDialog() != DialogResult.Cancel)
                {
                    return dialog.SelectedPath;
                }

                return null;
            }
            finally
            {
                if (dialog != null) dialog.Dispose();
            }
        }

        public static void AutoSelectPath()
        {
            if (SteamHandler.IsSteamAppsPathValid(SteamHandler.SteamAppsPath))
            {
                RegistryHandler.SetValue(@"Software\Frechdax\EAW Steam Launcher", "SteamPath", SteamHandler.SteamAppsPath);

                return;
            }

            System.Windows.MessageBox.Show("Could not find steamapps path, please select it manually.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}