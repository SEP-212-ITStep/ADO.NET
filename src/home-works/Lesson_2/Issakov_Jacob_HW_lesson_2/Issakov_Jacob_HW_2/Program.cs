using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

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
            //AddNewGood(connectionString);


            //■ Вставка новых типов товаров;
            //AddNewType(connectionString);


            //Вставка новых поставщиков.
            //AddNewSupplier(connectionString);



            //Задание 2
            //Добавьте к приложению из практического задания по
            //базе данных «Склад» такую функциональность:


            //■ Обновление информации о существующих товарах;
            //UpdateGood(connectionString, "Apple", "Ipad Mini");


            //■ Обновление информации о существующих поставщиках;
            //UpdateSupplier(connectionString, "Apple");


            //■ Обновление информации о существующих типах товаров
            //UpdateType(connectionString, "Apple", "Ipad");



            //Задание 3
            //Добавьте к приложению из практического задания по
            //базе данных «Склад» такую функциональность:


            //■ Удаление товаров;
            //RemoveGood(connectionString);

            //■ Удаление поставщиков;
            //RemoveSupplier(connectionString, "Apple", "Ipad 14");

            //■ Удаление типов товаров
            //RemoveType(connectionString, "Tablet", "Apple");


            //Задание 4
            //Добавьте к приложению из практического задания по
            //базе данных «Склад» такую функциональность:


            //■ Показать информацию о поставщике с наибольшим
            //количеством товаров на складе;
            //SupplierWithMaxAmount(connectionString);

            //■ Показать информацию о поставщике с наименьшим
            //количеством товаров на складе;
            //SupplierWithMinAmount(connectionString);

            //■ Показать информацию о типе товаров с наибольшим
            //количеством товаров на складе;


            //■ Показать информацию о типе товаров с наименьшим
            //количеством товаров на складе;


            //■ Показать товары с поставки, которых прошло заданное количество дней.
            //ShowGoodsFromDate(connectionString, 100);
        }

        static void AddNewGood(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Name Product: ");
                string name = Console.ReadLine();
                Console.WriteLine("Type name: ");
                string type = Console.ReadLine();
                Console.WriteLine("Supplier name: ");
                string supplier = Console.ReadLine();
                Console.WriteLine("Amount: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Cost price: ");
                int costPrice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(costPrice * 1.0);
                Console.WriteLine("Delivery date: ");
                string date = Console.ReadLine();

                string sqlQuery = String.Format($"INSERT INTO Goods (Name, Type, Supplier, Amount, Cost_Price, Delivery_Date)" +
                $" VALUES ('{name}', '{type}', '{supplier}', {amount}, {costPrice}, '{date}')");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        static void AddNewType(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Type name: ");
                string type = Console.ReadLine();
                Console.WriteLine("Supplier name: ");
                string supplier = Console.ReadLine();

                string sqlQuery = String.Format($"INSERT INTO Types (Type, Supplier)" +
                $" VALUES ('{type}', '{supplier}')");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        static void AddNewSupplier(string connectionString)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Name Product: ");
                string name = Console.ReadLine();
                Console.WriteLine("Type name: ");
                string type = Console.ReadLine();
                Console.WriteLine("Supplier name: ");
                string supplier = Console.ReadLine();
                Console.WriteLine("Delivery date: ");
                string date = Console.ReadLine();

                string sqlQuery = String.Format($"INSERT INTO Suppliers (Goods_Name, Type, Supplier, Delivery_Date)" +
                $" VALUES ('{name}', '{type}', '{supplier}', '{date}')");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        static void UpdateGood(string connectionString, string supplier, string previousName)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("New Name Product: ");
                string name = Console.ReadLine();
                Console.WriteLine("New Type name: ");
                string type = Console.ReadLine();
                Console.WriteLine("Amount: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Cost price: ");
                int costPrice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("New Delivery date: ");
                string date = Console.ReadLine();

                string sqlQuery = String.Format($"UPDATE Goods SET Name='{name}', Type='{type}', Amount='{amount}', Cost_Price='{costPrice}', Delivery_Date='{date}' " +
                                                $"WHERE Name='{previousName}' AND Supplier='{supplier}'");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        static void UpdateType(string connectionString, string previousSupplier, string previousType)
        {
            try 
            {
            Console.ForegroundColor = ConsoleColor.Red;
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("New Type name: ");
            string type = Console.ReadLine();
            Console.WriteLine("New Supplier name: ");
            string supplier = Console.ReadLine();

            string sqlQuery = String.Format($"UPDATE Types SET Type='{type}', Supplier='{supplier}' " +
                                            $"WHERE Supplier='{previousSupplier}' AND Type='{previousType}'");
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        static void UpdateSupplier(string connectionString, string previousSupplier) 
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("New Name Product: ");
                string name = Console.ReadLine();
                Console.WriteLine("New Type name: ");
                string type = Console.ReadLine();
                Console.WriteLine("New Supplier name: ");
                string supplier = Console.ReadLine();
                Console.WriteLine("New Delivery date: ");
                string date = Console.ReadLine();

                string sqlQuery = String.Format($"UPDATE Suppliers SET Goods_Name='{name}', Supplier='{supplier}', Type='{type}', Delivery_Date='{date}' " +
                                                $"WHERE Supplier='{previousSupplier}'");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Подключение к базе прошло не успешно");
            }
        }
        static void RemoveGood(string connectionString)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string sqlQuery = String.Format("DELETE FROM Goods WHERE Amount > 300");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void RemoveSupplier(string connectionString, string supplier, string goodsName)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string sqlQuery = String.Format($"DELETE FROM Suppliers WHERE Supplier='{supplier}' AND Goods_Name='{goodsName}'");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void RemoveType(string connectionString, string type, string supplier)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string sqlQuery = String.Format($"DELETE FROM Types WHERE Type='{type}' AND Supplier='{supplier}'");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void SupplierWithMaxAmount(string connectionString)
        {
            try
            {
                const string sqlQuery= "SELECT * FROM Goods";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                int max = 0;
                string nameMax = "";
                while (reader.Read())
                {
                    var goodsName = reader["Name"].ToString();
                    var amount = reader["Amount"].ToString();
                    if (!string.IsNullOrEmpty(amount) && Int32.Parse(amount) > max)
                    {

                        max = Int32.Parse(amount);
                        nameMax = goodsName;
                    }
                }

                string sql = String.Format($"SELECT * FROM Suppliers WHERE Goods_Name='{nameMax}'");

                using var sqlConnection2 = new SqlConnection(connectionString);
                sqlConnection2.Open();
                using var sqlCommand2 = new SqlCommand(sql, sqlConnection2);
                using var reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    var goodSName = reader2["Goods_Name"].ToString();
                    var type = reader2["Type"].ToString();
                    var supplier = reader2["Supplier"].ToString();
                    var deliveryDate = reader2["Delivery_Date"].ToString();

                    Console.WriteLine("Supplier with MAX Goods Amount: ");
                    Console.WriteLine($"Goods Name - {goodSName}, Type - {type}, Supplier - {supplier}, Delivery date - {deliveryDate}, Amount: {max}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void SupplierWithMinAmount(string connectionString)
        {
            try
            {
                const string sqlQuery = "SELECT * FROM Goods";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                int max = int.MaxValue;
                string nameMax = "";
                while (reader.Read())
                {
                    var goodsName = reader["Name"].ToString();
                    var amount = reader["Amount"].ToString();
                    //Console.WriteLine($"[good's name - {goodSName}, type - {type}, quantity - {quantity}, cost - {cost}, delivery date - {deliveryDate}]");
                    if (!string.IsNullOrEmpty(amount) && Int32.Parse(amount) < max)
                    {

                        max = Int32.Parse(amount);
                        nameMax = goodsName;
                    }
                }

                string sql = String.Format($"SELECT * FROM Suppliers WHERE Goods_Name='{nameMax}'");

                using var sqlConnection2 = new SqlConnection(connectionString);
                sqlConnection2.Open();
                using var sqlCommand2 = new SqlCommand(sql, sqlConnection2);
                using var reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    var goodSName = reader2["Goods_Name"].ToString();
                    var type = reader2["Type"].ToString();
                    var supplier = reader2["Supplier"].ToString();
                    var deliveryDate = reader2["Delivery_Date"].ToString();

                    Console.WriteLine("Supplier with MAX Goods Amount: ");
                    Console.WriteLine($"Goods Name - {goodSName}, Type - {type}, Supplier - {supplier}, Delivery date - {deliveryDate}, Amount: {max}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ShowGoodsFromDate(string connectionString, int days)
        {
            try
            {

                string SqlQuerty = String.Format("SELECT * FROM Goods;");

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    var goodsName = reader["Name"].ToString();
                    var type = reader["Type"].ToString();
                    var supplier = reader["Supplier"].ToString();
                    var amount = reader["Amount"].ToString();
                    var costPrice = reader["Cost_Price"].ToString();
                    var deliveryDate = reader["Delivery_Date"].ToString();

                    if (DateTime.Today.AddDays(-days) < DateTime.Parse(deliveryDate))
                    {
                        Console.WriteLine($"Name - {goodsName}, Type - {type}, Supplier: {supplier}, Cost Price - {costPrice}, Amount - {amount}, Delivery date - {deliveryDate}");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}