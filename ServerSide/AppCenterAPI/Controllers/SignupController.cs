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

        [HttpGet("{email}/{password}/{passwordReenter}/{name}/{dob}/{gender}/{phoneNo}", Name = "SignupGet")]
        public ResponseViewModel Get(string email, string password, string passwordReenter, string name, int dob, string gender, long phoneNo)
        {
            PasswordValidationServiceModel passwordValidationViewModel = new PasswordValidationServiceModel();
            passwordValidationViewModel.password = password;
            passwordValidationViewModel.passwordReenter = passwordReenter;

            PasswordValidationService passwordValidationService = new PasswordValidationService();
            ResponseViewModel responseViewModel = new ResponseViewModel();

            responseViewModel = passwordValidationService.PasswordValidation(passwordValidationViewModel);

            if (string.Equals(responseViewModel.message, "Validation Successful"))
            {
                SignupViewModel signupViewModel = new SignupViewModel();
                signupViewModel.email = email;
                signupViewModel.password = password;
                signupViewModel.name = name;
                signupViewModel.dob = dob;
                signupViewModel.gender = gender;
                signupViewModel.phoneNo = phoneNo;

                return signupService.AddUser(signupViewModel);
            }
            else
            {
                return responseViewModel;
            }
        }
    }
}
