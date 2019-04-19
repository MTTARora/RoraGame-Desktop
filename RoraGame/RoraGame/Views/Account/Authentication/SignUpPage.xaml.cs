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
    /// Interaction logic for PageSignUp.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        private UserUCViewModel userUCViewModel;

        public SignUpPage()
        {
            InitializeComponent();
            userUCViewModel = new UserUCViewModel();
        }

        #region ACTIONS

        private void SignupClick(object sender, RoutedEventArgs e)
        {
            if(!isValidInfo())
            {
                return;
            }

            var result = userUCViewModel.register(tbEmail.Text, pbPassword.Password, pbConfirmPassword.Password, tbPhone.Text).Result;

            if(!string.IsNullOrEmpty(result.errMsg)) {
                MessageBox.Show(result.errMsg);
                return;
            }

            //var phoneVerifyPage = new PhoneVerifyPage();
            //NavigationService.Navigate(phoneVerifyPage);

            var signInPage = new LoginPage();
            signInPage.registerdEmail = tbEmail.Text;
            NavigationService.Navigate(signInPage);

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

        #region SUPPORT FUNCS

        private bool isValidInfo()
        {
            if (!Validator.isValidEmail(tbEmail.Text))
            {
                MessageBox.Show(StringResource_vn_VN.inValidEmailMsg);
                return false;
            }

            if (!Validator.IsValidPhoneNumber(tbPhone.Text))
            {
                MessageBox.Show(StringResource_vn_VN.inValidPhoneNumberMsg);
                return false;
            }

            if (string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show(StringResource_vn_VN.isMissingPasswordMsg);
                return false;
            }

            if (string.IsNullOrEmpty(pbConfirmPassword.Password))
            {
                MessageBox.Show(StringResource_vn_VN.isMissingConfirmPasswordMsg);
                return false;
            }

            return true;
        }

        #endregion
    }
}
