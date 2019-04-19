using RestSharp;
using RoraGame.Ulti;
using System.Threading.Tasks;

namespace RoraGame.Network
{
    class APIServices
    {
        private static readonly APIServices instance = new APIServices();
        private static RestClient client;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static APIServices()
        {
        }

        private APIServices()
        {
            client = new RestClient(URLHelper.baseURL);
        }

        public static APIServices Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// GET Request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param">This param is nullable</param>
        /// <returns></returns>

        public async Task<(IRestResponse response, string err)> GETRequest(string url, string param = null)
        {
            var request = new RestRequest(url);
            request.AddParameter(param, ParameterType.QueryString);

            var response = client.Post(request);
            var content = response.Content;
            return (response, null);

            //try
            //{
            //    var response = await url.GetAsync();
            //    //HttpResponseMessage response = await client.GetAsync(url);

            //    response.EnsureSuccessStatusCode();

            //    return (response, null);
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //    return (null, ex.Message + "\n" + ex.InnerException.Message ?? "");
            //}
        }

        /// <summary>
        /// POST Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>

        public async Task<(IRestResponse response, string err)> POSTRequest<T>(string url, T data)
        {
                var request = new RestRequest(url);
                request.AddJsonBody(data);
            
                var response = client.Post(request);
                var content = response.Content;
                return (response, null);
        }
    }
}
