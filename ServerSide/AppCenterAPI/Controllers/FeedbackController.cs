using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : Controller
    {
        [HttpGet("{email}", Name = "OTPGet")]
        public ResponseViewModel Get(string email)
        {
            OTPService otpService = new OTPService();

            return otpService.SendOTP(email);
        }
    }
}
