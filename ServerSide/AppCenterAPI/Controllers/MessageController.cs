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
    public class MessageController : Controller
    {
        [HttpGet("{Id}", Name = "MessageGet")]
        public MessageViewModel Get(int Id)
        {
            MessageService messageService = new MessageService();

            return messageService.GetMessage(Id);
        }
    }
}
