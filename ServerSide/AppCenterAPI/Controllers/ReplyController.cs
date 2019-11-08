using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCenterAPI.Services;
using AppCenterAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : Controller
    {
        [HttpGet("{email}/{cm}/{sm}/{date}/{id}", Name = "ReplyGet")]
        public ResponseViewModel Get(string email, string cm, string sm, string date, int id)
        {
            ReplyService replyService = new ReplyService();

            return replyService.SendEmail(email, cm, sm, date, id);
        }
    }
}
