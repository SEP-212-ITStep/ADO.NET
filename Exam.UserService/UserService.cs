using Exam.UserService.Data;
using Exam.UserService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Exam.UserService
{
    public class UserService
    {
        //Путь к БД
        public static ConnectToSql connect = new ConnectToSql();

        //Экземпляр класса "Menu" для упращения рвботы с функционалом
        Menu menu = new Menu();

        //Регистрация
        public void Registration(ChatDbContext db)
        {
            User newUser = new User();
            Console.Write("Enter login: ");
            newUser.Login = Console.ReadLine();
            Console.Write("Enter password: ");
            newUser.Password = HashPass(newUser.Password = Console.ReadLine());
            if (!(EnterTo(newUser.Login, newUser.Password)))
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                Console.WriteLine("Added!");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        //Хэширование пароля
        static string HashPass(string pass)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(
                Encoding.UTF8.GetBytes(pass)
            );
            return Convert.ToBase64String(hash);
        }

        //Вход в аккаунт
        public bool EnterTo(string login, string password)
        {

            try
            {
                const string SqlQuery = "SELECT [id], [login], [password] FROM dbo.Users WHERE login = @Login";
                using var SqlConnection = new SqlConnection(connect.Connect());
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand(SqlQuery, SqlConnection);
                cmd.Parameters.Add("Login", SqlDbType.VarChar, 500).Value = login;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var pass = reader.GetString(1);
                    var id = reader.GetInt32(0);
                    if (HashPass(password) == reader["password"].ToString())
                    {
                        Console.WriteLine("Wellcome!");
                        var user = new User()
                        {
                            Id = reader.GetInt32(0),
                            Login = login,
                            Password = password
                        };
                        menu.UserMenu(user);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Password is wrong!");
                        return false;
                    }

                    // вывести список пользователей вместе с идентификатором которым можно отправить сообщение 
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}

