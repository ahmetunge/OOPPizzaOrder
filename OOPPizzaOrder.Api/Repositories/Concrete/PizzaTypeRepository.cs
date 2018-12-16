using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Repository.Concrete
{
    public class PizzaTypeRepository : IPizzaTypeRepository
    {
        public List<PizzaType> GetAllPizzas()
        {
            PizzaType cheese = new PizzaType
            {
                Id=1,
                Price = 10,
                Name = "Cheese"
            };

            PizzaType pepperoni = new PizzaType
            {
                Id = 2,
                Price =14,
                Name="Pepperoni"
            };


            PizzaType cheesyChicken = new PizzaType
            {
                Id = 3,
                Name = "Cheesy Chicken",
                Price = 17
            };


            PizzaType godfather = new PizzaType
            {
                Id = 4,
                Name = "Godfather",
                Price = 30
            };

            PizzaType italianSausage = new PizzaType
            {
                Id=5,
                Name = "Italian Sausage",
                Price = 17.5m
            };

            List<PizzaType> pizzaTypes = new List<PizzaType>
            {
                cheese,
                pepperoni,
                cheesyChicken,
                godfather,
                italianSausage
            };
            
            return pizzaTypes;
        }

        public string GetPizzaTypeName(int pizzaTypeId)
        {
            string name = GetAllPizzas()
                 .Where(pt => pt.Id == pizzaTypeId)
                 .Select(pt => pt.Name)
                 .SingleOrDefault();

            return name;
        }

        public decimal GetPizzaTypePrice(int pizzaTypeId)
        {
            decimal price = GetAllPizzas()
                 .Where(pt => pt.Id == pizzaTypeId)
                 .Select(pt => pt.Price)
                 .SingleOrDefault();

            return price;
        }
    }
}
