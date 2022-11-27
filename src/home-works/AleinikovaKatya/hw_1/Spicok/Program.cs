using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Reflection.PortableExecutable;
using System.Linq;

namespace Spicok
{
    internal class Program
    {
        const string connectionString = "Server=DESKTOP-D9GJV4L\\MSSQLSERVER01;Database=Product;Trusted_Connection=true;Encrypt=false;";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Вся информация: ");
                Price();

                Console.WriteLine("Названия овощей и фруктов: ");
                ProductsName();

                Console.WriteLine("Названия цветов: ");
                ProductColor();

                Console.WriteLine("Максимальная ккал: ");
                MaxCall();

                Console.WriteLine("Минимальная ккал: ");
                MinCall();

                Console.WriteLine("Средняя ккал: ");
                SredCall();

                Console.WriteLine("Овощи и фрукты каждого цвета: ");
                ShowAllColor();

                Console.WriteLine("Кол-во овощей: ");
                ShowInfoVeg();

                Console.WriteLine("Кол-во фруктов: ");
                ShowInfoFruit();

                Console.WriteLine("Все овощи и фрукты, у которых цвет желтый или красный: ");
                YellowOrRed();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void Price()
        {

            try
            {
                const string SqlQuery = "SELECT * FROM dbo.Eda";
                using var SqlConnection = new SqlConnection(connectionString);
                Console.WriteLine("Подключение успешно!");
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var name = reader["name"].ToString();
                    var tip = reader["tip"].ToString();
                    var color = reader["color"].ToString();
                    var call = reader.GetInt32(i: 3);
                    Console.WriteLine($"Name - {name},Tip - {tip},Color - {color},Call - {call}");

                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Не подключились");
            }
        }

        static void ProductsName()
        {
            try
            {
                const string SqlQuery = "SELECT [Name] FROM dbo.Eda";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["Name"].ToString();

                    Console.WriteLine($"Name: {ProductName}");
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void ProductColor()
        {
            try
            {
                const string SqlQuery = "SELECT [Color] FROM dbo.Eda";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductColor = reader["Color"].ToString();
                    Console.WriteLine($"Color: {ProductColor}");
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void MaxCall()
        {
            try
            {
                const string SqlQuery = "SELECT [Callor] FROM dbo.Eda";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();
                int max = 0;
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductCalories = reader.GetInt32(i: 0);
                    if (ProductCalories > max)
                    {
                        max = ProductCalories;
                    }
                }
                Console.WriteLine($"Max calories: {max}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void MinCall()
        {
            try
            {
                const string SqlQuery = "SELECT [Callor] FROM dbo.Eda";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();
                int min = 10000;
                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Call = reader.GetInt32(i: 0);
                    if (Call < min)
                    {
                        min = Call;
                    }

                }
                Console.WriteLine($"Min Colories: {min}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void SredCall()
        {
            try
            {
                const string SqlQuery = "SELECT [Callor] FROM dbo.Eda";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();


                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                int temp = 0;
                List<int> avg = new List<int>();

                while (reader.Read())
                {
                    var ProductCalories = reader.GetInt32(i: 0);

                    avg.Add(ProductCalories);
                }
                foreach (var item in avg)
                {
                    temp += item;
                }
                Console.WriteLine($"Average colories: {temp / avg.Count}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void ShowAllColor()
        {
            try
            {
                const string SqlQuery = "SELECT [Name], [Color] FROM Eda";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var ProductName = reader["Name"].ToString();
                    var color = reader["Color"].ToString();
                    Console.WriteLine($"---> {ProductName} --- {color}");
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ShowInfoVeg()
        {

            const string SqlQuery = "SELECT [Tip] FROM dbo.Eda WHERE Tip = 'Fruit'";
            using var SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();

            using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
            using var reader = SqlCommand.ExecuteReader();
            int temp = 0;
            int tmp = 0;
            {

                while (reader.Read())
                {
                    var tipname = reader["tip"].ToString();
                    List<string> tip = new List<string>();


                    tip.Add(tipname);
                    foreach (var item in tip)
                    {

                        if (tipname == "Fruit")
                            temp++;
                        else
                            tmp++;
                    }

                }
                Console.WriteLine($"Col-vo Fruit: {tmp}");
                Console.WriteLine();
            }

        }
        public static void ShowInfoFruit()
        {

            const string SqlQuery = "SELECT [Tip] FROM dbo.Eda WHERE Tip = 'Vegetable'";
            using var SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();

            using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
            using var reader = SqlCommand.ExecuteReader();
            int temp = 0;
            int tmp = 0;
            {

                while (reader.Read())
                {
                    var tipname = reader["tip"].ToString();
                    List<string> tip = new List<string>();


                    tip.Add(tipname);
                    foreach (var item in tip)
                    {

                        if (tipname == "Vegetable")
                            temp++;
                        else
                            tmp++;
                    }

                }
                Console.WriteLine($"Col-vo Vegetable: {tmp}");
                Console.WriteLine();
            }

        }

        static void YellowOrRed()
        {
            try
            {
                const string SqlQuery = "SELECT * FROM Eda WHERE [Color]='Red' OR [Color]='Yellow';";
                using var SqlConnection = new SqlConnection(connectionString);
                SqlConnection.Open();

                using var SqlCommand = new SqlCommand(SqlQuery, SqlConnection);
                using var reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var Name = reader["Name"].ToString();
                    var color = reader["Color"].ToString();
                    Console.WriteLine($"---> {Name} --- {color}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}