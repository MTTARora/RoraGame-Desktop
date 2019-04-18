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
            configView();
        }

        #region Configs

        private void configView()
        {
            var userToken = Properties.Settings.Default.Token;
            if(string.IsNullOrEmpty(userToken))
            {
                Main.Content = new LoginPage();
            } else
            {
                Main.Content = new AccountInformationPage();
            }
        }

        #endregion

        #region Actions

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LoginPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new SignUpPage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new AccountInformationPage();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Content = new ForgotPasswordPage();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Main.Content = new PhoneVerifyPage();
        }

        #endregion

        #region CALLBACK

        #endregion

    }
}
