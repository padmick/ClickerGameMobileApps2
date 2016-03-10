﻿using System;
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

            // if total capital is less than 100
            if (clickCounter < 100)
            { 
                btnWorker.IsEnabled = false; // button functionality is turned off
            }

            // if total capital is less than 100
            if (clickCounter < 500 )
            {
                btnSupervisor.IsEnabled = false;
                btnSupervisor.Opacity = 0;   
            }

            if (clickCounter < 1500)
            {
               btnManager.IsEnabled = false;
               btnManager.Opacity = 0;
            }

            if (clickCounter < 5000)
            {
                btnSupplier.IsEnabled = false;
                btnSupplier.Opacity = 0;
            }

            if (clickCounter < 12000)
            {
                btnManufacturer.IsEnabled = false;
                btnManufacturer.Opacity = 0;
            }

            if (clickCounter < 30000)
            {
                btnBoss.IsEnabled = false;
                btnBoss.Opacity = 0;
            }

        }
        // VARIABLES
  
        int clickCounter;
        int click = 100; // CHANGE LATER, ONLY ON 100 FOR TESTING PURPOSES
        int totalNoOfDays;

        // WORKERS
        int costPerWorker = 100;
        int costPerWorkerIncrease = 8;
        int noOfWorkers;
        int AmountGainPerWorker = 5;
        int WorkerScoreIncrease = 5;

        //SUPERVISORS
        int costPerSupervisor = 500;
        int costPerSupervisorIncrease = 16;
        int noOfSupervisors;
        int AmountGainPerSupervisor = 20;
        int SupervisorScoreIncrease = 20; 

        //MANAGERS
        int costPerManager = 1500;
        int costPerManagerIncrease = 34 ;
        int noOfManagers;
        int AmountGainPerManager = 75;
        int ManagerScoreIncrease = 75;

        //SUPPLIERS
        int costPerSupplier = 5000;
        int costPerSupplierIncrease = 74;
        int noOfSuppliers;
        int AmountGainPerSupplier = 320;
        int SupplierScoreIncrease = 320;

        //MANUFACTURERS
        int costPerManufacturer = 12000;
        int costPerManufacturerIncrease = 192;
        int noOfManufacturers;
        int AmountGainPerManufacturer = 1140;
        int ManufacturerScoreIncrease = 1140;

        //BOSSES
        int costPerBoss = 30000;
        int costPerBossIncrease = 526;
        int noOfBosses;
        int AmountGainPerBoss = 2600;
        int BossScoreIncrease = 2600;

        //TOTAL EMPLOYEES
        int totalEmployees;

        //PERKS
        int costEcoBoom = 200000;
        int costExtraTime = 250000;
        int costMoraleBoost = 300000;

        public async void btnPlayer_Click(object sender, RoutedEventArgs e)
        {
            // makes WORKER button visible and clickable when Capital is 100
            if(clickCounter >= 90)
            {
                btnWorker.IsEnabled = true;
                txtAmountGainPerWorker.Text = AmountGainPerWorker.ToString(); // display how much user makes if they buy the WORKER
                btnSupervisor.Opacity = 30;
            }
            // makes SUPERVISOR button visible and clickable when Capital is 500
            if (clickCounter >= (490 -click))
            {
                btnManager.Opacity = 30;
                btnSupervisor.IsEnabled = true;
                txtAmountGainPerSupervisor.Text = AmountGainPerSupervisor.ToString(); // display how much user makes if they buy the SUPERVISOR
            }

            // makes MANAGER button visible and clickable when Capital is 500
            if (clickCounter >= (1000 - click))
            {
                btnSupplier.Opacity = 30;
                btnManager.IsEnabled = true;
                txtAmountGainPerManager.Text = AmountGainPerManager.ToString();
            }
            
            if (clickCounter >= (2500 - click))
            {
                btnManufacturer.Opacity = 30;
                btnSupplier.IsEnabled = true;
                txtAmountGainPerSupplier.Text = AmountGainPerSupplier.ToString();
            }
            if (clickCounter > (7000 - click))
            {
                btnBoss.Opacity = 30;
                btnManufacturer.IsEnabled = true;
                txtAmountGainPerManufacturer.Text = AmountGainPerManufacturer.ToString();
            }

            if (clickCounter >= (12000 - click))
            {
                btnBoss.Opacity = 100;
                btnBoss.IsEnabled = true;
                txtAmountGainPerBoss.Text = AmountGainPerBoss.ToString();
            }

            // each time the button is clicked, the counter goes up by value of clickCounter
            clickCounter = clickCounter + click;
            txtScore.Text = "€   " + clickCounter.ToString();
            txtScorePerClick.Text = "€  " + click.ToString();

            totalNoOfDays = totalNoOfDays + 1;
            txtTotalNoOfDays.Text = totalNoOfDays.ToString();

            if (totalNoOfDays == 365 & clickCounter > 100000 )
            {
                var dialog = new MessageDialog("You made €" + clickCounter + " in a year, well done!!!");
                await dialog.ShowAsync();
            }
            else if(totalNoOfDays == 365 && clickCounter < 100000)
            {
                var dialog = new MessageDialog("You ended the term with only €" + clickCounter + ", too bad. You needed €" + (50000 - clickCounter + click) + " more. Please restart and try again next year!");
                await dialog.ShowAsync();
                this.Frame.Navigate(typeof(MainPage), null);
            }
        }

        public async void btnWorker_Click(object sender, RoutedEventArgs e)
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
                txtScorePerClick.Text = "€  " + click.ToString();

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
        public async void btnSupervisor_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerSupervisor)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Supervisor!" + " You can't just leave it to him to look at the budget");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerSupervisor++;

                clickCounter = clickCounter - costPerSupervisor;
                click = click + SupervisorScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = "€  " + click.ToString();

                costPerSupervisor = costPerSupervisor + costPerSupervisorIncrease++;
                txtCostForSupervisor.Text = costPerSupervisor.ToString();

                noOfSupervisors = noOfSupervisors + 1;
                txtNoOfSupervisors.Text = noOfSupervisors.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerSupervisor.Text = AmountGainPerSupervisor.ToString();

            }
            return;
        }

        public async void btnManager_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerManager)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Manager!" + " We're still on a budget, you do know that right?");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerManager++;

                clickCounter = clickCounter - costPerManager;
                click = click + ManagerScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = "€  " + click.ToString();

                costPerManager = costPerManager + costPerManagerIncrease++;
                txtCostForManager.Text = costPerManager.ToString();

                noOfManagers = noOfManagers + 1;
                txtNoOfManagers.Text = noOfManagers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerManager.Text = AmountGainPerManager.ToString();
            }
            return;
        }

        public async void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerSupplier)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Supplier!" + "You kind of need to supply some money to afford a supplier!");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerSupplier++;

                clickCounter = clickCounter - costPerSupplier;
                click = click + SupplierScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = "€  " + click.ToString();

                costPerSupplier = costPerSupplier + costPerSupplierIncrease++;
                txtCostPerSupplier.Text = costPerSupplier.ToString();

                noOfSuppliers = noOfSuppliers + 1;
                txtNoOfSuppliers.Text = noOfSuppliers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerSupplier.Text = AmountGainPerSupplier.ToString();

            }
            return;
        }

        public async void btnManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerManufacturer)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Boss!" + "THE BUDGET, REMEMBER THE BUDGET!!!");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerManufacturer++;

                clickCounter = clickCounter - costPerManufacturer;
                click = click + ManufacturerScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = "€  " + click.ToString();

                costPerManufacturer = costPerManufacturer + costPerManufacturerIncrease++;
                txtCostPerManufacturer.Text = costPerManufacturer.ToString();

                noOfManufacturers = noOfManufacturers + 1;
                txtNoOfManufacturers.Text = noOfManufacturers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerManufacturer.Text = AmountGainPerManufacturer.ToString();
            }
            return;
        }
        public async void btnBoss_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerBoss)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Boss!" + "THE BUDGET, REMEMBER THE BUDGET!!!");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerBoss++;

                clickCounter = clickCounter - costPerBoss;
                click = click + BossScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString();
                txtScorePerClick.Text = "€  " + click.ToString();

                costPerBoss = costPerBoss + costPerBossIncrease++;
                txtCostForBoss.Text = costPerBoss.ToString();

                noOfBosses = noOfBosses + 1;
                txtNoOfBosses.Text = noOfBosses.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerBoss.Text = AmountGainPerBoss.ToString();

            }
            return;
        }

        // navigation button to go back to the home page
        public async void btnNavGamePage1_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Progress won't be saved upon exiting application!");
            await dialog.ShowAsync();

            this.Frame.Navigate(typeof(MainPage), null);

        }
        ////////////////////////////////////////////////////////////////////////
        // LAY OFF WORKERS///////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        public async void btnRelocateWorker_Click(object sender, RoutedEventArgs e)
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
                txtScorePerClick.Text = "€  " + click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

            }
            return;
        }

        public async void btnRelocateSupervisor_Click(object sender, RoutedEventArgs e)
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
                txtScorePerClick.Text = "€  " + click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;
        }

        public async void btnRelocateManager_Click(object sender, RoutedEventArgs e)
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
                txtScorePerClick.Text = "€  " + click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;
        }

        public async void btnRelocateSupplies_Click(object sender, RoutedEventArgs e)
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
                txtScorePerClick.Text = "€  " + click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;

        }

        public async void btnRelocateBoss_Click(object sender, RoutedEventArgs e)
        {
            if (noOfBosses < 1) // if the player has none
            {
                // then display the message on the screen that they have none
                var dialog = new MessageDialog("You don't have any Bosses to relocate");
                await dialog.ShowAsync();
            }
            else
            {
                noOfBosses = noOfBosses - 1;
                click = click - costPerBoss;
                clickCounter = clickCounter + (costPerBoss / 2); // so you can't keep buying and selling to keep making money
                txtNoOfBosses.Text = noOfBosses.ToString(); // updates no of managers being displayed after changes made
                txtScore.Text = "€   " + clickCounter.ToString(); // updates scores after changes made
                txtScorePerClick.Text = "€  " + click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

            }
            return;
        }

        public async void btnRelocateManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if (noOfManufacturers < 1) // if the player has none
            {
                // then display the message on the screen that they have none
                var dialog = new MessageDialog("You don't have any Manufacturers to relocate");
                await dialog.ShowAsync();
            }
            else
            {
                noOfManufacturers = noOfManufacturers - 1;
                click = click - costPerManufacturer;
                clickCounter = clickCounter + (costPerManufacturer / 2); // so you can't keep buying and selling to keep making money
                txtNoOfManufacturers.Text = noOfManufacturers.ToString(); // updates no of manufacturers being displayed after changes made
                txtScore.Text = "€   " + clickCounter.ToString(); // updates scores after changes made
                txtScorePerClick.Text = "€  " + click.ToString(); // updates the scores per click counter 

                totalEmployees = totalEmployees - 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();
            }
            return;
        }
        ////////////////////////////////////////////////////////////////////////
        //PERKS///////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        private async void btnPerkEcoBoom_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter > costEcoBoom)
            {
                costPerWorker = costPerWorker / 2;
                costPerSupervisor = costPerSupervisor / 2;
                costPerManager = costPerManager / 2;
                costPerSupplier = costPerSupplier / 2;
                costPerManufacturer = costPerManufacturer / 2;
                costPerBoss = costPerBoss / 2;

                clickCounter = clickCounter - costEcoBoom;

                txtCostForWorker.Text = costPerWorker.ToString();
                txtCostForSupervisor.Text = costPerSupervisor.ToString();
                txtCostForManager.Text = costPerManager.ToString();
                txtCostPerSupplier.Text = costPerSupplier.ToString();
                txtCostPerManufacturer.Text = costPerManufacturer.ToString();
                txtCostForBoss.Text = costPerBoss.ToString();
                txtScore.Text = "€   " + clickCounter.ToString();

                btnPerkEcoBoom.IsEnabled = false;
                btnSupplier.Opacity = 30;

            }
            else
            {
                var dialog = new MessageDialog("You don't have enough for this perk");
                await dialog.ShowAsync();
            }
        }

        private async void btnPerkExtraTime_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter >= costExtraTime)
            {
                clickCounter = clickCounter - costExtraTime;
                totalNoOfDays = totalNoOfDays - 30;
                txtTotalNoOfDays.Text = totalNoOfDays.ToString();

                btnPerkExtraTime.IsEnabled = false;
                btnPerkExtraTime.Opacity = 30;

                txtScore.Text = "€   " + clickCounter.ToString();

            }
            else
            {
                var dialog = new MessageDialog("You don't have enough for this perk");
                await dialog.ShowAsync();
            }
        }

        private async void btnPerkMoraleBoost_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter >= costMoraleBoost)
            {
                clickCounter = clickCounter - costMoraleBoost;
                click = click * 2;
                txtScorePerClick.Text = "€  " + click.ToString();

                btnPerkMoraleBoost.IsEnabled = false;
                btnPerkMoraleBoost.Opacity = 30;

                txtScore.Text = "€   " + clickCounter.ToString();
            }
            else
            {
                var dialog = new MessageDialog("You don't have enough for this perk");
                await dialog.ShowAsync();
            }
        }
    }
}
