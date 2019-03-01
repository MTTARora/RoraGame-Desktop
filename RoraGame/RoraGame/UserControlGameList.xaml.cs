using System;
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
using GameListViewModel;
using KAutoHelper;

namespace RoraGame
{
    /// <summary>
    /// Interaction logic for UserControlGameList.xaml
    /// </summary>
    public partial class UserControlGameList : UserControl
    {

        //API GameList Get
        private void GetDataGameList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57677/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/GameList").Result;

            if (response.IsSuccessStatusCode)
            {
                var gameList = response.Content.ReadAsAsync<IEnumerable<GameList>>().Result;
                LsGames.ItemsSource = gameList;

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        public UserControlGameList()
        {
            InitializeComponent();

            GetDataGameList();

            //Listview Search
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LsGames.ItemsSource);
            view.Filter = UserFilter;
        }

        //Listview Search
        private bool UserFilter(object item)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as GameList).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LsGames.ItemsSource).Refresh();
        }
        //Clear Search
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            txtFilter.Clear();
        }

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

        string Platform = "Steam";
        //string GameName = "PlayerUnknown's Battlegrounds";
        string GameExtention = "csgo.exe";
        string SteamUsername = @"pubgvna_2875";
        string SteamPassword = @"Pubgvna123123";
        string FolderSteam = @"C:\Program Files (x86)\Steam\";

        //Button Thue Game
        private void ThueGame_Click(object sender, RoutedEventArgs e)
        {
            #region Bước 1: Kiểm tra
            //Kiểm tra xem đăng nhập chưa
            //Kiểm tra xem có đang thuê game không
            //Kiểm tra đủ lvl thuê game không
            //Kiểm tra ví tiền còn không
            //Gửi thông tin cho server - server response thông tin để đăng nhập
            #endregion

            #region Bước 2: Kill Platform

            //Kill Game Platform
            foreach (System.Diagnostics.Process killPlatform in System.Diagnostics.Process.GetProcesses())
            {
                if (killPlatform.ProcessName == Platform)
                {
                    killPlatform.Kill();
                }
            }
            System.Threading.Thread.Sleep(500);
            #endregion

            #region Bước 2: Đăng nhập Game

            switch (Platform)
            {
                #region Login Steam
                case "Steam":
                    string LoginSteam;
                    LoginSteam = @"/c cd " + FolderSteam + " && start steam.exe -login " + SteamUsername + " " + SteamPassword;
                    Process p = new Process();
                    p.StartInfo.FileName = "CMD.exe";
                    p.StartInfo.Arguments = LoginSteam;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    string error = p.StandardError.ReadToEnd();
                    string errors = error + "Xem tại mục hướng dẫn để khắc phục lỗi này.";
                    p.WaitForExit();
                    if (error == "")
                    {
                        //Hiện Dock Đang thuê game
                        ShowDockThueGame();

                        //Code Tính giờ
                        //Code Active Application_Exit
                        //Code Kill Game if lose connect to server
                        //Code kill Game if log out
                    }
                    else
                    {
                        MessageBox.Show(errors, "Lỗi");
                    }
                    break;
                #endregion

                //Login Epic
                case "Epic":
                    break;

                //Login Uplay
                case "Uplay":
                // C:\Users\Sky\AppData\Local\Ubisoft Game Launcher
                    break;

                //Login Battle
                case "Battle":
                    break;

                //Login Origin
                case "Origin":
                    break;
            }
        }
        #endregion

            #region Bước 3: Dừng thuê game

            //Button Dừng thuê game
            private void DungThueGame_Click(object sender, RoutedEventArgs e)
        {
            //Kill Platform
            foreach (System.Diagnostics.Process killPlatform in System.Diagnostics.Process.GetProcesses())
            {
                if (killPlatform.ProcessName == Platform)
                {
                    killPlatform.Kill();
                }
            }

            //Kill Game
            foreach (System.Diagnostics.Process killGameEx in System.Diagnostics.Process.GetProcesses())
            {
                if (killGameEx.ProcessName == GameExtention)
                {
                    killGameEx.Kill();
                }
            }

            //Ẩn Dock Đang thuê game
            HideDockThueGame();

            //Code ngừng tính giờ
            //Code Disable Application_Exit
        }
        #endregion
    }
}