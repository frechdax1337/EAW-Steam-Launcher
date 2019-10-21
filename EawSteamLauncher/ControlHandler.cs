using System.Windows;

namespace EawSteamLauncher
{
    class ControlHandler
    {
        readonly static LauncherWindow launcherWindow = (LauncherWindow)Application.Current.MainWindow;

        public static void UpdateListBoxMod()
        {
            ModHandler.Mod[] mods = ModHandler.CurrentMods;

            launcherWindow.ListMod.Items.Clear();

            foreach (ModHandler.Mod mod in mods)
            {
                launcherWindow.ListMod.Items.Add(mod.ModName);
            }
        }
    }
}
