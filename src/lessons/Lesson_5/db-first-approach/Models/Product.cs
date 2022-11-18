using System;
using System.Collections.Generic;

namespace db_first_approach.Models
{
    public partial class Product
    {
        public Product()
        {
            BasketProducts = new HashSet<BasketProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Count { get; set; }

        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
