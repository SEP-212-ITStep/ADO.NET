﻿using FinalExam.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Services
{
    internal class Messages
    {
        public void ShowChats(User user)
        {
            try
            {
                Console.WriteLine("Private chats:");
                Console.WriteLine("--------------");
                ShowPrivateChats(user);
                Console.WriteLine("");
                Console.WriteLine("Group chats:");
                CheckUsersGroups(user);
                                
            }
            catch(Exception ex) { Console.Clear(); Console.WriteLine("Error: chatshowing error {0}", ex.Message); }
        }
        public List<int> CheckUsersGroupsIds(User user)
        {
            try
            {
                List<int> groups = new List<int>();
                const string SqlQuery = "SELECT group_id FROM UserGroups JOIN Groups ON UserGroups.group_id = Groups.id WHERE user_id = @user_id;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@user_id", user.Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int groupId = new();
                        groupId = reader.GetInt32(0);
                        groups.Add(groupId);
                    }
                    return groups;
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: checking groups {0}", ex.Message); return null; }
        }
        public List<string> CheckUsersGroups(User user)
        {
            try
            {
                List<string> groups = new List<string>();
                const string SqlQuery = "SELECT name FROM UserGroups JOIN Groups ON UserGroups.group_id = Groups.id WHERE user_id = @user_id;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@user_id", user.Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string chat = new("");
                        chat = reader.GetString(0);
                        groups.Add(chat);
                    }
                    return groups;
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: checking groups {0}", ex.Message); return null; }
        }
        public List<string> ShowPrivateChats(User user)
        {
            try
            {
                List<string> messages = new List<string>();
                const string SqlQuery = "SELECT * FROM PrivateMessages WHERE from_user_id = @user_id OR to_user_id = @user_id;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@user_id", user.Id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string chat = new("");
                        chat = reader.GetString(0);
                        messages.Add(chat);
                    }
                    return messages;
                }
            }
            catch(Exception ex) { Console.WriteLine("Error: Chat Selection Error {0}", ex.Message); return null; }
        }
        public List<User> GetActiveUsersList()
        {
            try
            {
                List<User> Users = new List<User>();
                const string SqlQuery = "SELECT * FROM dbo.Users";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Login= reader.GetString(1);
                    user.Password = "";
                    Users.Add(user);
                }
                return Users;
            }
            catch(Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message)); return null; }
        }
        public List<string> GetActiveUsers() {
            try
            {
                List<string> Users = new List<string>();
                const string SqlQuery = "SELECT [login] FROM dbo.Users";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string user = new string("");
                    user = reader.GetString(0);
                    Users.Add(user);
                }
                return Users;
            }
            catch (Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message)); return null; }
        }
        public bool SendPrivateMessage(User Sender, string Message, User Recepient)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection(ConnectionStringProvider.ConnectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT PrivateMessages (from_user_id, to_user_id, message, create_date, is_user_in_black_list, additiounal_info, is_deleted) VALUES (@from_user_id, @to_user_id, @message, @create_date, @is_user_in_black_list, @additional_info, @is_deleted)";
                cmd.Parameters.Add(new SqlParameter("from_user_id", Sender.Id));
                cmd.Parameters.Add(new SqlParameter("to_user_id", Recepient.Id));
                cmd.Parameters.Add(new SqlParameter("message", Message));
                cmd.Parameters.Add(new SqlParameter("create_date", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("is_user_in_black_list", false));
                cmd.Parameters.Add(new SqlParameter("additional_info", ""));
                cmd.Parameters.Add(new SqlParameter("is_deleted", false));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();

                return true;
            }
            catch(Exception ex) { Console.WriteLine(String.Format("Error: Sending message {0}", ex.Message)); return false; }
        }
        public bool SendGroupMessage(User sender, string message, int groupId)
        {
            try
            {

                return true;
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); return false; }
        }
    }
}
