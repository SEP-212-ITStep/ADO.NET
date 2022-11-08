using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Claims;
using System.Xml.Linq;

namespace TimurAzhiguzhayev_Console_App;
class Program
{
    public class Product
    {
        public string Name { get; set; } = default;
        public string ProductNumber { get; set; } = default;
        public bool MakeFlag { get; set; } = default;
        public bool FinishedGoodsFlag { get; set; } = default;
        public string Color { get; set; } = default;
        public string SafetyStockLevel { get; set; } = default;
        public int ReorderPoint { get; set; } = default;
        public double StandardCost { get; set; } = default;
        public double ListPrice { get; set; } = default;
        public string Size { get; set; } = default;
        public string SizeUnitMeasureCode { get; set; } = default;
        public string WeightUnitMeasureCode { get; set; } = default;
        public double Weight { get; set; } = default;
        public int DaysToManufacture { get; set; } = default;
        public string ProductLine { get; set; } = default;
        public string Class { get; set; } = default;
        public string Style { get; set; } = default;
        public int ProductSubcategoryID { get; set; } = default;
        public int ProductModelID { get; set; } = default;
        public DateTime SellStartDate { get; set; } = default;
        public DateTime SellEndDate { get; set; } = default;
        public DateTime DiscontinuedDate { get; set; } = default;
        public string rowguid { get; set; } = default;
        public DateTime ModifiedDate { get; set; } = default;

        public Product(string Name, string ProductNumber, bool MakeFlag, bool FinishedGoodsFlag, string Color, string SafetyStockLevel, int ReorderPoint, double StandardCost, double ListPrice, string Size, string SizeUnitMeasureCode, string WeightUnitMeasureCode, double Weight, int DaysToManufacture, string ProductLine, string Class, string Style, int ProductSubcategoryID, int ProductModelID, DateTime SellStartDate, DateTime SellEndDate, DateTime DiscontinuedDate, string rowguid, DateTime ModifiedDate)
        {
            this.Name = Name;
            this.ProductNumber = ProductNumber;
            this.MakeFlag = MakeFlag;
            this.FinishedGoodsFlag=FinishedGoodsFlag;
            this.Color=Color;
            this.SafetyStockLevel = SafetyStockLevel;
            this.ReorderPoint = ReorderPoint;
            this.StandardCost = StandardCost;
            this.ListPrice = ListPrice;
            this.Size = Size;
            this.SizeUnitMeasureCode = SizeUnitMeasureCode;
            this.WeightUnitMeasureCode = WeightUnitMeasureCode;
            this.Weight = Weight;
            this.DaysToManufacture = DaysToManufacture;
            this.ProductLine = ProductLine;
            this.Class = Class;
            this.Style = Style;
            this.ProductSubcategoryID = ProductSubcategoryID;
            this.ProductModelID = ProductModelID;
            this.SellStartDate = SellStartDate;
            this.SellEndDate = SellEndDate;
            this.DiscontinuedDate = DiscontinuedDate;
            this.rowguid = rowguid;
            this.ModifiedDate = ModifiedDate;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} |{6}| {7:0.00} {8:0.00} {9} {10} {11} {12:0.00} {13} {14} {15} {16} {17} {18:MM/dd/yy} {19:MM/dd/yy} {20:MM/dd/yy} {21} {22:MM/dd/yy}", Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size,  SizeUnitMeasureCode,  WeightUnitMeasureCode,  Weight,  DaysToManufacture,  ProductLine,  Class,  Style,  ProductSubcategoryID, ProductModelID,  SellStartDate,  SellEndDate,  DiscontinuedDate,  rowguid, ModifiedDate);
        }

        public static List<Product> products = new List<Product>();
        public static void getData()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=AdventureWorks2019;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [Name]   ,[ProductNumber]   ,[MakeFlag]   ,[FinishedGoodsFlag]   ,[Color]   ,[SafetyStockLevel]   ,[ReorderPoint]   ,[StandardCost]   ,[ListPrice]   ,[Size]   ,[SizeUnitMeasureCode]   ,[WeightUnitMeasureCode]   ,[Weight]   ,[DaysToManufacture]   ,[ProductLine]   ,[Class]   ,[Style]   ,[ProductSubcategoryID]   ,[ProductModelID]   ,[SellStartDate]   ,[SellEndDate]   ,[DiscontinuedDate]   ,[rowguid]   ,[ModifiedDate] FROM Production.Product";

                bool MakeFlagTemp=default;
                bool FinishedGoodsFlagTemp=default;
                var ColorTemp = "";
                string SizeTemp = "";
                string SizeUnitMeasureCodeTemp = "";
                string WeightUnitMeasureCodeTemp = "";
                double WeightTemp = default;
                string ProductLineTemp = "";
                string ClassTemp = "";
                string StyleTemp = "";
                int ProductSubcategoryIDTemp = default;
                int ProductModelIDTemp = default;
                DateTime SellEndDateTemp=default;
                DateTime DiscontinuedEndDateTemp= default;

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Name = reader["Name"].ToString();
                    var ProductNumber = reader["ProductNumber"].ToString();
                    var MakeFlag = reader["MakeFlag"];
                    
                    if (MakeFlag is not null && MakeFlag is not DBNull)
                    {
                        MakeFlagTemp=bool.Parse(MakeFlag.ToString());
                    }
                    var FinishedGoodsFlag = reader["FinishedGoodsFlag"];
                    
                    if (FinishedGoodsFlag is not null && FinishedGoodsFlag is not DBNull)
                    {
                        FinishedGoodsFlagTemp=bool.Parse(FinishedGoodsFlag.ToString());
                    }
                    var Color = reader["Color"];
                    if (Color is not null && Color is not DBNull)
                    {
                        ColorTemp=Color.ToString();
                    }
                    var SafetyStockLevel = reader["SafetyStockLevel"].ToString();
                    var ReorderPoint = Convert.ToInt32(reader["ReorderPoint"]);
                    var StandardCost = Convert.ToDouble(reader["StandardCost"]);
                    var ListPrice = Convert.ToDouble(reader["ListPrice"].ToString());
                    var Size = reader["Size"];
                    if (Size is not null && Size is not DBNull)
                    {
                        SizeTemp = Size.ToString();
                    }
                    var SizeUnitMeasureCode = reader["SizeUnitMeasureCode"];
                    if (SizeUnitMeasureCode is not null && SizeUnitMeasureCode is not DBNull)
                    {
                        SizeUnitMeasureCodeTemp = SizeUnitMeasureCode.ToString();
                    }
                    var WeightUnitMeasureCode = reader["WeightUnitMeasureCode"];
                    if (WeightUnitMeasureCode is not null && WeightUnitMeasureCode is not DBNull)
                    {
                        WeightUnitMeasureCodeTemp=WeightUnitMeasureCode.ToString();
                    }
                    var Weight = reader["Weight"];
                    if (Weight is not null && Weight is not DBNull)
                    {
                        WeightTemp=Convert.ToDouble(Weight.ToString());
                    }
                    var DaysToManufacture = Convert.ToInt32(reader["DaysToManufacture"]);

                    var ProductLine = reader["ProductLine"];
                    if (ProductLine is not null && ProductLine is not DBNull)
                    {
                        ProductLineTemp=reader["ProductLine"].ToString();
                    }
                    var Class = reader["Class"];
                    if (Class is not null && Class is not DBNull)
                    {
                        ClassTemp=reader["Class"].ToString();
                    }
                    var Style = reader["Style"];
                    if (Style is not null && Style is not DBNull)
                    {
                        StyleTemp=reader["Style"].ToString();
                    }
                    var ProductSubcategoryID = reader["ProductSubcategoryID"];
                    if (ProductSubcategoryID is not null && ProductSubcategoryID is not DBNull)
                    {
                        ProductSubcategoryIDTemp=Convert.ToInt32(reader["ProductSubcategoryID"]);
                    }
                    var ProductModelID = reader["ProductModelID"];
                    if (ProductModelID is not null && ProductModelID is not DBNull)
                    {
                        ProductModelIDTemp=Convert.ToInt32(reader["ProductModelID"]);
                    }
                    var SellStartDate = DateTime.Parse(reader["SellStartDate"].ToString());

                    var SellEndDate = reader["SellEndDate"];
                    if (SellEndDate is not null && SellEndDate is not DBNull)
                    {
                        SellEndDateTemp=DateTime.Parse(reader["SellEndDate"].ToString());
                    }
                    var DiscontinuedDate = reader["DiscontinuedDate"];
                    if (DiscontinuedDate is not null && DiscontinuedDate is not DBNull)
                    {
                        DiscontinuedEndDateTemp=DateTime.Parse(reader["DiscontinuedDate"].ToString());
                    }
                    var rowguid = reader["rowguid"].ToString();
                    var ModifiedDate = DateTime.Parse(reader["ModifiedDate"].ToString());
                    
                    Product product = new Product(Name, ProductNumber, MakeFlagTemp, FinishedGoodsFlagTemp, ColorTemp, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, SizeTemp, SizeUnitMeasureCodeTemp, WeightUnitMeasureCodeTemp, WeightTemp, DaysToManufacture, ProductLineTemp, ClassTemp, StyleTemp, ProductSubcategoryIDTemp, ProductModelIDTemp, SellStartDate, SellEndDateTemp, DiscontinuedEndDateTemp, rowguid, ModifiedDate);

                    if(product.ReorderPoint>3)
                    {
                        products.Add(product);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(product);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine(product);
                    }
                    //Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16} {17} {18} {19} {20} {21} {22}", Name, ProductNumber, MakeFlag, FinishedGoodsFlag, Color, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, Size, SizeUnitMeasureCode, WeightUnitMeasureCode, Weight, DaysToManufacture, ProductLine, Class, Style, ProductSubcategoryID, ProductModelID, SellStartDate, SellEndDate, DiscontinuedDate, rowguid, ModifiedDate);
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void Main(string[] args)
        {
            const string ConnectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=AdventureWorks2019;User Id=sa;Password=Qwerty123!;Encrypt=false;";

            var sqlconnection = new SqlConnection(ConnectionString);
            sqlconnection.Open();

            try
            {
                getData();
                Console.WriteLine("Всего записей - {0}",products.Count()); ;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //using var sqlCommand= sqlconnection.CreateCommand();
            //sqlCommand.CommandText = "SELECT TOP (1000) [AddressID]      ,[AddressLine1]      ,[AddressLine2]      ,[City]      ,[StateProvinceID]      ,[PostalCode]      ,[SpatialLocation]      ,[rowguid]      ,[ModifiedDate]  FROM [AdventureWorks2019].[Person].[Address]";


            ////Последний код. Сохранить!!!
            ////начало
            //var adapter = new SqlDataAdapter("SELECT City, AddressLine1,PostalCode FROM  " + "[AdventureWorks2019].[Person].[Address]", sqlconnection);

            //var dataSet = new DataSet();
            //adapter.Fill(dataSet);
            //var rows = dataSet.Tables[0].Rows;
            //int count = 0;
            //foreach (DataRow dataRow in rows)
            //{
            //    if (count++ >= 100)
            //    {
            //        return;
            //    }
            //    var addressLine = dataRow["Addressline1"];
            //    var city = dataRow["City"];
            //    var postalCode = dataRow["PostalCode"];

            //    Console.WriteLine($"{addressLine},{city},{postalCode}");
            //}
            //sqlconnection.Close();
            ////конец


        }
    }
}