using AppCenterAPI.Services;
using AppCenterAPI.SharedServices;
using AppCenterAPI.StaticData;
using AppCenterAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppCenterAPI.ServiceModels
{
    public class ResetService
    {
        SqlCon sqlcon = new SqlCon();

        public ResponseViewModel ResetPassword(ResetViewModel resetViewModel)
        {
            if (Validation(resetViewModel.otp, resetViewModel.email))
            {
                ResponseViewModel responseViewModel = new ResponseViewModel();
                responseViewModel = PasswordValidation(resetViewModel.password, resetViewModel.passwordReenter);

                if (responseViewModel.message == "Validation Successful")
                {
                    return UpdatePassword(resetViewModel.password, resetViewModel.email);
                }
                else
                {
                    return responseViewModel;
                }
            }
            else
            {
                ResponseViewModel responseViewModel = new ResponseViewModel();
                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                responseViewModel.message = "Reset failed due to following reasons. \n1. Wrong OTP \n2. OTP Expired";

                return responseViewModel;
            }
        }

        private ResponseViewModel UpdatePassword(string password, string email)
        {
            HashService hashService = new HashService();
            ResponseViewModel responseViewModel = new ResponseViewModel();

            try
            {
                SqlConnection sqlConnection = sqlcon.GetConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("update [User] set Password = '" + hashService.SHA512(password) + "' where Email = '" + email + "';", sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                responseViewModel.message = "Password Updated Successfully";

                return responseViewModel;
            }
            catch (Exception ex)
            {
                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                responseViewModel.message = ex.ToString();

                return responseViewModel;
            }
        }

        private bool Validation(int otp, string email)
        {
            int Id = 0;

            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from [User] where Email = '" + email + "';", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Id = int.Parse(reader["Id"].ToString());
            }

            return EmailOTPValidation(Id, otp);
        }

        private bool EmailOTPValidation(int Id, int otp)
        {
            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from [OTP] where UserId = " + Id + " and OTP = " + otp + ";", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime now = DateTime.Now;
                DateTime old = Convert.ToDateTime(reader["CreatedDate"].ToString());

                if((now-old).Minutes <= 5)
                {
                    return true;
                }
            }
            return false;
        }

        private ResponseViewModel PasswordValidation(string password, string passwordReenter)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            PasswordValidationService passwordValidationService = new PasswordValidationService();

            PasswordValidationServiceModel passwordValidationServiceModel = new PasswordValidationServiceModel();
            passwordValidationServiceModel.password = password;
            passwordValidationServiceModel.passwordReenter = passwordReenter;

            return passwordValidationService.PasswordValidation(passwordValidationServiceModel);
        }
    }
}
