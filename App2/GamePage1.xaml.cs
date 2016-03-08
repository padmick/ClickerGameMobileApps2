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

            if (clickCounter < 100)
            { 
                btnWorker.Opacity = 0;
                btnWorker.IsEnabled = false;
            }

            if (clickCounter < 500 )
            {
                btnSupervisor.Opacity = 0;
                btnSupervisor.IsEnabled = false;
            }

            if (clickCounter < 1000)
            {
                //btnManager.IsEnabled = false;
            }

            if (clickCounter < 2500)
            {
              //  btnSupplier.IsEnabled = false;
            }

            if (clickCounter < 7000)
            {
                //btnManufacturer.IsEnabled = false;
            }

            if (clickCounter < 12000)
            {
              //  btnBoss.IsEnabled = false;
            }

        }
        // VARIABLES
  
        int clickCounter;
        int click = 10; // CHANGE LATER, ONLY ON 10 FOR TESTING PURPOSES
        int totalNoOfDays;

        // WORKERS
        int costPerWorker = 100;
        int costPerWorkerIncrease = 8;
        int noOfWorkers;
        int AmountGainPerWorker = 3;
        int WorkerScoreIncrease = 3;

        //SUPERVISORS
        int costPerSupervisor = 500;
        int costPerSupervisorIncrease = 16;
        int noOfSupervisors;

        //MANAGERS
        int costPerManager = 1000;
        int costPerManagerIncrease = 34;
        int noOfManagers;

        //SUPPLIERS
        int costPerSupplier = 2500;
        int costPerSupplierIncrease = 74;
        int noOfSuppliers;

        //MANUFACTURERS
        int costPerManufacturer = 7000;
        int costPerManufacturerIncrease = 192;
        int noOfManufacturers;

        //BOSSES
        int costPerBoss = 12000;
        int costPerBossIncrease = 526;
        int noOfBosses;

        //TOTAL EMPLOYEES
        int totalEmployees;



        private async void btnPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter > 80)
            {
                btnWorker.Opacity = 100;
                btnWorker.IsEnabled = true;
            }
            if(clickCounter == 90)
            {
                txtAmountGainPerWorker.Text = AmountGainPerWorker.ToString();
            }


            if (clickCounter >= (500 - click))
            {
                btnSupervisor.Opacity = 100;
                btnSupervisor.IsEnabled = true;
            }

            // each time the button is clicked, the counter goes up by value of clickCounter
            clickCounter = clickCounter + click;
            txtScore.Text = "€   " + clickCounter.ToString();
            txtScorePerClick.Text = click.ToString();

            totalNoOfDays = totalNoOfDays + 1;
            txtTotalNoOfDays.Text = totalNoOfDays.ToString();

            if (totalNoOfDays == 365 && clickCounter == 50000  )
            {
                var dialog = new MessageDialog("You made" + clickCounter + " in a year, well done!!!");
                await dialog.ShowAsync();
            }
            else if(totalNoOfDays == 100 && clickCounter < 50000)
            {
                var dialog = new MessageDialog("You ended the term with only €" + clickCounter + " in a year, too bad. You needed €" + (50000 - clickCounter) + " more. Please restart and try again next year!");
                await dialog.ShowAsync();
                this.Frame.Navigate(typeof(MainPage), null);
            }
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
                AmountGainPerWorker++;
                clickCounter = clickCounter - costPerWorker;
                click = click + WorkerScoreIncrease++;
                
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerWorker = costPerWorker + costPerWorkerIncrease++;
                txtCostForWorker.Text = costPerWorker.ToString();

                noOfWorkers = noOfWorkers + 1;
                txtNoOfWorkers.Text = noOfWorkers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerWorker.Text = AmountGainPerWorker.ToString();

            }

            return;
        }

        private async void btnSupervisor_Click(object sender, RoutedEventArgs e)
        {
            //if (clickCounter == 50)
           // {
               // btnSupervisor.Opacity = 100;
               // btnSupervisor.IsEnabled = true;
           // }

            if (clickCounter < costPerSupervisor)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Supervisor!" + " You can't just leave it to him to look at the budget");
                await dialog.ShowAsync();
            }
            else
            {
                clickCounter = clickCounter - costPerSupervisor;
                click = click + 12;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerSupervisor = costPerSupervisor + costPerSupervisorIncrease++;
                txtCostForSupervisor.Text = costPerSupervisor.ToString();

                noOfSupervisors = noOfSupervisors + 1;
                txtNoOfSupervisors.Text = noOfSupervisors.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
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
                clickCounter = clickCounter - costPerManager;
                click = click + 32;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerManager = costPerManager + costPerManagerIncrease++;
                txtCostForManager.Text = costPerManager.ToString();

                noOfManagers = noOfManagers + 1;
                txtNoOfManagers.Text = noOfManagers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;
        }

        private async void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerSupplier)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Supplier!" + "You kind of need to supply some money to afford a supplier!");
                await dialog.ShowAsync();
            }
            else
            {
                clickCounter = clickCounter - costPerSupplier;
                click = click + 80;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerSupplier = costPerSupplier + costPerSupplierIncrease++;
                txtCostPerSupplier.Text = costPerSupplier.ToString();

                noOfSuppliers = noOfSuppliers + 1;
                txtNoOfSuppliers.Text = noOfSuppliers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
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
                clickCounter = clickCounter - costPerBoss;
                click = click + 250;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerBoss = costPerBoss + costPerBossIncrease++;
                txtCostForBoss.Text = costPerBoss.ToString();

                noOfBosses = noOfBosses + 1;
                txtNoOfBosses.Text = noOfBosses.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;

        }

        private async void btnManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerManufacturer)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Boss!" + "THE BUDGET, REMEMBER THE BUDGET!!!");
                await dialog.ShowAsync();
            }
            else
            {
                clickCounter = clickCounter - costPerManufacturer;
                click = click + 250;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = click.ToString();

                costPerManufacturer = costPerManufacturer + costPerManufacturerIncrease++;
                txtCostPerManufacturer.Text = costPerManufacturer.ToString();

                noOfManufacturers = noOfManufacturers + 1;
                txtNoOfManufacturers.Text = noOfManufacturers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;

        }


        // navigation button to go back to the home page
        private async void btnNavGamePage1_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Progress won't be saved upon exiting application!");
            await dialog.ShowAsync();

            this.Frame.Navigate(typeof(MainPage), null);

        }
        ////////////////////////////////////////////////////////////////////////
        // RELOCATION OF WORKERS///////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
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
                click = click - 3;
                clickCounter = clickCounter + (costPerWorker / 2); // so you can't keep buying and selling 
                txtNoOfWorkers.Text = noOfWorkers.ToString(); // updates no of workers being displayed after changes made
                txtScore.Text = "€   " + clickCounter.ToString(); // updates scores after changes made
                txtScorePerClick.Text = click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

            }
            return;
        }

        private async void btnRelocateSupervisor_Click(object sender, RoutedEventArgs e)
        {
            if (noOfSupervisors < 1) // if the player has none
            {
                // then display the message on the screen that they have none
                var dialog = new MessageDialog("You don't have any Supervisors to relocate");
                await dialog.ShowAsync();
            }
            else
            {
                noOfSupervisors = noOfSupervisors - 1;
                click = click - 12;
                clickCounter = clickCounter + (costPerSupervisor / 2); // so you can't keep buying and selling 
                txtNoOfSupervisors.Text = noOfSupervisors.ToString(); // updates no of supervisors being displayed after changes made
                txtScore.Text = "€   " + clickCounter.ToString(); // updates scores after changes made
                txtScorePerClick.Text = click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;
        }

        private async void btnRelocateManager_Click(object sender, RoutedEventArgs e)
        {
            if (noOfManagers < 1) // if the player has none
            {
                // then display the message on the screen that they have none
                var dialog = new MessageDialog("You don't have any Managers to relocate");
                await dialog.ShowAsync();
            }
            else
            {
                noOfManagers = noOfManagers - 1;
                click = click - 32;
                clickCounter = clickCounter + (costPerManager / 2); // so you can't keep buying and selling to keep making money
                txtNoOfManagers.Text = noOfManagers.ToString(); // updates no of managers being displayed after changes made
                txtScore.Text = "€   " + clickCounter.ToString(); // updates scores after changes made
                txtScorePerClick.Text = click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;
        }

        private async void btnRelocateSupplies_Click(object sender, RoutedEventArgs e)
        {
            if (noOfSuppliers < 1) // if the player has none
            {
                // then display the message on the screen that they have none
                var dialog = new MessageDialog("You don't have any Suppliers to relocate");
                await dialog.ShowAsync();
            }
            else
            {
                noOfSuppliers = noOfSuppliers - 1;
                click = click - 80;
                clickCounter = clickCounter + (costPerSupplier / 2); // so you can't keep buying and selling 
                txtNoOfSuppliers.Text = noOfSuppliers.ToString(); // updates no of suppliers being displayed after changes made
                txtScore.Text = "€   " + clickCounter.ToString(); // updates scores after changes made
                txtScorePerClick.Text = click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;

        }

        private async void btnRelocateBoss_Click(object sender, RoutedEventArgs e)
        {
            if (noOfBosses < 1) // if the player has none
            {
                // then display the message on the screen that they have none
                var dialog = new MessageDialog("You don't have any Managers to relocate");
                await dialog.ShowAsync();
            }
            else
            {
                noOfBosses = noOfBosses - 1;
                click = click - 250;
                clickCounter = clickCounter + (costPerBoss / 2); // so you can't keep buying and selling to keep making money
                txtNoOfBosses.Text = noOfBosses.ToString(); // updates no of managers being displayed after changes made
                txtScore.Text = "€   " + clickCounter.ToString(); // updates scores after changes made

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

            }
            return;
        }

        private void btnRelocateManufacturer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
