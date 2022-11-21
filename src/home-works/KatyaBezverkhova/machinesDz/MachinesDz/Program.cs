using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace MachinesDz
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("/1/ - Display all info about machines woth selected realise date");
            Console.WriteLine("/2/ - Display basic characteristic of selected machine");
            Console.WriteLine("/3/ - Add additional info");
            Console.WriteLine("/4/ - Add new machine");
            var ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)

            {
                case 1: PrintInfoDate(); break;
                case 2: PrintSelectedMachine(); break;
                case 3: AdditionalInfo();   break;
                case 4: MachineAdd();   break;
            }
        }
        public static void PrintInfoDate()
        {
            var Query = "SELECT * FROM Machines";
            var connectionString = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Machines;Trusted_Connection=true;Encrypt=false";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Enter date please");
                int num = Convert.ToInt32(Console.ReadLine());
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataTableReader dataTableReader = table.CreateDataReader();
                while (dataTableReader.Read())
                {
                    if (dataTableReader["RealiseDate"].ToString() == num.ToString())
                    {
                        Console.WriteLine(dataTableReader["Name"]);
                    }
                   
                       


                }
                  if (dataTableReader["RealiseDate"].ToString() != num.ToString())
                {
                    Console.WriteLine("Wrong data");
                }
                //DataRow dataRow = dataSet.Tables[0].NewRow();
                //dataSet.Tables[0].Rows.Add(dataRow);
                //adapter.Update(dataSet);
            }

        }
        public static void PrintSelectedMachine()
        {


            var Query = "SELECT * FROM Machines";
            var connectionString = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Machines;Trusted_Connection=true;Encrypt=false";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Enter model please");
                string model = Console.ReadLine() ?? throw new InvalidOperationException("Wrong");
                Console.WriteLine("Enter date please");
                int date = Convert.ToInt32(Console.ReadLine());
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(Query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataTableReader dataTableReader = table.CreateDataReader();
                while (dataTableReader.Read())
                {
                    var dtColumn = dataTableReader.GetValue(1);
                    var modelColumn = dataTableReader.GetValue(0).ToString();
                    var engineColumn = dataTableReader.GetValue(3);
                    var brakesCol = dataTableReader.GetValue(4);
                    var typeCol = dataTableReader.GetValue(5); 
                    if(date == Convert.ToInt32(dtColumn) && model == modelColumn)

                    {
                        Console.WriteLine($"Engine - {engineColumn}\nBrake System - {brakesCol}\nType - {typeCol}\n____________________");
                    }
           


                }
                


            }

        }
        public static void AdditionalInfo()
        {
            var Query = "INSERT INTO Machines (AdditionalInfo) VALUES (@AdditionalInfo)";
            var connectionString = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Machines;Trusted_Connection=true;Encrypt=false";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
     
                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    Console.WriteLine("Enter additional info please");
                    var info = Console.ReadLine();
                    command.Parameters.AddWithValue("@AdditionalInfo", info);
                    connection.Open();
                    int rezult = command.ExecuteNonQuery();
                    if (rezult < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                    Console.WriteLine("Additional data added");
                   
                }


            }


        }
        public static void MachineAdd()
        {
            var Query = "INSERT INTO Machines (Name, RealiseDate, Id, Engine, Brakes, Type) VALUES (@Name, @RealiseDate, @Id, @Engine, @Brakes, @Type)";
            var connectionString = "Server=DESKTOP-B19C890\\MSSQLSERVER03;Database=Machines;Trusted_Connection=true;Encrypt=false";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    Console.WriteLine("Enter new model");
                    var model = Console.ReadLine();
                    Console.WriteLine("Enter new RealiseDate");
                    var rel = Console.ReadLine();
                    Console.WriteLine("Enter new id");
                    var id = Console.ReadLine();
                    Console.WriteLine("Enter neew Engine");
                    var engine = Console.ReadLine();
                    Console.WriteLine("Enter new Brakes");
                    var breaks = Console.ReadLine();
                    Console.WriteLine("Enter new Type please");
                    var type = Console.ReadLine();
                    command.Parameters.AddWithValue("@Name", model);
                    command.Parameters.AddWithValue("@RealiseDate", rel);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Engine", engine);
                    command.Parameters.AddWithValue("@Brakes", breaks);
                    command.Parameters.AddWithValue("@Type", type);
                    connection.Open();
                    int rezult = command.ExecuteNonQuery();
                    if(rezult < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                    Console.WriteLine("Machine added");
                }

            }
        }

        


    }
}

