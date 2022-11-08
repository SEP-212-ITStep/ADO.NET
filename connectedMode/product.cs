using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connectedMode
{
    internal class product
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public provider Provider { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
        public DateTime GetDate { get; set; }


    }
}
