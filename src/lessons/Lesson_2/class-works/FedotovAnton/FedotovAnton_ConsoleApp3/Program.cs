using Microsoft.Data.SqlClient;
using System.Data;
namespace FedotovAnton_ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-U7VKKN0;Database=AdventureWorks2019;" + "Trusted_Connection=true;Encrypt=false";

            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var adapter = new SqlDataAdapter(selectCommandText: "SELECT City,AddressLine1,PostalCode FROM " +
                "[AdventureWorks2019].[Person].[Address] ORDER By City", sqlConnection);

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
            sqlConnection.Close();
        }
    }
}
            
            
            //try
            //{
            //    const string SqlQuery = "SELECT [ProductID]," +
            //        "[Name], [ProductNumber], [MakeFlag], [FinishedGoodsFlag], " +
            //        "[Color], [SafetyStockLevel], [ReorderPoint]," +
            //        "[StandardCost], [ListPrice], [Size],[SizeUnitMeasureCode],[WeightUnitMeasureCode], " +
            //        "[Weight], [DaysToManufacture], [ProductLine], [Class], [Style],[ProductSubcategoryID]," +
            //        "[ProductModelID],[SellStartDate],[SellEndDate], [DiscontinuedDate], [rowguid], " +
            //        "[ModifiedDate] FROM Production.Product";

            //    SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            //    using var sqlConnection = sqlConnection1;
            //    sqlConnection.Open();
            //    using var sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
            //    using var reader = sqlCommand.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        var ProductID = reader["ProductID"].ToString();
            //        var Name = reader["Name"].ToString();
            //        var ProductNumber = reader["ProductNumber"].ToString();
            //        var MakeFlag = reader["MakeFlag"].ToString();
            //        var FinishedGoodsFlag = reader["FinishedGoodsFlag"].ToString();
            //        var Color = reader["Color"].ToString();
            //        var SafetyStockLevel = reader["SafetyStockLevel"].ToString();
            //        var ReorderPoint = reader["ReorderPoint"].ToString();
            //        var StandardCost = reader["StandardCost"].ToString();
            //        var ListPrice = reader["ListPrice"].ToString();
            //        var Size = reader["Size"].ToString();
            //        var SizeUnitMeasureCode = reader["SizeUnitMeasureCode"].ToString();
            //        var WeightUnitMeasureCode = reader["WeightUnitMeasureCode"].ToString();
            //        var Weight = reader["Weight"].ToString();
            //        var DaysToManufacture = reader["DaysToManufacture"].ToString();
            //        var ProductLine = reader["ProductLine"].ToString();
            //        var Class = reader["Class"].ToString();
            //        var Style = reader["Style"].ToString();
            //        var ProductSubcategoryID = reader["ProductSubcategoryID"].ToString();
            //        var ProductModelID = reader["ProductModelID"].ToString();
            //        var SellStartDate = reader["SellStartDate"].ToString();
            //        var SellEndDate = reader["SellEndDate"].ToString();
            //        var DiscontinuedDate = reader["DiscontinuedDate"].ToString();
            //        var rowguid = reader["rowguid"].ToString();
            //        var ModifiedDate = reader["ModifiedDate"].ToString();

            //        Console.WriteLine($" ProductID-{ProductID}\n Name - {Name}\n ProductNumber - {ProductNumber}\n MakeFlag - {MakeFlag}\n FinishedGoodsFlag-{FinishedGoodsFlag}\n Color-{Color}\n " +
            //            $"SafetyStockLevel-{SafetyStockLevel}\n ReorderPoint-{ReorderPoint}\n StandardCost-{StandardCost}\n ListPrice-{ListPrice}\n Size-{Size}\n SizeUnitMeasureCode-{SizeUnitMeasureCode}\n" +
            //            $" WeightUnitMeasureCode-{WeightUnitMeasureCode}\n Weight-{Weight}\n DaysToManufacture-{DaysToManufacture}\n ProductLine-{ProductLine}\n" +
            //            $" Class-{Class}\n Style-{Style}\n ProductSubcategoryID-{ProductSubcategoryID}\n ProductModelID-{ProductModelID}\n" +
            //            $" SellStartDate-{SellStartDate}\n SellEndDate-{SellEndDate}\n DiscontinuedDate-{DiscontinuedDate}\n rowguid-{rowguid}\n" +
            //            $" ModifiedDate-{ModifiedDate}\n");
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

