using Exam.UserService.Data;
using Exam.UserService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Group = Exam.UserService.Models.Group;

namespace Exam.UserService
{
    public class GroupService
    {
        //Путь к БД
        public static ConnectToSql connect = new ConnectToSql();

        //Для возврата к менюшкам
        Menu menu = new Menu();

        //Создание группы
        public void AddGroup(ChatDbContext db, User user)
        {
            var addGroup = new Group();
            var userGroup = new UserGroup();
            Console.Write("Введите название группы:");
            addGroup.Name = Console.ReadLine().ToString();
            addGroup.OwnerId = user.Id;

            db.Groups.Add(addGroup);
            db.SaveChanges();

            Console.WriteLine("Группа добавлена!");


            //const string insertGroup = "INSERT INTO Groups(name,owner_id) VALUES('@Name','@id')";
            //using var SqlConnection = new SqlConnection(connect.Connect());
            //SqlConnection.Open();
            //SqlCommand cmd = new SqlCommand(insertGroup, SqlConnection);
            //SqlDataRecord insert = cmd.BeginExecuteNonQuery();
        }

        //Проверка на то является ли пользователь участником группы
        public bool IsUserInGroup(int user, int gr)
        {
            string SelectIdGroup = "SELECT * FROM dbo.UserGroups WHERE group_id = @gr";

            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(SelectIdGroup, SqlConnection);
            cmd.Parameters.Add("@gr", SqlDbType.Int).Value = gr;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var userrid = reader.GetInt32(2);
                if (userrid == user) { return true; }
                else { return false; }
            }
            return false;
        }

        //Добавление пользователя в группу
        public void addUsergroup(ChatDbContext db, int uss, int gru)
        {
            try
            {
                if (IsUserInGroup(uss, gru) == false)
                {

                    using var SqlConnection = new SqlConnection(connect.Connect());
                    SqlConnection.Open();
                    string addUsGInsert = "INSERT UserGroups (group_id, user_id) VALUES (@groupId, @userId)";
                    SqlCommand cmd = new SqlCommand(addUsGInsert, SqlConnection);
                    cmd.Parameters.Add("@gru", SqlDbType.Int).Value = gru;
                    cmd.Parameters.Add("@uss", SqlDbType.Int).Value = uss;
                    cmd.Parameters.AddWithValue("@groupid", gru);
                    cmd.Parameters.AddWithValue("@userId", uss);
                    cmd.ExecuteNonQuery();
                    SqlConnection.Close();
                    Console.WriteLine("Пользователь успешно добавлен");
                }
                else
                {

                    Console.WriteLine("Пользователь уже является участником группы");
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine(ex.Message); }
        }

        //Показ всех групп в которых пользователь является овнером +
        public void ShowGroupsWhereOwner(User user)
        {
            Console.WriteLine("Группы в которых вы являетесь админом:");
            int uid = user.Id;
            string queryShowgrooup = $"SELECT [id],[name] FROM [Groups] WHERE owner_id = @uid";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(queryShowgrooup, SqlConnection);
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = uid;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                Console.WriteLine(" ||| " + "ID группы = " + id + " ||| " + "Имя группы - " + name);
            }

        }

        //Показ всех групп в которых участвует пользователь  +
        public void ShowAllGroups(User user)
        {
            Console.WriteLine("Группы в которых вы состоите:");
            int uid = user.Id;
            string queryShowgrooup = $"SELECT [Groups].id , [name] FROM Groups INNER Join UserGroups ON user_id = @uid";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand cmd = new SqlCommand(queryShowgrooup, SqlConnection);
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = uid;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                Console.WriteLine(" ||| " + "ID группы = " + id + " ||| " + "Имя группы - " + name);
            }
        }

        //поиск логина пользователя 
        public string FindUserLoginInThisGroup(int usId, int grId)
        {
            string FindLoginQuery = "SELECT login FROM Users INNER JOIN GroupMessages ON Users.id = GroupMessages.user_id WHERE GroupMessages.user_id = @usId AND GroupMessages.group_id = @grId";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand vvd = new SqlCommand(FindLoginQuery, SqlConnection);
            vvd.Parameters.Add("@usId", SqlDbType.Int).Value = usId;
            vvd.Parameters.Add("@grId", SqlDbType.Int).Value = grId;
            SqlDataReader reader = vvd.ExecuteReader();
            string login = null;
            while (reader.Read()) { login = reader.GetString(0); }

            return login;
        }

        //Показ всех сообщений ГРУППi +
        public void ShowGroupMessages(int groupId)
        {
            try
            {
                string SelectSqlQuery = "SELECT * FROM [GroupMessages] WHERE [GroupMessages].group_id = @groupId";

                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlConnection.Open();
                SqlCommand vvd = new SqlCommand(SelectSqlQuery, SqlConnection);
                vvd.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;
                SqlDataReader reader = vvd.ExecuteReader();
                while (reader.Read())
                {
                    var group_id = reader.GetInt32(1);
                    var user_id = reader.GetInt32(2);
                    var create_date = reader.GetDateTime(3);
                    var message = reader.GetString(4);
                    Console.WriteLine(FindUserLoginInThisGroup(user_id, group_id) + ": " + message + "  |" + create_date + "|");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        //Показ Новых сообщений ГРУППi +
        public void ShowNEWGroupMessages(int groupId)
        {
            List<int> mesIdList = new List<int>();
            string SelectSqlQuery = "SELECT * FROM [GroupMessages] WHERE group_id = @groupId";

            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand vvd = new SqlCommand(SelectSqlQuery, SqlConnection);
            vvd.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;
            SqlDataReader reader = vvd.ExecuteReader();
            while (reader.Read())
            {
                var mesID = reader.GetInt32(0);
                mesIdList.Add(mesID);
            }
            while (reader.Read())
            {
                var mesID = reader.GetInt32(0);
                if (mesID > mesIdList.Last())
                {
                    var groupid = reader.GetInt32(1);
                    var user_id = reader.GetInt32(2);
                    var create_date = reader.GetDateTime(3);
                    var message = reader.GetString(4);
                    Console.WriteLine(FindUserLoginInThisGroup(user_id, groupid) + ": " + message + "  |" + create_date + "|");
                }

            }
        }

        //Показ сообщений с Группы которые пользователь может изменить и/или удалить
        public void ShowGroupMessagesDelEdit(int groupId, int userId)
        {

            string SelectSqlQuery = "SELECT * FROM [GroupMessages] WHERE group_id = @groupId AND user_id = @userId";

            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand vvd = new SqlCommand(SelectSqlQuery, SqlConnection);
            vvd.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;
            vvd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
            SqlDataReader reader = vvd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var group_id = reader.GetInt32(1);
                var user_id = reader.GetInt32(2);
                var create_date = reader.GetDateTime(3);
                var message = reader.GetString(4);
                Console.WriteLine("|Id - " + id + "| " + FindUserLoginInThisGroup(user_id, group_id) + ": " + message + "  |" + create_date + "|");
            }
        }

        //Поиск имени группы по айди 
        public string FindGroupName(int groupId)
        {
            string FindLoginQuery = "SELECT name FROM Groups WHERE group_id = @groupId";
            using var SqlConnection = new SqlConnection(connect.Connect());
            SqlConnection.Open();
            SqlCommand vvd = new SqlCommand(FindLoginQuery, SqlConnection);
            vvd.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;
            SqlDataReader reader = vvd.ExecuteReader();
            var name = reader.GetString(0);
            return name;
        }

        //Отправить сообщение в группу - 
        public void SendGroupMessage(ChatDbContext db, User user, int groupId)
        {
            try
            {
                var newMessage = new GroupMessage();
                //Console.WriteLine($"%{FindGroupName(groupId)}%");
                newMessage.UserId = user.Id;
                newMessage.CreateDate = DateTime.Now;
                newMessage.GroupId = groupId;

                Console.Write("Введите текст сообщения: ");
                newMessage.Message = Console.ReadLine();
                if (newMessage.Message == "/end") { menu.GroupMenu(user); }
                else if (newMessage.Message == "/edit") { EditGroupMessage(db, user.Id, groupId); }
                else if (newMessage.Message == "/delete") { DeleteGroupMessage(db, user.Id, groupId); }
                else
                {
                    db.GroupMessages.Add(newMessage);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            //Console.WriteLine($"|ID Группы: {newMessage.GroupId}| Ваш ID{newMessage.UserId}|\n|{newMessage.Message}|\n|{newMessage.CreateDate}|");
        }

        //Редактировать GROUP сообщения   +
        public void EditGroupMessage(ChatDbContext db, int userId, int groupId)
        {
            try
            {
                ShowGroupMessagesDelEdit(groupId, userId);
                Console.Write("Выберите ID сообщения которое хотите изменить:");
                int mesID = int.Parse(Console.ReadLine());
                Console.Write("Введите новый текст сообщения: ");
                string newMessage = Console.ReadLine().ToString();
                const string updatePrvtMess = "UPDATE GroupMessages SET [message] = @newMessage WHERE id = @mesID";
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

        //Удаление GROUP сообщений +
        public void DeleteGroupMessage(ChatDbContext db, int userId, int groupId)
        {
            try
            {
                ShowGroupMessagesDelEdit(groupId, userId);
                Console.Write("Выберите ID сообщения которое хотите удалить:");
                int mesID = int.Parse(Console.ReadLine());
                const string deletePrvtMess = "DELETE FROM GroupMessages WHERE id = @mesID";
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

        public void DeleteGroup(ChatDbContext db, User user)
        {
            try
            {
                ShowGroupsWhereOwner(user);
                Console.Write("Выберите ID группы которую хотите удалить:");
                int GrID = int.Parse(Console.ReadLine());
                const string deletePrvtMess = "DELETE FROM Groups WHERE id = @GrID";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlCommand vvd = new SqlCommand(deletePrvtMess, SqlConnection);
                vvd.Parameters.Add("@GrID", SqlDbType.Int).Value = GrID;
                SqlConnection.Open();
                vvd.ExecuteNonQuery();
                db.SaveChanges();
                Console.WriteLine("Группа успешно удалена");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
