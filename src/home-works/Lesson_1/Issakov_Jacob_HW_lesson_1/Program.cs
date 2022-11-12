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
            ShowAllColors(connectionString);



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
            //■ Показать количество овощей и фруктов заданного
            //цвета;
            // $"SELECT COUNT(*) FROM dbo.VAF WHERE color='input'";
            //■ Показать количество овощей фруктов каждого цвета;

            //■ Показать овощи и фрукты с калорийностью ниже
            //указанной;
            // $"SELECT * FROM dbo.VAF WHERE calories<'input'";
            //■ Показать овощи и фрукты с калорийностью выше
            //указанной;
            // $"SELECT * FROM dbo.VAF WHERE calories>'input'";
            //■ Показать овощи и фрукты с калорийностью в указанном диапазоне;
            // $"SELECT * FROM dbo.VAF WHERE calories BETWEEN 'input1' AND 'input2'";
            //■ Показать все овощи и фрукты, у которых цвет желтый
            // "SELECT [name] FROM dbo.VAF WHERE color='yellow'";



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
                const string sqlQuery = "SELECT [name] FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    Console.WriteLine($"Name - {name}");
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        public static void ShowAllColors(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                SortedSet<string> colors = new SortedSet<string>();
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
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
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
                string sqlQuery = "SELECT * FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                int min = int.MaxValue;
                while (reader.Read())
                {
                    var calories = Convert.ToInt32(reader["calories"].ToString());

                    if (calories < min)
                        min = calories;
                }
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
                string sqlQuery = "SELECT * FROM dbo.VAF";
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();;
                int sum = 0;
                int amount = 0;
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var type = reader["type"].ToString();
                    var color = reader["color"].ToString();
                    var calories = Convert.ToInt32(reader["calories"].ToString());
                    sum += calories;
                    amount++;
                }
                Console.WriteLine($"Mean calories: {sum / amount}");
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
    }
}