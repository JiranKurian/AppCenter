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

        // GET: api/Login
        [HttpGet]
        public string Get()
        {
            return "Hi valikuttan";
        }

        [HttpGet("{id}/{name}", Name = "Gets")]
        public string Get(int id, string name)
        {
            return name + id.ToString();
            //return signupService.GetUser(signupViewModel);
        }

        /* // POST api/<controller>
         [EnableCors("AllowMyOrigin")]
         [HttpPost]
         public HttpResponseMessage Post([FromBody] SignupViewModel signupViewModel)
         {
             return signupService.GetUser(signupViewModel);
         }*/
    }
}
