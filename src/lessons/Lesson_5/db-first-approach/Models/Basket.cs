using System;
using System.Collections.Generic;

namespace db_first_approach.Models
{
    public partial class Basket
    {
        public Basket()
        {
            BasketProducts = new HashSet<BasketProduct>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
