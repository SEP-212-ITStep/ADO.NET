using System;
using System.Data;
using Microsoft.Data.SqlClient;
namespace LukmankhakimDarkhan_Console_App_Lesson_3
{
    public class Product
    {
        public string Name { get; set; }
        public int ReorderPoint { get; set; }

        public Product(string Name, int ReorderPoint)
        {
            this.Name = Name;
            this.ReorderPoint = ReorderPoint;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GetRecordersPoints();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void GetRecordersPoints()
        {
            //создаем подключение к серверу
            const string connectionString = "Server=223-9; Database=AdventureWorks2019;Trusted_Connection=true;Encrypt=false;";
            //создаем переменную куда оборочаваем SQL коды
            const string SqlQuery = "SELECT [ProductID]\r\n      " +
                ",[Name]\r\n      " +
                ",[ProductNumber]\r\n      " +
                ",[MakeFlag]\r\n      " +
                ",[FinishedGoodsFlag]\r\n      " +
                ",[Color]\r\n      " +
                ",[SafetyStockLevel]\r\n     " +
                " ,[ReorderPoint]\r\n      " +
                ",[StandardCost]\r\n     " +
                " ,[ListPrice]\r\n      " +
                ",[Size]\r\n     " +
                " ,[SizeUnitMeasureCode]\r\n     " +
                " ,[WeightUnitMeasureCode]\r\n   " +
                "   ,[Weight]\r\n    " +
                "  ,[DaysToManufacture]\r\n    " +
                "  ,[ProductLine]\r\n      ,[Class]\r\n   " +
                "   ,[Style]\r\n   " +
                "   ,[ProductSubcategoryID]\r\n   " +
                "   ,[ProductModelID]\r\n    " +
                "  ,[SellStartDate]\r\n   " +
                "   ,[SellEndDate]\r\n   " +
                "   ,[DiscontinuedDate]\r\n   " +
                "   ,[rowguid]\r\n     " +
                " ,[ModifiedDate]\r\n  " +
                "FROM [AdventureWorks2019].[Production].[Product]";

            //используем метод для подключения к серверу
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //используем метод для вычитывание SQL кода
            using var sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            //выводим в цикле данные из таблицы
            while (reader.Read())
            {

                var name = reader["Name"].ToString();
                int point = int.Parse(reader["ReorderPoint"].ToString());
                if (point > 3)
                {
                    Product product = new Product(name, point);
                    products.Add(product);
                    //Console.WriteLine($"Name is - {name}, Reorder Point - {point}");
                }
            }

            foreach (var item in products)
            {
                Console.Write($"Name is - {item.Name}");
                Console.WriteLine($"|| RecorderPoint is - {item.ReorderPoint}");
            }
        }
        public static void GetsAlls()
        {



            //создаем подключение к серверу
            const string connectionString = "Server=223-9; Database=AdventureWorks2019;Trusted_Connection=true;Encrypt=false;";
            try
            {
                //создаем переменную куда оборочаваем SQL коды
                const string SqlQuery = "SELECT [ProductID]\r\n      " +
                    ",[Name]\r\n      " +
                    ",[ProductNumber]\r\n      " +
                    ",[MakeFlag]\r\n      " +
                    ",[FinishedGoodsFlag]\r\n      " +
                    ",[Color]\r\n      " +
                    ",[SafetyStockLevel]\r\n     " +
                    " ,[ReorderPoint]\r\n      " +
                    ",[StandardCost]\r\n     " +
                    " ,[ListPrice]\r\n      " +
                    ",[Size]\r\n     " +
                    " ,[SizeUnitMeasureCode]\r\n     " +
                    " ,[WeightUnitMeasureCode]\r\n   " +
                    "   ,[Weight]\r\n    " +
                    "  ,[DaysToManufacture]\r\n    " +
                    "  ,[ProductLine]\r\n      ,[Class]\r\n   " +
                    "   ,[Style]\r\n   " +
                    "   ,[ProductSubcategoryID]\r\n   " +
                    "   ,[ProductModelID]\r\n    " +
                    "  ,[SellStartDate]\r\n   " +
                    "   ,[SellEndDate]\r\n   " +
                    "   ,[DiscontinuedDate]\r\n   " +
                    "   ,[rowguid]\r\n     " +
                    " ,[ModifiedDate]\r\n  " +
                    "FROM [AdventureWorks2019].[Production].[Product]";

                //используем метод для подключения к серверу
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                //используем метод для вычитывание SQL кода
                using var sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                //выводим в цикле данные из таблицы
                while (reader.Read())
                {

                    var id = reader["ProductID"].ToString();
                    var name = reader["Name"].ToString();
                    var number = reader["ProductNumber"].ToString();
                    var make = reader["MakeFlag"].ToString();
                    var finished = reader["FinishedGoodsFlag"].ToString();
                    var color = reader["Color"].ToString();
                    var level = reader["SafetyStockLevel"].ToString();
                    var point = reader["ReorderPoint"].ToString();
                    var cost = reader["StandardCost"].ToString();
                    var price = reader["ListPrice"].ToString();
                    var size = reader["Size"].ToString();
                    var sizeunit = reader["SizeUnitMeasureCode"].ToString();
                    var weightunit = reader["WeightUnitMeasureCode"].ToString();
                    var Weight = reader["Weight"].ToString();
                    var DaysToManufacture = reader["DaysToManufacture"].ToString();
                    var ProductLine = reader["ProductLine"].ToString();
                    var Class = reader["Class"].ToString();
                    var Style = reader["Style"].ToString();
                    var ProductSubcategoryID = reader["ProductSubcategoryID"].ToString();
                    var ProductModelID = reader["ProductModelID"].ToString();
                    var SellStartDate = reader["SellStartDate"].ToString();
                    var DiscontinuedDate = reader["DiscontinuedDate"].ToString();
                    var rowguid = reader["rowguid"].ToString();
                    var ModifiedDate = reader["ModifiedDate"].ToString();
                    //var point = reader["ReorderPoint"].ToString();
                    Console.WriteLine($"Name is - {name}, Product number is - {number}, Price - {price}, Color - {color}, Maked - {make}, Reorder Point - {point}");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void GetDataSet()
        {


            const string ConnectionString = "Server=223-9; Database=AdventureWorks2019;Trusted_Connection=true;Encrypt=false;";
            var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            var adapter = new SqlDataAdapter("SELECT TOP 10 City, AddressLine1, PostalCode FROM" + "[AdventureWorks2019].[Person].[Address]", sqlConnection);
            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            var rows = dataSet.Tables[0].Rows;
            int count = 0;
            foreach (DataRow dataRow in rows)
            {
                if (count++ >= 100)
                {
                    return;
                }
                var addressLine = dataRow["AddressLine1"];
                var city = dataRow["City"];
                var postalCode = dataRow["PostalCode"];
                Console.WriteLine($"{addressLine}, {city}, {postalCode}");
            }

        }
    }
}