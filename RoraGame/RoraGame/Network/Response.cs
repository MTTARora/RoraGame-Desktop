using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Network
{
    class Response<T>
    {
        public string status { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public List<T> data { get; set; }
    }
}
