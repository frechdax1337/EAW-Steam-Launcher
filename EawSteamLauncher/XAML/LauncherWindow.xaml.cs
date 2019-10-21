using System;
using System.Collections.Generic;
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
            ControlHandler.UpdateComboLang();
        }

        private void BtnLaunch_Click(object sender, RoutedEventArgs e)
        {
            if (ListMod.SelectedIndex != -1 && ComboLanguage.SelectedIndex != -1)
            {
                Launcher.Launch(ModHandler.CurrentMods[ListMod.SelectedIndex]);
            }
        }
    }
}