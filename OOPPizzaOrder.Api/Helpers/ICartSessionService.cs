using OOPPizzaOrder.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Helpers
{
    public interface ICartSessionService
    {
        Cart GetCart();

        void SetCart(Cart cart);
    }
}
