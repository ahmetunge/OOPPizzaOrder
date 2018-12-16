using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOPPizzaOrder.Api.Helpers;
using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Services.Abstract;

namespace OOPPizzaOrder.Api.Controllers
{
    [Route("api/carttest")]
    [ApiController]
    public class CartTestController : ControllerBase
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;

        public CartTestController(
            ICartSessionService cartSessionService,
            ICartService cartService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
        }
        [HttpGet]
        public ActionResult AddToCart()
        {
            var cart = _cartSessionService.GetCart();

            PizzaToAddCart pizzaToAddCart = new PizzaToAddCart
            {
                Id = 1,
                PizzaName = "",
                NumberOfPizza = 2,
                Price = 25,
                Toppings =new List<string>()
            };

            _cartService.AddTocart(cart, pizzaToAddCart);

            _cartSessionService.SetCart(cart);

            var cart2 = _cartSessionService.GetCart();

            return Ok(pizzaToAddCart);
        }
    }
}