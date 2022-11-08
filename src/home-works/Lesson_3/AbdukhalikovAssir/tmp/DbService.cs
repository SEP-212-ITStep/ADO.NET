using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace connectedMode
{
    internal class DbService : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=ASIRUSH-PC;Database=stock;" +
            "Trusted_Connection=true;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Blog>().HasData(new List<Blog>()
            {
                new Blog(){
                    AuthorName="Nurik",
                    Content="I'm Mickelangelo.",
                    Id=1,
                    LikeCount=10_000_000,
                    Url="cartoonnetwork.com"
                },
                new Blog(){
                    AuthorName="Katya",
                    Content="I'm Batman.",
                    Id=2,
                    LikeCount=250_000,
                    Url="tiktok.com"
                },
            });
        }
    }
}
