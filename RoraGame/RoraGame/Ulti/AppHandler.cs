using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Diagnostics;
using RoraGame.Models;
using RoraGame.Ulti;

namespace RoraGame.Ulti
{
    class AppHandler
    {

        public static void killPlatform(string platform)
        {

            foreach (System.Diagnostics.Process killPlatform in System.Diagnostics.Process.GetProcesses())
            {
                if (killPlatform.ProcessName == platform)
                {
                    killPlatform.Kill();
                }
            }
            System.Threading.Thread.Sleep(500);
        }

        /// <summary>
        /// Kill platform by cmd
        /// </summary>
        /// <param name="platform"> exp: steam.exe </param>

        public static void killPlatformByCMD(string platform)
        {
            string cmd = "/c taskkill /F /IM ";

            Process p = new Process();
            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Arguments = cmd + platform;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();

        }
    }
}
