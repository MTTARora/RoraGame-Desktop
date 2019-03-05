using RoraGame.Ulti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Network
{
    class APIServices
    {
        private static readonly APIServices instance = new APIServices();
        private static HttpClient client;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static APIServices()
        {
        }

        private APIServices()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(URLStorage.baseURL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
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

        public async Task<(HttpResponseMessage response, string err)> GETRequest(string url, string param = null)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                return (response, null);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return (null, ex.Message + "\n" + ex.InnerException.Message ?? "");
            }
        }

        /// <summary>
        /// POST Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>

        public async Task<(HttpResponseMessage response, string err)> POSTRequest<T>(string url, T data)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(url, data);
                return (response, null);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return (null, ex.Message + "\n" + ex.InnerException.Message ?? "");
            }
        }

    }
}
