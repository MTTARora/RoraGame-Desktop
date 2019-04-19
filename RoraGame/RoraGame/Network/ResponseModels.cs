using RoraGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Network
{
    class ResponseModels
    {
    }

    class LoginResponseModel
    {
        public User info { get; set; }
        public string token { get; set; }
    }
}
