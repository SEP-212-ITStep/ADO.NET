using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HomeWork28._10
{
    internal class Program
    {
        const string connectionString = "Server=AMIKAN;Database=vegetables&fruits;Trusted_Connection=true;Encrypt=false;";
        private static void Main(string[] args)
        {
            try
            {
                const string sqlQuery = "SELECT * FROM dbo.Table1";

                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        using (var reader = sqlCommand.ExecuteReader())
                        {
                            Console.WriteLine("Сonnected to the database: ");

                            while (reader.Read())
                            {
                                var Name = reader["Name"].ToString();
                                var Type = reader["Type"].ToString();
                                var Color = reader["Color"].ToString();
                                var Calories = reader.GetInt32(i: 3);
                                Console.WriteLine($"Name - {Name}, Type - {Type}, Color - {Color}, Calories - {Calories}");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Database connection error");
            }

            Console.WriteLine(" ");
            Console.WriteLine("All names: ");
            AllName();
            Console.WriteLine(" ");
            Console.WriteLine("All colors: ");
            AllColors();
            Console.WriteLine(" ");
            Console.WriteLine("Max calories: ");
            MaxCalories();
            Console.WriteLine(" ");
            Console.WriteLine("Min calories: ");
            MinCalories();
            Console.WriteLine(" ");
            Console.WriteLine("AverageCalories: ");
            AverageCalories();
        }

        public static void AllName()
        {

            try
            {
                const string sqlQuery = "SELECT [Name] FROM dbo.Table1";

                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        using (var reader = sqlCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                var Name = reader["Name"].ToString();
                                Console.WriteLine($"Name - {Name}");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void AllColors()
        {
            try
            {
                const string sqlQuery = "SELECT [Color] FROM dbo.Table1";

                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        using (var reader = sqlCommand.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                var Color = reader["Color"].ToString();
                                Console.WriteLine($"Color - {Color}");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void MaxCalories()
        {
            try
            {
                const string SqlQuery = "SELECT [Сalories] FROM dbo.Table1";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();
                int max = 0;
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Colories = reader.GetInt32(i: 0);
                    if (Colories > max)
                    {
                        max = Colories;
                    }
                }
                Console.WriteLine($"MaxCalories - {max}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void MinCalories()
        {
            try
            {
                const string SqlQuery = "SELECT [Сalories] FROM dbo.Table1";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();
                int min = 1000;
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Calories = reader.GetInt32(i: 0);
                    if (Calories < min)
                    {
                        min = Calories;
                    }
                }
                Console.WriteLine($"MinCalories - {min}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void AverageCalories()
        {
            try
            {
                const string SqlQuery = "SELECT [Сalories] FROM dbo.Table1";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                int x = 0;
                List<int> avg = new List<int>();
                while (reader.Read())
                {
                    var Calories = reader.GetInt32(i: 0);
                    avg.Add(Calories);
                    foreach (var item in avg)
                    {
                        x += item;
                    }
                }
                Console.WriteLine($"Calories - {x / avg.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void AmountVega()
        {
            try
            {
                const string SqlQuery = "SELECT [Сalories] FROM dbo.Table1";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                int x = 0;
                List<int> avg = new List<int>();
                while (reader.Read())
                {
                    var Calories = reader.GetInt32(i: 0);
                    avg.Add(Calories);
                    foreach (var item in avg)
                    {
                        x += item;
                    }
                }
                Console.WriteLine($"Calories - {x / avg.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
