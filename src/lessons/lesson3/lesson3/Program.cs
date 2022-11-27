using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Lesson3
{
    internal class Program
    {
        const string sql = "Server=127.0.0.1;Database=Production;User Id=CA;password=as23@bull;Encrypt=false";
        private static void Main(string[] args)
        {
            ShowByReorderPoint(sql);
        }

        static void ShowByReorderPoint(string ConnectionString)
        {
            try
            {
                using var sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();

                var adapter = new SqlDataAdapter("SELECT * FROM " + "Production.Product p", sqlConnection);

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                var rows = dataSet.Tables[0].Rows;

                foreach (DataRow dataRow in rows)
                {
                    var productId = dataRow["ProductID"];
                    var name = dataRow["Name"];
                    var reorderPoint = dataRow["ReorderPoint"];

                    Console.WriteLine($"{productId}, {name}, {reorderPoint}");
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
