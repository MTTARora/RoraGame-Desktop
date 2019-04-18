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
    /// Interaction logic for ForgotPasswordPage.xaml
    /// </summary>
    public partial class ForgotPasswordPage : Page
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        #region ACTIONS

        private void SendClick(object sender, RoutedEventArgs e)
        {
        }

        private void SigninClick(object sender, RoutedEventArgs e)
        {
            var signInPage = new LoginPage();
            NavigationService.Navigate(signInPage);
        }

        private void SignupClick(object sender, RoutedEventArgs e)
        {
            var signUpPage = new SignUpPage();
            NavigationService.Navigate(signUpPage);
        }

        #endregion
    }
}
