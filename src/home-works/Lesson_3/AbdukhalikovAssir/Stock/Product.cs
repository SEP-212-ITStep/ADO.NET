using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Provider Provider { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
        public DateTime GetDate { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool ShowProductData()
        {
            try
            {

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: ", ex);
                return false;
            }
        }
    }
}
