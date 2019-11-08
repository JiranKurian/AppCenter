using AppCenterAPI.StaticData;
using AppCenterAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppCenterAPI.Services
{
    public class UserFeedbackService
    {
        SqlCon sqlcon = new SqlCon();

        public ResponseViewModel Feedback(UserFeedbackViewModel userFeedbackViewModel)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            if (AddFeedback(userFeedbackViewModel))
            {
                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                responseViewModel.message = "FEEDBACK SUBMITED \nWe will followup via mail";
                return responseViewModel;
            }
            else
            {
                responseViewModel.httpResponseMessage = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                responseViewModel.message = "The system is busy, please try after some time";
                return responseViewModel;
            }
        }

        private bool AddFeedback(UserFeedbackViewModel userFeedbackViewModel)
        {
            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into [Feedback] values(" + userFeedbackViewModel.userId + ", '" + userFeedbackViewModel.message + "' ,'pending' ,'" + DateTime.Now + "')", sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }
    }
}
