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
    /// Interaction logic for UserControlAccount.xaml
    /// </summary>
    public partial class UserControlAccount : UserControl
    {
        public UserControlAccount()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageLogIn();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageSignUp();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new PageAccountInformation();
        }
    }
}
