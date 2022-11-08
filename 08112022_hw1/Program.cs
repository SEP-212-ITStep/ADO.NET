using System.Data.SqlClient;

namespace _08112022_hw1
{
    public class Program
    {
        public static void connectToDB()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Vegetables&Fruits;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [Name],[Type],[Color],[Calories] FROM dbo.VegetablesFruits";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Name = reader["Name"].ToString();
                    var Type = reader["Type"].ToString();
                    var Color = reader["Color"].ToString();
                    //var Calories = Double.Parse(reader["Calories"]);

                    var Calories = Convert.ToDouble(reader["Calories"].ToString());

                    Console.WriteLine($"[Name - {Name}, Type - {Type}, Color - {Color}, Calories - {Calories}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void connectToDBName()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Vegetables&Fruits;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [Name],[Type],[Color],[Calories] FROM dbo.VegetablesFruits";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Name = reader["Name"].ToString();
                    Console.WriteLine($"[Name - {Name}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void connectToDBColor()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Vegetables&Fruits;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [Name],[Type],[Color],[Calories] FROM dbo.VegetablesFruits";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {

                    var Color = reader["Color"].ToString();
                    Console.WriteLine($"[Color - {Color}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void connectToDBMaxcalories()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Vegetables&Fruits;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [Name],[Type],[Color],[Calories] FROM dbo.VegetablesFruits";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                List<double> strings = new List<double>();

                while (reader.Read())
                {
                    var Calories = Convert.ToDouble(reader["Calories"].ToString());
                    strings.Add(Calories);
                }

                var Maxcalories = strings[0];
                foreach (var item in strings)
                {
                    if (Maxcalories < item)
                        Maxcalories = item;
                }
                Console.WriteLine($"[Maxcalories - {Maxcalories}]");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void connectToDBMincalories()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Vegetables&Fruits;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [Name],[Type],[Color],[Calories] FROM dbo.VegetablesFruits";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();


                List<double> strings = new List<double>();

                while (reader.Read())
                {
                    var Calories = Convert.ToDouble(reader["Calories"].ToString());
                    strings.Add(Calories);
                }

                var Mincalories = strings[0];
                double buf = 0;
                double avr = 0;

                foreach (var item in strings)
                {
                    if (Mincalories > item)
                        Mincalories = item;
                }
                Console.WriteLine($"[Mincalories - {Mincalories}]");

                foreach (var item in strings)
                {
                    buf += item;
                }
                avr = buf / (strings.Count);
                Console.WriteLine($"[Среднее значение калорий - {avr}]");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Task4()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Vegetables&Fruits;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [Name],[Type],[Color],[Calories] FROM dbo.VegetablesFruits";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                List<Vegefruits> vegefruits = new List<Vegefruits>();
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    var Name = reader["Name"].ToString();
                    var Type = reader["Type"].ToString();
                    var Color = reader["Color"].ToString();
                    var Calories = Convert.ToDouble(reader["Calories"].ToString());

                    Vegefruits vegfru = new Vegefruits(Name, Type, Color, Calories);
                    vegefruits.Add(vegfru);
                }
                //■ Показать количество овощей;
                showVegNumber(vegefruits);
                //■ Показать количество фруктов;
                showFruitNumbers(vegefruits);
                //■ Показать количество овощей и фруктов заданного цвета;
                showVegFruitsByColor(vegefruits, "зеленый");
                //■ Показать количество овощей фруктов каждого цвета;
                showVegFruitsEachColor(vegefruits);
                //■ Показать овощи и фрукты с калорийностью ниже указанной;
                showVegFruitsCaloriesBelowLevel(vegefruits, 99);
                //■ Показать овощи и фрукты с калорийностью выше указанной;
                showVegFruitsCaloriesAboveLevel(vegefruits, 150);
                //■ Показать овощи и фрукты с калорийностью в указанном диапазоне;
                showVegFruitsCaloriesInRange(vegefruits, 100, 200);
                //■ Показать все овощи и фрукты, у которых цвет желтый или красный
                showVegFruitsYelRed(vegefruits);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {

            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Vegetables&Fruits;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                connectToDB();
                connectToDBName();
                connectToDBColor();
                connectToDBMaxcalories();
                connectToDBMincalories();

                Task4();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
        public class Vegefruits
        {
            public string Name { get; set; } = default;
            public string Type { get; set; } = default;
            public string Color { get; set; } = default;
            public double Calories { get; set; }
            public Vegefruits(string Name, string Type, string Color, double Calories)
            {
                this.Name = Name;
                this.Type = Type;
                this.Color = Color;
                this.Calories = Calories;
            }
            public override string ToString()
            {
                return String.Format("{0}, {1}, {2}, {3} ", Name, Type, Color, Calories);
            }
        }
        public static void showVegNumber(List<Vegefruits> bag)
        {
            int i = 0;
            foreach (var item in bag)
            {
                if (item.Type == "Овощ")
                    i++;
            }
            Console.WriteLine("овощей - {0} ", i);
        }
        public static void showFruitNumbers(List<Vegefruits> bag)
        {
            int i = 0;
            foreach (var item in bag)
            {
                if (item.Type == "Фрукт")
                    i++;
            }
            Console.WriteLine("Фруктов - {0} ", i);
        }
        public static void showVegFruitsByColor(List<Vegefruits> bag, string clr)
        {
            int i = 0;
            foreach (var item in bag)
            {
                if (item.Color == clr)
                    i++;
            }
            Console.WriteLine("овощей и фруктов цвета {0} - {1}", clr, i);
        }
        public static void showVegFruitsEachColor(List<Vegefruits> bag)
        {
            Dictionary<string, int> tmpbag = new Dictionary<string, int>();
            //int i = 0;
            foreach (var item in bag)
            {
                //tmpbag.Add(item.Color, i++);
                tmpbag.TryGetValue(item.Color, out var currentCount);
                tmpbag[item.Color] = currentCount + 1;
            }
            foreach (var item in tmpbag)
            {
                Console.WriteLine("овощей и фруктов цвета {0} - {1}", item.Key, item.Value);
            }
        }
        public static void showVegFruitsCaloriesBelowLevel(List<Vegefruits> bag, double caloraielevel)
        {
            Console.WriteLine("овощи и фрукты с калорийностью меньше {0} ", caloraielevel);
            foreach (var item in bag)
            {
                if (item.Calories < caloraielevel)
                    Console.WriteLine(item);
            }
        }
        public static void showVegFruitsCaloriesAboveLevel(List<Vegefruits> bag, double caloraielevel)
        {
            Console.WriteLine("овощи и фрукты с калорийностью больше {0} ", caloraielevel);
            foreach (var item in bag)
            {
                if (item.Calories > caloraielevel)
                    Console.WriteLine(item);
            }
        }
        public static void showVegFruitsCaloriesInRange(List<Vegefruits> bag, double caloraiemin, double caloraiemax)
        {
            Console.WriteLine("овощи и фрукты с калорийностью в даипозоне от {0} до {1}", caloraiemin, caloraiemax);
            foreach (var item in bag)
            {
                if (item.Calories > caloraiemin && item.Calories < caloraiemax)
                    Console.WriteLine(item);
            }
        }
        public static void showVegFruitsYelRed(List<Vegefruits> bag)
        {
            Console.WriteLine("все овощи и фрукты, у которых цвет желтый или красный");
            foreach (var item in bag)
            {
                if (item.Color == "желтый" || item.Color == "красный")
                    Console.WriteLine(item);
            }
        }
    }
}