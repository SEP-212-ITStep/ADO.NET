using FinalExam.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Services
{
    internal class Groups
    {
        public bool IsGroupUnique(string groupName, int CreatorId)
        {
            try
            {
                int result = new();
                const string SqlQuery = "SELECT id FROM dbo.Groups WHERE owner_id = @ownerId AND name = @GroupName";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.AddWithValue("@ownerId", CreatorId);
                cmd.Parameters.AddWithValue("@GroupName", groupName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                if (result != 0) { Console.Clear(); Console.WriteLine("Error: Group is not unique."); return false; }
                else { return true; }
            }
            catch (Exception ex) { Console.WriteLine("Error: Checking group unique {0}", ex.Message); return false; }
        }

        public int GetGroupId(string GroupName)
        {
            try
            {
                int result = new();
                const string SqlQuery = "SELECT id FROM dbo.Groups WHERE name = @groupName";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
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

        public string GetGroupName(User user, int id)
        {
            try
            {
                string result = new string("");
                const string SqlQuery = "SELECT name FROM dbo.Groups WHERE id = @groupName";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.AddWithValue("@groupName", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }
                return result;
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: Getting Group Id {0}", ex.Message); return ""; }
        }

        public bool CreateGroup(User creator, string groupName)
        {
            try
            {
                if (IsGroupUnique(groupName, creator.Id) == false)
                {
                    return false;
                }
                else
                {
                    Group group = new Group();
                    group.Owner = creator;
                    group.Name = groupName;
                    group.OwnerId = creator.Id;
                    SqlConnection sqlConnection1 = new SqlConnection(ConnectionStringProvider.ConnectionString);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT Groups (name, owner_id) VALUES (@name, @owner_id)";
                    cmd.Parameters.AddWithValue("@name", groupName);
                    cmd.Parameters.AddWithValue("@owner_id", creator.Id);
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();
                    Thread.Sleep(5000);

                    return true;
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: Group Creation {0}", ex.Message); Thread.Sleep(5000); return false; }
        }

        public bool AddUserToAGroup(User user, string groupName)
        {
            try
            {
                if(IsUserInGroup(user, groupName)==false)
                {
                    UserGroup tmp = new UserGroup();    
                    SqlConnection sqlConnection1 = new SqlConnection(ConnectionStringProvider.ConnectionString);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT UserGroups (group_id, user_id) VALUES (@group_id, @user_id)";
                    cmd.Parameters.AddWithValue("@group_id", GetGroupId(groupName));
                    cmd.Parameters.AddWithValue("@user_id", user.Id);
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("User is already in group");
                    Thread.Sleep(5000);
                    return false;
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine(ex.Message); Thread.Sleep(5000); return false; }
        }

        public bool IsUserInGroup(User user, string groupName)
        {
            try
            {
                const string SqlQuery = "SELECT id FROM dbo.UserGroups WHERE group_id = @groupId AND user_id = @userId";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.AddWithValue("@groupId", GetGroupId(groupName));
                cmd.Parameters.AddWithValue("@userId", user.Id);
                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                while (reader.Read())
                {
                    reader.GetInt32(0);
                    counter++;
                }
                if (counter != 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch(Exception ex) { Console.Clear(); Console.WriteLine("Error: cheching groups contain user, {0}", ex.Message); Thread.Sleep(5000); return true; }
        }
    }
}
