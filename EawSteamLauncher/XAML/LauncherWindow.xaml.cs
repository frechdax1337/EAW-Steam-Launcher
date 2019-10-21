using System.Diagnostics;
using System.Windows;

namespace EawSteamLauncher
{
    /// <summary>
    /// Interaction logic for LauncherWindow.xaml
    /// </summary>
    public partial class LauncherWindow : Window
    {
        public LauncherWindow()
        {
            InitializeComponent();
        }

        private void MainLauncherWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Launcher.Initialize();
            ModHandler.UpdateMods();
            ControlHandler.UpdateListBoxMod();
        }
    }
}