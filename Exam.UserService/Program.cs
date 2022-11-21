using Exam.UserService.Data;
using Exam.UserService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Exam.UserService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Scaffold - DbContext 'Data Source=223-9;Initial Catalog=ChatDb;Trusted_Connection=true;Encrypt=false' Microsoft.EntityFrameworkCore.SqlServer - ContextDir Data - OutputDir Models

            using var dbContext = new ChatDbContext();
            try
            {
                Console.WriteLine("Выберите пункты меню:");
                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Войти");
                Console.WriteLine("3.Показать список пользователей");
                int ch = Convert.ToInt32(Console.ReadLine());
                
                switch (ch)
                {
                    case 1:
                        Registration(dbContext);
                        break;

                    case 2:
                        break;
                    case 3:

                        break;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void Registration(ChatDbContext db)
        {


            User newUser = new User();
            try
            {
                if (newUser.Login!=null)
                {
                    Console.WriteLine("Пользователь:" + newUser.Login + "уже зарегестрирован!");
                }
           
                else
                {
                    Console.Write("Enter login: ");
                    newUser.Login = Console.ReadLine();
                    Console.Write("Enter password: ");
                    newUser.Password = HashPass(Console.ReadLine());
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    Console.WriteLine("Added!");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Пользователь: " + newUser.Login + " уже зарегестрирован!", ex);
            }
        }

        public static void EnterTo()
        {
            User newUser = new User();
            string connectionL = "SELECT [login] FROM [ChatDb].[dbo].[Users]";
            string connectionP = "SELECT [password] FROM [ChatDb].[dbo].[Users]";

        }
        static string HashPass(string pass)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));
            return Convert.ToBase64String(hash);
        }
        //static string GetAllUsers()
        //{
        //    Console.WriteLine();
        //}
    }

}


