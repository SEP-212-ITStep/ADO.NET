using Exam.UserService.Data;
using Exam.UserService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
//using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Timers;
using Timer = System.Timers.Timer;
using Exam.UserService;
namespace Exam.UserService
{
    internal class Program
    {

        ConnectServer connect = new ConnectServer();
        static void Main(string[] args)
        {
            {
                Menu menu = new Menu();
                menu.StartMenu();
            }
        }

    }
}

