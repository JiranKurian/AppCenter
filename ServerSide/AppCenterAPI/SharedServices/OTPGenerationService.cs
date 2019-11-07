using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCenterAPI.SharedServices
{
    public class OTPGenerationService
    {
        public int GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}
