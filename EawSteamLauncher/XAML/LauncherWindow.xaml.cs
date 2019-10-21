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

            Launcher.Initialize();
        }

        private void BtnTest_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process()
            {
                StartInfo =
                {
                    FileName = @"D:\Steam\steamapps\common\Star Wars Empire at War\GameData\StarWarsG.exe",
                    Arguments = @"STEAMMOD=1129810972"
                }

            };

            process.Start();
            //Launcher.Launch(new ModHandler.Mod { IsWorkshopMod = false, ModPath = @"D:\Steam\steamapps\common\Star Wars Empire at War\corruption\Mods\1129810972", ModName = "1129810972" });
        }
    }
}