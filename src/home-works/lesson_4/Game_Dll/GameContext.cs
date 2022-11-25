using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Game_Dll
{
    public class GameContext : DbContext
    {
        public DbSet<Model> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-6O1ENUJ;Database=GamesInfo;Trusted_Connection=true;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Random rnd = new Random();
            builder.Entity<Model>().HasData(new List<Model>()
            {
                new Model()
                {
                   Id = 1,
                   Game_Name = "Uncharted 4: A Thief’s End",
                   Developer_Name = "Naughty Dog",
                   Game_Style = "action-adventure",
                   Game_Mode = "SingleUserMode",
                   Publishing_Year = 2016,
                   Sales = 15000000
                }
            });
        }
    }
}
