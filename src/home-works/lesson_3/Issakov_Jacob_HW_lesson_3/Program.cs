using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Collections;

namespace Issakov_Jacob_HW_lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-6O1ENUJ;Database=Cars_Show_Room;" +
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

            ShowMenu();
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter year: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    SelectYear(connectionString, year);
                    break;
                case 2:
                    ShowAll(connectionString);
                    Console.WriteLine("Choose model from the list: ");
                    string model = Console.ReadLine();
                    Console.WriteLine("Enter year: ");
                    year = Convert.ToInt32(Console.ReadLine());
                    SelectModelAndYear(connectionString, model, year);
                    break;
                case 3:
                    ShowAll(connectionString);
                    Console.WriteLine("Choose model from the list: ");
                    model = Console.ReadLine();
                    BaseСharacteristics(connectionString, model);
                    break;
                case 4:
                    Update(connectionString);
                    break;
                case 5:
                    Add(connectionString);
                    break;

            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("1 - Показать все модели за введённый год");
            Console.WriteLine("\n2 - Выбрать конкретную машину под номером модели и года");
            Console.WriteLine("\n3 - Показать Базовые характеристики выбранного автомобиля");
            Console.WriteLine("\n4 - Внести дополнительную информацию по машине (SqlUpdateCommand)");
            Console.WriteLine("\n5 - Добавить новую машину (SqlInsertCommand)");

        }
        static void SelectYear(string connectionString, int year)
        {
            string sqlQuery = $"SELECT * FROM dbo.Car WHERE age='{year}'";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var brand = reader["brand"].ToString();
                var model = reader["model"].ToString();
                var age = reader["age"].ToString();
                Console.WriteLine($"Brand: {brand}, Model: {model}, Age: {age}");
            }
        }
        static void SelectModelAndYear(string connectionString, string model2,int year)
        {
            string sqlQuery = $"SELECT * FROM dbo.Car WHERE model='{model2}' AND age='{year}'";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var brand = reader["brand"].ToString();
                var model = reader["model"].ToString();
                var age = reader["age"].ToString();
                Console.WriteLine($"Brand: {brand}, Model: {model}, Age: {age}");
            }
        }
        static void ShowAll(string connectionString)
        {
            string sqlQuery = $"SELECT * FROM dbo.Car";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var brand = reader["brand"].ToString();
                var model = reader["model"].ToString();
                var age = reader["age"].ToString();
                Console.WriteLine($"Brand: {brand}, Model: {model}, Age: {age}");
            }
        }
        public static void BaseСharacteristics(string connectionString, string model)
        {
            string sqlQuery = $"SELECT * FROM dbo.Сharacteristics WHERE model='{model}'";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "dbo.Сharacteristics");
            DataTable dt = ds.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine($"speed: {item["speed"].ToString()}, ATH: {item["ATH"].ToString()}, " +
                    $"Horse_Power: {item["Horse_Power"].ToString()}, Weight: {item["Weight"].ToString()}, Color: {item["Color"].ToString()}");

            }
        }

        public static void Update(string connectionString)
        {
            ShowAll(connectionString);
            Console.WriteLine("Choose model from the list: ");
            string model = Console.ReadLine();
            BaseСharacteristics(connectionString, model);
            Console.WriteLine("Choose characteristic: ");
            string c = Console.ReadLine();
            Console.WriteLine("Write new value: ");
            string new_value = Console.ReadLine();
            string sqlQuery = $"SELECT * FROM dbo.Сharacteristics WHERE model='{model}'";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "dbo.Characteristics");
            DataTable table = ds.Tables[0];
            switch (c)
            {
                case "speed":
                    table.Rows[0][c] = Convert.ToDouble(new_value);
                    break;
                case "ATH":
                    table.Rows[0][c] = Convert.ToDouble(new_value);
                    break;
                case "Horse_Power":
                    table.Rows[0][c] = Convert.ToInt32(new_value);
                    break;
                default:
                    table.Rows[0][c] = new_value;
                    break;
            }
        }
        public static void Add(string connectionString)
        {
            Console.WriteLine("Enter the brand: ");
            string brand = Console.ReadLine();
            Console.WriteLine("Enter the model: ");
            string model = Console.ReadLine();
            Console.WriteLine("Enter the age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            string sqlQuery = $"SELECT * FROM dbo.Car";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Car");
            DataRow dr = ds.Tables["Car"].NewRow();
            dr["Brand"] = brand;
            dr["Model"] = model;
            dr["Age"] = age;
        }
    }
}