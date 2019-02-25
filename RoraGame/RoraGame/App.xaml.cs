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
using Notifications.Wpf;
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

            //create the notifyicon (it's a resource declared in NotifyIconResources.xaml
            notifyIcon = (TaskbarIcon)FindResource("NotifyIcon");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            notifyIcon.Dispose(); //the icon would clean up automatically, but this is cleaner
            base.OnExit(e);
        }

        #endregion Tray system

        #region Kill App Before Exit
        //Code lại: Nếu đang thuê thì chạy hàm Kill Steam, nếu ko thuê thì ko chạy hàm này
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "process name")
                {
                    myProc.Kill();
                }
            }
        }
        #endregion Kill App Before Exit
    }
}

