using FinalExam.Data;
using FinalExam.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace FinalExam.Services
{
    internal class UserServices
    {
        static bool Registration(ChatDbContext db)
        {
            try
            {
                User newUser = new User();
                Console.Write("Enter login: ");
                newUser.Login = Console.ReadLine();
                Console.Write("Enter password: ");
                newUser.Password = HashPass(newUser.Password = Console.ReadLine());
                db.Users.Add(newUser);
                db.SaveChanges();
                Console.WriteLine("Added!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: registration error ", ex.Message);
                return false;
            } 
        }

        static string HashPass(string pass)
        {
            try
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(
                    Encoding.UTF8.GetBytes(pass)
                );
                return Convert.ToBase64String(hash);
            }
            catch (Exception ex) { Console.WriteLine("Error: hashing {0}", ex.Message); return null; }
            
        }        
    }
}
