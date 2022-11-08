using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connectedMode
{
    internal class DbService
    {
        public bool ConnectDb(string ConnString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();
                }
                Console.WriteLine("Connection successfull");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Connection refused! Error:", ex);
                return false;
            }
        }
    }
}
