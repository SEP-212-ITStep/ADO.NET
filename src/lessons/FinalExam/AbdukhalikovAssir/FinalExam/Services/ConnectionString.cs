using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Services
{
    public static class ConnectionStringProvider
    {
        public const string connectionString = "Server=ASIRUSH-NTBOOK;Database=ChatDb;Trusted_Connection=True;Encrypt=false";
        public static string ConnectionString { get; } = connectionString;
    }
}
