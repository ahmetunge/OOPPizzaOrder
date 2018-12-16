using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Services.Concrete
{
    public class PizzaPriceCalculater : IPizzaPriceCalculater
    {
        public decimal Calculate(decimal size, decimal pizzaType, int edgeTypeId, int number)
        {
            decimal excessCost = 0;
            if (edgeTypeId==1)
            {
                excessCost = 2;
            }

            decimal price = (pizzaType * size + excessCost)*number;

            return price;
        }
    }
}
