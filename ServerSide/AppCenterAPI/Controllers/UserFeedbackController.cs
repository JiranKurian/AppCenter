using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCenterAPI.ServiceModels;
using AppCenterAPI.Services;
using AppCenterAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppCenterAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserFeedbackController : Controller
    {
        [HttpGet("{userId}/{message}", Name = "UserFeedbackGet")]
        public ResponseViewModel Get(int userId, string message)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            UserFeedbackViewModel userFeedbackViewModel = new UserFeedbackViewModel();
            userFeedbackViewModel.userId = userId;
            userFeedbackViewModel.message = message;

            UserFeedbackService userFeedbackService = new UserFeedbackService();

            return userFeedbackService.Feedback(userFeedbackViewModel);
        }
    }
}
