using Db_First_Approach.Data;
using Microsoft.EntityFrameworkCore;

namespace Db_First_Approach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new ShopDbContext();
            try
            {
                //Console.Write("Input Login:");
                var login = "sidorenkoegor";
                //Console.ReadLine() ?? throw new InvalidOperationException("Логин введи!");

                var user = dbContext.Users
                    .Include(d => d.Baskets)
                        .ThenInclude(d => d.BasketProducts)
                            .ThenInclude(p => p.Product)
                    .Where(w => w.Baskets.Any(a => a.BasketProducts.Any()))
                    .First(f => f.Login == login);

                Console.WriteLine($"User with login - {user.Login} has following baskets: ");

                foreach (var userBasket in user.Baskets)
                {
                    foreach (var userBasketProduct in userBasket.BasketProducts)
                    {
                        Console.WriteLine($"User {userBasket.User.Name} has - {userBasketProduct.Product.Name}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}