﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfSingleInstanceByEventWaitHandle;

namespace RoraGame
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 1 Single Instance
        internal delegate void ProcessArgDelegate(String arg);
        internal static ProcessArgDelegate ProcessArg;
        internal class ArgsRun
        {
            internal static string Text;
        }
        #endregion 1Single Instance

        public MainWindow()
        {
            InitializeComponent();

            #region 2 Single Instance
            ProcessArg = delegate (String arg)
            {
                ArgsRun.Text = arg;
            };

            this.Initialized += delegate (object sender, EventArgs e) {
                ArgsRun.Text = (String)Application.Current.Resources[WpfSingleInstance.StartArgKey];
                Application.Current.Resources.Remove(WpfSingleInstance.StartArgKey);
            };
            #endregion 2 Single Instance
        }

        #region Minimize to system tray when applicaiton is closed
        protected override void OnClosing(CancelEventArgs e)
        {
            // setting cancel to true will cancel the close request
            // so the application is not closed
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }
        #endregion Minimize to tray system

        #region Left Side Menu
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlHome();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemAccount":
                    usc = new UserControlAccount();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemGameList":
                    usc = new UserControlGameList();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemGuide":
                    usc = new UserControlGuide();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }
        #endregion Left Side Menu

        #region Close Button
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion Close Button

        #region Click to move window
        private void GridOfWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                if (this.WindowState == System.Windows.WindowState.Normal)
                {
                    this.WindowState = System.Windows.WindowState.Maximized;
                }
                else
                {
                    this.WindowState = System.Windows.WindowState.Normal;
                }
            }
            else
            {
                var move = sender as System.Windows.Controls.Grid;
                var win = Window.GetWindow(move);
                win.DragMove();
            }

        }
        #endregion Click to move window

    }

}
