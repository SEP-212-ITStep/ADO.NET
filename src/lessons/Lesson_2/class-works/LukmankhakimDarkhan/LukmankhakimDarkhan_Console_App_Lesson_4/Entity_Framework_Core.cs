using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukmankhakimDarkhan_Console_App_Lesson_4
{
    internal class Entity_Framework_Core:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=223-9; Database=BlockOb;Trusted_Connection=true;Encrypt=false;");
        }
    
    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Blog>().HasData(new List<Blog>()
            {
                new Blog()
                {
                    AuthorName="Nurik",
                    Content="I'm Mickelangelo.",
                    BlogId=1,LikeCount=10_000_000,
                    Url="cartoonnetwork.com"
                },


                new Blog()
                {
                    AuthorName="Katiya",
                    Content="I'm Batman.",
                    BlogId=2,LikeCount=10_000_000,
                    Url="tiktok.com"
                }
            });
        }
    }
}
