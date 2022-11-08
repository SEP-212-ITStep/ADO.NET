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

        public static void getGoods()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [good's name],[type],[quantity],[cost],[delivery date] FROM dbo.goods";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var goodSName = reader["good's name"].ToString();
                    var type = reader["type"].ToString();
                    var quantity = reader["quantity"].ToString();
                    var cost = reader["cost"].ToString();
                    var deliveryDate = reader["delivery date"].ToString();

                    Console.WriteLine($"[good's name - {goodSName}, type - {type}, quantity - {quantity}, cost - {cost}, delivery date - {deliveryDate}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }  
        public static void getSuppliers()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [good's name],[type],[supplier],[delivery date] FROM dbo.suppliers";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var goodSName = reader["good's name"].ToString();
                    var type = reader["type"].ToString();
                    var supplier = reader["supplier"].ToString();
                    var deliveryDate = reader["delivery date"].ToString();

                    Console.WriteLine($"[good's name - {goodSName}, type - {type}, supplier - {supplier}, delivery date - {deliveryDate}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }    
        public static void getTypes()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                const string SqlQuerty = "SELECT [good's name],[type],[quantity] FROM dbo.types";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var goodSName = reader["good's name"].ToString();
                    var type = reader["type"].ToString();
                    var quantity = reader["quantity"].ToString();

                    Console.WriteLine($"[good's name - {goodSName}, type - {type}, quantity - {quantity}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void AddNewRow(string name1,int price1, int quantity1)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                string buf2 = price1.ToString();
                string buf3 = quantity1.ToString();

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
                //connectToDB();
                //AddNewColumn("supplier");
                //AddNewColumn("type");
                getGoods();
                getSuppliers();
                getTypes();

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