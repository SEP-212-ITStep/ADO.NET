using FinalExam.Data;
using FinalExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Services
{
    internal class Menu
    {
        public void ChatMenu()
        {
            UserServices userService = new UserServices();
            using var DbContext = new ChatDbContext();
            User a = new();

            try
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("1. Sign in");
                Console.WriteLine("2. Sign up ");
                int ch = Int32.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        string login = "", password = "";
                        Console.Write("Enter login: ");
                        login = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password = Console.ReadLine();
                        UserMenu(userService.SignIn(login, password));
                        a.Login = login;
                        break;
                    case 2:
                        string login_r = ""; string password_r = "";
                        Console.Write("Enter login: ");
                        login_r = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password_r = Console.ReadLine();
                        if (userService.Registration(DbContext, login_r, password_r)) { UserMenu(userService.SignIn(login_r, password_r)); };
                        break;
                }
            }
            catch (UserNotFoundException e)
            {
                ChatMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UserMenu(bool signIn)
        {
            if (signIn == true)
            {
                Console.WriteLine("1. Send message to user");
                Console.WriteLine("2. Send message to group");
                Console.WriteLine("3. Add group");
                Console.WriteLine("4. Block user");
                Console.WriteLine("0. Log out");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 0:

                        break;
                }
            }
        }
    }
}
