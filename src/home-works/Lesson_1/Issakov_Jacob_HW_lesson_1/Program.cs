using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Drawing;

namespace Issakov_Jacob_HW_lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-6O1ENUJ;Database=VegetablesAndFruits;" +
                "Trusted_Connection=true;Encrypt=false;";

            // Task 2

            //try
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    using var sqlConnection = new SqlConnection(connectionString);
            //    sqlConnection.Open();
            //    Console.WriteLine($"Connected DB: {sqlConnection.Database}");
            //    Console.WriteLine("1 - Close connection");
            //    string response = Console.ReadLine();
            //    if (response == "1")
            //    {
            //        sqlConnection.Close();
            //        Console.WriteLine("The connection was successfully closed");
            //    }
            //}
            //catch (Exception)
            //{
            //    Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //    Console.WriteLine("Подключение к базе прошло не успешно");
            //}



            // Отображение всей информации из таблицы с овощами и фруктами;
            //ShowAll(connectionString);



            // Отображение всех названий овощей и фруктов;
            //ShowAllNames(connectionString);



            // Отображение всех цветов;
            //ShowAllColors(connectionString);



            // Показать максимальную калорийность;
            //MaxCalor(connectionString);



            // Показать минимальную калорийность;
            //MinCalor(connectionString);



            // Показать среднюю калорийность.
            //MeanCalor(connectionString);



            // Показать количество овощей;
            //VegetablesCount(connectionString);


            //■ Показать количество фруктов;
            // "SELECT COUNT(*) FROM dbo.VAF WHERE type='fruit'";
            //FruitsCount(connectionString);



            //■ Показать количество овощей и фруктов заданного
            //цвета;
            // $"SELECT COUNT(*) FROM dbo.VAF WHERE color='input'";
            //SelectColor(connectionString);



            //■ Показать количество овощей фруктов каждого цвета;
            //EveryColor(connectionString);


            //■ Показать овощи и фрукты с калорийностью ниже
            //указанной;
            //CaloriesBelowInput(connectionString);



            // $"SELECT * FROM dbo.VAF WHERE calories<'input'";
            //■ Показать овощи и фрукты с калорийностью выше
            //указанной;
            //CaloriesAboveInput(connectionString);

            //■ Показать овощи и фрукты с калорийностью в указанном диапазоне;
            // $"SELECT * FROM dbo.VAF WHERE calories BETWEEN 'input1' AND 'input2'";
            //CaloriesDiapazon(connectionString);



            //■ Показать все овощи и фрукты, у которых цвет желтый
            // "SELECT [name] FROM dbo.VAF WHERE color='yellow'";
            //YellowColor(connectionString);



            // Показать все овощи и фрукты, у которых цвет желтый или красный;
            //RedOrYellow(connectionString);

        }
        public static void ShowAll(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                const string sqlQuery = "SELECT * FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var type = reader["type"].ToString();
                    var color = reader["color"].ToString();
                    var calories = reader["calories"].ToString();
                    Console.WriteLine($"Name - {name}, Type - {type}, Color - {color}, Calories - {calories}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void ShowAllNames(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                SortedSet<string> names = new SortedSet<string>();
                const string sqlQuery = "SELECT [name] FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    names.Add(name);
                }
                foreach (var item in names)
                {
                    Console.WriteLine($"Name - {item}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static SortedSet<string> ShowAllColors(string connectionString)
        {
            SortedSet<string> colors = new SortedSet<string>();
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                const string sqlQuery = "SELECT [color] FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var color = reader["color"].ToString();
                    colors.Add(color);
                }
                foreach (var item in colors)
                {
                    Console.WriteLine($"Color - {item}");
                }
                return colors;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
            return colors;
        }
        public static void MaxCalor(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string sqlQuery = "SELECT MAX(calories) FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                object max = sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                sqlConnection.Open();
                sqlQuery = $"SELECT * FROM dbo.VAF WHERE calories='{max}'";
                using var sqlCommand2 = new SqlCommand(sqlQuery, sqlConnection);
                using var reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    var name = reader2["name"].ToString();
                    var type = reader2["type"].ToString();
                    var color = reader2["color"].ToString();
                    var calories = reader2["calories"].ToString();
                    Console.WriteLine($"Name - {name}, Type - {type}, Color - {color}, Calories - {calories}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void MinCalor(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string sqlQuery = "SELECT MIN(calories) FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                object min = sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                sqlConnection.Open();
                sqlQuery = $"SELECT * FROM dbo.VAF WHERE calories='{min}'";
                using var sqlCommand2 = new SqlCommand(sqlQuery, sqlConnection);
                using var reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    var name = reader2["name"].ToString();
                    var type = reader2["type"].ToString();
                    var color = reader2["color"].ToString();
                    var calories = reader2["calories"].ToString();
                    Console.WriteLine($"Name - {name}, Type - {type}, Color - {color}, Calories - {calories}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void MeanCalor(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string sqlQuery = "SELECT AVG(calories) FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                object avg = sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                Console.WriteLine(avg.ToString());

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void VegetablesCount(string connectionString)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string sqlQuery = "SELECT COUNT(*) FROM dbo.VAF WHERE type='vegetable'";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);;
            object count = sqlCommand.ExecuteScalar();
            Console.WriteLine(count.ToString());
        }
        public static void FruitsCount(string connectionString)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string sqlQuery = "SELECT COUNT(*) FROM dbo.VAF WHERE type='fruit'";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection); ;
            object count = sqlCommand.ExecuteScalar();
            Console.WriteLine(count.ToString());
        }
        public static void SelectColor(string connectionString)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ShowAllColors(connectionString);
            string input = Console.ReadLine();
            string sqlQuery = $"SELECT COUNT(*) FROM dbo.VAF WHERE color='{input}'";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection); ;
            object count = sqlCommand.ExecuteScalar();
            Console.WriteLine(count.ToString());
        }
        public static void RedOrYellow(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                const string sqlQuery = "SELECT [name] FROM dbo.VAF WHERE color='yellow' OR color='red'";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    Console.WriteLine($"Name: {name}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void EveryColor(string connectionString)
        {
            try
            {
                SortedSet<string> colors = ShowAllColors(connectionString);
                foreach (var item in colors)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    string sqlQuery = $"SELECT * FROM dbo.VAF WHERE color='{item}'";
                    using var sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                    using var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var name = reader["name"].ToString();
                        var type = reader["type"].ToString();
                        var color = reader["color"].ToString();
                        var calories = reader["calories"].ToString();
                        Console.WriteLine($"Name - {name}, Type - {type}, Color - {color}, Calories - {calories}");
                    }
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void CaloriesBelowInput(string connectionString)
        {
            try
            {
                Console.WriteLine("Введите максимум калорий: ");
                string maxCalories = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                string sqlQuery = $"SELECT * FROM dbo.VAF WHERE calories<{maxCalories}";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var type = reader["type"].ToString();
                    var color = reader["color"].ToString();
                    var calories = reader["calories"].ToString();
                    Console.WriteLine($"Name - {name}, Type - {type}, Color - {color}, Calories - {calories}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void CaloriesAboveInput(string connectionString)
        {
            try
            {
                Console.WriteLine("Введите минимум калорий: ");
                string minCalories = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                string sqlQuery = $"SELECT * FROM dbo.VAF WHERE calories>{minCalories}";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var type = reader["type"].ToString();
                    var color = reader["color"].ToString();
                    var calories = reader["calories"].ToString();
                    Console.WriteLine($"Name - {name}, Type - {type}, Color - {color}, Calories - {calories}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void CaloriesDiapazon(string connectionString)
        {
            try
            {
                Console.WriteLine("Введите минимум калорий: ");
                string minCalories = Console.ReadLine();
                Console.WriteLine("Введите максимум калорий: ");
                string maxCalories = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                string sqlQuery = $"SELECT * FROM dbo.VAF WHERE calories BETWEEN {minCalories} AND {maxCalories}";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var type = reader["type"].ToString();
                    var color = reader["color"].ToString();
                    var calories = reader["calories"].ToString();
                    Console.WriteLine($"Name - {name}, Type - {type}, Color - {color}, Calories - {calories}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void YellowColor(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                const string sqlQuery = "SELECT * FROM dbo.VAF WHERE color='yellow'";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var type = reader["type"].ToString();
                    var color = reader["color"].ToString();
                    var calories = reader["calories"].ToString();
                    Console.WriteLine($"Name - {name}, Type - {type}, Color - {color}, Calories - {calories}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
    }
}