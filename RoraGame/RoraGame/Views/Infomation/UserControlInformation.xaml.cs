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
    /// Interaction logic for UserControlInformation.xaml
    /// </summary>
    public partial class UserControlInformation : UserControl
    {
        public UserControlInformation()
        {
            InitializeComponent();
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
}
