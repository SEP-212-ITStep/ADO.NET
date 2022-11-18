using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace practical_task_by_Nurik
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
