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

namespace RoraGame
{
    /// <summary>
    /// Interaction logic for UserControlGameList.xaml
    /// </summary>
    public partial class UserControlGameList : UserControl
    {
        public UserControlGameList()
        {
            InitializeComponent();

            List<Games> items = new List<Games>();
            items.Add(new Games() { No = 1, Name = "Assassin's Creed", Platform = "Steam", Status = "Chơi được", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { No = 2, Name = "Battlefield ", Platform = "Steam", Status = "Chơi được", Description = "https://www.ea.com/games/battlefield" });
            items.Add(new Games() { No = 3, Name = "Call of Duty", Platform = "Steam", Description = "https://www.callofduty.com" });
            items.Add(new Games() { No = 4, Name = "PlayerUnknown's Battlegrounds", Platform = "Steam", Description = "https://www.pubg.com" });
            items.Add(new Games() { No = 5, Name = "Grand Theft Auto 5", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 6, Name = "Final Fantasy XV", Platform = "Steam", Description = "Fortnite là một trò chơi sinh tồn phối hợp trên sandbox do Epic Games và People Can Fly phát triển, và Epic Games phát hành." });
            items.Add(new Games() { No = 7, Name = "Warhammer Vermintide 2  ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 8, Name = "Northgard  ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 9, Name = "Rise Of The Tomb Raider ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 10, Name = "Ghost Recon Wildlands  ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 11, Name = "We need to go deeper", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 12, Name = "FIGHTING EX LAYER ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 13, Name = "Shadow Warrior 2 ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 14, Name = "Naruto to Boruto  ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 15, Name = "Monster Hunter World  ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 16, Name = "Rend  ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 17, Name = "Tricky Tower  ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 18, Name = "Legion TD 2 ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 19, Name = "Conan Exiles  ", Platform = "Steam", Description = "https://www.epicgames.com/fortnite/hom" });

            LsGames.ItemsSource = items;

            //Listview Search
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LsGames.ItemsSource);
            view.Filter = UserFilter;

        }

        //Listview Search
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Games).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LsGames.ItemsSource).Refresh();
        }


        public class Games
        {
            internal string Status;

            public int No { get; set; }

            public String Name { get; set; }

            public string Platform { get; set; }

            public string Description { get; set; }
        }

        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            txtFilter.Clear();
        }
    }
}