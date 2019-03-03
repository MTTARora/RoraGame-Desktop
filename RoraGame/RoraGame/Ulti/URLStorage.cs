using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Ulti
{
    class URLStorage
    {
        public static string baseURL = "http://localhost:57677/";

        #region USER

        public static string register = baseURL + "";
        public static string login = baseURL + "";
        public static string forgotPassword = baseURL + "";

        #endregion


        #region GAME

        public static string getGameByID = baseURL + "";
        public static string getGameList = baseURL + "api/GameList";
        public static string getGameAccount = baseURL + "";

        #endregion


        #region OTHERS

        public static string getNews = baseURL + "";
        public static string getGuides = baseURL + "";

        #endregion
    }
}
