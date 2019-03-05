using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        string platform = "upc";
        //string GameName = "PlayerUnknown's Battlegrounds";
        //string gameUsername = @"pubgvna_2875";
        //string gamePassword = @"Pubgvna123123";
        string gameUsername = "truonghoangha002@gmail.com";
        string gamePassword = "Ha916022";
        string imageLoginPlatform = "uplay_login_screen.PNG";
        //string folderPlatform = @"C:\Program Files (x86)\Steam\steam.exe";
        string folderPlatform = @"C:\Program Files (x86)\Ubisoft\Ubisoft Game Launcher\upc.exe";
        string killGame = "csgo";

        public async Task<(List<Game> gameList, string errMsg)> getGameList()
        {
            var result = await Game.GetGameList();

            if(result.errMsg != null) {
                return (null, result.errMsg);
            }

            List<Game> gameList = result.gameList;
            return (gameList, null);
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
            System.Threading.Thread.Sleep(500);

            switch (platform)
            {
                //Login Steam
                case "steam":
                    AppHandler.loginPlaform(folderPlatform, gameUsername, gamePassword);

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
                case "upc":
                    //Delete Setting Platform
                    System.IO.File.Delete(@"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher\settings.yml");
                    System.IO.File.Delete(@"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher\users.dat");
                    //Login Platform
                    AppHandler.loginPlaform(folderPlatform, gameUsername, gamePassword);
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
                    hWnd = Process.GetProcessesByName(platform)[0].MainWindowHandle;
                    var subBitmap = ImageScanOpenCV.GetImage(imageLoginPlatform);
                    for (int i = 0; i < 100; i++)
                    {
                        AppHandler.ShowWindow(hWnd, 9);
                        AppHandler.SetForegroundWindow(hWnd);
                        var screen = CaptureHelper.CaptureScreen();
                        var resBitmap = ImageScanOpenCV.Find((Bitmap)screen, subBitmap); //Scan Login Image
                        if (resBitmap != null)
                        {
                            AppHandler.InputBlocker.BlockInput(true); //Lock keyboard
                            System.Threading.Thread.Sleep(300);
                            AppHandler.ShowWindow(hWnd, 9);
                            AppHandler.SetForegroundWindow(hWnd);
                            AutoControl.SendClickOnPosition(hWnd, 226, 152);
                            SendKeys.SendWait(gameUsername);
                            SendKeys.SendWait("{TAB}");
                            SendKeys.SendWait(gamePassword);
                            SendKeys.SendWait("{ENTER}");                            
                            AppHandler.InputBlocker.BlockInput(false);
                            i = 100;
                        }
                    }
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
                case "steam":
                    AppHandler.killPlatform(platform);
                    AppHandler.killPlatform(killGame);
                    return true;

                //Quit Epic
                case "Epic":
                    return true;

                //Quit Uplay
                case "upc":
                    System.IO.File.Delete(@"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher\settings.yml");
                    System.IO.File.Delete(@"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher\users.dat");
                    AppHandler.killPlatform(platform);
                    AppHandler.killPlatform(killGame);
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
