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
                Console.WriteLine($"{game.GameName} was developed by {game.Developer} in genre {game.Genre}, relesead on " + game.ReleaseDate.ToString("dd/MM/yyyy"));
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