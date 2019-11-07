using AppCenterAPI.ServiceModels;
using AppCenterAPI.SharedServices;
using AppCenterAPI.StaticData;
using AppCenterAPI.ViewModels;
using AppCenterBL.ViewModels;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace AppCenterBL.Services
{
    public class LoginService
    {
        public ResponseViewModel LoginValidation(LoginViewModel loginViewModel)
        {
            ResponseViewModel response = new ResponseViewModel();

            if(CheckLogin(loginViewModel.username, loginViewModel.password))
            {
                return GetUserDetails(loginViewModel.username);
            }
            else
            {
                response.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                response.message = "WRONG CREDENTIALS. \nKindly enter the correct username and password";

                return response;
            }
        }

        private bool CheckLogin(string email, string password)
        {
            HashService hashService = new HashService();

            SqlCon sqlcon = new SqlCon();
            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from [User] where Email = '" + email + "' and Password = '" + hashService.SHA512(password) + "';", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private ResponseViewModel GetUserDetails(string email)
        {
            ResponseViewModel response = new ResponseViewModel();

            SqlCon sqlcon = new SqlCon();
            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from [User] where Email = '" + email + "';", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                response.UserId = int.Parse(reader["Id"].ToString());
                response.UserName = reader["Name"].ToString();
            }

            response.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            response.message = "User Authenticated";

            return response;
        }
    }
}
