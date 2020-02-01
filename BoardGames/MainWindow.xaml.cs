using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoardGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProgramLogic programLogic = new ProgramLogic();
        public List<string> availableOwners = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            cbxGameOwner.ItemsSource = null;
            cbxGameOwner.ItemsSource = programLogic.owners;
        }
        public void UpdateUI() 
        {
            txbGameName.Clear();
            txbNumberOfPlayers.Clear();
            cbxGameOwner.SelectedItem = null;
            lbxRelevantGames.ItemsSource = null;
            lbxRelevantGames.ItemsSource = programLogic.boardGames;
        }
        private void BtnAddGame_Click(object sender, RoutedEventArgs e)
        {
            string gameName = txbGameName.Text;
            string owner = cbxGameOwner.SelectedItem.ToString();
            string amountOfPlayers = txbNumberOfPlayers.Text;
            programLogic.AddNewGame(gameName, owner, amountOfPlayers);
            UpdateUI();
        }
        private void cbxEveryone_Checked(object sender, RoutedEventArgs e)
        {
            cbxAlice.IsChecked = true;
            cbxDogge.IsChecked = true;
            cbxGherald.IsChecked = true;
            cbxOlivia.IsChecked = true;
            cbxRuna.IsChecked = true;
            cbxSly.IsChecked = true;
            cbxTim.IsChecked = true;
            cbxEveryone.IsChecked = false;
        }
        public List<string> AvailableOwners() 
        {
            if (availableOwners.Count > 0)
            {
                availableOwners.Clear();
            }
            if (cbxAlice.IsChecked==true)
            {
                availableOwners.Add("Alice");
            }
            if (cbxDogge.IsChecked == true)
            {
                availableOwners.Add("Dogge");
            }
            if (cbxGherald.IsChecked == true)
            {
                availableOwners.Add("Gherald");
            }
            if (cbxOlivia.IsChecked == true)
            {
                availableOwners.Add("Olivia");
            }
            if (cbxRuna.IsChecked == true)
            {
                availableOwners.Add("Runa");
            }
            if (cbxSly.IsChecked == true)
            {
                availableOwners.Add("Sly");
            }
            if (cbxTim.IsChecked == true)
            {
                availableOwners.Add("Tim");
            }
            return availableOwners;
        }
        private void btnFilterGames_Click(object sender, RoutedEventArgs e)
        {
            string numberOfPlayersRaw = txbNumberOfActualPlayers.Text;
            int numberOfPlayers;
            int.TryParse(numberOfPlayersRaw, out numberOfPlayers);
            List<BoardGame> playableBoardGames = programLogic.FilterRelevantGames(AvailableOwners(), numberOfPlayers);
            lbxRelevantGames.ItemsSource = null;
            lbxRelevantGames.ItemsSource = playableBoardGames;
            txbRandomSuggestedGame.Text = "";
            txbRandomSuggestedGame.Text = programLogic.SuggestRandomGame(playableBoardGames).ToString();
        }
        private void btnGenerateRandomPlayableGame_Click(object sender, RoutedEventArgs e)
        {
            List<BoardGame> playableBoardGames = lbxRelevantGames.Items.Cast<BoardGame>().ToList();
            txbRandomSuggestedGame.Text = "";
            txbRandomSuggestedGame.Text = programLogic.SuggestRandomGame(playableBoardGames).ToString();
        }
    }
}
