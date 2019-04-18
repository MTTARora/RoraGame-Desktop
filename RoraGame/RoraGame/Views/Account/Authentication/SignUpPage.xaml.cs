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
    /// Interaction logic for PageSignUp.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        #region ACTIONS

        private void SignupClick(object sender, RoutedEventArgs e)
        {
            var phoneVerifyPage = new PhoneVerifyPage();
            NavigationService.Navigate(phoneVerifyPage);

            //var signInPage = new PageLogIn();
            //NavigationService.Navigate(signInPage);

        }

        private void SigninClick(object sender, RoutedEventArgs e)
        {
            var signInPage = new LoginPage();
            NavigationService.Navigate(signInPage);
        }

        private void ForgotPasswordClick(object sender, RoutedEventArgs e)
        {
            var forgotPasswordPage = new ForgotPasswordPage();
            NavigationService.Navigate(forgotPasswordPage);
        }

        #endregion
    }
}
