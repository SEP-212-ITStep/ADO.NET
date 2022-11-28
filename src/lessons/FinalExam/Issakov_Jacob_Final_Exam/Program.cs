using Azure.Core;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using Issakov_Jacob_Final_Exam.Data;
using Issakov_Jacob_Final_Exam.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Issakov_Jacob_Final_Exam.Services;

namespace FinalDb
{
    internal class Program
    {
        const string ConnectionString = "Server=DESKTOP-6O1ENUJ;Database=ChatDb;Trusted_Connection=true;Encrypt=false";
        static void Main(string[] args)
        {
            MenuService.externalMenu();
        }



































        //static void Chat(ChatDbContext db, int ToWHoId)
        //{

        //    var newMessage = new PrivateMessage();
        //    newMessage.CreateDate = DateTime.Now;
        //    newMessage.Message = Console.ReadLine();
        //    db.Add(newMessage);
        //    db.SaveChanges();

        //}
        //static void ShowMessage(ChatDbContext db)
        //{
        //    const string SqlQuery1 = "SELECT [from_user_id], [to_user_id], [message] FROM dbo.PrivateMessage";
        //    var message = new PrivateMessage();

        //}
    }
}

