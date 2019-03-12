using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using RoraGame.Network;
using RoraGame.Ulti;

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

        public async static Task<(List<Game> gameList, string errMsg)> GetGameList()
        {
            var result = await APIServices.Instance.GETRequest(URLStorage.getGameList);

            if(result.err != null)
            {
                return (null, result.err);
            }

            HttpResponseMessage data = result.response;

            if (data.IsSuccessStatusCode)
            {   
                var gameList = data.Content.ReadAsAsync<List<Game>>().Result;
                return (gameList, null);
            }
            else
            {
                return (null, "Can't get data");
            }

        }

        #endregion
    }
}
