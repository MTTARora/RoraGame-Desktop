using KAutoHelper;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        //Kill Platform
        public static void killPlatform(string platform)
        {

            foreach (System.Diagnostics.Process killPlatform in System.Diagnostics.Process.GetProcesses())
            {
                if (killPlatform.ProcessName == platform)
                {
                    killPlatform.Kill();
                }
            }
        }
                
        //Run Platform
        public static void startPlaform(string folderPlatform, string steamUsername, string steamPassword)
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

        //Image Scan
        public static bool sceenScan(string imagePatten)
        {
            var subBitmapPatten = ImageScanOpenCV.GetImage(imagePatten);
            var screen = CaptureHelper.CaptureScreen();
            var resBitmap = ImageScanOpenCV.Find((Bitmap)screen, subBitmapPatten);
            if (resBitmap != null)
            {
                return true;
            }
            return false;
        }

        //Delete File Setting
        public static void deleteFileSetting(string pathSettingPlatform)
        {
            DirectoryInfo di = new DirectoryInfo(pathSettingPlatform);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete(); 
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true); 
            }
        }
    }
}
