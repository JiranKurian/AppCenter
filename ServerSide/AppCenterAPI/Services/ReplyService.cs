using AppCenterAPI.StaticData;
using AppCenterAPI.ViewModels;
using AppCenterBL.ServiceModels;
using AppCenterBL.SharedServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppCenterAPI.Services
{
    public class ReplyService
    {
        public ResponseViewModel SendEmail(string email, string cm, string sm, string date, int id)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            EmailService emailService = new EmailService();
            EmailServiceModel emailServiceModel = new EmailServiceModel();

            emailServiceModel.HtmlBody = false;
            emailServiceModel.ToAddress = email;
            emailServiceModel.Subject = "Re. feedback sent on " + date;
            emailServiceModel.Body = "Your Message:\n\n" + cm + "\n\nMessage from our team:\n\n" + sm;

            emailService.SendEmail(emailServiceModel);

            responseViewModel.httpResponseMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
            responseViewModel.message = "Reply Successfuly Sent";

            SqlCon sqlcon = new SqlCon();


            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("update [Feedback] set FeedbackStatus = 'processed' where Id = '" + id + "';", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return responseViewModel;
        }

        
    }
}
