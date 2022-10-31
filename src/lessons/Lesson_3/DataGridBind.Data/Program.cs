using Microsoft.Data.SqlClient;

namespace DataGridBind.Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public List<Product> Query(string connectionString, string sql)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCmd = sqlConnection.CreateCommand();
                sqlCmd.CommandText = sql;
                using var sqlDataReader = sqlCmd.ExecuteReader();

                var result = new List<Product>(100);

                while (sqlDataReader.Read())
                {
                    var name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
                    var productNumber = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ProductNumber"));

                    var product = new Product()
                    {
                        Name = name,
                        ProductNumber = productNumber
                    };
                    result.Add(product);
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public class Product
    {
        public string? Name { get; set; }
        public string? ProductNumber { get; set; }
    }
}