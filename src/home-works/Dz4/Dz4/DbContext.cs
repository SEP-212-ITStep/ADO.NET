using Dz4;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Dz4
{
    public class GameContext : DbContext
    {
        public DbSet<Model> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server = WIN - J11P7J0O85B; Database = GameDb; Trusted_Connection = true; Encrypt = false; ");

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
                   GameCells = 5000000,
                   GamePublishYear = 2016
                }
            });
        }
    }
}
