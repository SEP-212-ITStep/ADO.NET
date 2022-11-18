using Dapper;
using Microsoft.Data.SqlClient;

namespace _18112022_lesson_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=ChatDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";

            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            const string selectSqlQuery = "SELECT gm.Message, gm.create_date as CreateDate, gm.user_id as UserId, u.login as [AuthorName] FROM [ChatDb].[dbo].[GroupMessages] gm INNER JOIN Users u on gm.user_id = u.id";

            //const string selectSqlQuery = "SELECT * FROM [GroupMessages] ORDER BY [create_date]";

            var groupMessages = sqlConnection.Query<GroupMessage>(selectSqlQuery).ToList();

            foreach (GroupMessage groupMessage in groupMessages)
            {
                Console.WriteLine($"{groupMessage.AuthorName},{groupMessage.UserId} : {groupMessage.Message} + {groupMessage.CreateDate}");
            }
        }
    }
    public partial class GroupMessage
    {
        public string AuthorName { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
    }
}