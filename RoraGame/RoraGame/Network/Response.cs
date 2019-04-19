using RoraGame.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoraGame.Network
{
    class BaseResponse
    {
        public string status { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
    }

    class ListResponse<T> : BaseResponse
    {
        public List<T> data { get; set; }
    }

    class ValueResponse<T> : BaseResponse
    {
        public T data { get; set; }
    }
}
