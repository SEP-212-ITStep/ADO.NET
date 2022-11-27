using Game_Dll;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Issakov_Jacob_HW_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        public static void ShowMenu()
        {
            // Задание 1
            //Добавьте новую функциональность к проекту об играх:
            //■ Поиск информации по названию игры;
            //■ Поиск игр по названию студии;
            //■ Поиск информации по названию студии и игры;
            //■ Поиск игр по стилю;
            //■ Поиск игр по году релиза

            // Задание 2
            //Добавьте новую функциональность к проекту об играх:
            //■ Отображение информации обо всех однопользовательских играх;
            //■ Отображение информации обо всех многопользовательских играх;
            //■ Показать игру с максимальным количеством проданных игр;
            //■ Показать игру с минимальным количеством проданных игр;
            //■ Отображение топ-3 самых продаваемых игр;
            //■ Отображение топ-3 самых непродаваемых игр.

            // Задание 3
            //Добавьте новую функциональность к проекту об играх:
            //■ Добавление новой игры.Перед добавлением нужно
            //проверить не существует ли уже такая игра;
            //■ Изменение данных существующей игры. Пользователь
            //может изменить любой параметр игры;
            //■ Удаление игры. Поиск удаляемой игры производится
            //по названию игры и студии.Перед удалением игры
            //приложение должно спросить пользователя нужно
            //ли удалять игру.

            Console.WriteLine("1 - Add new Game: ");
            Console.WriteLine("2 - Show all Games: ");
            Console.WriteLine("3 - Find Game by Name: ");
            Console.WriteLine("4 - Find Game by Developer: ");
            Console.WriteLine("5 - Find Game by Developer and Game Name: ");
            Console.WriteLine("6 - Find Game by Game Style: ");
            Console.WriteLine("7 - Find Game by Publishing Year: ");
            Console.WriteLine("8 - Show only SinglePlayerMode Games: ");
            Console.WriteLine("9 - Show only MultiplayerMode Games: ");
            Console.WriteLine("10 - Show Game with MAX Sales: ");
            Console.WriteLine("11 - Show Game with MIN Sales: ");
            Console.WriteLine("12 - Show 3 Games with MAX Sales: ");
            Console.WriteLine("13 - Show 3 Games with MIN Sales: ");
            Console.WriteLine("14 - Add new Unique Game: ");
            Console.WriteLine("15 - Edit Game: ");
            Console.WriteLine("16 - Delete Game: ");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    AddGame();
                    break;
                case 2:
                    ShowAllGames();
                    break;
                case 3:
                    FindByName();
                    break;
                case 4:
                    FindByDeveloper();
                    break;
                case 5:
                    FindByDeveloperAndGameName();
                    break;
                case 6:
                    FindByStyle();
                    break;
                case 7:
                    FindByYear();
                    break;
                case 8:
                    SelectSinglePlayerMode();
                    break;
                case 9:
                    SelectMultiplayerMode();
                    break;
                case 10:
                    MaxSales();
                    break;
                case 11:
                    MinSales();
                    break;
                case 12:
                    Select_3_Max_Sales();
                    break;
                case 13:
                    Select_3_Min_Sales();
                    break;
                case 14:
                    AddUniqueGame();
                    break;
                case 15:
                    EditGame();
                    break;
                case 16:
                    DeleteGame();
                    break;
                default:
                    break;
            }
        }
        public static void AddGame()
        {
            try
            {
                using var db = new GameContext();
                Random rnd = new Random();
                Console.WriteLine("Enter the Developer Name: ");
                string developerName = Console.ReadLine();
                Console.WriteLine("Enter the Game Name: ");
                string gameName = Console.ReadLine();
                Console.WriteLine("Enter the Game Style: ");
                string gameStyle = Console.ReadLine();
                Console.WriteLine("Enter the Publishing Year");
                int publishingYear = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Game Mode (SingleUserMode or MultiplayerMode): ");
                string mode = Console.ReadLine();
                Console.WriteLine("Enter the Game Sales: ");
                int sales = int.Parse(Console.ReadLine());
                Model game = new Model(developerName, gameName, gameStyle, publishingYear, mode, sales);
                db.Games.Add(game);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void ShowAllGames()
        {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (Model game in games)
                {
                    Console.WriteLine($"\nDeveloper: {game.Developer_Name}\nGame Name: {game.Game_Name}" +
                                      $"\nGame Style: {game.Game_Style}\nPublishing Year: {game.Publishing_Year}" +
                                      $"\nGame Mode: {game.Game_Mode}\nSales: {game.Sales}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void FindByName()
        {
            try
            {
                Console.WriteLine("Enter the Game Name you want to find: ");
                string gameName = Console.ReadLine();
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (Model game in games)
                {
                    if (game.Game_Name == gameName)
                    {
                        Console.WriteLine(game);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void FindByDeveloper()
        {
            try
            {
                Console.WriteLine("Enter the Developer Name: ");
                string developerName = Console.ReadLine();
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (Model game in games)
                {
                    if (game.Developer_Name == developerName)
                    {
                        Console.WriteLine(game);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void FindByDeveloperAndGameName()
        {
            try
            {
                Console.WriteLine("Enter the Developer Name: ");
                string developerName = Console.ReadLine();
                Console.WriteLine("Enter the Game Name you want to find: ");
                string gameName = Console.ReadLine();
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (Model game in games)
                {
                    if (game.Developer_Name == developerName && game.Game_Name == gameName)
                    {
                        Console.WriteLine(game);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void FindByStyle()
        {
            try
            {
                Console.WriteLine("Enter the Game Style: ");
                string style= Console.ReadLine();  
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (Model game in games)
                {
                    if (game.Game_Style == style)
                    {
                        Console.WriteLine(game);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void FindByYear()
        {
            try
            {
                Console.WriteLine("Enter the Publishing Year: ");
                int year = int.Parse(Console.ReadLine());
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (Model game in games)
                {
                    if (game.Publishing_Year == year)
                    {
                        Console.WriteLine(game);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void SelectSinglePlayerMode() {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (Model game in games)
                {
                    if (game.Game_Mode == "SingleUserMode")
                    {
                        Console.WriteLine(game);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void SelectMultiplayerMode()
        {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                foreach (Model game in games)
                {
                    if (game.Game_Mode == "MultiplayerMode")
                    {
                        Console.WriteLine(game);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void MaxSales()
        {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                var maxGame = games[0];
                int maxSales = maxGame.Sales;

                foreach (Model game in games)
                {
                    if (game.Sales > maxSales)
                    {
                        maxGame = game;
                    }
                }
                Console.WriteLine(maxGame);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void MinSales()
        {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                var minGame = games[0];
                int minSales = minGame.Sales;

                foreach (Model game in games)
                {
                    if (game.Sales < minSales)
                    {
                        minGame = game;
                    }
                }
                Console.WriteLine(minGame);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void Select_3_Max_Sales()
        {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                var sorted = games.OrderByDescending(i => i.Sales);
                var threeGames = sorted.Take(3);
                foreach (Model item in threeGames)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void Select_3_Min_Sales()
        {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                var sorted = games.OrderBy(i => i.Sales);
                var threeGames = sorted.Take(3);
                foreach (Model item in threeGames)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void AddUniqueGame() {
            try
            {
                using var db = new GameContext();
                Random rnd = new Random();
                Console.WriteLine("Enter the Developer Name: ");
                string developerName = Console.ReadLine();
                Console.WriteLine("Enter the Game Name: ");
                string gameName = Console.ReadLine();
                Console.WriteLine("Enter the Game Style: ");
                string gameStyle = Console.ReadLine();
                Console.WriteLine("Enter the Publishing Year");
                int publishingYear = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Game Mode (SingleUserMode or MultiplayerMode): ");
                string mode = Console.ReadLine();
                Console.WriteLine("Enter the Game Sales: ");
                int sales = int.Parse(Console.ReadLine());
                Model game = new Model(developerName, gameName, gameStyle, publishingYear, mode, sales);
                var games = db.Games.ToList();
                foreach (var g in games)
                {
                    if (g.Game_Name == game.Game_Name)
                    {
                        Console.WriteLine("Такая игра уже существует");
                        return;
                    }
                }
                db.Games.Add(game);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void EditGame()
        {
            try
            {
                using var db = new GameContext();
                var games = db.Games.ToList();
                Model selectedGame = new Model();
                Console.WriteLine("Enter the Game Name: ");
                string gameName = Console.ReadLine();
                foreach (Model game in games)
                {
                    if (game.Game_Name == gameName)
                    {
                        selectedGame = game;
                    }
                }
                Console.WriteLine("Enter the characteristic: \n1 - Developer Name\n2 - Game Name\n3 - Game Style" +
                              "\n4 - Publishing Year\n5 - Game Mode\n6 - Sales");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter the New Developer Name: ");
                        string newName = Console.ReadLine();
                        selectedGame.Game_Name = newName;
                        break;
                    case 2:
                        Console.WriteLine("Enter the New Game Name: ");
                        string newDeveloper = Console.ReadLine();
                        selectedGame.Developer_Name = newDeveloper;
                        break;
                    case 3:
                        Console.WriteLine("Enter the New Game Style: ");
                        string newStyle = Console.ReadLine();
                        selectedGame.Game_Style = newStyle;
                        break;
                    case 4:
                        Console.WriteLine("Enter the New Publishing Year: ");
                        int publishingYear = int.Parse(Console.ReadLine());
                        selectedGame.Publishing_Year = publishingYear;
                        break;
                    case 5:
                        Console.WriteLine("Enter the New Game Mode (SingleUserMode or MultiplayerMode): ");
                        string mode = Console.ReadLine();
                        selectedGame.Game_Mode = mode;
                        break;
                    case 6:
                        Console.WriteLine("Enter the New Sales: ");
                        int sales = int.Parse(Console.ReadLine());
                        selectedGame.Sales = sales;
                        break;
                    default:
                        break;
                }
                db.Games.Update(selectedGame);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
        public static void DeleteGame()
        {
            try
            {
                Console.WriteLine("Enter the Developer Name: ");
                string developerName = Console.ReadLine();
                Console.WriteLine("Enter the Game Name you want to delete: ");
                string gameName = Console.ReadLine();
                using var db = new GameContext();
                var games = db.Games.ToList();
                bool contains = false;
                foreach (Model game in games)
                {
                    if (game.Developer_Name == developerName && game.Game_Name == gameName)
                    {
                        Console.WriteLine("Are you sure?\n1 - Yes\n2 - No");
                        int ch = int.Parse(Console.ReadLine());
                        if (ch == 1)
                        {
                            contains = true;
                            db.Games.Remove(game);
                            db.SaveChanges();
                        }
                    }
                }
                if (contains == false)
                {
                    Console.WriteLine("The game with such Name doesn't exists");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nПодключение к базе прошло не успешно\n{e.Message}");
            }
        }
    }
}