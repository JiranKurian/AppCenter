using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCenterAPI.ViewModels
{
    public class SignupViewModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public int dob { get; set; }
        public string gender { get; set; }
        public long phoneNo { get; set; }
    }
}
