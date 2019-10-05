using AppCenterBL.ViewModels;
using AppCenterData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCenterBL.Services
{
    public class LoginService
    {
        public string LoginValidation(LoginViewModel loginViewModel)
        {
            int count = 0;
            using AppCenterDBContext context = new AppCenterDBContext();
            var user = context.Login.Where(l => string.Equals(l.Email, loginViewModel.username) && string.Equals(l.Password, loginViewModel.password));
            
            foreach (var u in user)
            {
                ++count;
            }

            if(count > 0)
            {
                return "Success";
            }
            else
            {
                return "failed";
            }
        }
    }
}
