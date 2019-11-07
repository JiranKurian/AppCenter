using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("{email}/{password}", Name = "Gets")]
        public string Get(string email, string password)
        {
            return "value";
        }

    }
}
