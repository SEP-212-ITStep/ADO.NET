using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Issakov_Jacob_Final_Exam.Services
{
    public static class ConnectionStringProvider
    {
        public const string connectionString = "Server=185.213.156.185;Database=ChatDb;User Id=student;Password=123;Encrypt=false;Application Name=Jacob";
        public static string ConnectionString { get; } = connectionString;
    }
}
