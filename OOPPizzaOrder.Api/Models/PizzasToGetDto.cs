using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Models
{
    public class PizzasToGetDto
    {
        public int Id { get; set; }

        public string PizzaName { get; set; }

        public List<string> MyProperty { get; set; }

        public int  Price { get; set; }

        public int  NumberOfPizza { get; set; }
    }
}
