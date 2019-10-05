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
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/Login
        [HttpGet]
        public string Get()
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            loginViewModel.username = "Jiran";
            loginViewModel.password = "Winston";


            LoginService loginService = new LoginService();
            return loginService.LoginValidation(loginViewModel);
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
