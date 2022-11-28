using Exam.UserService.Data;
using Exam.UserService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Exam.UserService
{
    public class Direct
    {
        //Путь к БД
        public static ConnectToSql connect = new ConnectToSql();

        //Для возврата к менюшкам
        Menu menu = new Menu();

        //отправить ПРИВАТНЫЕ сообщения +
        public void SendPrivateMessage(ChatDbContext db, User fromId, int toId)
        {
            var newMessage = new PrivateMessage();
            newMessage.FromUserId = fromId.Id;
            newMessage.ToUserId = toId;
            newMessage.CreateDate = DateTime.Now;
            Console.Write("-");
            newMessage.Message = Console.ReadLine();
            if (newMessage.Message == "/end") { menu.UserMenu(fromId); }
            else if (newMessage.Message == "/edit") { EditPrivatMessage(db, fromId, toId); }
            else if (newMessage.Message == "/delete") { DeletePrivateMessage(db, fromId, toId); }
            else
            {
                db.PrivateMessages.Add(newMessage);
                db.SaveChanges();
            }

        }

        //Показ всех пользователей +
        public void ShowUsers()
        {
            //SELECT TOP (1000) [id] ,[login] ,[password] FROM[ChatDb].[dbo].[Users]
            const string queryUsers = "SELECT [id], [login] FROM [ChatDb].[dbo].[Users]";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(queryUsers, SqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var login = reader.GetString(1);
                Console.WriteLine(" ||| " + " ID = " + id + " ||| " + "User = " + login);
            }
        }

        //Показ ПРИВАТНЫХ сообщений этого пользователя   +
        public void ShowPrivateMessages(int userId, int toId)
        {
            string messprvt = "SELECT * FROM dbo.PrivateMessages WHERE from_user_id = @userId AND to_user_id = @toId";
            //Timer timer = new Timer(3000);
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand vvd = new SqlCommand(messprvt, SqlConnection);
            vvd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            vvd.Parameters.Add("@toId", SqlDbType.Int).Value = toId;
            SqlDataReader reader = vvd.ExecuteReader();
            while (reader.Read())
            {
                //timer.Start();
                var id = reader.GetInt32(0);
                var message = reader.GetString(3);
                var date = reader.GetDateTime(4);
                Console.WriteLine("ID = " + id + ":  " + message + "   |" + date + "|");
            }
        }

        //Редактировать приватные сообщения   +
        public void EditPrivatMessage(ChatDbContext db, User fromId, int toId)
        {
            try
            {
                ShowPrivateMessages(fromId.Id, toId);
                Console.Write("Выберите ID сообщения которое хотите изменить:");
                int mesID = int.Parse(Console.ReadLine());
                Console.Write("Введите новый текст сообщения: ");
                string newMessage = Console.ReadLine().ToString();
                const string updatePrvtMess = "UPDATE dbo.PrivateMessages SET [message] = @newMessage,[additional_info] = '|edited|' WHERE id = @mesID";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlCommand vvd = new SqlCommand(updatePrvtMess, SqlConnection);
                vvd.Parameters.Add("@mesID", SqlDbType.Int).Value = mesID;
                vvd.Parameters.Add("@newMessage", SqlDbType.VarChar, 500).Value = newMessage;
                SqlConnection.Open();
                vvd.ExecuteNonQuery();
                db.SaveChanges();
                Console.WriteLine("Сообщение успешно измененно");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Удаление PRIVATE сообщений +
        public void DeletePrivateMessage(ChatDbContext db, User fromId, int toId)
        {
            try
            {
                ShowPrivateMessages(fromId.Id, toId);
                Console.Write("Выберите ID сообщения которое хотите удалить:");
                int mesID = int.Parse(Console.ReadLine());
                const string deletePrvtMess = "DELETE FROM dbo.PrivateMessages WHERE id = @mesID";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlCommand vvd = new SqlCommand(deletePrvtMess, SqlConnection);
                vvd.Parameters.Add("@mesID", SqlDbType.Int).Value = mesID;
                SqlConnection.Open();
                vvd.ExecuteNonQuery();
                db.SaveChanges();
                Console.WriteLine("Сообщение успешно удалено");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
