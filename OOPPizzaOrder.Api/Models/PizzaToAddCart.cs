using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Models
{
    public class PizzaToAddCart
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public List<string> Toppings { get; set; }

        public decimal Price { get; set; }

        public int NumberOfPizza { get; set; }
    }
}
