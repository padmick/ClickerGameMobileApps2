using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnNavGamePage1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage1), 0); // goes to the main game page
        }

        private async void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Helpful Instructions here!");
            await dialog.ShowAsync();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit(); // close the app

        }

        private void SPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
