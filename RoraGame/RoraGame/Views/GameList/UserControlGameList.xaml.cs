﻿using System;
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using RoraGame.Views.UserControls.GameList;
using RoraGame.Models;

namespace RoraGame
{
    /// <summary>
    /// Interaction logic for UserControlGameList.xaml
    /// </summary>
    public partial class UserControlGameList : UserControl
    {

        private GameListUCViewModel gameListViewModel;
        private IEnumerable<Game> gameList;

        public UserControlGameList()
        {
            InitializeComponent();
            gameListViewModel = new GameListUCViewModel();

            GetDataGameList();

            //Listview Search
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LsGames.ItemsSource);
            view.Filter = UserFilter;
        }


        #region ACTIONS

        // Delete filter
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            txtFilter.Clear();
        }

        // Rent game
        private void ThueGame_Click(object sender, RoutedEventArgs e)
        {
            gameListViewModel.rentGame();
        }

        // Stop renting
        private void DungThueGame_Click(object sender, RoutedEventArgs e)
        {

            gameListViewModel.stopRentingGame();

            //Ẩn Dock Đang thuê game
            HideDockThueGame();

            //Code ngừng tính giờ
            //Code Disable Application_Exit
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LsGames.ItemsSource).Refresh();
        }

        #endregion


        #region API SERVICES

        private void GetDataGameList()
        {
            gameList = gameListViewModel.getGameList();
            if (gameList != null)
            {
                LsGames.ItemsSource = gameList;
            }
            else
            {
                //MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                MessageBox.Show("Message: Error");
            }
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