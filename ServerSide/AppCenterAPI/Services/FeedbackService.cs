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
            List<FeedbackServiceModel> model = new List<FeedbackServiceModel>();

            int temp = 0;

            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select [Feedback].Id, [User].Name, [User].Email, [Feedback].Date, [Feedback].FeedbackStatus from [User], [Feedback] where [User].Id = [Feedback].UserID", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
  
                FeedbackServiceModel feedbackServiceModel = new FeedbackServiceModel();

                feedbackServiceModel.Id = int.Parse(reader["Id"].ToString());
                feedbackServiceModel.name = reader["Name"].ToString();
                feedbackServiceModel.email = reader["Email"].ToString();
                feedbackServiceModel.date = Convert.ToDateTime(reader["Date"].ToString()).ToShortDateString();
                feedbackServiceModel.status = reader["FeedbackStatus"].ToString();
                
                model.Add(feedbackServiceModel);
            }
            sqlConnection.Close();

            return model;
        }
    }
}
