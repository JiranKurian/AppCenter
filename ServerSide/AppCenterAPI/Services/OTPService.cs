using AppCenterAPI.SharedServices;
using AppCenterAPI.StaticData;
using AppCenterAPI.ViewModels;
using AppCenterBL.ServiceModels;
using AppCenterBL.SharedServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppCenterAPI.Services
{
    public class OTPService
    {
        SqlCon sqlcon = new SqlCon();

        public ResponseViewModel SendOTP(string email)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();
            OTPGenerationService otpGenerationService = new OTPGenerationService();

            if (ValidateEmail(email))
            {
                return SendEmail(email, otpGenerationService.GenerateOTP());
            }
            else
            {
                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
                responseViewModel.message = "The given email doesnot exist";

                return responseViewModel;
            }
        }

        private bool ValidateEmail(string email)
        {
            SqlCon sqlcon = new SqlCon();

            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from [User] where Email = '" + email + "';", sqlConnection);
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

        private ResponseViewModel SendEmail(string email, int otp)
        {
            int Id = 0;

            ResponseViewModel responseViewModel = new ResponseViewModel();

            EmailServiceModel emailServiceModel = new EmailServiceModel();
            emailServiceModel.ToAddress = email;
            emailServiceModel.HtmlBody = false;
            emailServiceModel.Subject = "Password reset OTP";
            emailServiceModel.Body = "Your six digit OTP is : " + otp + " .\n It will expire in 5 min.";

            try
            {
                EmailService emailService = new EmailService();
                emailService.SendEmail(emailServiceModel);

                SqlConnection sqlConnection = sqlcon.GetConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from [User] where Email = '" + email + "';", sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Id = int.Parse(reader["Id"].ToString());
                }

                return AddOTP(Id, otp);
            }
            catch (Exception ex)
            {
                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                responseViewModel.message = ex.ToString();

                return responseViewModel;
            }

        }

        private ResponseViewModel AddOTP(int Id, int otp)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            try
            {

                SqlConnection sqlConnection = sqlcon.GetConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into [OTP] values(" + Id + ", " + otp + ", '" + DateTime.Now.ToString() + "');", sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();

                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
                responseViewModel.message = "OTP has been sent to your Email Id";

                return responseViewModel;
            }
            catch(Exception ex)
            {
                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                responseViewModel.message = ex.ToString();

                return responseViewModel;
            }
        }
    }
}
