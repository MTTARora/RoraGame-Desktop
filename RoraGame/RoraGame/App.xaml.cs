using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using WpfSingleInstanceByEventWaitHandle;

namespace RoraGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Tray system
        private TaskbarIcon notifyIcon;

        protected override void OnStartup(StartupEventArgs e)
        {
            #region Single Instance
            base.OnStartup(e);
            WpfSingleInstance.Make("MyWpfApplication", this);
            #endregion Single Instance

        }
        #endregion Tray system

    }
}

