using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCenterAPI.ViewModels
{
    public class ResetViewModel
    {
        public string password { get; set; }
        public string passwordReenter { get; set; }
        public string email { get; set; }
        public int otp { get; set; }
    }
}
