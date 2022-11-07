using db_first_approach.Data;
using db_first_approach.Models;
using Microsoft.EntityFrameworkCore;

namespace db_first_approach
{
    // Scaffold-DbContext 'Data Source=LAPTOP-EGOR\EGOR_SQL_SERVER;Initial Catalog=ShopDb;Trusted_Connection=true;Encrypt=false' Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Models
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new ShopDbContext();
            using var tran = dbContext.Database.BeginTransaction();
            try
            {

                var products = dbContext.Products.Take(10).ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"[id - {product.Id}, name - {product.Name}, price - {product.Price}]");
                }

                var user = dbContext.Users
                    .Include(d => d.Baskets)
                    .ThenInclude(d => d.BasketProducts)
                            .ThenInclude(p => p.Product)
                    .Where(w => w.Baskets.Any(a => a.BasketProducts.Any()))
                    .First(f => f.Login == "sidorenkoegor");

                foreach (var userBasket in user.Baskets)
                {
                    foreach (var userBasketProduct in userBasket.BasketProducts)
                    {
                        Console.WriteLine($"User {userBasket.User.Name} has - {userBasketProduct.Product.Name}");
                    }
                }

                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                Console.WriteLine(e);
            }
        }
    }
}