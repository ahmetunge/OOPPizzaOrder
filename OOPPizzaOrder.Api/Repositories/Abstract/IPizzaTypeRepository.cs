using OOPPizzaOrder.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Repository.Abstract
{
    public interface IPizzaTypeRepository
    {
        List<PizzaType> GetAllPizzas();

        decimal GetPizzaTypePrice(int pizzaTypeId);

        string GetPizzaTypeName(int pizzaTypeId);
    }
}
