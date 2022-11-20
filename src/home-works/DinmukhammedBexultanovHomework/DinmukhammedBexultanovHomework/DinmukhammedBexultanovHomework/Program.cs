using System.Data.SqlClient;

namespace DinmukhammedBexultanovHomework
{
    internal class Program
    {
        const string connectionString = "Server=localhost;Database=Fruits&Vegetables;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
            //Task2();
            //allInfo();
            //maxCalory();
            //minCalory();
            //avgCalory();
            //numFruits();
            //numVegetables();
            //maxCalory(200);
            //minCalory(200);

            colorsRedYellow();
        }

        static void Task2()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";

            using var sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            Console.WriteLine("Connection opened");
        }

        static void allInfo()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                var type = reader["Type"].ToString();
                var color = reader["Color"].ToString();
                var calory = reader["Calory"].ToString();

                Console.WriteLine($"{name} [{type},{color}] {calory} calories");
            }
        }

        static void allNames()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["Name"].ToString();

                Console.WriteLine($"{name}");
            }
        }

        static void allColors()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var color = reader["Color"].ToString();

                Console.WriteLine($"{color}");
            }
        }

        static void maxCalory()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            int max = 0;
            while (reader.Read())
            {
                var calory = int.Parse(reader["Calory"].ToString());

                if(calory > max)
                {
                    max = calory;
                }
            }

            Console.WriteLine($"Max: {max}");
        }

        static void minCalory()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            int min = int.MaxValue;
            while (reader.Read())
            {
                var calory = int.Parse(reader["Calory"].ToString());

                if (calory < min)
                {
                    min = calory;
                }
            }

            Console.WriteLine($"Min: {min}");
        }

        static void avgCalory()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            int avg = 0;
            int i = 0;
            while (reader.Read())
            {
                var calory = int.Parse(reader["Calory"].ToString());

                avg += calory;
                i++;
            }

            avg = avg / i;
            Console.WriteLine($"Avg: {avg}");
        }

        static void numFruits()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            int num = 0;
            while (reader.Read())
            {
                var type = reader["Type"].ToString();

                if(type == "fruit")
                {
                    num++;
                }
            }

            Console.WriteLine($"Num of fruits: {num}");
        }

        static void numVegetables()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            int num = 0;
            while (reader.Read())
            {
                var type = reader["Type"].ToString();

                if (type == "vegetable")
                {
                    num++;
                }
            }

            Console.WriteLine($"Num of vegetables: {num}");
        }

        static void numColors(string c)
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            int num = 0;
            while (reader.Read())
            {
                var color = reader["Color"].ToString();

                if(color == c)
                {
                    num++;
                }
            }

            Console.WriteLine($"Num: {num}");
        }

        static void maxCalory(int c)
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                var calory = int.Parse(reader["Calory"].ToString());

                if(calory <= c)
                {
                    Console.WriteLine($"{name}");
                }
            }
        }

        static void minCalory(int c)
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                var calory = int.Parse(reader["Calory"].ToString());

                if (calory >= c)
                {
                    Console.WriteLine($"{name}");
                }
            }
        }

        static void periodCalory(int min, int max)
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                var calory = int.Parse(reader["Calory"].ToString());

                if (calory >= min && calory <= max)
                {
                    Console.WriteLine($"{name}");
                }
            }
        }

        static void colorsRedYellow()
        {
            const string sqlQuery = "SELECT * FROM dbo.Products";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();

            int num = 0;
            while (reader.Read())
            {
                var name = reader["Name"].ToString();
                var color = reader["Color"].ToString();

                if (color == "yellow" || color == "red")
                {
                    Console.WriteLine($"{name}");
                }
            }
        }
    }
}