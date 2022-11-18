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
        const string ConnectionString = "Server=127.0.0.1;Database=ChatDb;Trusted_Connection=True;Encrypt=false";
        public List<User> GetActiveUsers()
        {
            try
            {
                List<User> UserLogins = new List<User>();
                const string SqlQuery = "SELECT * FROM dbo.Users";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User();
                    user.Id = reader.GetInt(0);
                    user.Login= reader.GetString(1);
                    user.Password= reader.GetString(2);
                    UserLogins.Add(userLogin);
                }
                return UserLogins;
            }
            catch(Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message)); return null; }
        }
        public bool SendPrivateMessage(string UserLogin, string Message, User Recepient)
        {
            try
            {

            }
            catch(Exception ex) { }
        }
    }
}
