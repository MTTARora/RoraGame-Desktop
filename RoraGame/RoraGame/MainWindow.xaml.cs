using Hardcodet.Wpf.TaskbarNotification;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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


        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType sig)
        {
            switch (sig)
            {
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                default:
                    return false;
            }
        }


        static void KillMain(string[] args)
        {
            // Some biolerplate to react to close window event
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);
        }


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

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlHome();
                    GridMain.Children.Add(usc);
                    ScrollViewer.SetVerticalScrollBarVisibility(ScrollViewMain, ScrollBarVisibility.Auto);
                    break;
                case "ItemAccount":
                    usc = new UserControlAccount();
                    GridMain.Children.Add(usc);
                    ScrollViewer.SetVerticalScrollBarVisibility(ScrollViewMain, ScrollBarVisibility.Auto);
                    break;
                case "ItemGameList":
                    usc = new UserControlGameList();
                    GridMain.Children.Add(usc);
                    ScrollViewer.SetVerticalScrollBarVisibility(ScrollViewMain, ScrollBarVisibility.Disabled);
                    break;
                case "ItemGuide":
                    usc = new UserControlGuide();
                    GridMain.Children.Add(usc);
                    ScrollViewer.SetVerticalScrollBarVisibility(ScrollViewMain, ScrollBarVisibility.Auto);
                    break;
                case "ItemInformation":
                    usc = new UserControlInformation();
                    GridMain.Children.Add(usc);
                    ScrollViewer.SetVerticalScrollBarVisibility(ScrollViewMain, ScrollBarVisibility.Auto);
                    break;
                default:
                    break;
            }
        }
        #endregion Left Side Menu

        #region Close, Minimize, Maximize Button
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();

            var notificationManager = new NotificationManager();

            notificationManager.Show(new NotificationContent
            {
                Title = "Thông báo",
                Message = "RoraGame Still Running in background",
                Type = NotificationType.Information
            });
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
        #endregion Close, Minimize, Maximize Button

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
