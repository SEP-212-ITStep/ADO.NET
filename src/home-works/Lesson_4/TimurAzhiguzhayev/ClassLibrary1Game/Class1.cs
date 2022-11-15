namespace ClassLibrary1Game
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Developer { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool isMultiplayer { get; set; } = false;
        public int Sales { get; set; }
        public Game()
        {
            Random rnd = new Random();
            this.Sales = rnd.Next(20000, 300000000);
            if (rnd.Next(0, 2) == 1)
                this.isMultiplayer = true;
            else
                this.isMultiplayer = false;
        }
    }
}