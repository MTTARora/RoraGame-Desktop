﻿using System;
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
        string platform = "Steam";
        string killGame = "csgo";
        //string GameName = "PlayerUnknown's Battlegrounds";
        string gameUsername = @"pubgvna_2875"; //Steam
        string gamePasswords = @"Pubgvna123123"; //Steam
        //string gameUsername = @"truonghoangha002@gmail.com";
        string gamePasswordf = @"Ha9"; //Fake Password
        //string gamePasswords = @"Ha916022"; //Uplay //Password Start
        string gamePassworde = @""; //Uplay //Password End
        string imageLoginPlatform = "uplay_login_screen.PNG"; //Getting form Server //Uplay
        string imageRememberPlatform = "uplay_remember_screen.PNG"; //Getting form Server //Uplay
        string folderPlatform = @"C:\Program Files (x86)\Steam\steam.exe"; //Steam
        //string folderPlatform = @"C:\Program Files (x86)\Ubisoft\Ubisoft Game Launcher\upc.exe"; //Uplay
        string pathSettingPlatform = @"C:\Users\Sky\AppData\Local\Ubisoft Game Launcher"; //Uplay
        string killTaskmngr = "Taskmgr";

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
            //Check Version
            //Check Level Require
            //Check Wallet
            //Get Data form Server
            //If Uplay, Origin, Battle, Epic Check Admin Right
            
            AppHandler.killPlatform(platform); //Kill Game Platform
            System.Threading.Thread.Sleep(500);
            switch (platform)
            {
                //Login Steam
                case "Steam":
                    //Check Location
                    //Check Certification

                    //Start Platform
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
                    AppHandler.deleteFileSetting(pathSettingPlatform);//Delete Setting Platform
                    AppHandler.startPlaform(folderPlatform, null, null); //Start Platform
                    for (int z = 0; z < 33; z++) //Wait for Login Screen 10 Second
                    {
                        IntPtr hWnd = IntPtr.Zero;
                        hWnd = Process.GetProcessesByName(platform)[0].MainWindowHandle;
                        System.Threading.Thread.Sleep(300);
                        if (hWnd != IntPtr.Zero) //Check Uplay Started
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                AppHandler.ShowWindow(hWnd, 9);
                                AppHandler.SetForegroundWindow(hWnd);
                                if(AppHandler.sceenScan(imageLoginPlatform)) //Scan Login
                                {
                                    AppHandler.killPlatform(killTaskmngr); //Kill Taskmgr
                                    AppHandler.InputBlocker.BlockInput(true); //Lock keyboard
                                    System.Threading.Thread.Sleep(300);
                                    AppHandler.ShowWindow(hWnd, 9);
                                    AppHandler.SetForegroundWindow(hWnd);
                                    if (AppHandler.sceenScan(imageRememberPlatform)) //Scan Remember
                                    {
                                        AutoControl.SendClickOnPosition(hWnd, 220, 270); //Click Remember
                                    }
                                    AutoControl.SendClickOnPosition(hWnd, 225, 225);
                                    AppHandler.ShowWindow(hWnd, 0); //Hide Window
                                    System.Threading.Thread.Sleep(20);
                                    AppHandler.killPlatform(killTaskmngr); //Kill Taskmgr
                                    AppHandler.InputBlocker.BlockInput(true); //Lock keyboard
                                    SendKeys.SendWait("+{TAB}");
                                    SendKeys.SendWait(gameUsername); //Send Username
                                    SendKeys.SendWait("{TAB}");
                                    Clipboard.SetText(gamePasswordf); //Clipboard Password Fake
                                    AutoControl.SendStringFocus(gamePasswords); //Send Password Start
                                    System.Threading.Thread.Sleep(50);
                                    AppHandler.killPlatform(killTaskmngr); //Kill Taskmgr
                                    AutoControl.SendTextKeyBoard(hWnd, gamePassworde); //Send Password End
                                    SendKeys.SendWait("{ENTER}");
                                    AppHandler.ShowWindow(hWnd, 9); //Show Window
                                    AppHandler.InputBlocker.BlockInput(false); //Unlock keyboard
                                    i = 100;
                                }
                            }
                            z = 33;
                        }
                    }
                    Clipboard.Clear();
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