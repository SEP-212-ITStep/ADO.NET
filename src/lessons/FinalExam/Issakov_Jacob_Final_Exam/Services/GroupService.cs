using Issakov_Jacob_Final_Exam.Data;
using Issakov_Jacob_Final_Exam.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issakov_Jacob_Final_Exam.Services
{
    public class GroupService
    {
        public static void AddToBlackList()
        {
            try
            {
                Console.WriteLine("Enter the User Login? you want to block: ");
                string blackListLogin = Console.ReadLine();
                using var db = new ChatDbContext();
                var users = db.Users.ToList();
                var privateMessages = db.PrivateMessages.ToList();
                foreach (var user in users)
                {
                    if (user.Login == blackListLogin)
                    {
                        foreach (var message in privateMessages)
                        {
                            if (message.FromUserId == user.Id)
                            {
                                message.IsUserInBlackList = true;
                                Console.WriteLine($"id: {message.Id}\t Creation Date: {message.CreateDate}");
                                Console.WriteLine($"\nFromUserId: {message.FromUserId}\t ToUserId: {message.ToUserId}");
                                db.PrivateMessages.Update(message);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public int GetGroupId(string GroupName)
        {
            try
            {
                int result = new();
                const string SqlQuery = "SELECT id FROM dbo.Groups WHERE name = @groupName";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.connectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.AddWithValue("@groupName", GroupName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                return result;
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: Getting Group Id {0}", ex.Message); return 0; }
        }
        public static void CreateGroup(int id)
        {
            Console.WriteLine("Enter Group Name");
            // добавить в 2 группы
            string groupName = Console.ReadLine();
            try
            {
                using var db = new ChatDbContext();
                var groups = db.Groups.ToList();
                foreach (var item in groups)
                {
                    if (item.Name == groupName)
                    {
                        while (item.Name == groupName)
                        {
                            Console.WriteLine("Group with such Name have already created! Rename the group: ");
                            groupName = Console.ReadLine();
                        }
                    }
                }
                GroupService service = new GroupService();
                string sqlQuery2 = string.Format($"INSERT INTO Groups (name, owner_id) VALUES ('{groupName}', {id})");
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.connectionString);
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery2, SqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }

        }// не уверен, что правильно сделал
        public static void DeleteGroup(string groupName)
        {
            // удалить из 2 групп
            try
            {
                GroupService service = new GroupService();
                string sqlQuery2 = string.Format($"DELETE FROM Groups WHERE Name='{groupName}'");
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.connectionString);
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery2, SqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }// не уверен, что правильно сделал
        public static void InviteUser(int id, string groupName)
        {
            // добавить только в user group
            try
            {
                GroupService service = new GroupService();
                string sqlQuery3 = string.Format($"INSERT UserGroups (group_id, user_id) VALUES ({service.GetGroupId(groupName)}, {id})");
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.connectionString);
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery3, SqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }// не уверен, что правильно сделал
        public static void ShowAllGroups()
        {
            try
            {
                string sqlQuery = $"SELECT * FROM Groups";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.connectionString);
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, SqlConnection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["Id"].ToString();
                    var name = reader["Name"].ToString();
                    var ownerId = reader["Owner_id"].ToString();
                    Console.WriteLine($"Id: {id}, Name: {name}, Owner_id: {ownerId}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void WriteInGroup()
        {
            UserService.ShowAllUsers();
            Console.WriteLine("Enter your id: ");
            int id = int.Parse(Console.ReadLine()); 
            GroupService.ShowAllGroups();
            Console.WriteLine("Enter the group name where you want to chat some: ");
            string groupName = Console.ReadLine();
            using var db = new ChatDbContext();
            var groups = db.Groups.ToList();
            bool status = false;
            foreach (var gru in groups)
            {
                if (gru.Name == groupName)
                {
                    status = true;
                }
            }
            if (status == true)
            {
                Console.WriteLine("Enter Message Text: ");
                string messageText = Console.ReadLine();
                GroupService service = new GroupService();
                GroupMessage groupMessage = new GroupMessage();
                groupMessage.GroupId = service.GetGroupId(groupName);
                groupMessage.UserId = id;
                groupMessage.CreateDate = DateTime.Now;
                groupMessage.Message = messageText;
                db.GroupMessages.Add(groupMessage);
                db.SaveChanges();
                Console.WriteLine("The mwssage was sent");
            }

        }
    }
}
