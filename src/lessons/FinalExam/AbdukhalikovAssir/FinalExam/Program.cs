using FinalExam.Data;
using FinalExam.Models;
using FinalExam.Services;
using Microsoft.Data.SqlClient;

namespace FinalExam
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Menu start = new();
            start.ChatMenu();
        }
    }
}