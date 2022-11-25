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
            label1:
            Menu start = new();
            start.ChatMenu();
        }
    }
}