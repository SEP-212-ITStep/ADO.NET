using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Services
{
    internal class ConnectionString
    {
        public string connectionString = "Server=127.0.0.1;Database=ChatDb;Trusted_Connection=True;Encrypt=false";
        public override string ToString()
        {
            return connectionString;
        }

        public ConnectionString()
        {

        }
    }
}
