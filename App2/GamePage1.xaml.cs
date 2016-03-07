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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage1 : Page
    {
        public GamePage1()
        {
            this.InitializeComponent();
        }

        // VARIABLES

        int clickCounter;
        int click = 5; // CHANGE LATER, ONLY ON 5 FOR TESTING PURPOSES

        // WORKERS
        int costPerWorker = 50;
        int costPerWorkerIncrease = 3;
        int noOfWorkers;

        //SUPERVISORS
        int costPerSupervisor = 150;
        int costPerSupervisorIncrease = 5;
        int noOfSupervisors;

        //MANAGERS
        int costPerManager = 500;
        int costPerManagerIncrease = 9;
        int noOfManagers;

        // BOSSES
        int costPerBoss = 1000;
        int costPerBossIncrease = 15;
        int noOfBosses;

        private void btnPlayer_Click(object sender, RoutedEventArgs e)
        {
            // each time the button is clicked, the counter goes up by value of clickCounter
            clickCounter = clickCounter + click;
            txtScore.Text = "€   " + clickCounter.ToString();
            txtScorePerClick.Text = click.ToString();
        }


        private async void btnWorker_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerWorker)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a worker!" + " We're on a budget!");
                await dialog.ShowAsync();
            }
            else
            {
                clickCounter = clickCounter - costPerWorker;
                click = click + 1;

                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerWorker = costPerWorker + costPerWorkerIncrease++;
                txtCostForWorker.Text = costPerWorker.ToString();

                noOfWorkers = noOfWorkers + 1;
                txtNoOfWorkers.Text = noOfWorkers.ToString();
            }
            return;
        }

        private async void btnSupervisor_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerSupervisor)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Supervisor!" + " You can't just leave it to him to look at the budget");
                await dialog.ShowAsync();
            }
            else
            {
                clickCounter = clickCounter - 150;
                click = click + 3;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerSupervisor = costPerSupervisor + costPerSupervisorIncrease++;
                txtCostForSupervisor.Text = costPerSupervisor.ToString();

                noOfSupervisors = noOfSupervisors + 1;
                txtNoOfSupervisors.Text = noOfSupervisors.ToString();
            }
            return;
        }

        private async void btnManager_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerManager)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Manager!" + " We're still on a budget, you do know that right?");
                await dialog.ShowAsync();
            }
            else
            {
                clickCounter = clickCounter - 500;
                click = click + 5;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerManager = costPerManager + costPerManagerIncrease++;
                txtCostForManager.Text = costPerManager.ToString();

                noOfManagers = noOfManagers + 1;
                txtNoOfManagers.Text = noOfManagers.ToString();
            }
            return;
        }

        private async void btnBoss_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerBoss)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Boss!" + "THE BUDGET, REMEMBER THE BUDGET!!!");
                await dialog.ShowAsync();
            }
            else
            {
                clickCounter = clickCounter - 1000;
                click = click + 8;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerBoss = costPerBoss + costPerBossIncrease++;
                txtCostForBoss.Text = costPerBoss.ToString();

                noOfBosses = noOfBosses + 1;
                txtNoOfBosses.Text = noOfBosses.ToString();
            }
            return;
        }

        private async void btnNavGamePage1_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Progress won't be saved upon exiting application!");
            await dialog.ShowAsync();

            this.Frame.Navigate(typeof(MainPage), null);

        }

        private async void btnRelocateWorker_Click(object sender, RoutedEventArgs e)
        {
            if (noOfWorkers < 1) // if the player has none
            {
                // then display the message on the screen that they have none
                var dialog = new MessageDialog("You don't have any Workers to relocate");
                await dialog.ShowAsync();
            }
            else
            {
                noOfWorkers = noOfWorkers - 1;
                click = click - 1;
                clickCounter = clickCounter + (costPerWorker / 2); // so you can't keep buying and selling 
                txtNoOfWorkers.Text = noOfWorkers.ToString(); // updates no of workers being displayed after changes made
                txtScore.Text = "€   " + clickCounter.ToString(); // updates scores after changes made
            }
            return;
        }
    }
}
