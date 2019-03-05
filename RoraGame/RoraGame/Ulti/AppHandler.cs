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
using System.Runtime.InteropServices;

namespace RoraGame.Ulti
{
    class AppHandler
    {
        //Set Window to Top View
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        //Show window even Minimize
        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

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

        //KillPlatformByproccessID


        //RunPlatformByCMD
        public static void loginPlaform(string folderPlatform, string steamUsername, string steamPassword)
        {
            string strLoginPlatform = "/c start \"\" \"" + folderPlatform + "\" -login " + steamUsername + " " + steamPassword;
            Process o = new Process();
            o.StartInfo.FileName = "CMD.exe";
            o.StartInfo.Arguments = strLoginPlatform;
            o.StartInfo.UseShellExecute = false;
            o.StartInfo.CreateNoWindow = true;
            o.StartInfo.RedirectStandardError = true;
            o.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            o.Start();
            string error = o.StandardError.ReadToEnd();
            o.WaitForExit();
        }

        //Lock Keyboard & Mouse
        public static class InputBlocker
        {
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern void BlockInput([In, MarshalAs(UnmanagedType.Bool)]bool fBlockIt);
        }
    }
}
