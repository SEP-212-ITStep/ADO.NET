using Microsoft.Data.SqlClient;

namespace lesson_3_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-2DFAO40;Database=AdventureWorks2019;" + "Trusted_Connection=true;Encrypt=false";
            try
            {
                const string SqlQuery = "SELECT [Name],[ProductNumber],[MakeFlag]," +
                    "[FinishedGoodsFlag],[Color],[SafetyStockLevel]," +
                    "[ReorderPoint],[StandardCost],[ListPrice],[Size]," +
                    "[SizeUnitMeasureCode],[WeightUnitMeasureCode],[Weight]," +
                    "[DaysToManufacture],[ProductLine],[Class],[Style]," +
                    "[ProductSubcategoryID],[ProductModelID]," +
                    "[SellStartDate],[SellEndDate],[DiscontinuedDate],[rowguid],[ModifiedDate]  FROM Production.Product";

                //const string SqlQuery = "SELECT * FROM dbo.StudentGrade";

                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                using var sqlConnection = sqlConnection1;
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuery, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Name = reader["Name"].ToString();
                    var ProductNumber = reader["ProductNumber"].ToString();
                    var MakeFlag = reader["MakeFlag"].ToString();
                    var FinishedGoodsFlag = reader["FinishedGoodsFlag"].ToString();
                    var Color = reader["Color"].ToString();
                    var SafetyStockLevel = reader["SafetyStockLevel"].ToString();
                    var ReorderPoint = reader["ReorderPoint"].ToString();
                    var StandardCost = reader["StandardCost"].ToString();
                    var ListPrice = reader["ListPrice"].ToString();
                    var Size = reader["Size"].ToString();
                    var SizeUnitMeasureCode = reader["SizeUnitMeasureCode"].ToString();
                    var WeightUnitMeasureCode = reader["WeightUnitMeasureCode"].ToString();
                    var Weight = reader["Weight"].ToString();
                    var DaysToManufacture = reader["DaysToManufacture"].ToString();
                    var ProductLine = reader["ProductLine"].ToString();
                    var Class = reader["Class"].ToString();
                    var Style = reader["Style"].ToString();
                    var ProductSubcategoryID = reader["ProductSubcategoryID"].ToString();
                    var ProductModelID = reader["ProductModelID"].ToString();
                    var SellStartDate = reader["SellStartDate"].ToString();
                    var SellEndDate = reader["SellEndDate"].ToString();
                    var DiscontinuedDate = reader["DiscontinuedDate"].ToString();
                    var rowguid = reader["rowguid"].ToString();
                    var ModifiedDate = reader["ModifiedDate"].ToString();

                    Console.WriteLine($"Name: {Name}\nProductNumber: {ProductNumber}\nMakeFlag: {MakeFlag}\n" +
                        $"FinishedGoodsFlag: {FinishedGoodsFlag}\n" +
                        $"Color: {Color}\nSafetyStockLevel: {SafetyStockLevel}\n" +
                        $"ReorderPoint: {ReorderPoint}\nStandardCost: {StandardCost}\nListPrice: {ListPrice}\n" +
                        $"Size: {Size}\nSizeUnitMeasureCode: {SizeUnitMeasureCode}\nWeightUnitMeasureCode: {WeightUnitMeasureCode}\n" +
                        $"Weight: {Weight}\nDaysToManufacture: {DaysToManufacture}\nProductLine: {ProductLine}\n" +
                        $"Class: {Class}\nStyle: {Style}\nProductSubcategoryID: {ProductSubcategoryID}\n" +
                        $"ProductModelID: {ProductModelID}\nSellStartDate: {SellStartDate}\nSellEndDate: {SellEndDate}\n" +
                        $"DiscontinuedDate: {DiscontinuedDate}\nrowguid: {rowguid}\nModifiedDate: {ModifiedDate}\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}