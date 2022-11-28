using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.UserService
{
    public class ConnectToSql
    {
        public string Connect()
        {
            const string ConnectionString = "Server=185.213.156.185;Database=ChatDb;User Id = student; Password = 123; Encrypt=false";
            return ConnectionString;
        }
    }
}
