using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppCenterAPI.ViewModels
{
    public class Response
    {
        public HttpResponseMessage httpResponseMessage { get; set; }
        public string message { get; set; }
    }
}
