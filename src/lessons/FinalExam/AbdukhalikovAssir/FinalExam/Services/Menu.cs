using FinalExam.Data;
using FinalExam.Models;
using Microsoft.VisualBasic;
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


            try
            {
                Console.Clear();
                Console.WriteLine("Welcome!");
                Console.WriteLine("1. Sign in");
                Console.WriteLine("2. Sign up ");
                Console.Write("chat: ");
                int ch = Int32.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        string login = "", password = "";
                        Console.Write("Enter login: ");
                        login = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password = Console.ReadLine();
                        User test = userService.SignIn(login, password);
                        if (test != null) { UserMenu(test); }
                        else { ChatMenu(); }
                        break;
                    case 2:
                        string login_r = ""; string password_r = "";
                        Console.Write("Enter login: ");
                        login_r = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password_r = Console.ReadLine();
                        if (userService.Registration(login_r, password_r)!=null) { UserMenu(userService.SignIn(login_r, password_r)); };
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UserMenu(User user)
        {
            if (user != null)
            {
                Console.Clear();
                Console.WriteLine("1. Messages");
                Console.WriteLine("2. Create group");
                Console.WriteLine("3. Block user");
                Console.WriteLine("0. Log out");
                Console.Write("{0}: ", user.Login);
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        MessagesMenu(user);
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Create a Group Name: "); string grName = Console.ReadLine();
                        Groups group = new Groups();
                        group.CreateGroup(user, grName);
                        UserMenu(user);
                        break;
                    case 3:
                        break;
                    case 0:
                        ChatMenu();
                        break;
                }
            }
        }

        public void MessagesMenu(User user)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("1. Show Messages");
                Console.WriteLine("2. Create Message");
                Console.WriteLine("0. Go Back");
                Console.Write("{0}: ", user.Login);

                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Messages msgs = new Messages();
                        int k = 0;
                        Console.WriteLine("Private Chats:");
                        foreach (var tmp in msgs.ShowPrivateChats(user))
                        {
                            Console.WriteLine("{0}. {1}", k, tmp);
                        }

                        Groups grps = new Groups();
                        Console.WriteLine("Group Messages: ");


                        if (Console.ReadLine() != null) { MessagesMenu(user); }
                        break;

                    case 2:

                        break;

                    case 0:
                        UserMenu(user);
                        break;
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: messages menu {0}", ex.Message); }
        }
    }
}
