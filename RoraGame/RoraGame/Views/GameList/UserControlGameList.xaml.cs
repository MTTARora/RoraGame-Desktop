using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.Generic;
using RoraGame.Views.UserControls.GameList;
using RoraGame.Models;

namespace RoraGame
{
    /// <summary>
    /// Interaction logic for UserControlGameList.xaml
    /// </summary>
    public partial class UserControlGameList : UserControl
    {

        // Views

        private CollectionView cvGameList;

        // Props

        private GameListUCViewModel gameListViewModel;
        private List<Game> gameList;


        #region LIFECYCLE

        public UserControlGameList()
        {
            InitializeComponent();
            gameListViewModel = new GameListUCViewModel();

            GetDataGameList();

            //Listview Search
        }

        #endregion


        #region CONFIGS

        private void configViews()
        {
            LsGames.ItemsSource = gameList;
            cvGameList = (CollectionView)CollectionViewSource.GetDefaultView(LsGames.ItemsSource);
            cvGameList.Filter = UserFilter;

        }

        #endregion


        #region ACTIONS

        // Delete filter
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            txtFilter.Clear();
        }

        // Rent game
        private void ThueGame_Click(object sender, RoutedEventArgs e)
        {
            if(gameListViewModel.rentGame())
            {                
                ShowDockThueGame();
            }    
        }

        // Stop renting
        private void DungThueGame_Click(object sender, RoutedEventArgs e)
        {
            if(true)
            {
                gameListViewModel.stopRentingGame();
                HideDockThueGame();
                //Code ngừng tính giờ
                //Code Disable Application_Exit
            }
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LsGames.ItemsSource).Refresh();
        }

        #endregion


        #region API SERVICES

        private async void GetDataGameList()
        {
            var result = await gameListViewModel.getGameList();

            if(result.errMsg != null)
            {
                MessageBox.Show("Message: " + result.errMsg, "Error!");
                return;
            }

            gameList = result.gameList;
            configViews();
        }

        #endregion


        #region SUPPORT FUNCS
        
        //Hide Dock Thue Game
        private void HideDockThueGame()
        {
            GridThueGameDock.RowDefinitions[1].Height = new GridLength(0.0, GridUnitType.Pixel);
            GridThueGameDock2.RowDefinitions[0].Height = new GridLength(0.0, GridUnitType.Pixel);
        }

        //Show Dock Thue Game
        private void ShowDockThueGame()
        {
            GridThueGameDock.RowDefinitions[1].Height = new GridLength(50.0, GridUnitType.Pixel);
            GridThueGameDock2.RowDefinitions[0].Height = new GridLength(30, GridUnitType.Pixel);
        }

        //Listview Search
        private bool UserFilter(object item)
        {
            return gameListViewModel.filterGame(txtFilter.Text) ? true : ((item as Game).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        #endregion
    }
}