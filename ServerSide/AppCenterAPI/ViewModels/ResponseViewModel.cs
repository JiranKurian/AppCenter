using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppCenterAPI.ViewModels
{
    public class ResponseViewModel
    {
        public HttpResponseMessage httpResponseMessage { get; set; }
        public string message { get; set; }

        public int? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
