using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Services
{
    public static class ConnectionStringProvider
    {
        public const string connectionString = "Server=185.213.156.185;Database=ChatDb;User Id=student;Password=123;Encrypt=false";
        public static string ConnectionString { get; } = connectionString;
    }
}
