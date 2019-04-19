using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Ulti
{
    class URLHelper
    {
        public static string baseURL = "http://localhost:52315/api/";
        public static string baseURLNews = "http://roragame.ddns.net/";

        #region USER

        public static string register = baseURL + "auth/register";
        public static string login = baseURL + "auth/login";
        public static string forgotPassword = baseURL + "auth/forgot-password";

        #endregion


        #region GAME

        public static string getGameByID = baseURL + "";
        public static string getGameList = baseURL + "games";
        public static string getGameAccount = baseURL + "";

        #endregion

        #region OTHERS

        public static string getNewsList = baseURLNews + "get_recent_posts";
        public static string getGameNew = baseURL + "";
        public static string getGuides = baseURL + "";

        #endregion
    }
}
