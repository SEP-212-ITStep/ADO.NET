using Nurik_Exam.Data;
using Nurik_Exam.Models;

namespace Nurik_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var DbContext = new ChatDbContext();
            try
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Регистрация");
                int ch = Int32.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Registration(DbContext);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Registration(ChatDbContext db)
        {
            User newUser = new User();
            Console.Write("Введите логин: ");
            newUser.Login = Console.ReadLine();
            Console.Write("Введите пароль: ");
            newUser.Password = Console.ReadLine();
            db.Users.Add(newUser);
            db.SaveChanges();
            Console.WriteLine("Успешно добавлено!");
        }

        
    }
}