using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Models
{
    public class Cart
    {

        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine>  CartLines{ get; set; }

        public decimal TotalPrice
        {
            get
            {
                return CartLines.Sum(c => c.Pizza.Price * c.Quantity);
            }
        }

        public int TotalQuantity
        {
            get
            {
                return CartLines.Sum(c=>c.Quantity);
            }
        }

    }
}
