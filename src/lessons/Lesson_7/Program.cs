using Dapper;
using Microsoft.Data.SqlClient;

namespace Lesson_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = "Data Source=ASIRUSH-PC;Initial Catalog=ChatDb;Trusted_Connection=true;Encrypt=false";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            const string SelectSqlQuery = "SELECT * FROM [GroupMessages]";
            GroupMessage groupMessages = sqlConnection.Query<GroupMessage>(SelectSqlQuery).ToList();
            foreach (var item in groupMessages)
            {
                Console.WriteLine($"{groupMessages.UserId} : {groupMessages.Message}" +
                    $"[{groupMessages.CreateDate}]");
            }
            Console.WriteLine();
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
}