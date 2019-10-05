using System;
using System.Collections.Generic;
using System.Text;

namespace AppCenterBL.ServiceModels
{
    public class EmailServiceModel
    {
        public string ToAddress { get; set; }
        public string Subject { get; set; }
        public bool HtmlBody { get; set; }
        public string Body { get; set; }
    }
}
