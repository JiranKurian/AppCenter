using AppCenterAPI.StaticData;
using AppCenterAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppCenterAPI.Services
{
    public class MessageService
    {
        public MessageViewModel GetMessage(int Id)
        {
            MessageViewModel messageViewModel = new MessageViewModel();

            SqlCon sqlcon = new SqlCon();

            SqlConnection sqlConnection = sqlcon.GetConnection();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select [User].Name, [User].Email, [Feedback].Date, [Feedback].Message from [User], [Feedback] where [User].Id = [Feedback].UserID and [Feedback].Id = " + Id + "", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                messageViewModel.name = reader["Name"].ToString();
                messageViewModel.email = reader["Email"].ToString();
                messageViewModel.date = reader["Date"].ToString();
                messageViewModel.message = reader["Message"].ToString();
            }
            sqlConnection.Close();

            return messageViewModel;
        }
    }
}
