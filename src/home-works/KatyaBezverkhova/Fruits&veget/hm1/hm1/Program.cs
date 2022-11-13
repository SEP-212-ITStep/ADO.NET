using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace hm1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DisplayingAllInfo();

            //DisplayOnlyNames();
            //DisplayOnlyColor();
            //MaxCalories();
            //MinimumCalories();
            //ShowInfo();
            //Console.WriteLine("Введите цвет овоща или фрукта:");
            //string ch = (Console.ReadLine());
            //ShowInfoByColor(ch);  // Red
            // ShowInfoByCalories(200);
            ShowRedAndYellow("Red", "Yellow");
        }
        public static void DisplayingAllInfo()
        {
            try
            {
                var Query = "SELECT * FROM fruits";
                var QuerySec = "SELECT Name FROM fruits";
                string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";
                using (var connection = new SqlConnection(Path))
                {
                    Console.WriteLine("Подключение успешно!");
                    connection.Open();
                    var command = new SqlCommand(Query, connection);
                    var reader = command.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        object Name = reader.GetValue(0);
                        object Type = reader.GetValue(1);
                        object Color = reader.GetValue(2);
                        object Calories = reader.GetValue(3);
                        Console.WriteLine("Name is:---- {0} Type is {1} Color is {2} Calories are: {3}", Name, Type, Color, Calories);
                        
                    }
                    Thread.Sleep(2000);
                    Console.Clear();

                }
            }

            catch (Exception)
            {

                Console.WriteLine("Не подключились");
            }
    }
        public static void DisplayOnlyNames()
        {
            var Query = "SELECT * FROM fruits";
           // var QuerySec = "SELECT Name FROM fruits";
            string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";
            Console.WriteLine("Displaying only names of fruits & vegetables:");
            using (var connectionSec = new SqlConnection(Path))
            {
                connectionSec.Open();
                var commandSec = new SqlCommand(Query, connectionSec);
                var readerSec = commandSec.ExecuteReader();
                while (readerSec.Read())
                {
                    object Name = readerSec.GetValue(0);
                    //object Color = readerSec.GetValue(2);
                    Console.WriteLine(Name);
                   
                }

            }
            Thread.Sleep(2000);
            Console.Clear();

        }
        public static void DisplayOnlyColor()
        {
            var Query = "SELECT * FROM fruits";
            string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";
            using(var connection = new SqlConnection(Path))
            {
                connection.Open();
                var command = new SqlCommand(Query, connection);
                var reader = command.ExecuteReader();
                Console.WriteLine("Displaying colors:");
                while(reader.Read())
                {
                    var Colors = reader.GetValue(2);
                    Console.WriteLine(Colors);
                }
            }

        }
        public static void MaxCalories()
        {
            var Query = "SELECT * FROM fruits";
            
            string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";
            Console.WriteLine("Displaying maximum calories");
            using (var connectionSec = new SqlConnection(Path))
            {
                connectionSec.Open();
                var commandSec = new SqlCommand(Query, connectionSec);
                var readerSec = commandSec.ExecuteReader();
                List<int> caloriesList = new List<int>();
                while (readerSec.Read())
                {
                    var Calories = Convert.ToInt32(readerSec.GetValue(3));
                    caloriesList.Add(Calories);      
                }
                var max = caloriesList[0];
                var temp = 0;
                foreach (int item in caloriesList)
                {
                    if (item > max)
                        max = item;
                    // else if(item < max)
                    temp = temp + item;

                }
                Console.WriteLine("Maximum calories {0}", max);
                Console.WriteLine("Average value of calories:", temp / caloriesList.Count);
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
        public static void MinimumCalories()
        {
            var Query = "SELECT * FROM fruits";

            string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";
            Console.WriteLine("Displaying minimum calories");
            using (var connectionSec = new SqlConnection(Path))
            {
                connectionSec.Open();
                var commandSec = new SqlCommand(Query, connectionSec);
                var readerSec = commandSec.ExecuteReader();
                List<int> caloriesList = new List<int>();
                while (readerSec.Read())
                {
                    var Calories = Convert.ToInt32(readerSec.GetValue(3));
                    caloriesList.Add(Calories);
                }
                var min = caloriesList[0];
                var temp = 0;
                foreach (int item in caloriesList)
                {

                    if (item < min)
                        min = item;

                }
                Console.WriteLine("Mininmum calories {0}", min);
   
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
        public static void ShowInfo()
        {
            var Query = "SELECT * FROM fruits";

            string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";
           
            using (var connectionSec = new SqlConnection(Path))
            {
                connectionSec.Open();
                var commandSec = new SqlCommand(Query, connectionSec);
                var readerSec = commandSec.ExecuteReader();
                int temp = 0;
                int tmp = 0;
                while (readerSec.Read())
                {
                    string Types = readerSec.GetValue(1).ToString();
                    List<string> types = new List<string>();
              
                    types.Add(Types);
                    foreach (var item in types)
                    {
                        
                        if (Types == "Fruit")
                            temp++;
                        else
                            tmp++;
                    }
                    
                }
                Console.WriteLine("Кол - во фруктов {0}", temp);
                Console.WriteLine("Кол-во овощей {0}", tmp);
            }
            Thread.Sleep(2000);
            Console.Clear();
        }
        public static void ShowInfoByColor(string color)
        {
            
            
                
                    var Query = "SELECT * FROM fruits";

                    string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";

                    using (var connectionSec = new SqlConnection(Path))
                    {
                        connectionSec.Open();
                        var commandSec = new SqlCommand(Query, connectionSec);
                        var readerSec = commandSec.ExecuteReader();
                        int tmp = 0;
                        int temp = 0;
                        while (readerSec.Read())
                        {
                            string Types = readerSec.GetValue(1).ToString();
                            string Color = readerSec.GetValue(2).ToString();
                            List<string> types = new List<string>();

                            types.Add(Types);
                            foreach (var item in types)
                            {
                                if (color == Color && Types == "Fruit")
                                {
                                    tmp++;

                                }
                                else if (color == Color && Types == "Vegetables")
                                {
                                    temp++;
                                }

                            }

                        }
                        Console.WriteLine("Кол-во красных фруктов: {0}", tmp);
                        Console.WriteLine("Кол-во красных овощей: {0}", temp);
                    }
                    Thread.Sleep(2000);
                    Console.Clear();
                   
            
        }
        public static void ShowInfoByCalories(int calories)
        {
            var Query = "SELECT * FROM fruits";
            string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";
            using (var connectionSec = new SqlConnection(Path))
            {
                connectionSec.Open();
                var commandSec = new SqlCommand(Query, connectionSec);
                var readerSec = commandSec.ExecuteReader();
                
                while (readerSec.Read())
                {
                    string Types = readerSec.GetValue(1).ToString();
                    
                    int Calories = Convert.ToInt32(readerSec.GetValue(3));
                    List<int> calor = new List<int>();
                    List<string> types = new List<string>();
                    types.Add(Types);
                    calor.Add(Calories);
                    foreach (var item in types)
                    {
                        if(calories > Calories)
                        {
                            Console.WriteLine("Овощи и фрукты с калорийностью меньше указанной", item);
                        }
                    }
                    

                }
             
            }
            
        }
        public static void ShowRedAndYellow(string color, string colorSec)
        {
            var Query = "SELECT * FROM fruits";

            string Path = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Fruits_Vegetables;Trusted_Connection=true;Encrypt=false";

            using (var connectionSec = new SqlConnection(Path))
            {
                connectionSec.Open();
                var commandSec = new SqlCommand(Query, connectionSec);
                var readerSec = commandSec.ExecuteReader();
                
                while (readerSec.Read())
                {
                    string Names = readerSec.GetValue(0).ToString();
                    string Types = readerSec.GetValue(1).ToString();
                    string Color = readerSec.GetValue(2).ToString();
                    List<string> types = new List<string>();

                    types.Add(Types);
                    foreach (var item in types)
                    {
                        if (color == Color || colorSec == Color)
                        {
                            Console.WriteLine("Фрукты и овощи: {0}", Names);

                        }
                          
                        

                    }

                }
                
            }
            
        }
    }

}
