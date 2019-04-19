using RoraGame.Resources.langs;
using RoraGame.Ulti;
using RoraGame.Views.Account;
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
        private UserUCViewModel userUCViewModel;
        public string registerdEmail;

        public LoginPage()
        {
            InitializeComponent();

            userUCViewModel = new UserUCViewModel();
            if (!string.IsNullOrEmpty(registerdEmail))
            {
                tbEmail.Text = registerdEmail;
                MessageBox.Show(StringResource_vn_VN.sentConrimsEmailMsg);
            }
        }

        #region ACTIONS

        private void SigninClick(object sender, RoutedEventArgs e)
        {
            if (!isValidInfo())
            {
                return;
            }

            var result = userUCViewModel.login(tbEmail.Text, pbPassword.Password).Result;

            if (!string.IsNullOrEmpty(result.errMsg))
            {
                MessageBox.Show(result.errMsg);
                return;
            }

            //var phoneVerifyPage = new PhoneVerifyPage();
            //NavigationService.Navigate(phoneVerifyPage);
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


        #region SUPPORT FUNCS

        private bool isValidInfo()
        {
            if (!Validator.isValidEmail(tbEmail.Text))
            {
                MessageBox.Show(StringResource_vn_VN.inValidEmailMsg);
                return false;
            }

            if (string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show(StringResource_vn_VN.isMissingPasswordMsg);
                return false;
            }

            return true;
        }

        #endregion
    }
}
