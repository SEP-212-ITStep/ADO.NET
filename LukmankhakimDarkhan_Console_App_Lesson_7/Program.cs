using Dapper;
using Microsoft.Data.SqlClient;

namespace LukmankhakimDarkhan_Console_App_Lesson_7
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=223-5; Database=Classwork;Trusted_Connection=true;Encrypt=false;";
            //используем метод для подключения к серверу
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

            //Console.WriteLine("Hello, World!");
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