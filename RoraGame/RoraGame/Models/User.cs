using RoraGame.Network;
using RoraGame.Ulti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Models
{
    class User
    {
        public string id { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        #region API SERVICES

        public async static Task<(string uId, string errMsg)> register(string email, string password, string confirmPassword, string phoneNumber)
        {
            var param = new Dictionary<string, string>()
            {
                { "Email", email },
                { "Password", password },
                { "ConfirmPassword", confirmPassword },
                { "PhoneNumber", phoneNumber }
            };

            await APIServices.Instance.POSTRequest(URLHelper.register, param);

            //if (response.err != null)
            //{
            //    return (null, response.err);
            //}

            //HttpResponseMessage data = response.response;

            //if (data.IsSuccessStatusCode)
            //{
            //    var result = data.Content.ReadAsAsync<ValueResponse<string>>().Result;
            //    if (result.statusCode == 200)
            //    {
            //        return (result.data, null);
            //    }

            //    return (null, result.message);
            //}
            //else
            //{
                return (null, "Can't get data");
            //}

        }

        public async static Task<(LoginResponseModel user, string errMsg)> login(string email, string userPassword)
        {
            var param = new
            {
                username = email,
                password = userPassword
            };

            //var response = await APIServices.Instance.POSTRequest(URLHelper.login, param);

            //if (response.err != null)
            //{
            //    return (null, response.err);
            //}

            //HttpResponseMessage data = response.response;

            //if (data.IsSuccessStatusCode)
            //{
            //    var result = data.Content.ReadAsAsync<ValueResponse<LoginResponseModel>>().Result;
            //    if (result.statusCode == 200)
            //    {
            //        return (result.data, null);
            //    }

            //    return (null, result.message);
            //}
            //else
            //{
                return (null, "Can't get data");
            //}

        }
        #endregion
    }
}
