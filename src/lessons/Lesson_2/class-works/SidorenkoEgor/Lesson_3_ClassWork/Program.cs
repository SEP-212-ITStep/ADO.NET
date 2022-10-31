using Microsoft.Data.SqlClient;
using System.Data;

namespace Lesson_3_ClassWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ConnectionString = "Server=LAPTOP-EGOR\\EGOR_SQL_SERVER;" +
                                            "Initial Catalog=AdventureWorks2019;" +
                                            "Trusted_Connection=true;Encrypt=false";
            var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var adapter = new SqlDataAdapter("SELECT City,AddressLine1,PostalCode FROM  " +
                                             "[AdventureWorks2019].[Person].[Address]", sqlConnection);

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