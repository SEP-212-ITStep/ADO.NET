using HWGame.dll;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HWGame.dll
{
    public class GameContext : DbContext
    {
        public DbSet<Model> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-D9GJV4L\\MSSQLSERVER01;Database=GameDb;Trusted_Connection=true;Encrypt=false");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Model>().HasData(new List<Model>()
            {
                new Model()
                {
                   Id = 1,
                   GameName = "Dead by Daylight",
                   GameDeveloper = "Behaviour Interactive",
                   GameStyle = "Horror",
                   GameMode = "Surviver",
                   GameCells = 3000000,
                   GamePublishYear = 2015
                }
            });
        }
    }
}
