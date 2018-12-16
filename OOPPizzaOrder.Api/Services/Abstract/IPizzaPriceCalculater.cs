using OOPPizzaOrder.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Services.Abstract
{
   public interface IPizzaPriceCalculater
    {
        decimal Calculate(decimal size, decimal pizzaType, int edgeTypeId, int number);
    }
}
