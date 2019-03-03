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

namespace RoraGame.Views.UserControls.GameList
{
    class GameListUCViewModel
    {

        string platform = "Steam";
        //string GameName = "PlayerUnknown's Battlegrounds";
        string steamUsername = @"pubgvna_2875";
        string steamPassword = @"Pubgvna123123";
        string folderSteam = @"C:\Program Files (x86)\Steam\steam.exe";

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

            #region Bước 1: Kiểm tra
            //Kiểm tra xem đăng nhập chưa
            //Kiểm tra xem có đang thuê game không
            //Kiểm tra đủ lvl thuê game không
            //Kiểm tra ví tiền còn không
            //Gửi thông tin cho server - server response thông tin để đăng nhập
            #endregion

            #region Bước 2: Kill Platform

            //Kill Game Platform
            AppHandler.killPlatform(platform);

            #endregion

            #region Bước 2: Đăng nhập Game

            switch (platform)
            {
                #region Login Steam
                case "Steam":
                    string LoginSteam;
                    LoginSteam = "/c start \"\" \"" + folderSteam + "\" -login " + steamUsername + " " + steamPassword;
                    Process p = new Process();
                    p.StartInfo.FileName = "CMD.exe";
                    p.StartInfo.Arguments = LoginSteam;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    string error = p.StandardError.ReadToEnd();
                    string errors = error + "Xem tại mục hướng dẫn để khắc phục lỗi này.";
                    p.WaitForExit();

                    // Handle result

                    if (error == "")
                    {
                        //Hiện Dock Đang thuê game
                        //ShowDockThueGame();

                        //Code Tính giờ
                        //Code Active Application_Exit
                        //Code Kill Game if lose connect to server
                        //Code kill Game if log out
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(errors, "Lỗi");
                        return false;
                    }
                #endregion

                //Login Epic
                case "Epic":
                    return true;

                //Login Uplay
                case "Uplay":
                    // C:\Users\Sky\AppData\Local\Ubisoft Game Launcher
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

            #endregion
        }

        public void stopRentingGame()
        {
            //Kill Platform
            string PlatformExe = "steam.exe";

            AppHandler.killPlatformByCMD(PlatformExe);

            //Kill Game Extention
            string KillGameExe = "csgo.exe";

            AppHandler.killPlatformByCMD(KillGameExe);
        }

        public bool filterGame(string name)
        {
            return string.IsNullOrEmpty(name);
        }
    }
}
