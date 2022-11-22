using FinalExam.Data;
using FinalExam.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FinalExam.Services
{
    internal class UserServices
    {
        public int GetUserId(string userName)
        {
            try
            {
                int result = new();
                const string SqlQuery = "SELECT id FROM dbo.Users WHERE login = @userName";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.AddWithValue("@groupName", userName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }
                return result;

            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: User Id is not recognized {0}", ex.Message); return 0; }
        }
        public User Registration(string Login, string Password)
        {
            try
            {
                List<string> tmp = GetActiveUsers();
                if (tmp.Contains(Login))
                {
                    Console.WriteLine("Error: registration error User exists");
                    return null;
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                    {
                        connection.Open();
                        User newUser = new User();
                        newUser.Login = Login;
                        newUser.Password = Password;
                        SqlCommand cmd = connection.CreateCommand();
                        cmd.CommandText = "insert into Users (login, password) values (@Login, @Password)";
                        cmd.Parameters.AddWithValue("@Login", Login);
                        cmd.Parameters.AddWithValue("@Password", HashPass(Password));
                      //  cmd.Parameters.Add("Password", SqlDbType.VarChar, 50).Value = HashPass(Password);
                        cmd.ExecuteNonQuery();
                        return newUser;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: registration error {0}", ex.Message);
                Console.WriteLine(ex);
                return null;
            }
        }
        public User SignIn(string login, string password)
        {
            try
            {
                const string SqlQuery = "SELECT [id], [login], [password] FROM dbo.Users WHERE login = @Login";

                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    cmd.Parameters.Add("Login", SqlDbType.VarChar, 500).Value = login;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var pass = reader.GetString(2);
                        if (HashPass(password) == reader["password"].ToString())
                        {
                            Console.WriteLine("Welcome!");
                            User AuthorizedUser = new User();
                            AuthorizedUser.Login = reader.GetString(1);
                            AuthorizedUser.Password = reader.GetString(2);
                            AuthorizedUser.Id = reader.GetInt32(0);
                            return AuthorizedUser;
                        }
                        else
                        {
                            Console.WriteLine("Password is wrong!");
                            return null;
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
        }
        static string HashPass(string pass)
        {
            try
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(
                    Encoding.UTF8.GetBytes(pass)
                );
                return Convert.ToBase64String(hash);
            }
            catch (Exception ex) { Console.WriteLine("Error: hashing {0}", ex.Message); return ""; }

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
                    user.Login = reader.GetString(1);
                    user.Password = "";
                    Users.Add(user);
                }
                return Users;
            }
            catch (Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message)); return null; }
        }

        public List<string> GetActiveUsers()
        {
            try
            {
                List<string> Users = new List<string>();
                const string SqlQuery = "SELECT [login] FROM dbo.Users";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string user = new string("");
                        user = reader.GetString(0);
                        Users.Add(user);
                    }
                    return Users;
                }
            }
            catch (Exception ex) { Console.WriteLine(String.Format("Error: GetActiveUsers, {0}", ex.Message)); return null; }
        }
    }
}
