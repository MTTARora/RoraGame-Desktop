﻿using System;
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
            items.Add(new Games() { Dates = "29/12/1999", Name = "Assassin's Creed", RequiredLvl = "Level 6", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Call Of Duty", RequiredLvl = "Level 6", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Fornite", RequiredLvl = "Level 6", Description = "https://www.assassinscreed.com" });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Battlefield", RequiredLvl = "Level 6", Description = "qweqwádfádf ăè ăè adfăè ăe ăè " });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Dota", RequiredLvl = "Level 6", Description = "qweqwádfádf ăè ăè adfăè ăe ăè " });
            items.Add(new Games() { Dates = "29/12/1999", Name = "Counter-Strike : Global Offensive", RequiredLvl = "Level 6", Description = "qweqwádfádf ăè ăè adfăè ăe ăè " });
            
            GameNew.ItemsSource = items;
        }

        private void Websiteroragame_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com.vn");
        }

        private void Facebookroragame_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.fb.com");
        }
    }

    public class Games
    {
        public string Dates { get; set; }
        public string Name { get; set; }
        public string RequiredLvl { get; set; }
        public string Description { get; set; }
    }
}
