using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Services.Concrete
{
    public class CartService : ICartService
    {
        public void AddTocart(Cart cart, PizzaToAddCart pizza)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(cl => cl.Pizza.Id == pizza.Id);

            //if (cartLine!=null)
            //{
            //    cartLine.Quantity++;
            //    return;
            //}

            cart.CartLines.Add(new CartLine { Pizza = pizza , Quantity=pizza.NumberOfPizza});
        }

        public List<CartLine> GetCartLines(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart,int pizzaId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(cl => cl.Pizza.Id == pizzaId));
        }
    }
}
