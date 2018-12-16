using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Models
{
    public class CartLine
    {
        public PizzaToAddCart Pizza { get; set; }

        public int Quantity{ get; set; }
    }
}
