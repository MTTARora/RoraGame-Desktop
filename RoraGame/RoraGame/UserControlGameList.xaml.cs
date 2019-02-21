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
            items.Add(new Games() { No = 1 , Name = "Assassin's Creed", Platform = "Steam", Description= "https://www.assassinscreed.com" });
            items.Add(new Games() { No = 2, Name = "Battlefield ", Platform = "Steam", Description = "https://www.ea.com/games/battlefield" });
            items.Add(new Games() { No = 3, Name = "Call of Duty", Platform = "Steam", Description = "https://www.callofduty.com" });
            items.Add(new Games() { No = 4, Name = "PlayerUnknown's Battlegrounds", Platform = "Steam", Description = "https://www.pubg.com" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });
            items.Add(new Games() { No = 5, Name = "Fornite", Platform = "Epic", Description = "https://www.epicgames.com/fortnite/hom" });

            LsGames.ItemsSource = items;
        }

        public class Games
        {
            public int No { get; set; }

            public String Name { get; set; }

            public string Platform { get; set; }

            public string Description { get; set; }

        }
    }
}