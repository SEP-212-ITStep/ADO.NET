using Dapper;
using Lesson_7;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System;

namespace Lesson_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = "Server=ASIRUSH-NTBOOK;Database=ChatDb;Trusted_Connection=true;Encrypt=false";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            const string SqlQuery = "SELECT gm.Message, gm.create_date as CreateDate, gm.user_id as UserId, u.login as [AuthorName] FROM [ChatDb].[dbo].[GroupMessages] gm INNER JOIN Users u on gm.user_id = u.id";
            var groupMessages = sqlConnection.Query<GroupMessage>(SqlQuery).ToList();
            foreach (var groupMessage in groupMessages)
            {
                Console.WriteLine($"{groupMessage.UserId} : {groupMessage.Message} [{groupMessage.CreateDate}]");
            }
        }

    }
    public class GroupMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }


    }
}
