using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vegetables
{
    public static class ConnectionStringProvider
    {
        public const string connectionString = "Server=ASIRUSH-NTBOOK;Database=Vegetables;Trusted_Connection=true;Encrypt=false";
        public static string ConnectionString { get; } = connectionString;
    }
}