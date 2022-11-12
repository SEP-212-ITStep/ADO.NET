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
    }
}