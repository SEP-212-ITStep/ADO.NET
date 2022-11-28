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

        public void AuthMenu()
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
                        else { AuthMenu(); }
                        break;
                    case 2:
                        string login_r = ""; string password_r = "";
                        Console.Write("Enter login: ");
                        login_r = Console.ReadLine();
                        Console.Write("Enter password: ");
                        password_r = Console.ReadLine();
                        if (userService.Registration(login_r, password_r) != null) { UserMenu(userService.SignIn(login_r, password_r)); };
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
                        AuthMenu();
                        break;
                }
            }
        }
        public void MessagesMenu(User user)
        {
            try
            {
                Messages msg = new();
                Console.Clear();
                int flag = 1;
                List<Chat> chats = new List<Chat>();
                List<User> users = msg.GetActiveUsersList();
                List<Group> groups = msg.CheckUsersGroupsList(user);
                Console.WriteLine("Private chats: ");
                foreach (var item in users)
                {
                    Console.WriteLine("{0}. {1}", flag, item.Login);
                    flag++;
                }
                Console.WriteLine("Groups: ");
                foreach (var item in groups)
                {
                    Console.WriteLine("{0}. {1}", flag, item.Name);
                    flag++;
                }
                
                Console.Write("{0}: ", user.Login); int setFlag = Console.Read();
                
                int flag2 = 1;
                foreach (var item in users)
                {
                    if (flag2 == setFlag)
                    {
                        ChatMenu(user, item);
                    }
                    else { flag2++; }
                }
                foreach (var item in groups)
                {
                    if (flag2 == setFlag)
                    {
                        GroupChatMenu(user, item.Name);
                    }
                    else { flag2++; }
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: messages menu {0}", ex.Message); }
        }
        public void ChatMenu(User user, User recepient)
        {
            try
            {
                Messages msg = new();
                string Comnd = "";
                while (Comnd != "q" || Comnd != "w")
                {
                    msg.GetPrivateMessages(user, recepient);
                    Console.WriteLine("Commands: u - update, w - write message, q - quit chat");
                    Console.Write("{0}: ", user.Login);
                    string answer = Console.ReadLine();
                    if (answer == "u")
                    {
                        ChatMenu(user, recepient);
                    }
                    if (answer == "w") { Console.Write("{0}: ", user.Login); string mssg = Console.ReadLine(); msg.SendPrivateMessage(user, mssg, recepient); ChatMenu(user, recepient); }
                    if (answer == "q") { Console.Clear(); MessagesMenu(user); }
                }
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: {0}", ex.Message); }
        }
        public void GroupChatMenu(User user, string groupName)
        {

        }
    }
}
