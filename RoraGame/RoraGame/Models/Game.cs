using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using RoraGame.Network;
using RoraGame.Ulti;

namespace RoraGame.Models
{
    class Game
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string trailer { get; set; }
        public string releaseDate { get; set; }
        public double? rating { get; set; }
        public string share { get; set; }
        public int? totalPlaytime { get; set; }
        public bool? pay { get; set; }
        public int? levelRequired { get; set; }
        public int? numberOfPlayer { get; set; }
        public int? nowPlaying { get; set; }
        public int? creditRequired { get; set; }
        public string fileName { get; set; }
        public string extensionPackage { get; set; }
        public string platformId { get; set; }
        public string platformName { get; set; }
        public List<string> GameAccounts { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Screenshot> Screenshots { get; set; }
        public List<Picture> Pictures { get; set; }
        //public List<object> SupportPlayType { get; set; }
        //public List<object> NumberOfPlayers { get; set; }

        #region METHOD



        #endregion


        #region API SERVICES

        public async static Task<(List<Game> gameList, string errMsg)> GetGameList()
        {
            var response = await APIServices.Instance.GETRequest(URLStorage.getGameList);

            if(response.err != null)
            {
                return (null, response.err);
            }

            HttpResponseMessage data = response.response;

            if (data.IsSuccessStatusCode)
            {   
                //var gameList = data.Content.ReadAsAsync<List<Game>>().Result;

                var result = data.Content.ReadAsAsync<Response<Game>>().Result;
                if(result.statusCode == 200)
                {
                    return (result.data, null);
                } else
                {
                    return (null, result.message);
                }
            }
            else
            {
                return (null, "Can't get data");
            }

        }

        #endregion
    }
}
