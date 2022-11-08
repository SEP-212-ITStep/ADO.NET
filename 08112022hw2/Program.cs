using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace _08112022hw2
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
        public static void getSupplier()
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
                const string SqlQuerty = "SELECT [type],[supplier] FROM dbo.types";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var type = reader["type"].ToString();
                    var supplier = reader["supplier"].ToString();

                    Console.WriteLine($"[type - {type}, supplier - {supplier}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void AddNewGood(string goodsname, string type, int quantity, int cost, string deliverydate)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

                string sql = String.Format("INSERT INTO goods ([good's name], type, quantity, cost,[delivery date]) VALUES ('{0}', '{1}', {2}, {3}, '{4}')", goodsname, type, quantity, cost, deliverydate);

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
        public static void AddNewType(string type, string supplier)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

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
        public static void AddNewSupplier(string supplier, string goodsname, string type, string deliverydate)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

                string sql = String.Format("INSERT INTO suppliers (supplier, [good's name], type,[delivery date]) VALUES ('{0}', '{1}','{2}', '{3}')", supplier, goodsname, type, deliverydate);

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
        public static void UpdateGood(string goodsname, string type, int quantity, int cost, string deliverydate)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

                string sql = String.Format("UPDATE goods SET [good's name]='{0}', type='{1}', quantity='{2}',cost='{3}',[delivery date]='{4}'", goodsname, type, quantity, cost, deliverydate);

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
        public static void UpdateType(string type, string supplier,string goodsname)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

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
        public static void UpdateSupplier(string supplier, string goodsname, string type, string deliverydate)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

                string sql = String.Format("UPDATE suppliers SET supplier='{0}', [good's name]='{1}', type='{2}',[delivery date]='{3}'", supplier, goodsname, type, deliverydate);

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
        public static void RemoveGood(int quantity)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

                //DELETE FROM Table1
                //WHERE StandardCost > 1000.00;

                string sql = String.Format("DELETE FROM goods WHERE quantity >'{0}';", quantity);

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
        public static void RemoveType(string type)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

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
        public static void RemoveSupplier(string supplier)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");

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
        public static void ShowSupplierWithMaxGoods()
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

                int maxquant = 0;
                string goodNameMax = "";
                while (reader.Read())
                {
                    var goodSName = reader["good's name"].ToString();
                    var type = reader["type"].ToString();
                    var quantity = reader["quantity"].ToString();
                    var cost = reader["cost"].ToString();
                    var deliveryDate = reader["delivery date"].ToString();

                    //Console.WriteLine($"[good's name - {goodSName}, type - {type}, quantity - {quantity}, cost - {cost}, delivery date - {deliveryDate}]");
                    if (!string.IsNullOrEmpty(quantity) && Int32.Parse(quantity) > maxquant)
                    {

                        maxquant = Int32.Parse(quantity);
                        goodNameMax = goodSName;
                    }
                }

                string sql = String.Format("SELECT [good's name],[type],[supplier],[delivery date] FROM suppliers WHERE [good's name]='{0}';", goodNameMax);

                using var sqlConnection2 = new SqlConnection(connectionString);
                sqlConnection2.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand2 = new SqlCommand(sql, sqlConnection2);
                using var reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    var goodSName = reader2["good's name"].ToString();
                    var type = reader2["type"].ToString();
                    var supplier = reader2["supplier"].ToString();
                    var deliveryDate = reader2["delivery date"].ToString();

                    Console.WriteLine("поставщик с наибольшим количеством товаров");
                    Console.WriteLine($"[good's name - {goodSName}, type - {type}, supplier - {supplier}, delivery date - {deliveryDate}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ShowSupplierWithMinGoods()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false";

            try
            {
                const string SqlQuerty = "SELECT [good's name],[type],[quantity],[cost],[delivery date] FROM dbo.goods";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                int minquant = 0;
                string goodNameMin = "";
                while (reader.Read())
                {
                    var goodSName = reader["good's name"].ToString();
                    var type = reader["type"].ToString();
                    var quantity = reader["quantity"].ToString();
                    var cost = reader["cost"].ToString();
                    var deliveryDate = reader["delivery date"].ToString();

                    //Console.WriteLine($"[good's name - {goodSName}, type - {type}, quantity - {quantity}, cost - {cost}, delivery date - {deliveryDate}]");

                    if (!string.IsNullOrEmpty(quantity) && Int32.Parse(quantity) < minquant)
                    {
                        minquant = Int32.Parse(quantity);
                        goodNameMin = goodSName;
                    }
                }
              
                string sql = String.Format("SELECT [good's name],[type],[supplier],[delivery date] FROM dbo.suppliers WHERE [good's name]='{0}'", goodNameMin);

                using var sqlConnection2 = new SqlConnection(connectionString);
                sqlConnection2.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand2 = new SqlCommand(sql, sqlConnection2);
                using var reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    var goodSName = reader2["good's name"].ToString();
                    var type = reader2["type"].ToString();
                    var supplier = reader2["supplier"].ToString();
                    var deliveryDate = reader2["delivery date"].ToString();

                    Console.WriteLine("поставщик с наименьшим количеством товаров");
                    Console.WriteLine($"[good's name - {goodSName}, type - {type}, supplier - {supplier}, delivery date - {deliveryDate}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
         public static void ShowTypeWithMaxGoods()
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

                int maxquant = 0;
                string goodNameMax = "";
                while (reader.Read())
                {
                    var goodSName = reader["good's name"].ToString();
                    var type = reader["type"].ToString();
                    var quantity = reader["quantity"].ToString();
                    var cost = reader["cost"].ToString();
                    var deliveryDate = reader["delivery date"].ToString();

                    //Console.WriteLine($"[good's name - {goodSName}, type - {type}, quantity - {quantity}, cost - {cost}, delivery date - {deliveryDate}]");
                    if (!string.IsNullOrEmpty(quantity) && Int32.Parse(quantity) > maxquant)
                    {

                        maxquant = Int32.Parse(quantity);
                        goodNameMax = goodSName;
                    }
                }

                string sql = String.Format("SELECT [type],[supplier],[good's name] FROM type WHERE [good's name]='{0}';", goodNameMax);

                using var sqlConnection2 = new SqlConnection(connectionString);
                sqlConnection2.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand2 = new SqlCommand(sql, sqlConnection2);
                using var reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    
                    var type = reader2["type"].ToString();
                    var supplier = reader2["supplier"].ToString();
                    var goodSName = reader2["good's name"].ToString();

                    Console.WriteLine("тип товаров с наибольшим количеством товаров");
                    Console.WriteLine($"[type - {type}, supplier - {supplier}, good's name - {goodSName}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ShowTypeWithMinGoods()
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false";

            try
            {
                const string SqlQuerty = "SELECT [good's name],[type],[quantity],[cost],[delivery date] FROM dbo.goods";

                using var sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand = new SqlCommand(SqlQuerty, sqlConnection);
                using var reader = sqlCommand.ExecuteReader();

                int minquant = 0;
                string goodNameMin = "";
                while (reader.Read())
                {
                    var goodSName = reader["good's name"].ToString();
                    var type = reader["type"].ToString();
                    var quantity = reader["quantity"].ToString();
                    var cost = reader["cost"].ToString();
                    var deliveryDate = reader["delivery date"].ToString();

                    //Console.WriteLine($"[good's name - {goodSName}, type - {type}, quantity - {quantity}, cost - {cost}, delivery date - {deliveryDate}]");

                    if (!string.IsNullOrEmpty(quantity) && Int32.Parse(quantity) < minquant)
                    {
                        minquant = Int32.Parse(quantity);
                        goodNameMin = goodSName;
                    }
                }

                string sql = String.Format("SELECT [type],[supplier],[good's name] FROM type WHERE [good's name]='{0}';", goodNameMin);

                using var sqlConnection2 = new SqlConnection(connectionString);
                sqlConnection2.Open();
                Console.WriteLine("Connection is opened");
                using var sqlCommand2 = new SqlCommand(sql, sqlConnection2);
                using var reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                    var type = reader2["type"].ToString();
                    var supplier = reader2["supplier"].ToString();
                    var goodSName = reader2["good's name"].ToString();

                    Console.WriteLine("тип товаров с наименьшим количеством товаров");
                    Console.WriteLine($"type - {type}, supplier - {supplier}, good's name - {goodSName}]");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ShowGoodsFromDate(int days)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=warehouse;User Id=sa;Password=Qwerty123!;Encrypt=false";

            try
            {
              
                string SqlQuerty = String.Format("SELECT [good's name],[type],[quantity],[cost],[delivery date] FROM dbo.goods;");

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

                    if (DateTime.Today.AddDays(-days)<DateTime.Parse(deliveryDate))
                    {
                        Console.WriteLine($"[good's name - {goodSName}, type - {type}, quantity - {quantity}, cost - {cost}, delivery date - {deliveryDate}]");
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //        Добавьте к приложению из практического задания по
        //базе данных «Склад» такую функциональность:
        //■ Показать информацию о поставщике с наибольшим
        //количеством товаров на складе;
        //■ Показать информацию о поставщике с наименьшим
        //количеством товаров на складе;
        //■ Показать информацию о типе товаров с наибольшим
        //количеством товаров на складе;
        //■ Показать информацию о типе товаров с наименьшим
        //количеством товаров на складе;
        //■ Показать товары с поставки, которых прошло заданное количество дней.

        //public static void AddNewColumn(string columnname)
        //{
        //    const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Shop;User Id=sa;Password=Qwerty123!;Encrypt=false;";
        //    try
        //    {
        //        //const string SqlQuerty = "SELECT [id],[price],[quantity] FROM dbo.Inventory";

        //        using var sqlConnection = new SqlConnection(connectionString);
        //        sqlConnection.Open();
        //        Console.WriteLine("Connection is opened");
        //        //string buf1 = id1.ToString();

        //        //ALTER TABLE employees
        //        //ADD last_name VARCHAR(50);

        //        string sql = String.Format($"ALTER TABLE Inventory ADD {columnname} NVARCHAR(20)");

        //        using (SqlCommand cmd = new SqlCommand(sql, sqlConnection))
        //        {
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}





        static void Main(string[] args)
        {
            const string connectionString = "Server=KCELL50787\\MSSQLSERVER2;Database=Shop;User Id=sa;Password=Qwerty123!;Encrypt=false;";
            try
            {
                //connectToDB();
                //AddNewColumn("supplier");
                //AddNewColumn("type");

                //getGoods();
                //getTypes();
                //getSupplier();

                AddNewGood("tylenol", "drug", 1000, 2, "2008.09.23");
                AddNewType("tyre", "yokohama");
                AddNewSupplier("toyo", "X1923knkj", "ToyotaSupplier", "2023.04.31");

                getGoods();
                getTypes();
                getSupplier();

                UpdateGood("tylenol", "material", 99, 777782, "1988.11.11");
                UpdateType("tyre", "Matador","X-drive");
                UpdateSupplier("toyo", "tyre", "", "2023.04.31");

                getGoods();
                getTypes();
                getSupplier();

             

                getGoods();
                getTypes();
                getSupplier();

                ShowSupplierWithMaxGoods();
                ShowSupplierWithMinGoods();

                ShowTypeWithMaxGoods();
                ShowTypeWithMinGoods();

                ShowGoodsFromDate(31);

                //RemoveGood(90);
                //RemoveType("tyre");
                //RemoveSupplier("toyo");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();

        }
    }
}