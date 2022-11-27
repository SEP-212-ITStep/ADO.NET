using .Lesson5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Lesson5;
using Microsoft.EntityFrameworkCore;

namespace Lesson5
{
    public class PersonDbContext : DbContext
    {
        public DbSet<PersonAddress> PeopleAddresses { get; set; }
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=LAPTOP-EGOR\\EGOR_SQL_SERVER;Database=PeopleDb;" +
                                 "Trusted_Connection=true;Encrypt=false");

        }
    }
}