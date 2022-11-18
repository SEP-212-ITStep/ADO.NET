using FinalExam.Data;
using FinalExam.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace FinalExam.Services
{
    internal class UserServices
    {
        const string ConnectionString = "Server=127.0.0.1;Database=ChatDb;Trusted_Connection=True;Encrypt=false";
        ChatDbContext asirush_srv = new();
        Messages msg = new();
        public bool Registration(ChatDbContext db, string Login, string Password)
        {
            try
            {
                List<string> tmp = new List<string>();

                User newUser = new User();
                newUser.Login = Login;
                newUser.Password = Password;
                db.Users.Add(newUser);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: registration error ", ex.Message);
                return false;
            }
        }
        public bool SignIn(string login, string password)
        {
            try
            {
                const string SqlQuery = "SELECT [password] FROM dbo.Users WHERE login = @Login";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.Add("Login", SqlDbType.VarChar, 500).Value = login;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var pass = reader.GetString(1);
                    if (HashPass(password) == reader["password"].ToString())
                    {
                        Console.WriteLine("Welcome!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Password is wrong!");
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
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
    }
}
