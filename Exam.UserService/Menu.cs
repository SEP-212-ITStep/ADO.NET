using Exam.UserService.Data;
using Exam.UserService.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
namespace Exam.UserService
{
    public class Menu
    {
        //Путь к БД
        public static ConnectToSql connect = new ConnectToSql();

        //Класс по работе с группами 
        public static GroupService grs = new GroupService();

        //Класс по работе с приватными сообщениями 
        public static Direct direct = new Direct();


        //Менюшка выходящая в САМОМ НАЧАЛЕ
        public void StartMenu()
        {
            SC();
            UserService userService = new UserService();
            using var dbContext = new ChatDbContext();
            try
            {



                Console.WriteLine("<-= MENU =->");
                Console.WriteLine("   |Регистрация >>> (1)");
                Console.WriteLine("   |Войти >>>       (2)");
                Console.WriteLine("___________________________");

                Console.Write("Выберите пункт меню: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                SC();
                switch (ch)
                {
                    case 1:
                        userService.Registration(dbContext);
                        StartMenu();
                        break;

                    case 2:
                        Console.Write("Введите логин: ");
                        string login = Console.ReadLine();
                        Console.Write("Введите пароль: ");
                        string password = Console.ReadLine();
                        userService.EnterTo(login, password);
                        break;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        //Менюшка выходящая при ВХОДЕ в аккаунт
        public void UserMenu(User user)
        {
            using var dbContext = new ChatDbContext();
            try
            {
                SC();
                Console.WriteLine($"|Your login - {user.Login}| \n\n");
                Console.WriteLine("<-= MENU =->");
                Console.WriteLine("1.Отправить приватное сообщение");
                Console.WriteLine("2.Меню групп");
                Console.WriteLine("0.Выход...");
                Console.WriteLine("_______________________________________");


                Console.Write("Выберите пункт меню: ");
                int chh = Convert.ToInt32(Console.ReadLine());
                SC();
                switch (chh)
                {
                    case 1:
                        direct.ShowUsers();
                        Console.Write("Выберите id пользователя которому хотите написать: ");
                        int toId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите \"/end\" чтоб завершить диалог");
                        Console.WriteLine("Введите \"/edit\" чтоб изменить сообщение");
                        Console.WriteLine("Введите \"/delete\" чтоб удалить сообщение");
                        Console.Write("Введите текст сообщения:");
                        while (true)
                        {
                            direct.SendPrivateMessage(dbContext, user, toId);
                        }
                        break;
                    case 2:
                        GroupMenu(user);
                        break;

                    case 0:
                        StartMenu();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GroupMenu(User user)
        {
            using var dbContext = new ChatDbContext();
            try
            {
                SC();
                Console.WriteLine($"|Your login - {user.Login}| \n\n");
                Console.WriteLine("<-= MENU =->");
                Console.WriteLine("1.Добавить группу");
                Console.WriteLine("2.Список всех групп");
                Console.WriteLine("3.Отправить сообщение в группу");
                Console.WriteLine("4.Добавить пользователя в группу");
                Console.WriteLine("5.Открыть чат с группой");
                Console.WriteLine("6.Удалить группу");
                Console.WriteLine("0.Выход...");
                Console.WriteLine("_______________________________________");


                int chh = int.Parse(Console.ReadLine());
                switch (chh)
                {
                    case 1:
                        grs.AddGroup(dbContext, user);
                        GroupMenu(user);
                        break;
                    case 2:
                        grs.ShowAllGroups(user);
                        grs.ShowGroupsWhereOwner(user);
                        Console.WriteLine("Введите /end , что-бы вернуться назад");
                        string end = Console.ReadLine();
                        if (end == "/end") { GroupMenu(user); }
                        break;
                    case 3:
                        grs.ShowAllGroups(user);
                        Console.WriteLine("Выберите группу:");
                        int groupId = Convert.ToInt32(Console.ReadLine());
                        grs.ShowGroupMessages(groupId);
                        Console.WriteLine("Введите \"/end\" чтоб завершить диалог");
                        Console.WriteLine("Введите \"/edit\" чтоб изменить сообщение");
                        Console.WriteLine("Введите \"/delete\" чтоб удалить сообщение");
                        Console.Write("Введите текст сообщения:");
                        while (true)
                        {
                            grs.SendGroupMessage(dbContext, user, groupId);
                        }
                        GroupMenu(user);
                        break;
                    case 4:
                        direct.ShowUsers();
                        Console.Write("Введите ID пользователя которого вы хотите добавить в группу:");
                        int usID = int.Parse(Console.ReadLine());
                        grs.ShowGroupsWhereOwner(user);
                        Console.Write("Введите ID группы в которую вы хотите добавить пользователя:");
                        int groupID = int.Parse(Console.ReadLine());
                        grs.addUsergroup(dbContext, usID, groupID);
                        GroupMenu(user);
                        break;
                    case 5:
                        grs.ShowAllGroups(user);
                        grs.ShowGroupsWhereOwner(user);
                        Console.Write("Введите Id группы в которой вы хотите открыть чат:");
                        int gId = int.Parse(Console.ReadLine());
                        Console.WriteLine($"%{grs.FindGroupName(gId)}%");
                        grs.ShowNEWGroupMessages(gId);
                        break;
                    case 6:
                        grs.DeleteGroup(dbContext, user);
                        break;
                    case 0:
                        UserMenu(user);
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        //Очистка и слип
        public void SC()
        {
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}

