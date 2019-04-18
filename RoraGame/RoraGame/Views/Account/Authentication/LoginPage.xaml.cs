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
    /// Interaction logic for PageLogIn.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        #region ACTIONS

        private void SigninClick(object sender, RoutedEventArgs e)
        {
            var accountInfo = new AccountInformationPage();
            NavigationService.Navigate(accountInfo);
        }

        private void SignupClick(object sender, RoutedEventArgs e)
        {
            var signUpPage = new SignUpPage();
            NavigationService.Navigate(signUpPage);
        }

        private void ForgotPasswordClick(object sender, RoutedEventArgs e)
        {
            var forgotPasswordPage = new ForgotPasswordPage();
            NavigationService.Navigate(forgotPasswordPage);
        }

        #endregion

    }
}
