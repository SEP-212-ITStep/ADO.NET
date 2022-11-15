using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClassLibrary2
{
    public class GameNewDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=KCELL50787\\MSSQLSERVER2;Database=GameDBForGit;User Id=sa;Password=Qwerty123!;Encrypt=false;");

        }
    }
}