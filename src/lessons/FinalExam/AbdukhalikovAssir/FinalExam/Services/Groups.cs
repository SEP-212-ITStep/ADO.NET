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
                cmd.Parameters.AddWithValue("@owner_id", CreatorId);
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

        public bool CreateGroup(User creator, string groupName)
        {
            try
            {
                if (IsGroupUnique(groupName, creator.Id) == false)
                {
                    return false;
                }
                else {
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

                    return true;
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: Group Creation {0}", ex.Message); return false; }
        }

        public bool AddUserToAGroup(User user, string groupName)
        {
            try
            {

                return true;
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine(ex.Message); return false; }
        }


    }
}
