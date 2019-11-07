using AppCenterAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;
using AppCenterAPI.StaticData;
using AppCenterAPI.SharedServices;

namespace AppCenterAPI.Services
{
    public class SignupService
    {
        HashService hashService = new HashService();
        SqlCon sqlcon = new SqlCon();

        public Response AddUser(SignupViewModel signupViewModel)
        {
            Response response = new Response();

            if (CheckUserName(signupViewModel.email))
            {
                string message = Add(signupViewModel);

                if ( message == "true")
                {
                    response.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Created);
                    response.message = "User Created";
                }
                else
                {
                    response.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                    response.message = message;
                }
            }
            else
            {
                response.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Conflict);
                response.message = "Username Already Exist";
            }

            return response;
        }

        private string Add(SignupViewModel signupViewModel)
        {
            try
            {
                SqlConnection sqlConnection = sqlcon.GetConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into [User] values('" + signupViewModel.name + "','" + signupViewModel.dob + "','" + signupViewModel.phoneNo + "','" + DateTime.Now.ToShortDateString() + "','" + signupViewModel.email + "','" + hashService.SHA512(signupViewModel.password) + "','" + signupViewModel.gender + "')", sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return "true";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        private bool CheckUserName(string email)
        {
            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from [User] where Email = '" + email + "';", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
