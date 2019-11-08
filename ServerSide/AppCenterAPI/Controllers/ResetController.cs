using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCenterAPI.ServiceModels;
using AppCenterAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppCenterAPI.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetController : Controller
    {
        [HttpGet("{password}/{passwordReenter}/{email}/{otp}", Name = "ResetGet")]
        public ResponseViewModel Get(string password, string passwordReenter, string email, int otp)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            ResetViewModel resetViewModel = new ResetViewModel();
            resetViewModel.password = password;
            resetViewModel.passwordReenter = passwordReenter;
            resetViewModel.email = email;
            resetViewModel.otp = otp;

            ResetService resetService = new ResetService();

            return resetService.ResetPassword(resetViewModel);
        }
    }
}
