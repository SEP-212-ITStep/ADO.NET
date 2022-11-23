using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Reflection;
using System.Collections;
using System.Threading.Tasks.Dataflow;

namespace Issakov_Jacob_HW_lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-6O1ENUJ;Database=Cars_Show_Room;" +
                "Trusted_Connection=true;Encrypt=false;";





            ShowMenu();
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    //a.Показать все модели за введенный год(к примеру 2002, 2012, 2022)
                    Console.WriteLine("Enter year: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    SelectYear(connectionString, year);
                    break;
                case 2:
                    //b.Выбрать конкретную машину под номером модели и года
                    Console.WriteLine("Enter the model name: ");
                    string model = Console.ReadLine();
                    Console.WriteLine("Enter year: ");
                    year = Convert.ToInt32(Console.ReadLine());
                    SelectModelAndYear(connectionString, model, year);
                    break;
                case 3:
                    //i.Показать Базовые характеристики выбранного автомобиля
                    ShowAll(connectionString);
                    Console.WriteLine("Choose model from the list: ");
                    model = Console.ReadLine();
                    BaseСharacteristics(connectionString, model);
                    break;
                case 4:
                    //ii.Внести дополнительную информацию по машине(SqlUpdateCommand)
                    Update(connectionString);
                    break;
                case 5:
                    //c.Добавить новую машину(SqlInsertCommand)
                    Add(connectionString);
                    break;
                case 6:
                    Delete(connectionString);
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
            Console.WriteLine("\n6 - Удалить машину");
        }
        static void SelectYear(string connectionString, int year)
        {
            string sqlQuery = $"SELECT * FROM dbo.Car WHERE age={year}";
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
            string sqlQuery = $"SELECT * FROM Characteristics WHERE model='{model}'";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet ds = new DataSet("Cars_Show_Room");
            da.Fill(ds, "dbo.Сharacteristics");
            DataTable dt = ds.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine($"speed: {item["speed"].ToString()}, ATH: {item["ATH"].ToString()}, " +
                                  $"Horse_Power: {item["Horse_Power"].ToString()}, Weight: {item["Weight"].ToString()}, " +
                                  $"Color: {item["Color"].ToString()}");

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
            string sqlQuery;
            if (c == "Color" || c == "Model" || c == "ATH")
                sqlQuery = $"UPDATE Characteristics SET {c} = '{new_value}' WHERE model='{model}'";
            else
                sqlQuery = $"UPDATE Characteristics SET {c} = {new_value} WHERE model='{model}'";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet ds = new DataSet("dbo.Characteristics");
            da.Fill(ds);
        }
        public static void Add(string connectionString)
        {
            try
            {
                Console.WriteLine("Enter the brand: ");
                string brand = Console.ReadLine();
                Console.WriteLine("Enter the model: ");
                string model = Console.ReadLine();
                Console.WriteLine("Enter the age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                string sqlQuery = $"INSERT INTO Car (Brand, Model, Age) VALUES ('{brand}', '{model}', {age})";
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connectionString);
                DataSet ds = new DataSet("dbo.Car");
                da.Fill(ds);
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                Console.WriteLine("Now enter please base characteristics: ");
                Console.WriteLine("Enter the speed: ");
                string speed_ = Console.ReadLine();
                int speed = Convert.ToInt32(speed_);
                Console.WriteLine("Enter the ATH: ");
                string ATH = Console.ReadLine();
                Console.WriteLine("Enter the horse power: ");
                string horsePower_ = Console.ReadLine();
                int horsePower = Convert.ToInt32(horsePower_);
                Console.WriteLine("Enter the weight: ");
                string weight_ = Console.ReadLine();
                int weight = Convert.ToInt32(weight_);
                Console.WriteLine("Enter the color: ");
                string color = Console.ReadLine();
                Console.WriteLine("Enter the model: ");
                string model2 = Console.ReadLine();
                string sqlQuery2 = $"INSERT INTO Characteristics (Speed, ATH, Horse_Power, Weight, Color, Model) " +
                    $"VALUES ({speed}, '{ATH}', {horsePower}, {weight}, '{color}', '{model2}')";
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery2, connectionString);
                DataSet ds = new DataSet("dbo.Characteristics");
                da.Fill(ds);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Delete(string connectionString)
        {
            Console.WriteLine("Enter the model: ");
            string model = Console.ReadLine();
            string sqlQuery = $"DELETE FROM Car WHERE Model='{model}'";
            string sqlQuery2 = $"DELETE FROM Characteristics WHERE Model='{model}'";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet ds = new DataSet("dbo.Car");
            da.Fill(ds);
            da = new SqlDataAdapter(sqlQuery2, connectionString);
            ds = new DataSet("dbo.Characteristics");
            da.Fill(ds);
        }
    }
}