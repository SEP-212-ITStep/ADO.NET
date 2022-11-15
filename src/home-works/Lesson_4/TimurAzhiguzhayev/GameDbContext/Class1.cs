using Game;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GameDbContext
{
    public class GameNewDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=KCELL50787\\MSSQLSERVER2;Database=GameDBNew;User Id=sa;Password=Qwerty123!;Encrypt=false;");

        }
        //public DbSet<Game> GamesExtended { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer("Server=KCELL50787\\MSSQLSERVER2;Database=GameDBNewExtended;User Id=sa;Password=Qwerty123!;Encrypt=false;");

        //}
    }
}