using AppCenterAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCenterAPI.ServiceModels
{
    public class ResetService
    {
        public ResponseViewModel ResetPassword(ResetViewModel resetViewModel)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            if (Validation(resetViewModel.otp, resetViewModel.email))
            {
                if(PasswordValidation(resetViewModel.password, resetViewModel.passwordReenter))
                {

                }
                else
                {

                }
            }
            else
            {

            }

            return responseViewModel;
        }

        private bool Validation(int otp, string email)
        {

            return false;
        }

        private bool PasswordValidation(string password, string passwordReenter)
        {

            return false;
        }
    }
}
