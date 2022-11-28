using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz2
{
    public class StockContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=WIN-J11P7J0O85B;Database=AdventureWorks2019;Trusted_Connection=true;Encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Stock>().HasData(new List<Stock>()
            {
                new Stock{ Id = 1,
                Product = "Samsung",
                Type = "Tech",
                Provider = "Name1"},

                new Stock{ Id = 2,
                Product = "Potato",
                Type= "Vegetable",
                Provider = "Name2"}
            });
        }
    }
    public class Stock
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
    }
}
