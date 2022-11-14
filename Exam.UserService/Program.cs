using Exam.UserService.Data;
using Exam.UserService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
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
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Выберите пункты меню:");
                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Войти");
                switch (ch)
                {
                    case 1:
                        Registration(dbContext);
                        break;

                    case 2:
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
            Console.Write("Enter login: ");
            newUser.Login = Console.ReadLine();
            Console.Write("Enter password: ");
            newUser.Password = Console.ReadLine();
            db.Users.Add(newUser);
            db.SaveChanges();
            Console.WriteLine("Added!");
        }

        public static void EnterTo()
        {
            User newUser = new User();
            string connectionL = "SELECT [login] FROM [ChatDb].[dbo].[Users]";
            string connectionP = "SELECT [password] FROM [ChatDb].[dbo].[Users]";

        }
    }

}