using ClassLibrary1Game;
using ClassLibrary1GameDbContext;

namespace _15112022_homework4
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SwitchMenu(ShowMenu());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
        public static Game GameCreate(string gamename, string developer, string genre, DateTime releasedate)
        {
            var game = new Game();
            game.GameName = gamename;
            game.Developer = developer;
            game.Genre = genre;
            game.ReleaseDate = releasedate;

            return game;
        }
        public static void ShowAllData()
        {
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            foreach (var game in games)
            {
                Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on {game.ReleaseDate.ToString("dd/MM/yyyy")}, sales - {game.Sales}, is Multiplayer - {game.isMultiplayer}");
            }
        }
        public static void ShowSinglePlayer()
        {
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            foreach (var game in games)
            {
                if (game.isMultiplayer == false)
                    Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on {game.ReleaseDate.ToString("dd/MM/yyyy")} - {game.Sales}, is Multiplayer - {game.isMultiplayer}");
            }
        }
        public static void ShowMultiplayerPlayer()
        {
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            foreach (var game in games)
            {
                if (game.isMultiplayer == true)
                    Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on {game.ReleaseDate.ToString("dd/MM/yyyy")} - {game.Sales}, is Multiplayer - {game.isMultiplayer}");
            }
        }
        public static void ShowMaxSales()
        {
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            var maxgame = games.First();
            int maxSales = maxgame.Sales;

            foreach (var game in games)
            {
                if (game.Sales > maxSales)
                {
                    maxgame = game;
                }
            }
            ShowAllData();
            Console.WriteLine("");
            Console.WriteLine($"{maxgame.GameName} was developed by {maxgame.Developer} in genre {maxgame.Genre}, relesead on {maxgame.ReleaseDate.ToString("dd/MM/yyyy")} - {maxgame.Sales}, is Multiplayer - {maxgame.isMultiplayer}");
        }
        public static void ShowMinSales()
        {
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            var mingame = games.First();
            int minSales = mingame.Sales;

            foreach (var game in games)
            {
                if (game.Sales < minSales)
                {
                    mingame = game;
                }
            }
            ShowAllData();
            Console.WriteLine("");
            Console.WriteLine($"{mingame.GameName} was developed by {mingame.Developer} in genre {mingame.Genre}, relesead on {mingame.ReleaseDate.ToString("dd/MM/yyyy")} - {mingame.Sales}, is Multiplayer - {mingame.isMultiplayer}");
        }
        public static void Show3MaxSales()
        {
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            var gamessorted = games.OrderByDescending(n => n.Sales);

            //ShowAllData();
            //Console.WriteLine("");

            foreach (var game in gamessorted)
            {
                Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on {game.ReleaseDate.ToString("dd/MM/yyyy")} - {game.Sales}, is Multiplayer - {game.isMultiplayer}");
            }

            Console.WriteLine("");
            var game3 = gamessorted.Take(3);
            Console.WriteLine("");
            foreach (var game in game3)
            {
                Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on {game.ReleaseDate.ToString("dd/MM/yyyy")} - {game.Sales}, is Multiplayer - {game.isMultiplayer}");
            }
        }
        public static void Show3MinSales()
        {
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            var gamessorted = games.OrderBy(n => n.Sales);

            foreach (var game in gamessorted)
            {
                Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on {game.ReleaseDate.ToString("dd/MM/yyyy")} - {game.Sales}, is Multiplayer - {game.isMultiplayer}");
            }

            Console.WriteLine("");
            var game3 = gamessorted.Take(3);
            Console.WriteLine("");
            foreach (var game in game3)
            {
                Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on {game.ReleaseDate.ToString("dd/MM/yyyy")} - {game.Sales}, is Multiplayer - {game.isMultiplayer}");
            }
        }
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Получить список всех игр");
            Console.WriteLine("2. Добавить Игру");
            Console.WriteLine("3. Поиск по названию игры");
            Console.WriteLine("4. Поиск игры по названии студии");
            Console.WriteLine("5. Поиск информации по названию студии и игры");
            Console.WriteLine("6. Поиск игр по стилю");
            Console.WriteLine("7. Поиск игр по году релиза");
            Console.WriteLine("8. Вывод всех однопользовательских игр");
            Console.WriteLine("9. Вывод всех многопользовательских игр");
            Console.WriteLine("10. Игра с максимальным количеством проданных игр");
            Console.WriteLine("11. Игра с минимальным количеством проданных игр");
            Console.WriteLine("12. Топ-3 с максимальным количеством проданных игр");
            Console.WriteLine("13. Топ-3 с минимальным количеством проданных игр");
            Console.WriteLine("14. Добавить игру c проверкой на уникальность");
            Console.WriteLine("15. Изменение данных существующей игры");
            Console.WriteLine("16. Удалить игру по названию игры и названию студии");
            Console.WriteLine();
            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }
            //var outputString = Console.ReadLine();

            Console.WriteLine();
            int number = int.Parse(inputString);

            return number;
        }
        public static void SwitchMenu(int number)
        {
            switch (number)
            {
                case 1:
                    ShowAllData();
                    BackToMenu();
                    break;
                case 2:
                    AddGame();
                    BackToMenu();
                    break;
                case 3:
                    getByName();
                    BackToMenu();
                    break;
                case 4:
                    getByStudio();
                    BackToMenu();
                    break;
                case 5:
                    getByNameAndStudio();
                    BackToMenu();
                    break;
                case 6:
                    getByGenre();
                    BackToMenu();
                    break;
                case 7:
                    getByReleaseDate();
                    BackToMenu();
                    break;
                case 8:
                    ShowSinglePlayer();
                    BackToMenu();
                    break;
                case 9:
                    ShowMultiplayerPlayer();
                    BackToMenu();
                    break;
                case 10:
                    ShowMaxSales();
                    BackToMenu();
                    break;
                case 11:
                    ShowMinSales();
                    BackToMenu();
                    break;
                case 12:
                    Show3MaxSales();
                    BackToMenu();
                    break;
                case 13:
                    Show3MinSales();
                    BackToMenu();
                    break;
                case 14:
                    AddGame2();
                    BackToMenu();
                    break;
                case 15:
                    EditGame();
                    BackToMenu();
                    break;
                case 16:
                    DeleteGame();
                    BackToMenu();
                    break;
                default:
                    break;
            }
        }
        public static void BackToMenu()
        {
            Console.WriteLine("0. Вернуться в меню.");
            Console.WriteLine("1. Выйти");
            var inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("Введите цифру");
            }
            //var outputString = Console.ReadLine();

            Console.WriteLine();
            int number = int.Parse(inputString);

            if (number == 0)
            {
                SwitchMenu(ShowMenu());
            }
            else if (number == 1)
            {
                return;
            }
        }
        public static void AddGame()
        {
            Console.WriteLine("Введите название игры, разработчика, жанр и дату релиза");
            Console.Write("название игры: ");
            var gamename = Console.ReadLine();
            Console.Write("название разработчика: ");
            var developer = Console.ReadLine();
            Console.Write("жанр: ");
            var genre = Console.ReadLine();
            Console.Write("дата релиза: ");
            var releasedate = Console.ReadLine();
            if (releasedate == null)
            {
                releasedate = DateTime.Now.ToString("dd/MM/yyyy");
            }

            using var dbContext = new GameNewDbContext();
            var game1 = GameCreate(gamename, developer, genre, DateTime.Parse(releasedate));

            dbContext.Games.Add(game1);

            dbContext.SaveChanges();
            Console.WriteLine("изменения успешно сохранены.");
        }
        public static void AddGame2()
        {
            Console.WriteLine("Введите название игры, разработчика, жанр и дату релиза");
            Console.Write("название игры: ");
            var gamename = Console.ReadLine();
            Console.Write("название разработчика: ");
            var developer = Console.ReadLine();
            Console.Write("жанр: ");
            var genre = Console.ReadLine();
            Console.Write("дата релиза: ");
            var releasedate = Console.ReadLine();
            if (releasedate == null)
            {
                releasedate = DateTime.Now.ToString("dd/MM/yyyy");
            }

            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            int flag = 0;

            foreach (var game in games)
            {
                if (game.GameName == gamename)
                {
                    Console.WriteLine("Game exists in DB");
                    flag++;
                    break;
                }
            }

            if (flag == 0)
            {
                var game1 = GameCreate(gamename, developer, genre, DateTime.Parse(releasedate));
                dbContext.Games.Add(game1);
                dbContext.SaveChanges();
                Console.WriteLine("изменения успешно сохранены.");
            }
        }
        public static void EditGame()
        {
            Console.Write("Введите название игры: ");
            var gamenm = Console.ReadLine();
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            var thegame = new Game();
            foreach (var game in games)
            {
                if (game.GameName == gamenm)
                    Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on " + game.ReleaseDate.ToString("dd/MM/yyyy"));
                thegame = game;
                //dbContext.Games.Add(game);
            }
            Console.Write("Какой параметр поменять? ");

            Console.WriteLine($"\t\n1. Название игры - {thegame.GameName}\n 2. студия разработчик - {thegame.Developer}\n 3. жанр -  {thegame.Genre}\n 4. дата релиза - {thegame.ReleaseDate.ToString("dd/MM/yyyy")}\n 5. многопользователский режим - {thegame.isMultiplayer}\n 6. продажи - {thegame.Sales}");

            int selector = int.Parse(Console.ReadLine());

            switch (selector)
            {
                case 1:
                    Console.WriteLine("выбрано: название игры");
                    Console.WriteLine("введите новое значение");
                    string newname = Console.ReadLine();
                    thegame.GameName = newname;
                    break;
                case 2:
                    Console.WriteLine("выбрано: студия разработчик");
                    Console.WriteLine("введите новое значение");
                    string newdev = Console.ReadLine();
                    thegame.Developer = newdev;
                    break;
                case 3:
                    Console.WriteLine("выбрано: жанр");
                    Console.WriteLine("введите новое значение");
                    string newgenre = Console.ReadLine();
                    thegame.Genre = newgenre;
                    break;
                case 4:
                    Console.WriteLine("выбрано: дата релиза");
                    Console.WriteLine("введите новое значение");
                    string newdr = Console.ReadLine();
                    thegame.ReleaseDate = DateTime.Parse(newdr);
                    break;
                case 5:
                    Console.WriteLine("выбрано: многопользователский режим");
                    Console.WriteLine("введите новое значение: true или false");
                    string newbool = Console.ReadLine();
                    thegame.isMultiplayer = bool.Parse(newbool);
                    break;
                case 6:
                    Console.WriteLine("выбрано: продажи");
                    Console.WriteLine("введите новое значение");
                    string newsales = Console.ReadLine();
                    thegame.Sales = int.Parse(newsales);
                    break;


            }
            dbContext.Games.Update(thegame);
            dbContext.SaveChanges();
            Console.WriteLine("изменения успешно сохранены.");
        }
        public static void DeleteGame()
        {
            Console.WriteLine("Введите название игры, разработчика, жанр и дату релиза");
            Console.Write("название игры: ");
            var gamename = Console.ReadLine();
            Console.Write("название разработчика: ");
            var developer = Console.ReadLine();

            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            int flag = 0;
            foreach (var game in games)
            {
                if (game.GameName == gamename && game.Developer == developer)
                {
                    Console.WriteLine($"Удалить игру {game.GameName} да или нет?");
                    string yesno = Console.ReadLine();
                    if (yesno == "да")
                    {
                        dbContext.Games.Remove(game);
                        flag++;
                        dbContext.SaveChanges();
                        Console.WriteLine("игра успешно удалена.");
                        break;
                    }
                    else if (yesno == "нет")
                    {
                        break;
                    }
                    else
                        break;

                }
            }
            if (flag == 0)
                Console.WriteLine("Нет такой игры");
        }
        public static void getByName()
        {
            Console.Write("Введите название игры: ");
            var gamenm = Console.ReadLine();
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            foreach (var game in games)
            {
                if (game.GameName == gamenm)
                    Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on " + game.ReleaseDate.ToString("dd/MM/yyyy"));
            }
        }
        public static void getByStudio()
        {
            Console.Write("Введите название разработчика: ");
            var developer = Console.ReadLine();
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            foreach (var game in games)
            {
                if (game.Developer == developer)
                    Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on " + game.ReleaseDate.ToString("dd/MM/yyyy"));
            }
        }
        public static void getByNameAndStudio()
        {
            Console.Write("Введите название игры: ");
            var gamenm = Console.ReadLine();
            Console.Write("название разработчика: ");
            var developer = Console.ReadLine();
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            foreach (var game in games)
            {
                if (game.GameName == gamenm && game.Developer == developer)
                    Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on " + game.ReleaseDate.ToString("dd/MM/yyyy"));
            }
        }
        public static void getByGenre()
        {
            Console.Write("Введите жанр: ");
            var genre = Console.ReadLine();
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            foreach (var game in games)
            {
                if (game.Genre == genre)
                    Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on " + game.ReleaseDate.ToString("dd/MM/yyyy"));
            }
        }
        public static void getByReleaseDate()
        {
            Console.Write("Введите дата релиза (ММ,ДД,ГГГГ): ");
            var releaseDate = Console.ReadLine();
            using var dbContext = new GameNewDbContext();
            var games = dbContext.Games.ToList();
            foreach (var game in games)
            {

                if (game.ReleaseDate.ToString("dd/MM/yyyy") == releaseDate)
                    Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on " + game.ReleaseDate.ToString("dd/MM/yyyy"));
            }
        }
    }
}