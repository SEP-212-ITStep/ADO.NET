using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace _28102022_homeworl_ADO.NET
{
    public class Program
    {

        //        Задание 1
        //Добавьте к приложению из практического задания по
        //базе данных «Склад» такую функциональность:
        //■ Вставка новых товаров;
        //■ Вставка новых типов товаров;
        //■ Вставка новых поставщиков.

        public static void connectToDB()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Shop;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [name],[id],[price],[quantity] FROM dbo.Inventory";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var id = reader["id"].ToString();
                    var price = reader["price"].ToString();
                    var quantity = reader["quantity"].ToString();
                    //var Calories = Double.Parse(reader["Calories"]);

                    Console.WriteLine($"[name - {name},id - {id}, price - {price}, quantity - {quantity}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void UpdateAddNewItem(string name1,int price1, int quantity1)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Shop;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                //const string SqlQuerty = "SELECT [id],[price],[quantity] FROM dbo.Inventory";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                //string buf1 = id1.ToString();
                string buf2 = price1.ToString();
                string buf3 = quantity1.ToString();

                //string sql = string.Format("INSERT INTO  dbo.Inventory ('name', 'price', 'quantity') VALUES {0} {1} {2}", name1, buf2, buf3);

                //INSERT INTO  dbo.Inventory('name', 'price', 'quantity') VALUES { 0}
                //{ 1}
                //{ 2}
                //", name1, buf2, buf3

                string sql = String.Format("INSERT INTO Inventory (name, /*id,*/ price, quantity) VALUES ('{0}',/*'Explicit identity value',*/ {1}, {2})", name1, price1, quantity1);

                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public static void AddNewColumn(string columnname)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Shop;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                //const string SqlQuerty = "SELECT [id],[price],[quantity] FROM dbo.Inventory";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                //string buf1 = id1.ToString();

                //ALTER TABLE employees
                //ADD last_name VARCHAR(50);

                string sql = String.Format($"ALTER TABLE Inventory ADD {columnname} NVARCHAR(20)");

                using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Shop;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                connectToDB();
                AddNewColumn("supplier");
                AddNewColumn("type");
                //UpdateAddNewItem("hammer",10,2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
    }
}