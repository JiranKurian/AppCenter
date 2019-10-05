using AppCenterData.Data;
using AppCenterData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCenterData.EFMethods
{
    public class LoginEF
    {
        public string GetLoginDetails(string username, string password)
        {
            using AppCenterDBContext appCenterDBContext = new AppCenterDBContext();
            var user = await appCenterDBContext.Login.FromSQL
            return username;
        }
    }
}
