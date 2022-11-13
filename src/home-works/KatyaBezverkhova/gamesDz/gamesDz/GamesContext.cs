using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace gamesDz
{
    public class GamesContext : DbContext
    {
        public string Path = "Server = DESKTOP-B19C890\\MSSQLSERVER03; Database = GamesDatabase; " + "Trusted_Connection = true; Encrypt = false";
        public DbSet<Games> games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Path);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Games>().HasData(new List<Games>()
            {
                new Games() {Name = "Overwatch", Creator = "Blizzard", RealiseDate = 2016, Id = 1, PlayStyle = "Shooter", GameMode = "Multiplayer", CopiesSold = 20000},
                new Games() {Name = "WoW", Creator = "Blizzard", RealiseDate = 2002, Id = 2, PlayStyle = "MM", GameMode = "Multiplayer", CopiesSold = 25000},
                new Games() {Name = "For Honor", Creator = "Ubisoft", RealiseDate = 2017, Id = 3, PlayStyle = "CCC", GameMode = "Multiplayer", CopiesSold = 10000 }
            });
        }
    }
}
