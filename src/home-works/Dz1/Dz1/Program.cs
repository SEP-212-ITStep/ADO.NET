using Azure.Core;
using Microsoft.Data.SqlClient;
using System;
namespace Dz1
{
    internal class Program
    {
        const string ConnectionString = "Server=WIN-J11P7J0O85B;Database=Products;Trusted_Connection=true;Encrypt=false;";
        static void Main(string[] args)
        {
            DbConnection();
            Console.WriteLine("____________________");
            AllProducts();
            Console.WriteLine("____________________");
            AllColors();
            Console.WriteLine("____________________");
            MaxColories();
            Console.WriteLine("____________________");
            MinColories();
            Console.WriteLine("____________________");
            AvgColories();
            Console.WriteLine("____________________");
            VegAmmount();
            Console.WriteLine("____________________");
            FruitAmmount();
            Console.WriteLine("____________________");
            WhatColor();
            Console.WriteLine("____________________");
            EachColor();
            Console.WriteLine("____________________");
            YellowOrRed();
            Console.WriteLine("____________________");
        }



        static void DbConnection()
        {

            try
            {
                const string SqlQuery = "SELECT [ProductName], [Type], [Color], [Colories] FROM dbo.Productis";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    var Type = reader["Type"].ToString();
                    var Color = reader["Color"].ToString();
                    var Colories = reader.GetInt32(i: 3);
                    Console.WriteLine($"|ProductName - {ProductName}|Type - {Type}|Color - {Color}|Colories - {Colories}|");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void AllProducts()
        {
            try
            {
                const string SqlQuery = "SELECT [ProductName] FROM dbo.Productis";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();

                    Console.WriteLine($"ProductName - {ProductName}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void AllColors()
        {
            try
            {
                const string SqlQuery = "SELECT [Color] FROM dbo.Productis";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Color = reader["Color"].ToString();
                    Console.WriteLine($"Color - {Color}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void MaxColories()
        {
            try
            {
                const string SqlQuery = "SELECT [Colories] FROM dbo.Productis";
                using var SqlConnection = new SqlConnection(ConnectionString);
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
                Console.WriteLine($"MaxColories - {max}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void MinColories()
        {
            try
            {
                const string SqlQuery = "SELECT [Colories] FROM dbo.Productis";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();
                int min = 10000;
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Colories = reader.GetInt32(i: 0);
                    if (Colories < min)
                    {
                        min = Colories;
                    }

                }
                Console.WriteLine($"MinColories - {min}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void AvgColories()
        {
            try
            {
                const string SqlQuery = "SELECT [Colories] FROM dbo.Productis";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();


                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                int temp = 0;
                List<int> avg = new List<int>();

                while (reader.Read())
                {
                    var Colories = reader.GetInt32(i: 0);

                    avg.Add(Colories);
                }
                foreach (var item in avg)
                {
                    temp += item;
                }
                Console.WriteLine($"Colories - {temp / avg.Count}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void VegAmmount()
        {
            try
            {
                const string SqlQuery = "SELECT * FROM[Productis] WHERE [Type] = 'vegetable';";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    var Type = reader["Type"].ToString();
                    Console.WriteLine($"{ProductName} - {Type}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void FruitAmmount()
        {
            try
            {
                const string SqlQuery = "SELECT * FROM[Productis] WHERE [Type] = 'fruit';";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    var Type = reader["Type"].ToString();
                    Console.WriteLine($"{ProductName} - {Type}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void WhatColor()
        {
            Console.WriteLine("Введите цвет:");

            try
            {
                const string SqlQuery = "SELECT * FROM[Productis] WHERE [Color] = 'green';";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    var color = reader["color"].ToString();
                    Console.WriteLine($"{ProductName} - {color}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void EachColor()
        {
            try
            {
                const string SqlQuery = "SELECT * FROM[Productis];";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    var color = reader["color"].ToString();
                    Console.WriteLine($"{ProductName} - {color}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void YellowOrRed()
        {
            try
            {
                const string SqlQuery = "SELECT * FROM Productis WHERE [COLOR]='red' OR [COLOR]='yellow';";
                using var SqlConnection = new SqlConnection(ConnectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["ProductName"].ToString();
                    var color = reader["color"].ToString();
                    Console.WriteLine($" just - {ProductName} - is {color}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

