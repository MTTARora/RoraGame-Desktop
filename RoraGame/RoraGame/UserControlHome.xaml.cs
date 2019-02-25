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

namespace RoraGame
{
    /// <summary>
    /// Interação lógica para UserControlHome.xam
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();

            List<Games> items = new List<Games>();
            items.Add(new Games() { Dates = "29/12/1999", Name = "Assassin's Creed", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Call Of Duty", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Fornite", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Battlefield", Description = "qweqwádfádf ăè ăè adfăè ăe ăè " });

            GameNew.ItemsSource = items;
        }

        private void Websiteroragame_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com.vn");
        }
    }

    public class Games
    {
        public string Dates { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
    }
}
