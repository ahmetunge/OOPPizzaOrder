using OOPPizzaOrder.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Repository.Concrete
{
    public class ToppingRepository : IToppingRepository
    {
        public List<string> GetAllToppings()
        {
            List<string> toppings = new List<string>
            {
               "Succulent chicken",
               "Rasher bacon",
               "Red onion",
               "Mozzarella",
               "Tomato",
               "Sauce",
               "Cheese",
               "Pepperoni",
               "Jambon",
               "New York Pepperoni",
               "Mushroom",
               "Tunny fish",
               "Oil",
               "Green capsicum",
               "Hot dog"
            };

            return toppings;
        }
    }
}
