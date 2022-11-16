using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Drawing;

namespace Issakov_Jacob_HW_lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-6O1ENUJ;Database=Storage;" +
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



            //Задание 1

            //Вставка новых товаров;
            Add(connectionString);

            //■ Вставка новых типов товаров;

            //Вставка новых поставщиков.



            // Отображение всей информации о товаре;
            // "SELECT * FROM dbo.Storage"

            // Отображение всех типов товаров;
            // "SELECT [type] FROM dbo.Storage" + Sorted Set

            // Отображение всех поставщиков;
            // "SELECT [supplier] FROM dbo.Storage" + Sorted Set

            // Показать товар с максимальным количеством;
            // "SELCT MAX(amount) FORM dbo.Storage"

            // Показать товар с минимальным количеством;
            // "SELCT MIN(amount) FORM dbo.Storage"

            // Показать товар с минимальной себестоимостью;
            // "SELCT MIN(cost_price) FORM dbo.Storage"

            // Показать товар с максимальной себестоимостью.
            // "SELCT MAX(cost_price) FORM dbo.Storage"
        }


        static void Add(string connectionString)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Name Product: ");
            var name = Console.ReadLine();
            Console.WriteLine("Type name: ");
            var type = Console.ReadLine();
            Console.WriteLine("Supplier name: ");
            var supplier = Console.ReadLine();
            Console.WriteLine("Amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cost price: ");
            double costPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(costPrice * 1.0);
            Console.WriteLine("Delivery date: ");
            DateTime deliveryDate = DateTime.Now;
            string sqlFormattedDate = deliveryDate.ToString("yyyy-MM-dd HH:mm:ss.fff"); // 2022-07-19 00:00:00.000
            Console.WriteLine(sqlFormattedDate);

            string sqlQuery = $"INSERT INTO dbo.Product (Name, Type, Supplier, Amount, Cost_Price, Delivery_Date)VALUES({name}," +
                              $" {type}, {supplier}, {amount}, {costPrice}, {sqlFormattedDate})";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            //try
            //{
            //}
            //catch (Exception)
            //{
            //    Console.ForegroundColor = ConsoleColor.DarkMagenta;
            //    Console.WriteLine("Подключение к базе прошло не успешно");
            //}
        }
    }
}