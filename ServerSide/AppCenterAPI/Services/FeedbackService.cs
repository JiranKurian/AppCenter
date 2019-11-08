using AppCenterAPI.ServiceModels;
using AppCenterAPI.StaticData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppCenterAPI.Services
{
    public class FeedbackService
    {
        SqlCon sqlcon = new SqlCon();

        public List<FeedbackServiceModel> GetFeedbackList()
        {
            List<FeedbackServiceModel> model;

            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select [Feedback].Id, [User].Name, [User].Email, [Feedback].Date, [Feedback].FeedbackStatus from [User], [Feedback] where [User].Id = [Feedback].UserID", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                FeedbackServiceModel feedbackServiceModel = new FeedbackServiceModel();
                feedbackServiceModel.Id = int.Parse(reader["[Feedback].Id"].ToString());
                feedbackServiceModel.name = reader["[User].Name"].ToString();
                feedbackServiceModel.email = reader["[User].Email"].ToString();
                feedbackServiceModel.date = Convert.ToDateTime(reader["[Feedback].Date"].ToString()).ToShortDateString();

            }
            sqlConnection.Close();


            return;
        }
    }
}
