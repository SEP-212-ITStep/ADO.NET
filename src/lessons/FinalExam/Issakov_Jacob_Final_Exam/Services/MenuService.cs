using Issakov_Jacob_Final_Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issakov_Jacob_Final_Exam.Services
{
    public class MenuService
    {
        public static void externalMenu()
        {
            using var DbContext = new ChatDbContext();

            Console.WriteLine("Select menu item:");
            Console.WriteLine("1. Registration");
            Console.WriteLine("2. Sign in");
            int ch = Int32.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    UserService.Registration(DbContext);
                    break;
                case 2:
                    Console.Write("Enter login: ");
                    string login = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    UserService.SignIn(login, password);
                    if (UserService.SignIn(login, password) == true)
                    {
                        internalMenu();
                    }
                    break;
                default:
                    break;
            }
        }
        public static void internalMenu()
        {
            Console.WriteLine("Select menu item:");
            Console.WriteLine("1. Create Group: ");
            Console.WriteLine("2. Delete Group: ");
            Console.WriteLine("3. Private Messages Actions: ");
            Console.WriteLine("9. Get Message History: ");
            Console.WriteLine("6. Add User to BlackList: ");
            Console.WriteLine("7. Show all Users: ");
            Console.WriteLine("8. Show all Groups: ");

            int ch = Int32.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter your id: ");
                    int id = int.Parse(Console.ReadLine());
                    GroupService.CreateGroup(id);
                    break;
                case 2:
                    Console.WriteLine("Enter group Name: ");
                    string groupName = Console.ReadLine();
                    GroupService.DeleteGroup(groupName);
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("4. Send Private Message: ");
                        Console.WriteLine("5. Delete Private Message: ");
                        Console.WriteLine("6. Edit Private Message: ");
                        Console.WriteLine("7. Get Message History");
                        Console.WriteLine("0. Back To Internal Menu: ");
                        ch = Int32.Parse(Console.ReadLine());
                        if (ch == 0)
                        {
                            internalMenu();
                        }
                        switch (ch)
                        {
                            case 4:
                                UserService.ShowAllUsers();
                                Console.WriteLine("Enter your id: ");
                                id = int.Parse(Console.ReadLine());
                                MessagesService.WritePrivateMessage(id);
                                break;
                            case 5:
                                Console.WriteLine("Enter from id: ");
                                int fromId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter destination id: ");
                                int destinationId = int.Parse(Console.ReadLine());
                                MessagesService.DeletePrivateMessage(fromId, destinationId);
                                break;
                            case 6:
                                Console.WriteLine("Enter from id: ");
                                fromId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter destination id: ");
                                destinationId = int.Parse(Console.ReadLine());
                                MessagesService.EditPrivateMessage(fromId, destinationId);
                                break;
                        }
                    } while (ch != 0);
                    break;
                case 6:
                    GroupService.AddToBlackList();
                    break;
                case 9:
                    bool temp = true;
                    do
                    {
                        Console.WriteLine("Enter from id: ");
                        int fromId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter destination id: ");
                        int destinationId = int.Parse(Console.ReadLine());
                        MessagesService.ShowPrivateMessages(fromId, destinationId);
                        Thread.Sleep(10000);
                        Console.WriteLine("Continue watch message history? (yes or no)");
                        string answer = Console.ReadLine();
                        if (answer == "no")
                        {
                            temp = false;
                        }
                    } while (temp == true);
                    internalMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
