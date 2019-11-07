using AppCenterAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppCenterAPI.Services
{
    public class PasswordValidationService
    {
        public ResponseViewModel PasswordValidation(PasswordValidationServiceModel passwordValidationViewModel)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            if (PasswordConditionCheck(passwordValidationViewModel.password))
            {
                if (PasswordMatchCheck(passwordValidationViewModel))
                {
                    responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                    responseViewModel.message = "Validation Successful";
                }
                else
                {
                    responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Conflict);
                    responseViewModel.message = "Passwords doesnot match";
                }
            }
            else
            {
                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Conflict);
                responseViewModel.message = "Password should contain \n1. Atleast 8 characters \n2. Atleast 1 digit \n3. Atleast 1 lowercase \n4. Atleast 1 upercase";
            }

            return responseViewModel;
        }

        private bool PasswordConditionCheck(string passwod)
        {
            if (passwod.Length >= 8 && passwod.Any(char.IsDigit) && passwod.Any(char.IsLower) && passwod.Any(char.IsUpper))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool PasswordMatchCheck(PasswordValidationServiceModel passwordValidationViewModel)
        {
            if(string.Equals(passwordValidationViewModel.password, passwordValidationViewModel.passwordReenter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
