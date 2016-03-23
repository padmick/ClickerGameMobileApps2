using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
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

            Frame rootFrame = Window.Current.Content as Frame;

            if(rootFrame == null)
            {
                rootFrame = new Frame();
            }

            // if total capital is less than 100
            if (clickCounter < costPerWorker)
            {
                btnWorker.IsEnabled = false; // button functionality is turned off
            }

            // if total capital is less than 100
            if (clickCounter < costPerSupervisor)
            {
                btnSupervisor.IsEnabled = false;
                btnSupervisor.Opacity = 0;
            }

            if (clickCounter < costPerManager)
            {
                btnManager.IsEnabled = false;
                btnManager.Opacity = 0;
            }

            if (clickCounter < costPerSupplier)
            {
                btnSupplier.IsEnabled = false;
                btnSupplier.Opacity = 0;
            }

            if (clickCounter < costPerManufacturer)
            {
                btnManufacturer.IsEnabled = false;
                btnManufacturer.Opacity = 0;
            }

            if (clickCounter < costPerBoss)
            {
                btnBoss.IsEnabled = false;
                btnBoss.Opacity = 0;
            }

        }

        // VARIABLES

        int clickCounter;
        int click = 200; // CHANGE LATER, ONLY ON 100 FOR TESTING PURPOSES
        int totalNoOfDays;

        // WORKERS
        int costPerWorker = 2000;
        int costPerWorkerIncrease = 50;
        int noOfWorkers;
        int AmountGainPerWorker = 30;
        int WorkerScoreIncrease = 30;

        //SUPERVISORS
        int costPerSupervisor = 15000;
        int costPerSupervisorIncrease = 250;
        int noOfSupervisors;
        int AmountGainPerSupervisor = 200;
        int SupervisorScoreIncrease = 200;

        //MANAGERS
        int costPerManager = 35000;
        int costPerManagerIncrease = 3000;
        int noOfManagers;
        int AmountGainPerManager = 800;
        int ManagerScoreIncrease = 800;

        //SUPPLIERS
        int costPerSupplier = 125000;
        int costPerSupplierIncrease = 10000;
        int noOfSuppliers;
        int AmountGainPerSupplier = 2500;
        int SupplierScoreIncrease = 2500;

        //MANUFACTURERS
        int costPerManufacturer = 240000;
        int costPerManufacturerIncrease = 18000;
        int noOfManufacturers;
        int AmountGainPerManufacturer = 8000;
        int ManufacturerScoreIncrease = 8000;

        //BOSSES
        int costPerBoss = 500000;
        int costPerBossIncrease = 50000;
        int noOfBosses;
        int AmountGainPerBoss = 15000;
        int BossScoreIncrease = 15000;
        
        //TOTAL EMPLOYEES
        int totalEmployees;

        //PERKS
        int costEcoBoom = 400000;
        int costExtraTime = 150000;
        int costMoraleBoost = 250000;

        //FILE
        // private const string saveFileName = "saveFile.xml";
        savedValues saves = new savedValues(); // saves


        public class savedValues
        {
            public int savedClickCounter { get; set; }
        }

        public async void btnPlayer_Click(object sender, RoutedEventArgs e)
        {
            if (totalNoOfDays == totalNoOfDays %365)
            {
                Random rnd = new Random();
                string[] phrases = { "Did you know that this is a game for a college project?",
                    "If you stop getting thirsty, you need to drink more water as the body is dehydrated, its thirst mechanism shuts off.",
                    "People in the U.S. spend at least 1896 hours per year at work", "No piece of normal-size paper can be folded in half more than seven times.",
                "A typist’s fingers travel 12.6 miles during an average workday.",
                "The average office worker spends 50 minutes a day looking for lost files and other items.",
                };
                txtMessageBoard.Text = (phrases[rnd.Next(0, phrases.Length)]);
            }

            // makes WORKER button visible and clickable when Capital is 100
            if (clickCounter >= (costPerWorker - click))
            {
                btnWorker.IsEnabled = true;
                txtAmountGainPerWorker.Text = AmountGainPerWorker.ToString(); // display how much user makes if they buy the WORKER
                btnSupervisor.Opacity = 30;
            }
            // makes SUPERVISOR button visible and clickable when Capital is 500
            if (clickCounter >= (costPerSupervisor - click))
            {
                btnManager.Opacity = 30;
                btnSupervisor.IsEnabled = true;
                txtAmountGainPerSupervisor.Text = AmountGainPerSupervisor.ToString(); // display how much user makes if they buy the SUPERVISOR
            }

            // makes MANAGER button visible and clickable when Capital is 500
            if (clickCounter >= (costPerManager - click))
            {
                btnSupplier.Opacity = 30;
                btnManager.IsEnabled = true;
                txtAmountGainPerManager.Text = AmountGainPerManager.ToString();
            }

            if (clickCounter >= (costPerSupplier - click))
            {
                btnManufacturer.Opacity = 30;
                btnSupplier.IsEnabled = true;
                txtAmountGainPerSupplier.Text = AmountGainPerSupplier.ToString();
            }
            if (clickCounter > (costPerManufacturer - click))
            {
                btnManufacturer.Opacity = 30;
                btnManufacturer.IsEnabled = true;
                txtAmountGainPerManufacturer.Text = AmountGainPerManufacturer.ToString();
            }

            if (clickCounter >= (costPerBoss - click))
            {
                btnBoss.Opacity = 100;
                btnBoss.IsEnabled = true;
                txtAmountGainPerBoss.Text = AmountGainPerBoss.ToString();
            }

            // each time the button is clicked, the counter goes up by value of clickCounter
            clickCounter = clickCounter + click;
            txtScore.Text = "€   " + clickCounter.ToString("#,#0");
            txtScorePerClick.Text = "€  " + click.ToString("#,#0");

            totalNoOfDays = totalNoOfDays + 1;
            txtTotalNoOfDays.Text = totalNoOfDays.ToString("#,#0");

            

            if (totalNoOfDays == 365 & clickCounter > 100000)
            {
                var dialog = new MessageDialog("You made €" + clickCounter + " in a year, well done!!!");
                await dialog.ShowAsync();
            }
            else if (totalNoOfDays == 365 && clickCounter < 100000)
            {
                var dialog = new MessageDialog("You ended the term with only €" + clickCounter + ", too bad. You needed €" + (100000 - clickCounter + click) + " more. Please restart and try again next year!");
                await dialog.ShowAsync();
                this.Frame.Navigate(typeof(MainPage), 5);
            }
        }

        public async void btnWorker_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerWorker)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a worker!");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerWorker++;
                clickCounter = clickCounter - costPerWorker;
                click = click + WorkerScoreIncrease++;

                txtScore.Text = "€   " + clickCounter.ToString("#,#0");
                txtScorePerClick.Text = "€  " + click.ToString("#,#0");

                costPerWorker = costPerWorker + costPerWorkerIncrease++;
                txtCostForWorker.Text = costPerWorker.ToString("#,#0");

                noOfWorkers = noOfWorkers + 1;
                txtNoOfWorkers.Text = noOfWorkers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerWorker.Text = AmountGainPerWorker.ToString("#,#0");
            }
            return;
        }
        public async void btnSupervisor_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerSupervisor)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Supervisor!");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerSupervisor++;

                clickCounter = clickCounter - costPerSupervisor;
                click = click + SupervisorScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString("#,#0");
                txtScorePerClick.Text = "€  " + click.ToString("#,#0");

                costPerSupervisor = costPerSupervisor + costPerSupervisorIncrease++;
                txtCostForSupervisor.Text = costPerSupervisor.ToString("#,#0");

                noOfSupervisors = noOfSupervisors + 1;
                txtNoOfSupervisors.Text = noOfSupervisors.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerSupervisor.Text = AmountGainPerSupervisor.ToString("#,#0");

            }
            return;
        }

        public async void btnManager_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerManager)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Manager!");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerManager++;

                clickCounter = clickCounter - costPerManager;
                click = click + ManagerScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString("#,#0");
                txtScorePerClick.Text = "€  " + click.ToString("#,#0");

                costPerManager = costPerManager + costPerManagerIncrease++;
                txtCostForManager.Text = costPerManager.ToString("#,#0");

                noOfManagers = noOfManagers + 1;
                txtNoOfManagers.Text = noOfManagers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerManager.Text = AmountGainPerManager.ToString("#,#0");
            }
            return;
        }

        public async void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerSupplier)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Supplier!");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerSupplier++;

                clickCounter = clickCounter - costPerSupplier;
                click = click + SupplierScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString("#,#0");
                txtScorePerClick.Text = "€  " + click.ToString("#,#0");

                costPerSupplier = costPerSupplier + costPerSupplierIncrease++;
               // txtC.Text = costPerSupplier.ToString("#,#0");

                noOfSuppliers = noOfSuppliers + 1;
                txtNoOfSuppliers.Text = noOfSuppliers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerSupplier.Text = AmountGainPerSupplier.ToString("#,#0");

            }
            return;
        }

        public async void btnManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if (clickCounter < costPerManufacturer)
            {
                var dialog = new MessageDialog("You do not have enough money to buy a Boss!");
                await dialog.ShowAsync();
            }
            else
            {
                AmountGainPerManufacturer++;

                clickCounter = clickCounter - costPerManufacturer;
                click = click + ManufacturerScoreIncrease++;
                txtScore.Text = "€   " + clickCounter.ToString("#,#0");
                txtScorePerClick.Text = "€  " + click.ToString("#,#00");

                costPerManufacturer = costPerManufacturer + costPerManufacturerIncrease++;
                txtCostPerManufacturer.Text = costPerManufacturer.ToString("#,#0");

                noOfManufacturers = noOfManufacturers + 1;
                txtNoOfManufacturers.Text = noOfManufacturers.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerManufacturer.Text = AmountGainPerManufacturer.ToString("#,#0");
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
                txtScore.Text = "€   " + clickCounter.ToString("#,#0");
                txtScorePerClick.Text = "€  " + click.ToString("#,#0");

                costPerBoss = costPerBoss + costPerBossIncrease++;
                txtCostForBoss.Text = costPerBoss.ToString("#,#0");

                noOfBosses = noOfBosses + 1;
                txtNoOfBosses.Text = noOfBosses.ToString();

                totalEmployees = totalEmployees + 1;
                txtTotalNoOfEmployees.Text = totalEmployees.ToString();

                txtAmountGainPerBoss.Text = AmountGainPerBoss.ToString("#,#0");

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

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            saves.savedClickCounter = clickCounter;
            await SaveAsync();
            //this.Frame.Navigate(typeof(MainPage));
        }

        private async Task SaveAsync()
        {
            StorageFile userdetailsfile = await ApplicationData.Current.LocalFolder.CreateFileAsync("UserDetails",
            CreationCollisionOption.ReplaceExisting);
            IRandomAccessStream raStream = await userdetailsfile.OpenAsync(FileAccessMode.ReadWrite);
            using (IOutputStream outStream = raStream.GetOutputStreamAt(0))
            {
                // Serialize the Session State.
                DataContractSerializer serializer = new DataContractSerializer(typeof(savedValues));
                serializer.WriteObject(outStream.AsStreamForWrite(), saves);
                await outStream.FlushAsync();
            }
            var dialog = new MessageDialog("Game is saved!");
            await dialog.ShowAsync();
        }

        private async void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("UserDetails");
            if (file == null) return;
            IRandomAccessStream inStream = await file.OpenReadAsync();
            // Deserialize the Session State.
            DataContractSerializer serializer = new DataContractSerializer(typeof(savedValues));
            var StatsDetails = (savedValues)serializer.ReadObject(inStream.AsStreamForRead());
            inStream.Dispose();
            var dialog = new MessageDialog("Game is loaded!");
            await dialog.ShowAsync();
        }

        private List<Worker> buildObjectGraph()
        {
            var myWorkers = new List<Worker>();

            myWorkers.Add(new Worker() {savedClickCounter = clickCounter});
            return myWorkers;
        }

        /*
private async Task writeXMLAsync()
{
   var myWorkers = clickCounter; //buildObjectGraph();

   var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(List<Worker>));
   using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                     saveFileName,
                     CreationCollisionOption.ReplaceExisting))
   {
       serializer.WriteObject(stream, myWorkers);
       var dialog = new MessageDialog("Save was successful");
       await dialog.ShowAsync();
   }
}
/*
private async Task readXMLAsync()
{
   string content = string.Empty;

   var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(saveFileName);
   using (StreamReader reader = new StreamReader(myStream))
   {
       content = await reader.ReadToEndAsync();
   }
   var dialog = new MessageDialog(content);
   await dialog.ShowAsync();



}
*/

    }
}

