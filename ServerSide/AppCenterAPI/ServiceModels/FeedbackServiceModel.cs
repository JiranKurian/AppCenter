using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCenterAPI.ServiceModels
{
    public class FeedbackServiceModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string date { get; set; }
    }
}
