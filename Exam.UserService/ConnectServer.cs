using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.UserService
{
    public class ConnectServer
    {
        public string Connect()
        {
            const string ConnectionString = "Server=185.213.156.185;Database=ChatDb; Encrypt=false; User Id=student; Password = 123;";
            return ConnectionString;
        }
    }
}
