using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace vegetables
{
    internal class VegetablesService
    {
        public VegetablesService() { }
        public bool AddVegetable(string name, string type, string colour, int cal)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection(ConnectionStringProvider.ConnectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT data (name, type, colour, calories) VALUES (@name, @type, @colour, @calories)";
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@type", type));
                cmd.Parameters.Add(new SqlParameter("@colour", colour));
                cmd.Parameters.Add(new SqlParameter("@calories", cal));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
        }
        public List<string> GetData()
        {
            try
            {
                List<string> Records = new List<string>();
                const string SqlQuery = "SELECT * FROM data;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        String tmp = new("");
                        tmp = String.Format("{0}. {1}, {2}, {3}, {4}", reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4).ToString());
                        Records.Add(tmp);
                    }
                    return Records;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return null; }
        }
        public List<string> GetNames()
        {
            try
            {
                List<string> Records = new List<string>();
                const string SqlQuery = "SELECT id, name FROM data;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        String tmp = new("");
                        tmp = (String.Format("{0}. {1}", reader.GetInt32(0).ToString(), reader.GetString(1)));
                    }
                    return Records;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return null; }
        }
        public List<string> GetColours()
        {
            try
            {
                List<string> Records = new List<string>();
                const string SqlQuery = "SELECT id, colour FROM data;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        String tmp = new("");
                        tmp = (String.Format("{0}. {1}", reader.GetInt32(0).ToString(), reader.GetString(1)));
                    }
                    return Records;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return null; }
        }
        public int GetMaxCal()
        {
            try
            {
                int tmp = new();
                const string SqlQuery = "SELECT MAX(calories) FROM data;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmp = reader.GetInt32(0);
                    }
                    return tmp;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return 0; }
        }
        public int GetMinCal()
        {
            try
            {
                int tmp = new();
                const string SqlQuery = "SELECT MIN(calories) FROM data;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmp = reader.GetInt32(0);
                    }
                    return tmp;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return 0; }
        }
        public int GetAvgCal()
        {
            try
            {
                int tmp = new();
                const string SqlQuery = "SELECT AVG(calories) FROM data;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmp = reader.GetInt32(0);
                    }
                    return tmp;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return 0; }
        }
        public int GetVegCount()
        {
            try
            {
                int tmp = new();
                const string SqlQuery = "SELECT Count(type) FROM data WHERE type='vegetable' OR type='veg';";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmp = reader.GetInt32(0);
                    }
                    return tmp;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return 0; }
        }
        public int GetFruitCount()
        {
            try
            {
                int tmp = new();
                const string SqlQuery = "SELECT Count(type) FROM data WHERE type='fruit' OR type='frt';";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmp = reader.GetInt32(0);
                    }
                    return tmp;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return 0; }
        }
        public int GetDataWithSpecColour(string colour)
        {
            try
            {
                int tmp = new();
                const string SqlQuery = "SELECT Count(colour) FROM data WHERE colour=@colour;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    cmd.Parameters.AddWithValue("@colour", colour);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tmp = reader.GetInt32(0);
                    }
                    return tmp;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return 0; }
        }
        public List<string> GetDataByColours()
        {
            try
            {
                List<string> Records = new List<string>();
                const string SqlQuery = "SELECT * FROM data GROUP BY colour;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        String tmp = new("");
                        tmp = (String.Format("{0}. {1}, {2}, {3}, {4}", reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4).ToString()));
                    }
                    return Records;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return null; }
        }
        public List<string> ListWithLoverCal(int SetCal)
        {
            try
            {
                List<string> Records = new List<string>();
                const string SqlQuery = "SELECT * FROM data WHERE cal < @SetCal;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    cmd.Parameters.Add("@SetCal", (SqlDbType)SetCal);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        String tmp = new("");
                        tmp = (String.Format("{0}. {1}, {2}, {3}, {4}", reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4).ToString()));
                    }
                    return Records;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return null; }
        }
        public List<string> ListWithHigherCal(int SetCal)
        {
            try
            {
                List<string> Records = new List<string>();
                const string SqlQuery = "SELECT * FROM data WHERE cal > @SetCal;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    cmd.Parameters.Add("@SetCal", (SqlDbType)SetCal);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        String tmp = new("");
                        tmp = (String.Format("{0}. {1}, {2}, {3}, {4}", reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4).ToString()));
                    }
                    return Records;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return null; }
        }
        public List<string> ListWithCalInRange(int LowCal, int HigCal)
        {
            try
            {
                List<string> Records = new List<string>();
                const string SqlQuery = "SELECT * FROM data WHERE cal > @LowCal AND cal < @HigCal;";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    cmd.Parameters.Add("@LowCal", (SqlDbType)LowCal);
                    cmd.Parameters.Add("@HigCal", (SqlDbType)HigCal);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        String tmp = new("");
                        tmp = (String.Format("{0}. {1}, {2}, {3}, {4}", reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4).ToString()));
                    }
                    return Records;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return null; }
        }
        public List<string> ShowYelAndRed()
        {
            try
            {
                List<string> Records = new List<string>();
                const string SqlQuery = "SELECT * FROM data WHERE colour='red' OR colour='yellow';";
                using (SqlConnection connection = new SqlConnection(ConnectionStringProvider.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SqlQuery, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        String tmp = new("");
                        tmp = (String.Format("{0}. {1}, {2}, {3}, {4}", reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4).ToString()));
                    }
                    return Records;
                }
            }
            catch (Exception ex) { Console.WriteLine("Error: {0}", ex.Message); return null; }
        }
    }
}
