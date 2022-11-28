using Issakov_Jacob_Final_Exam.Data;
using Issakov_Jacob_Final_Exam.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Issakov_Jacob_Final_Exam.Services
{
    public class UserService
    {
        public static void Registration(ChatDbContext db)
        {
            try
            {
                User newUser = new User();
                Console.Write("Enter login: ");
                newUser.Login = Console.ReadLine();
                Console.Write("Enter password: ");
                newUser.Password = HashPass(newUser.Password = Console.ReadLine());
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    if (user.Login == newUser.Login)
                    {
                        Console.WriteLine("User with such Login was already registrated: ");
                        while (user.Login == newUser.Login)
                        {
                            if (user.Login == newUser.Login)
                            {
                                Console.WriteLine("Enter unique Login: ");
                                newUser.Login = Console.ReadLine();
                            }
                        }
                    }
                }
                db.Users.Add(newUser);
                db.SaveChanges();
                Console.WriteLine("Added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static string HashPass(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(
                Encoding.UTF8.GetBytes(password)
            );
            return Convert.ToBase64String(hash);
        } // +
        public static bool SignIn(string login, string password)
        {
            try
            {
                const string SqlQuery = "SELECT [login], [password] FROM dbo.Users WHERE login = @Login";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.connectionString);
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.Add("Login", SqlDbType.VarChar, 500).Value = login;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var pass = reader.GetString(1);
                    if (HashPass(password) == reader["password"].ToString())
                    {
                        Console.WriteLine("Wellcome!");
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
        } // +
        public static void ShowAllUsers()
        {
            try
            {
                string sqlQuery = $"SELECT * FROM Users";
                using var SqlConnection = new SqlConnection(ConnectionStringProvider.connectionString);
                SqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, SqlConnection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["Id"].ToString();
                    var login = reader["Login"].ToString();
                    var password = reader["Password"].ToString();
                    Console.WriteLine($"Id: {id}, Login: {login}, Password: {password}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
