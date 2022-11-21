using FinalExam.Data;
using FinalExam.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FinalExam.Services
{
    internal class UserServices
    {
        
        SqlConnection UserServiceConnection = new SqlConnection("Server=127.0.0.1;Database=ChatDb;Trusted_Connection=True;Encrypt=false");
        ChatDbContext asirush_srv = new();
        Messages msg = new();

        public User Registration(string Login, string Password)
        {
            try
            {
                User newUser = new User();
                newUser.Login = Login;
                newUser.Password = Password;
                List<string> tmp = GetActiveUsers();

                if (tmp.Contains(Login))
                {
                    Console.WriteLine("Error: registration error User exists");
                    return null;
                }
                else
                {
                    // prepare command string
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "insert into Users (login, password) values (@Login, @Password)";
                    cmd.Parameters.Add(new SqlParameter("Login", Login));
                    cmd.Parameters.Add(new SqlParameter("Password", HashPass(Password)));
                    cmd.ExecuteNonQuery();
                    return newUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: registration error ", ex.Message);
                return null;
            }
        }
        public User SignIn(string login, string password)
        {
            try
            {
                const string SqlQuery = "SELECT [id], [login], [password] FROM dbo.Users WHERE login = @Login";
                SqlCommand cmd = new SqlCommand(SqlQuery, UserServiceConnection);
                SqlConnection.Open();
                cmd.Parameters.Add("Login", SqlDbType.VarChar, 500).Value = login;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var pass = reader.GetString(2);
                    if (HashPass(password) == reader["password"].ToString())
                    {
                        Console.WriteLine("Welcome!");
                        User AuthorizedUser= new User();
                        AuthorizedUser.Login = reader.GetString(1);
                        AuthorizedUser.Password = reader.GetString(2);
                        AuthorizedUser.Id= reader.GetInt32(0);
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
                using var SqlConnection = new SqlConnection(UserServiceConnection.ToString());
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
                using (SqlConnection connection = new SqlConnection(UserServiceConnection.ToString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string user = new string();
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
