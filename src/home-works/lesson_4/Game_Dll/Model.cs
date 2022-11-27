using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_Dll
{
    public enum Modes
    {
        SingleUserMode,
        MultiplayerMode
    }
    public class Model
    {
        public Model()
        {

        }
        public Model(string developer, string name, string style, int publishingYear, string gameMode, int sales)
        {
            Developer_Name = developer;
            Game_Name = name;
            Game_Style = style;
            Publishing_Year = publishingYear;
            Game_Mode = gameMode;
            Sales = sales;
        }

        public int Id { get; set; }
        public string Developer_Name { get; set; }
        public string Game_Name { get; set; }
        public string Game_Style { get; set; }
        public int Publishing_Year { get; set; }
        public string Game_Mode { get; set; }
        public int Sales { get; set; }

        public override string ToString()
        {
            return $"\nDeveloper: {this.Developer_Name}\nGame Name: {this.Game_Name}" +
                   $"\nGame Style: {this.Game_Style}\nPublishing Year: {this.Publishing_Year}" +
                   $"\nGame Mode: {this.Game_Mode}\nSales: {this.Sales}";
        }
    }
}