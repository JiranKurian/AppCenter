using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCenterAPI.ViewModels;
using AppCenterBL.Services;
using AppCenterBL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppCenterAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // GET: api/Login/5
        [HttpGet("{email}/{password}", Name = "LoginGet")]
        public Response Get(string email, string password)
        {

            LoginService loginService = new LoginService();

            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.username = email;
            loginViewModel.password = password;

            return loginService.LoginValidation(loginViewModel);
        }

    }
}
