using System.ComponentModel;
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dapper_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=LAPTOP-EGOR\\EGOR_SQL_SERVER;Database=ChatDb;" +
                                            "Trusted_Connection=true;" +
                                            "Encrypt=false";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            const string selectSqlQuery = "SELECT gm.Message, gm.create_date as CreateDate, gm.user_id as UserId, u.login as [AuthorName] " +
                                          "FROM [ChatDb].[dbo].[GroupMessages] gm" +
                                          "  INNER JOIN Users u on gm.user_id = u.id";

            var groupMessages = sqlConnection.Query<GroupMessage>(selectSqlQuery).ToList();
            
            foreach (var groupMessage in groupMessages)
            {
                Console.WriteLine($"{groupMessage.AuthorName}, [{groupMessage.UserId}] : {groupMessage.Message} " +
                                  $"[{groupMessage.CreateDate}]");
            }

        }
    }

    public class GroupMessage
    {
        public string AuthorName { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}