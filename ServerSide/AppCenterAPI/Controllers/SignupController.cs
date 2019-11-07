using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppCenterAPI.Services;
using AppCenterAPI.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : Controller
    {
        SignupService signupService = new SignupService();

        [HttpGet("{email}/{password}/{name}/{dob}/{gender}/{phoneNo}", Name = "Get")]
        public HttpResponseMessage Get(string email, string password, string name, int dob, string gender, long phoneNo)
        {
            SignupViewModel signupViewModel = new SignupViewModel();
            signupViewModel.email = email;
            signupViewModel.password = password;
            signupViewModel.name = name;
            signupViewModel.dob = dob;
            signupViewModel.gender = gender;
            signupViewModel.phoneNo = phoneNo;

            return signupService.GetUser(signupViewModel);
        }

    }
}
