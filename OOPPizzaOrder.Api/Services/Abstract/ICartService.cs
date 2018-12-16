using OOPPizzaOrder.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Services.Abstract
{
   public interface ICartService
    {
        void AddTocart(Cart cart, PizzaToAddCart pizza);

        void RemoveFromCart(Cart cart,int pizzaId);

        List<CartLine> GetCartLines(Cart cart);
    }
}
