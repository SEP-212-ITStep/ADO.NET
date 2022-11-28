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
                Console.WriteLine("3. Add User to a Group");
                Console.WriteLine("4. Block user");
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
                        Console.Clear();
                        AddUser(user);
                        UserMenu(user);
                        break;
                    case 4: 
                        Console.Clear();
                        UserMenu(user);
                        break;
                    case 0:
                        AuthMenu();
                        break;
                }
            }
        }
        public void AddUser(User user)
        {
            try
            {
                if (user != null) { }
                Console.WriteLine("Select the group: ");
                Messages msg = new(); Groups grps = new(); User nurik = new();
                List<Group> groups = msg.CheckUsersGroupsList(user);
                int k = 0, k1 = 0; int tmp_user_id = 0, tmp_group_id = 0;
                foreach (var item in groups)
                {
                    Console.WriteLine("{0}. {1}", k, item.Name);
                    k++;
                }
                Console.WriteLine("Select group");
                Console.Write("{0}: ", user.Login); int answer = Console.Read();

                foreach (var item in groups)
                {
                    if (k1 == answer)
                    {
                        tmp_group_id = item.Id;
                    }
                    k1++;
                }
                List<string> users = msg.GetActiveUsers(); int user_counter = 0;
                foreach(var item in users)
                {
                    Console.WriteLine("{0}. {1}", user_counter, item);
                    user_counter++;
                }

                grps.AddUserToAGroup(nurik, grps.GetGroupName(user, tmp_group_id));
                UserMenu(user);
            }
            catch(Exception e) { Console.WriteLine("Error: {0}", e.Message);}
        }
        public void MessagesMenu(User user)
        {
            try
            {
                Messages msg = new();
                List<User> users = msg.GetActiveUsersList();
                List<Group> groups = msg.CheckUsersGroupsList(user);

                Console.Clear();
                Console.WriteLine("Private Chats: ");
                Console.WriteLine("--------------");
                int list_counter = 0, user_counter = 0, group_counter = 0;
                foreach (var item in users) { Console.WriteLine("{0}. {1}", list_counter, item.Login); list_counter++; user_counter++; }
                Console.WriteLine("");
                Console.WriteLine("Group Chats: ");
                Console.WriteLine("--------------");
                foreach (var item in groups) {Console.WriteLine("{0}. {1}", list_counter, item.Name); list_counter++; group_counter++; }
                
                int answer = int.Parse(Console.ReadLine());

                if(answer <= user_counter)
                {
                    for (int i = 0; i <= user_counter; i++)
                    {
                        if (i == answer)
                        {
                            ChatMenu(user, users[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= group_counter; i++)
                    {
                        if (i == answer-user_counter)
                        {
                            GroupChatMenu(user, groups[i].Name);
                        }
                    }
                }
                UserMenu(user);
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
                    Console.Clear();
                    List<PrivateMessage> history = msg.GetPrivateMessages(user, recepient);
                    foreach (var item in history) { Console.WriteLine("{0}| {1} {2} {3}", item.FromUser.Login, item.ToUser.Login, item.CreateDate.ToString(), item.Message); }
                    Console.WriteLine("Commands: u - update, w - write message, q - quit chat");
                    Console.Write("{0}: ", user.Login);
                    string answer = Console.ReadLine();
                    if (answer == "u")
                    {
                        ChatMenu(user, recepient);
                    }
                    if (answer == "w") { Console.Write("{0} message: ", user.Login); string mssg = Console.ReadLine(); msg.SendPrivateMessage(user, mssg, recepient); ChatMenu(user, recepient); }
                    if (answer == "q")
                    {
                        Console.Clear(); MessagesMenu(user);
                    }
                }
                MessagesMenu(user);
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: {0}", ex.Message); }
        }
        public void GroupChatMenu(User user, string groupName)
        {
            try
            {
                Messages msg = new(); Groups grps = new Groups();
                string Comnd = "";
                while (Comnd != "q" || Comnd != "w")
                {
                    Console.Clear();
                    
                    List<string> history = msg.GetGroupMessages(user, groupName);
                    foreach (var line in history) { Console.WriteLine(line); }
                    Console.WriteLine("Commands: u - update, w - write message, q - quit chat");
                    Console.Write("{0}: ", user.Login);
                    string answer = Console.ReadLine();
                    if (answer == "u")
                    {
                        GroupChatMenu(user, groupName);
                    }
                    if (answer == "w") { Console.Write("{0}: ", user.Login); string mssg = Console.ReadLine(); msg.SendGroupMessage(user, mssg, grps.GetGroupId(groupName)); GroupChatMenu(user, groupName); }
                    if (answer == "q") { Console.Clear(); MessagesMenu(user); }
                }
                MessagesMenu(user);
            }
            catch (Exception ex) { Console.Clear(); Console.WriteLine("Error: {0}", ex.Message); }
        }
    }
}
