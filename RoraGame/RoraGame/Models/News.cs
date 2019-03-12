using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using RoraGame.Network;
using RoraGame.Ulti;

namespace RoraGame.Models
{
    class News
    {
        public int date { get; set; }
        public string categories { get; set; }
        public string title { get; set; }
        public string excerpt { get; set; }
        public string url { get; set; }


        #region METHOD



        #endregion


        #region API SERVICES

        public async static Task<(List<News> newsList, string errMsg)> GetNewsList()
        {
            var result = await APIServices.Instance.GETRequest(URLStorage.getNewsList);

            if (result.err != null)
            {
                return (null, result.err);
            }

            HttpResponseMessage data = result.response;

            if (data.IsSuccessStatusCode)
            {
                var newsList = data.Content.ReadAsAsync<List<News>>().Result;
                return (newsList, null);
            }
            else
            {
                return (null, "Can't get data");
            }

        }

        #endregion
    }
}
