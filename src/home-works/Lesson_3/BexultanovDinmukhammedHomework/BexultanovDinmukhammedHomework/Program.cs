using System.Data.SqlClient;

namespace BexultanovDinmukhammedHomework
{
    internal class Program
    {
        const string connectionString = "Server=localhost;Database=Warehouse;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
            //addGood("Lego", "Toy", 2, 1500, "21 January 2020");
            //supplierMinGoods();
            typeMaxGoods();
        }

        public static void addGood(string goodname, string type, int quantity, int cost, string deliveryDate)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("INSERT INTO goods (good_name, type, quantity, cost,delivery_date) VALUES ('{0}', '{1}', {2}, {3}, '{4}')", goodname, type, quantity, cost, deliveryDate);

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
        public static void addType(string type, string supplier)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("INSERT INTO types (type, supplier) VALUES ('{0}', '{1}')", type, supplier);

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
        public static void addSupplier(string supplier, string goodname, string type, string deliveryDate)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

                string sql = String.Format("INSERT INTO suppliers (supplier, good_name type,delivery_date) VALUES ('{0}', '{1}','{2}', '{3}')", supplier, goodname, type, deliveryDate);

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

        public static void updateGood(string goodname, string type, int quantity, int cost, string deliveryDate)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("UPDATE goods SET good_name='{0}', type='{1}', quantity='{2}',cost='{3}',delivery_date='{4}'", goodname, type, quantity, cost, deliveryDate);

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
        public static void updateType(string type, string supplier, string goodsname)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("UPDATE types SET type='{0}', supplier='{1}'", type, supplier);

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
        public static void updateSupplier(string supplier, string goodsname, string type, string deliverydate)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("UPDATE suppliers SET supplier='{0}', good_name='{1}', type='{2}',delivery_date='{3}'", supplier, goodsname, type, deliverydate);

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

        public static void deleteGood(int quantity)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("DELETE FROM goods WHERE quantity ='{0}';", quantity);

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
        public static void deleteType(string type)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("DELETE FROM types WHERE type='{0}';", type);

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
        public static void deleteSupplier(string supplier)
        {
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sql = String.Format("DELETE FROM suppliers WHERE supplier='{0}';", supplier);

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

        public static void supplierMaxGoods()
        {
            try
            {

                string SqlQuerty = String.Format("SELECT * FROM dbo.goods;");

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                Dictionary<string, int> goodQuantity = new Dictionary<string, int>();
                Dictionary<string, int> supplierQuantity = new Dictionary<string, int>();
                while (reader.Read())
                {
                    var name = reader["good_name"].ToString();
                    var quantity = int.Parse(reader["quantity"].ToString());

                    if (goodQuantity.ContainsKey(name))
                    {
                        goodQuantity[name]++;
                    }
                    else
                        goodQuantity.Add(name, quantity);
                }
                sqlConnection.Close();

                string SqlQuertyAlt = String.Format("SELECT * FROM dbo.suppliers;");

                using var sqlConnectionAlt = new SqlConnection(connectionString);
                sqlConnectionAlt.Open();
                using var sqlCommandAlt = new SqlCommand(SqlQuertyAlt, sqlConnectionAlt);
                using var readerAlt = sqlCommandAlt.ExecuteReader();

                while (readerAlt.Read())
                {
                    var supplier = readerAlt["supplier"].ToString();
                    var name = readerAlt["good_name"].ToString();

                    if (supplierQuantity.ContainsKey(supplier))
                    {
                        supplierQuantity[supplier]++;
                    }
                    else
                    {
                        supplierQuantity.Add(supplier, 1);
                    }
                }

                int max = 0;
                string key = "";
                foreach (var item in supplierQuantity)
                {
                    if(max < item.Value)
                    {
                        max = item.Value;
                        key = item.Key;
                    }
                }
                Console.WriteLine(key);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void supplierMinGoods()
        {
            try
            {

                string SqlQuerty = String.Format("SELECT * FROM dbo.goods;");

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                Dictionary<string, int> goodQuantity = new Dictionary<string, int>();
                Dictionary<string, int> supplierQuantity = new Dictionary<string, int>();
                while (reader.Read())
                {
                    var name = reader["good_name"].ToString();
                    var quantity = int.Parse(reader["quantity"].ToString());

                    if (goodQuantity.ContainsKey(name))
                    {
                        goodQuantity[name]++;
                    }
                    else
                        goodQuantity.Add(name, quantity);
                }
                sqlConnection.Close();

                string SqlQuertyAlt = String.Format("SELECT * FROM dbo.suppliers;");

                using var sqlConnectionAlt = new SqlConnection(connectionString);
                sqlConnectionAlt.Open();
                using var sqlCommandAlt = new SqlCommand(SqlQuertyAlt, sqlConnectionAlt);
                using var readerAlt = sqlCommandAlt.ExecuteReader();

                while (readerAlt.Read())
                {
                    var supplier = readerAlt["supplier"].ToString();
                    var name = readerAlt["good_name"].ToString();

                    if (supplierQuantity.ContainsKey(supplier))
                    {
                        supplierQuantity[supplier]++;
                    }
                    else
                    {
                        supplierQuantity.Add(supplier, 1);
                    }
                }

                int min = int.MaxValue;
                string key = "";
                foreach (var item in supplierQuantity)
                {
                    if (min > item.Value)
                    {
                        min = item.Value;
                        key = item.Key;
                    }
                }
                Console.WriteLine(key);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void typeMaxGoods()
        {
            try
            {

                string SqlQuerty = String.Format("SELECT * FROM dbo.goods");

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                Dictionary<string, int> typeQuantity = new Dictionary<string, int>();
                while (reader.Read())
                {
                    var type = reader["type"].ToString();
                    var quantity = int.Parse(reader["quantity"].ToString());

                    if (typeQuantity.ContainsKey(type))
                    {
                        typeQuantity[type]++;
                    }
                    else
                    {
                        typeQuantity.Add(type, quantity);
                    }
                }

                int max = 0;
                string key = "";
                foreach (var item in typeQuantity)
                {
                    if (max < item.Value)
                    {
                        max = item.Value;
                        key = item.Key;
                    }
                }
                Console.WriteLine(key);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void typeMinGoods()
        {
            try
            {

                string SqlQuerty = String.Format("SELECT * FROM dbo.goods");

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                Dictionary<string, int> typeQuantity = new Dictionary<string, int>();
                while (reader.Read())
                {
                    var type = reader["type"].ToString();
                    var quantity = int.Parse(reader["quantity"].ToString());

                    if (typeQuantity.ContainsKey(type))
                    {
                        typeQuantity[type]++;
                    }
                    else
                    {
                        typeQuantity.Add(type, quantity);
                    }
                }

                int min = int.MaxValue;
                string key = "";
                foreach (var item in supplierQuantity)
                {
                    if (min > item.Value)
                    {
                        min = item.Value;
                        key = item.Key;
                    }
                }
                Console.WriteLine(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void deliveryTime(int days)
        {
            try
            {

                string SqlQuerty = String.Format("SELECT * FROM dbo.goods;");

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    var goodName = reader["good's name"].ToString();
                    var type = reader["type"].ToString();
                    var quantity = reader["quantity"].ToString();
                    var cost = reader["cost"].ToString();
                    var deliveryDate = reader["delivery date"].ToString();

                    if (DateTime.Today.AddDays(-days) < DateTime.Parse(deliveryDate))
                    {
                        Console.WriteLine($"[good's name - {goodName}, type - {type}, quantity - {quantity}, cost - {cost}, delivery date - {deliveryDate}]");
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}