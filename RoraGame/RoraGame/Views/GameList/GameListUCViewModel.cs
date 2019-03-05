using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Diagnostics;
using RoraGame.Models;
using RoraGame.Ulti;
using KAutoHelper;
using System.Windows.Forms;
using System.Drawing;

namespace RoraGame.Views.UserControls.GameList
{
    class GameListUCViewModel
    {

        string platform = "Steam";
        //string GameName = "PlayerUnknown's Battlegrounds";
        string steamUsername = @"pubgvna_2875";
        string steamPassword = @"Pubgvna123123";
        string folderPlatform = @"C:\Program Files (x86)\Steam\steam.exe";
        //string folderPlatform = @"C:\Program Files (x86)\Ubisoft\Ubisoft Game Launcher\upc.exe";

        public List<Game> getGameList()
        {
            List<Game> gameList = Game.getGameList();
            if (gameList != null)
            {
                return gameList;
            } else
            {
                return null;
            }
        }

        public bool rentGame()
        {
            //Kiểm tra xem đăng nhập chưa
            //Kiểm tra xem có đang thuê game không
            //Kiểm tra đủ lvl thuê game không
            //Kiểm tra ví tiền còn không
            //Gửi thông tin cho server - server response thông tin để đăng nhập

            //Kill Game Platform
            AppHandler.killPlatform(platform);

            switch (platform)
            {
                //Login Steam
                case "Steam":
                    AppHandler.loginPlaform(folderPlatform, steamUsername, steamPassword);

                    // Handle result

                    //if (error == "")
                    //{
                    //    //Code Tính giờ
                    //    //Code Active Application_Exit
                    //    //Code Kill Game if lose connect to server
                    //    //Code kill Game if log out
                    return true;
                //}
                //else
                //{
                //    MessageBox.Show(errors, "Lỗi");
                //    return false;
                //}

                //Login Epic
                case "Epic":
                    return true;

                //Login Uplay
                case "Uplay":
                    //Delete Setting Platform
                    System.IO.File.Delete(@"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher\settings.yml");
                    System.IO.File.Delete(@"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher\users.dat");
                    //Login Platform
                    AppHandler.loginPlaform(folderPlatform, steamUsername, steamPassword);
                    int z = 0;
                    while (z < 20)
                    {
                        System.Threading.Thread.Sleep(200);
                        IntPtr hWnd1 = IntPtr.Zero;
                        hWnd1 = Process.GetProcessesByName("upc")[0].MainWindowHandle;
                        if ((int)hWnd1 != 0)
                        {
                            z = 20;
                        }
                        z++;
                    }
                    IntPtr hWnd = IntPtr.Zero;
                    hWnd = Process.GetProcessesByName("upc")[0].MainWindowHandle;
                    var subBitmap = ImageScanOpenCV.GetImage("uplay_login_screen.PNG");
                    for (int i = 0; i < 100; i++)
                    {
                        AppHandler.ShowWindow(hWnd, 9);
                        AppHandler.SetForegroundWindow(hWnd);
                        var screen = CaptureHelper.CaptureScreen();
                        var resBitmap = ImageScanOpenCV.Find((Bitmap)screen, subBitmap);
                        if (resBitmap != null)
                        {
                            AppHandler.InputBlocker.BlockInput(true);
                            System.Threading.Thread.Sleep(500);
                            AppHandler.ShowWindow(hWnd, 9);
                            AppHandler.SetForegroundWindow(hWnd);
                            string Username = "truonghoangha002@gmail.com";
                            string Password = "Ha916022";
                            AutoControl.SendClickOnPosition(hWnd, 226, 152);
                            SendKeys.SendWait(Username);
                            SendKeys.SendWait("{TAB}");
                            SendKeys.SendWait(Password);
                            SendKeys.SendWait("{ENTER}");
                            i = 100;
                            AppHandler.InputBlocker.BlockInput(false);
                        }
                    }
                    AppHandler.InputBlocker.BlockInput(false);
                    return true;

                //Login Battle
                case "Battle":
                    return true;

                //Login Origin
                case "Origin":
                    return true;

                default:
                    return true;
            }
        }

        public bool stopRentingGame()
        {
            switch (platform)
            {
                //Quit Steam
                case "Steam":
                    //Kill Platform
                    string PlatformExe = "steam.exe";

                    AppHandler.killPlatformByCMD(PlatformExe);

                    //Kill Game Extention
                    string KillGameExe = "csgo.exe";

                    AppHandler.killPlatformByCMD(KillGameExe);
                    return true;

                //Quit Epic
                case "Epic":
                    return true;

                //Quit Uplay
                case "Uplay":
                    //Delete Setting Platform
                    System.IO.File.Delete(@"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher\settings.yml");
                    System.IO.File.Delete(@"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher\users.dat");
                    return true;

                //Quit Battle
                case "Battle":
                    return true;

                //Quit Origin
                case "Origin":
                    return true;

                default:
                    return true;
            }
        }

        public bool filterGame(string name)
        {
            return string.IsNullOrEmpty(name);
        }   
    }
}
