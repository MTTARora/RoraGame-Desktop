using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using RoraGame.Models;
using RoraGame.Ulti;
using KAutoHelper;
using System.Windows.Forms;

namespace RoraGame.Views.UserControls.GameList
{
    class GameListUCViewModel
    {

        string platform = "upc";
        string killGame = "csgo";
        //string GameName = "PlayerUnknown's Battlegrounds";
        //string gameUsername = @"pubgvna_2875";
        //string gamePassword = @"Pubgvna123123";
        string gameUsername = "truonghoangha002@gmail.com";
        string gamePasswordf = "Ha9"; //Fake Password
        string gamePasswords = "Ha9"; //Password Start
        string gamePassworde = "Ha9"; //Password End
        string imageLoginPlatform = "uplay_login_screen.PNG"; //Getting form Server
        string imageRememberPlatform = "uplay_remember_screen.PNG"; //Getting form Server
        //string folderPlatform = @"C:\Program Files (x86)\Steam\steam.exe";
        string folderPlatform = @"C:\Program Files (x86)\Ubisoft\Ubisoft Game Launcher\upc.exe";
        string pathSettingPlatform = @"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher";


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
            //Check Logged in
            //Check Rented
            //Check Level Require
            //Check Wallet
            //Get Data form Server
            //If Uplay, Origin, Battle, Epic Check Admin Right
            //Kill Game Platform
            AppHandler.killPlatform(platform);
            System.Threading.Thread.Sleep(500);

            switch (platform)
            {
                //Login Steam
                case "steam":
                    AppHandler.startPlaform(folderPlatform, gameUsername, gamePasswords);

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
                    AppHandler.deleteFileSetting(pathSettingPlatform);
                    
                    //Login Platform
                    AppHandler.startPlaform(folderPlatform, null, null);
                    
                    for (int z = 0; z < 33; z++)
                    {
                        System.Threading.Thread.Sleep(300);
                        IntPtr hWnd = IntPtr.Zero;
                        hWnd = Process.GetProcessesByName(platform)[0].MainWindowHandle;
                        
                        if (hWnd != IntPtr.Zero)
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                AppHandler.ShowWindow(hWnd, 9);
                                AppHandler.SetForegroundWindow(hWnd);
                                if(AppHandler.sceenScan(imageLoginPlatform)) //Scan Login
                                {
                                    AppHandler.InputBlocker.BlockInput(true); //Lock keyboard
                                    System.Threading.Thread.Sleep(300);
                                    AppHandler.ShowWindow(hWnd, 9);
                                    AppHandler.SetForegroundWindow(hWnd);
                                    if (AppHandler.sceenScan(imageRememberPlatform)) //Scan Remember
                                    {
                                        AutoControl.SendClickOnPosition(hWnd, 220, 270); //Click Remember
                                    }
                                    AutoControl.SendClickOnPosition(hWnd, 225, 150);
                                    AppHandler.ShowWindow(hWnd, 0); //Hide Window
                                    System.Threading.Thread.Sleep(50);
                                    SendKeys.SendWait(gameUsername); //Send Username
                                    SendKeys.SendWait("{TAB}");
                                    Clipboard.SetText(gamePasswordf); //Clipboard Password Fake
                                    AutoControl.SendStringFocus(gamePasswords); //Send Password Start
                                    AutoControl.SendTextKeyBoard(hWnd, gamePassworde); //Send Password End
                                    SendKeys.SendWait("{ENTER}");
                                    AppHandler.ShowWindow(hWnd, 9); //Show Window
                                    AppHandler.InputBlocker.BlockInput(false); //Unlock keyboard
                                    i = 100;
                                }
                            }
                            z = 33;
                        }
                        Clipboard.Clear();
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
                    //Delete Setting Platform
                    AppHandler.deleteFileSetting(pathSettingPlatform);
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
