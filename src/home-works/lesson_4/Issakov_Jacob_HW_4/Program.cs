using Game_Dll;

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
            Console.WriteLine("1 - Add new Game: ");
            Console.WriteLine("2 - Show all Games:");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    AddGame();
                    break;
                case 2:
                    ShowAllGames();
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
                //int id = rnd.Next(10000, 1000000);
                //List<Model> games = db.Games.ToList();
                //for (int i = 0; i < games.Count(); i++)
                //{
                //    // Проверка на уникальность Id
                //    if (games[i].Id == id)
                //    {
                //        id = rnd.Next(10000, 1000000);
                //        i = 0;
                //    }
                //}
                //int id = 1;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}