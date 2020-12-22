using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomerceProject.Entities
{
    public class Cart
    {
        public Product product { get; set; }

        public int quantity { get; set; }
    }
}
