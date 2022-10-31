using Microsoft.VisualBasic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace BexultanovDinmukhammed
{
    internal class Program
    {
        const string connectionString = "Server=223-10;Database=AdventureWorks2019;Trusted_Connection=true;Encrypt=false";
        const string connectionStringNew = "Server=223-10;" + "Initial Catalog=AdventureWorks2019;" + "Trusted_Connection=true;Encrypt=false";

        static void Main(string[] args)
        {
            try
            {
                //getAllProducts();
                newMethod();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void getAllProducts()
        {
            const string sqlQuery = "SELECT * FROM Production.Product";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                int reorderPoint = int.Parse(reader["ReorderPoint"].ToString());

                if (reorderPoint > 3)
                {
                    Product product = new Product(name, reorderPoint);
                    products.Add(product);
                }
            }

            products.Sort((one, two) => one.ReorderPoint.CompareTo(two.ReorderPoint));

            Console.WriteLine(String.Format("{0,-30}   {1,-10} ", "Product Name", "ReorderPoint"));
            Console.WriteLine();
            foreach (var item in products)
            {
                Console.WriteLine(String.Format("{0,-35} | {1,-5} ", item.Name, item.ReorderPoint));
            }
        }
        private static void newMethod()
        {
            var sqlConnection = new SqlConnection(connectionStringNew);
            sqlConnection.Open();

            var adapter = new SqlDataAdapter("SELECT City, AddressLine1,PostalCode FROM " + "[AdventureWorks2019].[Person].[Address]", sqlConnection);

            var dataSet = new DataSet();

            adapter.Fill(dataSet);  

            var rows = dataSet.Tables[0].Rows;

            int count = 0;
            foreach (DataRow dataRow in rows)
            {
                if(count++ >= 100)
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

    class Product
    {
        public Product(string name, int reorderPoint)
        {
            Name = name;
            ReorderPoint = reorderPoint;
        }
        public string Name { get; set; }
        public int ReorderPoint { get; set; }
    }
}