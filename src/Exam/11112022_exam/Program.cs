namespace _11112022_exam
{
    public class Program
    {
        public static User CreateUser(string login, string password)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;

            return user;
        }
        public static void AddNewUser(string username)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=ChatDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                string password = "";
                while (password.IsNullOrEmpty())
                {
                    Console.WriteLine("create password");
                    password = Console.ReadLine();
                }
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("connection is opened");
                //hash password
                string hashpas = GetHashString(password);
                Console.WriteLine(hashpas);
                //end

                using var dbContext = new ChatDbContext();
                var theruser = CreateUser(username, hashpas);

                if (!CheckUser(username))
                {
                    dbContext.SaveChanges();
                    Console.WriteLine("successfully updated.");
                }
                else
                {
                    Console.WriteLine("error.login exist");
                }

                dbContext.Users.Add(theruser);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static bool CheckUser(string testlogin)
        {
            try
            {
                using var dbContext = new ChatDbContext();
                var users = dbContext.Users.ToList();
                foreach (var user in users)
                {
                    if (user.Login == testlogin)
                    {
                        Console.WriteLine($"{user.Login} - {user.Password}");
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
        public static void GetUsers()
        {
            try
            {
                using var dbContext = new ChatDbContext();
                var users = dbContext.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Login} - {user.Password}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void GetUsersNoEF()
        {

            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=ChatDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuery = "SELECT Id, Login, Password FROM dbo.Users ";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Id = reader["Id"].ToString();
                    var Login = reader["Login"].ToString();
                    var Password = reader["Password"].ToString();

                    Console.WriteLine($"Id- {Id}, Login - {Login}, Password - {Password}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        public static int VerifyPassword(string login, string wordpas)
        {
            try
            {
                using var dbContext = new ChatDbContext();
                var users = dbContext.Users.ToList();
                foreach (var user in users)
                {
                    if (user.Login == login && GetHashString(wordpas) == user.Password)
                    {
                        Console.WriteLine($"you are authorized");
                        InternalMenu();
                        return user.Id;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
        public static int ExternalMenu()
        {
            Console.WriteLine("Выберете:");
            Console.WriteLine("0 - Список пользователей ");
            Console.WriteLine("1 - Создать нового пользователя ");
            Console.WriteLine("2 - Авторизоваться ");
            Console.WriteLine("3 - Список пользователей(без EF Core) ");
            Console.WriteLine("4 - Получить историю переписки с пользователем ");

            int ch = Int32.Parse(Console.ReadLine());
            return ch;
        }
        public static int InternalMenu()
        {
            Console.WriteLine("Выберете:");
            Console.WriteLine("1 - Отправить сообщение в директ");
            Console.WriteLine("     3.1 - Редактировать отправленное сообщение ");
            Console.WriteLine("     3.2 - Удалить сообщение ");
            Console.WriteLine("     3.3 - Добавить пользователя в черный список ");
            Console.WriteLine("     3.4 - Записать аудиосообщение и отправить адресату ");
            Console.WriteLine("     3.5 - Отправить файл пользователю ");
            Console.WriteLine("2 - Создать группу ");
            Console.WriteLine("     4.1 - пригласить пользователя в группу ");
            Console.WriteLine("     4.2 - удалить пользователя из группы ");
            Console.WriteLine("3 - Показать историю переписки с пользователем. Выбор пользователя по логину ");
            Console.WriteLine("     5.1 - Получение новых(непрочитанных) сообщений ");
            //метод который циклично делает запрос в базу данных
            Console.WriteLine("4 - Показать список созданных групп ");
            Console.WriteLine("5 - Показать историю переписки в группе ");

            BackToInternalMenu();

            int ch = Int32.Parse(Console.ReadLine());
            return ch;
        }
        public static void InternalSwitchMenu(int switchval)
        {
            switch (ch2internal)
            {
                case 1:
                    {
                        GetUsers();
                        SendMessage(userid);
                    }
                    break;
                case 2:
                    {
                        GetPrivateMessages(userid);
                        DeletePrivateMessage(userid);
                    }
                    break;
                case 3:
                    {
                        GetPrivateMessages(userid);
                        EditPrivateMessage();
                    }
                    break;
                case 4:
                    {
                        GetUsers();
                        BlackListUser();
                    }
                    break;
            }
            int ch3internal = int.Parse(Console.ReadLine());
            switch (ch3internal)
            {
                case 1:
                    {
                        CreateGroup();
                        BackToInternalMenu();
                    }
                    break;
                case 2:
                    {
                        DeleteGroup();
                        BackToInternalMenu();
                    }
                    break;
                case 3:
                    {
                        GetAllGroups();
                        GetUsers();
                        AddUserToGroup();
                        BackToInternalMenu();
                    }
                    break;
                case 4:
                    {
                        GetAllGroups();
                        GetUsers();
                        DeleteUserFromGroup();
                        BackToInternalMenu();
                    }
                    break;
                case 5:
                    {
                        GetAllGroups();
                        GetUsers();
                        DeleteUserFromGroup();
                        BackToInternalMenu();
                    }
                    break;
            }
        }
        public static void SwitchMenu(int caseval)
        {
            switch (caseval)
            {
                case 0:
                    {
                        GetUsers();
                        BackToExternalMenu();
                    }
                    break;
                case 1:
                    {
                        string inputUsrName = "";
                        while (inputUsrName.IsNullOrEmpty())
                        {
                            Console.Write("create userlogin ");
                            inputUsrName = Console.ReadLine();
                            AddNewUser(inputUsrName);
                            //Реализовать проверку на уникальность пользователя
                        }
                        BackToExternalMenu();
                    }
                    break;
                case 2:
                    {
                        string login = "";
                        string password = "";
                        int userid = 0;
                        while (login.IsNullOrEmpty() || password.IsNullOrEmpty())
                        {
                            Console.WriteLine("input userlogin");
                            login = Console.ReadLine();
                            Console.WriteLine("input password");
                            password = Console.ReadLine();
                        }
                        userid = VerifyPassword(login, password);
                        InternalMenu();
                        Console.WriteLine("");
                        BackToInternalMenu();
                        //реализовать проверку на совпадение с базой.
                        //создать метод. Передовать в метод логин и пароль

                        int ch2internal = int.Parse(Console.ReadLine());

                        switch (ch2internal)
                        {
                            case 1:
                                {
                                    GetUsers();
                                    SendMessage(userid);
                                }
                                break;
                            case 2:
                                {
                                    GetPrivateMessages(userid);
                                    DeletePrivateMessage(userid);
                                }
                                break;
                            case 3:
                                {
                                    GetPrivateMessages(userid);
                                    EditPrivateMessage();
                                }
                                break;
                            case 4:
                                {
                                    GetUsers();
                                    BlackListUser();
                                }
                                break;
                        }
                        int ch3internal = int.Parse(Console.ReadLine());
                        switch (ch3internal)
                        {
                            case 1:
                                {
                                    CreateGroup();
                                    BackToInternalMenu();
                                }
                                break;
                            case 2:
                                {
                                    DeleteGroup();
                                    BackToInternalMenu();
                                }
                                break;
                            case 3:
                                {
                                    GetAllGroups();
                                    GetUsers();
                                    AddUserToGroup();
                                    BackToInternalMenu();
                                }
                                break;
                            case 4:
                                {
                                    GetAllGroups();
                                    GetUsers();
                                    DeleteUserFromGroup();
                                    BackToInternalMenu();
                                }
                                break;
                            case 5:
                                {
                                    GetAllGroups();
                                    GetUsers();
                                    DeleteUserFromGroup();
                                    BackToInternalMenu();
                                }
                                break;
                        }
                    }
                    break;
                case 3:
                    {
                        GetUsersNoEF();
                        BackToExternalMenu();
                    }
                    break;
                case 4:
                    {
                        GetMessageHistoryByUsername();
                        BackToExternalMenu();
                    }
                    break;
                case 5:
                    {
                        GetNewMessages();
                        BackToExternalMenu();
                    }
                    break;
            }
        }
        public static void GetMessageHistoryByUsername()
        {
            try
            {
                string firstuser = "";
                string seconduser = "";
                while (firstuser.IsNullOrEmpty() && seconduser.IsNullOrEmpty())
                {
                    firstuser = Console.ReadLine();
                    Console.WriteLine("enter group name");
                    seconduser = Console.ReadLine();
                    Console.WriteLine("enter group name");
                }
                int one = Int32.Parse(firstuser);
                int two = Int32.Parse(seconduser);
                using var dbContext = new ChatDbContext();
                var privatemessages = dbContext.PrivateMessages.ToList();

                List<PrivateMessage> messages = new List<PrivateMessage>();

                foreach (var privatemessage in privatemessages)
                {
                    if (privatemessage.FromUserId == one && privatemessage.ToUserId == two)
                    {
                        messages.Add(privatemessage);
                        Console.WriteLine($"id - {privatemessage.Id}\t CreateDate - {privatemessage.CreateDate}");
                        Console.WriteLine($"FromUserId - {privatemessage.FromUserId}\t ToUserId- {privatemessage.ToUserId}");
                        //Console.WriteLine($"Message:\n{privatemessage.Message}");
                    }
                    if (privatemessage.ToUserId == one && privatemessage.FromUserId == two)
                    {
                        messages.Add(privatemessage);
                        Console.WriteLine($"id - {privatemessage.Id}\t CreateDate - {privatemessage.CreateDate}");
                        Console.WriteLine($"FromUserId - {privatemessage.FromUserId}\t ToUserId- {privatemessage.ToUserId}");
                    }
                }
                messages.Sort();
                List<PrivateMessage> SortedList = messages.OrderBy(o => o.CreateDate).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ShowConversationHistory(List<PrivateMessage> conversation)
        {
            foreach (var item in conversation)
            {
                PrintPrivateMessage(item);
            }
        }
        public static void GetNewMessages()
        {

        }
        public static void PrintPrivateMessage(PrivateMessage oneprivatemessage)
        {
            Console.WriteLine($"\t CreateDate - {oneprivatemessage.CreateDate}");
            Console.WriteLine($"\tFromUserId - {oneprivatemessage.FromUserId}");
            Console.WriteLine($"\tMessage\n{oneprivatemessage.Message}");
        }
        public static int getUserId(string username)
        {
            try
            {
                using var dbContext = new ChatDbContext();
                var users = dbContext.Users.ToList();
                foreach (var user in users)
                {
                    if (user.Login == username)
                    {
                        return user.Id;
                    }
                    else
                    {
                        Console.WriteLine("no user");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
        public static int getGroupId(string usergroup)
        {
            try
            {
                using var dbContext = new ChatDbContext();
                var groups = dbContext.Groups.ToList();
                foreach (var group in groups)
                {
                    if (group.Name == usergroup)
                    {
                        return group.Id;
                    }
                    else
                    {
                        Console.WriteLine("no group");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
        public static void AddUserToGroup()
        {
            string tmpuser = "";
            string tmpgroup = "";
            int tmpuserid = 0;
            int tmpgroupid = 0;
            while (tmpuser.IsNullOrEmpty() || tmpgroup.IsNullOrEmpty())
            {
                tmpuser = Console.ReadLine();
                Console.WriteLine("enter user id");
                tmpgroup = Console.ReadLine();
                Console.WriteLine("enter group id");
            }
            tmpuserid = int.Parse(tmpuser);
            tmpgroupid = int.Parse(tmpgroup);
            try
            {
                using var dbContext = new ChatDbContext();
                UserGroup theusergoup = new UserGroup();
                theusergoup.GroupId = tmpgroupid;
                theusergoup.UserId = tmpuserid;
                dbContext.UserGroups.Add(theusergoup);
                dbContext.SaveChanges();
                Console.WriteLine("user added to group");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DeleteUserFromGroup()
        {
            string tmpuser = "";
            string tmpgroup = "";
            int tmpuserid = 0;
            int tmpgroupid = 0;
            while (tmpuser.IsNullOrEmpty() || tmpgroup.IsNullOrEmpty())
            {
                tmpuser = Console.ReadLine();
                Console.WriteLine("enter user id");
                tmpgroup = Console.ReadLine();
                Console.WriteLine("enter group id");
            }
            tmpuserid = int.Parse(tmpuser);
            tmpgroupid = int.Parse(tmpgroup);
            try
            {
                using var dbContext = new ChatDbContext();
                UserGroup theusergoup = new UserGroup();
                theusergoup.GroupId = tmpgroupid;
                theusergoup.UserId = tmpuserid;
                var usergroups = dbContext.UserGroups.ToList();
                foreach (var usergroup in usergroups)
                {
                    if (usergroup.UserId == tmpuserid && usergroup.GroupId == tmpgroupid)
                    {
                        dbContext.UserGroups.Remove(theusergoup);
                        dbContext.SaveChanges();
                        Console.WriteLine("user deleted from group");
                    }
                    else
                    {
                        Console.WriteLine("unsuccessfully");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void GetAllGroups()
        {
            using var dbContext = new ChatDbContext();
            var groups = dbContext.Groups.ToList();
            foreach (var group in groups)
            {
                Console.WriteLine($"Id - {group.Id}\tName - {group.Name}");
            }
        }
        public static void CreateGroup()
        {
            string groupname = "";
            while (groupname.IsNullOrEmpty())
            {
                groupname = Console.ReadLine();
                Console.WriteLine("enter group name");
            }
            Group thegroup = new Group();
            thegroup.Name = groupname;

            using var dbContext = new ChatDbContext();
            //var groups = dbContext.Groups.ToList();
            dbContext.Groups.Add(thegroup);
            Console.WriteLine($"gruop {groupname} created");
        }
        public static void DeleteGroup()
        {
            string groupname = "";
            while (groupname.IsNullOrEmpty())
            {
                groupname = Console.ReadLine();
                Console.WriteLine("enter group name");
            }
            using var dbContext = new ChatDbContext();
            var groups = dbContext.Groups.ToList();
            foreach (var group in groups)
            {
                if (group.Name == groupname)
                {
                    dbContext.Groups.Remove(group);
                    Console.WriteLine("group deleted");
                }
                else
                {
                    Console.WriteLine("unable to delete group");
                }
            }
        }
        public static void BlackListUser()
        {
            string usertoblacklist = "";
            while (usertoblacklist.IsNullOrEmpty())
            {
                Console.WriteLine("enter username you want to blacklist");
                usertoblacklist = Console.ReadLine();
            }
            try
            {
                using var dbContext = new ChatDbContext();
                var privatemessages = dbContext.PrivateMessages.ToList();
                var users = dbContext.Users.ToList();
                int flag = 0;
                foreach (var user in users)
                {
                    if (user.Login == usertoblacklist)
                    {
                        foreach (var privatemessage in privatemessages)
                        {
                            if (privatemessage.FromUserId == user.Id)
                            {
                                privatemessage.IsUserInBlackList = true;
                                Console.WriteLine($"message with id - {privatemessage.Id}\t is blacklisted " +
                                    $"\t CreateDate - {privatemessage.CreateDate}");
                                Console.WriteLine($"FromUserId - {privatemessage.FromUserId}\t ToUserId- {privatemessage.ToUserId}");
                                Console.WriteLine("");
                                dbContext.PrivateMessages.Update(privatemessage);
                                //Console.WriteLine($"Message:\n{privatemessage.Message}");
                                flag++;
                            }
                        }
                        if (flag > 0)
                            Console.WriteLine($"all messages form user {user.Login} is blacklisted");
                        else
                        {
                            Console.WriteLine($"no messages form user {user.Login}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("no such username");
                    }
                }
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void SendMessage(int fromuserid)
        {
            //outmessage.FromUserId = ;
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=ChatDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var dbContext = new ChatDbContext();

                var touserid = "";
                var inputmessage = "";
                int iter = 0;
                int bufid = 0;
                if (touserid.IsNullOrEmpty() && inputmessage.IsNullOrEmpty())
                {
                    if (iter > 0)
                    {
                        Console.WriteLine("fill all fields");
                    }
                    Console.WriteLine("enter destination user id");
                    touserid = Console.ReadLine();
                    bufid = Int32.Parse(touserid);
                    Console.WriteLine("enter message");
                    inputmessage = Console.ReadLine();

                    iter++;
                }
                PrivateMessage outmessage = new PrivateMessage();
                outmessage.FromUserId = fromuserid;
                outmessage.ToUserId = bufid;
                outmessage.Message = inputmessage;
                outmessage.CreateDate = DateTime.Today;

                dbContext.PrivateMessages.Add(outmessage);
                dbContext.SaveChanges();
                Console.WriteLine("successfully updated.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DeletePrivateMessage(int fromuserid)
        {
            //outmessage.FromUserId = ;

            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=ChatDb;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                var inputmessageid = "";
                int bufid = 0;
                if (inputmessageid.IsNullOrEmpty())
                {
                    Console.WriteLine("input message id");
                    inputmessageid = Console.ReadLine();
                    bufid = Int32.Parse(inputmessageid);
                }
                using var dbContext = new ChatDbContext();
                var privatemessages = dbContext.PrivateMessages.ToList();
                foreach (var privatemessage in privatemessages)
                {
                    if (privatemessage.FromUserId == fromuserid && privatemessage.Id == bufid)
                    {
                        Console.WriteLine($"id - {privatemessage.Id}\t CreateDate - {privatemessage.CreateDate}");
                        Console.WriteLine($"FromUserId - {privatemessage.FromUserId}\t ToUserId- {privatemessage.ToUserId}");
                        //Console.WriteLine($"Message:\n{privatemessage.Message}");
                        dbContext.PrivateMessages.Remove(privatemessage);
                        Console.WriteLine("message deleted");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void GetPrivateMessages(int fromuserid)
        {
            try
            {
                using var dbContext = new ChatDbContext();
                var privatemessages = dbContext.PrivateMessages.ToList();
                foreach (var privatemessage in privatemessages)
                {
                    if (privatemessage.FromUserId == fromuserid)
                    {
                        Console.WriteLine($"id - {privatemessage.Id}\t CreateDate - {privatemessage.CreateDate}");
                        Console.WriteLine($"FromUserId - {privatemessage.FromUserId}\t ToUserId- {privatemessage.ToUserId}");
                        //Console.WriteLine($"Message:\n{privatemessage.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void EditPrivateMessage()
        {

            string msgid = "";
            int intmsgid = 0;
            while (msgid.IsNullOrEmpty())
            {
                Console.WriteLine("enter message id");
                msgid = Console.ReadLine();
                intmsgid = Int32.Parse(msgid);
            }
            try
            {
                using var dbContext = new ChatDbContext();
                var privatemessages = dbContext.PrivateMessages.ToList();
                foreach (var privatemessage in privatemessages)
                {
                    if (privatemessage.Id == intmsgid)
                    {
                        Console.WriteLine($"id - {privatemessage.Id}\t CreateDate - {privatemessage.CreateDate}");
                        Console.WriteLine($"FromUserId - {privatemessage.FromUserId}\t ToUserId- {privatemessage.ToUserId}");
                        Console.WriteLine($"Message:\n{privatemessage.Message}");
                        string newmessage = "";
                        while (newmessage.IsNullOrEmpty())
                        {
                            Console.WriteLine("enter new message text");
                            newmessage = Console.ReadLine();
                            privatemessage.Message = newmessage;
                        }
                        dbContext.PrivateMessages.Update(privatemessage);
                        dbContext.SaveChanges();
                        Console.WriteLine("successfully updated");
                    }
                    else
                    {
                        Console.WriteLine("no messages");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void BackToInternalMenu()
        {
            Console.WriteLine("100. Вернуться в меню.");
            Console.WriteLine("111. Выйти");
            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("Введите цифру");
            }
            //var outputString = Console.ReadLine();

            Console.WriteLine();
            int number = int.Parse(inputString);

            if (number == 100)
            {
                SwitchMenu(InternalMenu());
            }
            else if (number == 111)
            {
                return;
            }
        }
        public static void BackToExternalMenu()
        {
            Console.WriteLine("100. Вернуться в меню.");
            Console.WriteLine("111. Выйти");
            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("Введите цифру");
            }
            //var outputString = Console.ReadLine();

            Console.WriteLine();
            int number = int.Parse(inputString);

            if (number == 100)
            {
                SwitchMenu(ExternalMenu());
            }
            else if (number == 111)
            {
                return;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                SwitchMenu(ExternalMenu());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }
        }
    }
}