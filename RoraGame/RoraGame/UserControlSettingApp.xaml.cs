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
    /// Interaction logic for UserControlSettingApp.xaml
    /// </summary>
    public partial class UserControlSettingApp : UserControl
    {
        public UserControlSettingApp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string defaul = @"C:\Program Files (x86)\Steam";
            SteamFolder.Text = defaul;
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            string defaul = @"C:\Program Files (x86)\Battle";
            BattleFolder.Text = defaul;
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            string defaul = @"C:\Program Files (x86)\Ubisoft";
            UplayFolder.Text = defaul;
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            string defaul = @"C:\Program Files (x86)\Origin";
            OriginFolder.Text = defaul;
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            string defaul = @"C:\Program Files (x86)\Epic Games";
            EpicFolder.Text = defaul;
        }
    }
}
