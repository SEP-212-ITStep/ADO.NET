namespace gamesDz
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ShowAllData();

        }
        public static void ShowAllData()
        {
            try
            {
                using var db = new GamesContext();
                var info = db.games.ToList();

                // Console.WriteLine("{0}", db.);
                foreach (var items in info)
                {
                    Console.WriteLine("Name: {0} ---> Creator: {1} ---> Play Style: {2} ---> RealiseDate: {3} ---> GameMode: {4}", items.Name, items.Creator, items.PlayStyle, items.RealiseDate, items.GameMode);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
          
        }
        
    }
}