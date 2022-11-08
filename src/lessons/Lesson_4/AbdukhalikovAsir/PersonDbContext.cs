using Microsoft.EntityFrameworkCore;

namespace lesson_4{
    public class PersonDbContext : DbContext{
        public DbSet<Person> People{set;get;}
        protected override void OnConfiguring(DbContextOptionBuilder builder){
            builder.UseSqlServer("Server=127.0.0.1;Database=Production;User Id=CA;password=as23@bull;Encrypt=false");
        }
    }
}