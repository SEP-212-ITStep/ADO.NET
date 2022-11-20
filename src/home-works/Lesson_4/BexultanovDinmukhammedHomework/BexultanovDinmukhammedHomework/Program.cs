using System.Data.SqlClient;

namespace BexultanovDinmukhammedHomework
{
    internal class Program
    {
        const string connectionString = "Server=localhost;Database=CarPark;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
            showCarsYear(2000);
        }

        static void showCarsYear(int n)
        {
            const string sqlQuery = "SELECT * FROM dbo.Cars";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var brand = reader["Brand"].ToString();
                var model = reader["Model"].ToString();
                var speed = reader["Speed"].ToString();
                var motor = reader["Motor"].ToString();
                var year = int.Parse(reader["Year"].ToString());
                
                if(year == n)
                {
                    Console.WriteLine($"{brand} {model} Speed: {speed} Motor: {motor} Year: {year}");
                }
            }
        }

        static void showCar(string m, int n)
        {
            const string sqlQuery = "SELECT * FROM dbo.Cars";
            using var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using var sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var brand = reader["Brand"].ToString();
                var model = reader["Model"].ToString();
                var speed = reader["Speed"].ToString();
                var motor = reader["Motor"].ToString();
                var year = int.Parse(reader["Year"].ToString());

                if (year == n && model == m)
                {
                    Console.WriteLine($"{brand} {model} Speed: {speed} Motor: {motor} Year: {year}");
                }
            }
        }

        static void updateCar(string model, int year)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string new_brand = Console.ReadLine();
                string new_model = Console.ReadLine();
                string new_speed = Console.ReadLine();
                string new_motor = Console.ReadLine();
                string new_year = Console.ReadLine();
                string sql = String.Format("UPDATE Cars SET Brand='{0}', Model='{1}', Speed={2}, Motor={3}, Year={4} WHERE Model='{5}' AND Year={6}", new_brand, new_model, new_speed, new_motor, new_year, model, year);

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

        static void addCar(string brand, string model, int speed, int motor, int year)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("INSERT INTO Cars (Brand, Model, Speed, Motor,Year) VALUES ('{0}', '{1}', {2}, {3}, '{4}')", brand, model, speed, motor, year);

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
    }
}