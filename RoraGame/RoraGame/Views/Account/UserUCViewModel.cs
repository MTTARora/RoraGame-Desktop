using RoraGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Views.Account
{
    class UserUCViewModel
    {
        public async Task<(string uId, string errMsg)> register(string userName, string password, string confirmPassword, string phoneNumber)
        {
            var result = await User.register(userName, password, confirmPassword, phoneNumber);

            if (result.errMsg != null)
            {
                return (null, result.errMsg);
            }

            string uId = result.uId;
            return (uId, null);
        }

        public async Task<(string uId, string errMsg)> login(string userName, string password)
        {
            var result = await User.login(userName, password);

            if (result.errMsg != null)
            {
                return (null, result.errMsg);
            }

            string uId = result.user.token;
            return (uId, null);
        }
    }
}
