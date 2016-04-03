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
            var dialog = new MessageDialog("The aim of the game is to reach a certain amount of money by the end of the term(365 days in this version). You can do this by clicking on the 'Work for a day' button. You do this to earn money in order to hire more employees to further increase the money earned per day. As you earn money, the higher-up employees slowly become available and if necessary, you can purchase Perks(although expensive, can be pretty reliable). The aim is to reach to Goal(€1 Million in this version) by the end of the term. If not, then the game is over and you must try again. Good Luck!!") ;
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
