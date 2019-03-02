using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RoraGame.Models
{
    class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public string RequiredLvl { get; set; }
        public string GameCode { get; set; }
        public string Description { get; set; }

        #region METHOD



        #endregion

        #region API SERVICES

        public static List<Game> getGameList()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57677/");

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/GameList").Result;

            if (response.IsSuccessStatusCode)
            {
                var gameList = response.Content.ReadAsAsync<List<Game>>().Result;
                return gameList;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
