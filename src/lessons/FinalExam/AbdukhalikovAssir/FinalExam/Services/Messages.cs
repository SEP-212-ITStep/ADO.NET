using FinalExam.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Services
{
    internal class Messages
    {

        public List<User> GetActiveUsersList()
        {
            try
            {
                List<User> Users = new List<User>();
                const string SqlQuery = "SELECT * FROM dbo.Users";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Login= reader.GetString(1);
                    user.Password = "";
                    Users.Add(user);
                }
                return Users;
            }
            catch(Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message)); return null; }
        }

        public List<string> GetActiveUsers() {
            try
            {
                List<string> Users = new List<string>();
                const string SqlQuery = "SELECT [login] FROM dbo.Users";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string user = new string("");
                    user = reader.GetString(0);
                    Users.Add(user);
                }
                return Users;
            }
            catch (Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message)); return null; }
        }

        public bool SendPrivateMessage(User Sender, string Message, User Recepient)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection(ConnectionStringProvider.ConnectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT PrivateMessages (from_user_id, to_user_id, message, create_date, is_user_in_black_list, additiounal_info, is_deleted) VALUES (@from_user_id, @to_user_id, @message, @create_date, @is_user_in_black_list, @additional_info, @is_deleted)";
                cmd.Parameters.Add(new SqlParameter("from_user_id", Sender.Id));
                cmd.Parameters.Add(new SqlParameter("to_user_id", Recepient.Id));
                cmd.Parameters.Add(new SqlParameter("message", Message));
                cmd.Parameters.Add(new SqlParameter("create_date", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("is_user_in_black_list", false));
                cmd.Parameters.Add(new SqlParameter("additional_info", ""));
                cmd.Parameters.Add(new SqlParameter("is_deleted", false));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();

                return true;
            }
            catch(Exception ex) { Console.WriteLine(String.Format("Error: Sending message {0}", ex.Message)); return false; }
        }
    }
}
