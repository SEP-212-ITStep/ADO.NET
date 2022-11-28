using Issakov_Jacob_Final_Exam.Data;
using Issakov_Jacob_Final_Exam.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issakov_Jacob_Final_Exam.Services
{

    public class MessagesService
    {
        const string ConnectionString = "Server=DESKTOP-6O1ENUJ;Database=ChatDb;Trusted_Connection=true;Encrypt=false";
        public static void WritePrivateMessage(int fromUserId)
        {
            try
            {
                using var db = new ChatDbContext();
                Console.WriteLine("Enter the destination Id: ");
                int destinationId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the message text: ");
                string messageText = Console.ReadLine();
                var users = db.Users;
                bool existFrom = false;
                bool existDestination = false;
                foreach (var user in users)
                {
                    if (user.Id == fromUserId)
                    {
                        existFrom = true;
                    }
                }
                foreach (var user in users)
                {
                    if (user.Id == destinationId)
                    {
                        existDestination = true;
                    }
                }
                if (existFrom == false || existDestination == false)
                {
                    Console.WriteLine("\nInvalid id entered");
                }
                else
                {
                    while (messageText.IsNullOrEmpty())
                    {
                        Console.WriteLine("Nothing entered. \nWrite something: ");
                        messageText = Console.ReadLine();
                    }
                    PrivateMessage message = new PrivateMessage();
                    message.FromUserId = fromUserId;
                    message.ToUserId = destinationId;
                    message.Message = messageText;
                    message.CreateDate = DateTime.Now;
                    db.PrivateMessages.Add(message);
                    db.SaveChanges();
                    Console.WriteLine("The mwssage was sent");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } // +
        public static void DeletePrivateMessage(int fromUserId, int toUserId)
        {
            try
            {
                MessagesService.ShowPrivateMessages(fromUserId, toUserId);
                Console.WriteLine("Enter the message id, you want to delete: ");
                int messageId = int.Parse(Console.ReadLine());
                using var db = new ChatDbContext();
                var users = db.Users.ToList();
                var privateMessages = db.PrivateMessages.ToList();
                bool existFrom = false;
                bool existTo = false;
                bool mId = false;
                foreach (var user in users)
                {
                    if (user.Id == fromUserId)
                    {
                        existFrom = true;
                    }
                }
                foreach (var user in users)
                {
                    if (user.Id == toUserId)
                    {
                        existTo = true;
                    }
                }
                foreach (var m in privateMessages)
                {
                    if (m.Id == messageId)
                    {
                        mId = true;
                    }
                }
                if (existFrom == false || mId == false || existTo == false)
                {
                    Console.WriteLine("\nInvalid id entered");
                }
                foreach (var item in privateMessages)
                {
                    if (item.FromUserId == fromUserId && item.ToUserId == toUserId && item.Id == messageId)
                    {
                        Console.WriteLine($"id: {item.Id}\t Creation Date: {item.CreateDate}");
                        Console.WriteLine($"\nFromUserId: {item.FromUserId}\t ToUserId: {item.ToUserId}\nMessage Text: {item.Message}");
                        item.IsDeleted = true;
                        db.PrivateMessages.Remove(item);
                        db.SaveChanges();
                        Console.WriteLine("The message was successfully deleted");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } // +
        public static void EditPrivateMessage(int fromUserId, int toUserId)
        {
            try
            {
                MessagesService.ShowPrivateMessages(fromUserId, toUserId);
                Console.WriteLine("Enter the message id, you want to edit: ");
                int messageId = int.Parse(Console.ReadLine());
                using var db = new ChatDbContext();
                var users = db.Users.ToList();
                var privateMessages = db.PrivateMessages.ToList();
                bool existFrom = false;
                bool existTo = false;
                bool mId = false;
                foreach (var user in users)
                {
                    if (user.Id == fromUserId)
                    {
                        existFrom = true;
                    }
                }
                foreach (var user in users)
                {
                    if (user.Id == toUserId)
                    {
                        existTo = true;
                    }
                }
                foreach (var m in privateMessages)
                {
                    if (m.Id == messageId)
                    {
                        mId = true;
                    }
                }
                if (existFrom == false || mId == false || existTo == false)
                {
                    Console.WriteLine("\nInvalid id entered");
                }
                foreach (var item in privateMessages)
                {
                    if (item.FromUserId == fromUserId && item.ToUserId == toUserId && item.Id == messageId)
                    {
                        Console.WriteLine($"id: {item.Id}\t Creation Date: {item.CreateDate}");
                        Console.WriteLine($"\nFromUserId: {item.FromUserId}\t ToUserId: {item.ToUserId}");
                        Console.WriteLine("Enter the edited message text: ");
                        string newMessageText = Console.ReadLine();
                        while (newMessageText.IsNullOrEmpty())
                        {
                            Console.WriteLine("Nothing entered. \nWrite something: ");
                            newMessageText = Console.ReadLine();
                        }
                        item.Message = newMessageText;

                        db.PrivateMessages.Update(item);
                        db.SaveChanges();
                        Console.WriteLine("The message was successfully edited");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } // +
        //public static void GetMessagesHistory(int fromUserId, int toUserId)
        //{
        //    do
        //    {
        //        ShowPrivateMessages(fromUserId, toUserId);
        //        Thread.Sleep(5000);

        //    } while ();
        //}
        public static void ShowPrivateMessages(int fromUserId, int destinationId)
        {
            try
            {
                string sqlQuery = $"SELECT * FROM PrivateMessages WHERE from_user_id={fromUserId} AND to_user_id={destinationId}";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, SqlConnection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var messageId = reader["Id"].ToString();
                    var messageText = reader["message"].ToString();
                    var fromId = reader["from_user_id"].ToString();
                    var toId = reader["to_user_id"].ToString();
                    var createDate = reader["create_date"].ToString();
                    Console.WriteLine($"\nMessage Id: {messageId}\t\t\tCreation Date: {createDate}\nFrom Id: {fromId}\t\t\t" +
                                      $"To Id: {toId}\nMessage Text: {messageText}\n-------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
