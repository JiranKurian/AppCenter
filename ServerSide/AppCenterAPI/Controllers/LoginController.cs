using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AppCenterBL.ViewModels;

namespace AppCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST: api/Login
        [HttpPost]
        public void Post([FromBody] LoginViewModel loginViewModel)
        {

        }
    }
}
