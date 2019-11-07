using AppCenterAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;
using AppCenterAPI.StaticData;

namespace AppCenterAPI.Services
{
    public class SignupService
    {
        public HttpResponseMessage GetUser(SignupViewModel signupViewModel)
        {
            SqlCon sqlcon = new SqlCon();
            SqlConnection sqlConnection = sqlcon.GetConnection();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into [User] values('" + signupViewModel.name + "'," + signupViewModel.dob + "," + signupViewModel.phoneNo + ",'" + DateTime.Now.ToShortDateString() + "','" + signupViewModel.email + "','" + signupViewModel.password + "','" + signupViewModel.gender + "')", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
