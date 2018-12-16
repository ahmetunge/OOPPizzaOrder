using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOPPizzaOrder.Api.Dtos;
using OOPPizzaOrder.Api.Helpers;
using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Repository.Abstract;
using OOPPizzaOrder.Api.Services.Abstract;

namespace OOPPizzaOrder.Api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private  ICartSessionService _cartSessionService;
        private  ICartService _cartService;
        private  IPizzaPriceCalculater _pizzaPriceCalculater;
        private  IPizzaTypeRepository _pizzaTypeRepository;
        private ISizeRepository _sizeRepository;

        public CartController(ICartSessionService cartSessionService,
            ICartService cartService,
            IPizzaPriceCalculater pizzaPriceCalculater,
            IPizzaTypeRepository pizzaTypeRepository,
            ISizeRepository sizeRepository
            )
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
           _pizzaPriceCalculater = pizzaPriceCalculater;
           _pizzaTypeRepository = pizzaTypeRepository;
            _sizeRepository = sizeRepository;
        }

        [HttpPost("addPizzaToCart")]
        public ActionResult AddToCart([FromBody]PizzaToAddCartDto  pizzaDto)
        {
            var cart = _cartSessionService.GetCart();
            

            decimal pizzaTypePrice = _pizzaTypeRepository.GetPizzaTypePrice(pizzaDto.PizzaTypeId);
            decimal sizeMultiplier = _sizeRepository.GetSizeMultiplier(pizzaDto.SizeId);
            decimal price = _pizzaPriceCalculater.Calculate(sizeMultiplier,pizzaTypePrice,pizzaDto.EdgeTypeId,pizzaDto.NumberOfPizza);
            string pizzaName = _pizzaTypeRepository.GetPizzaTypeName(pizzaDto.PizzaTypeId);


            PizzaToAddCart pizzaToAddCart = new PizzaToAddCart
            {
                Id = pizzaDto.PizzaTypeId,
                PizzaName = pizzaName,
                NumberOfPizza = pizzaDto.NumberOfPizza,
                Price = price,
                Toppings = pizzaDto.Toppings
            };
            
            _cartService.AddTocart(cart,pizzaToAddCart);

            _cartSessionService.SetCart(cart);

            var cartFromSession = _cartSessionService.GetCart();
            int totalPizzas = cartFromSession.TotalQuantity;

            return Ok(totalPizzas);
        }

        [HttpGet("pizzas")]
        public ActionResult GetPizzasFromCart()
        {
            var cart= _cartSessionService.GetCart();

            return Ok(cart);
        }

        [HttpGet("pizzas/totalQuantity")]
        public ActionResult GetTotalQuantity()
        {
            var cart = _cartSessionService.GetCart();

            int totalQuantity = cart.TotalQuantity;

            return Ok(totalQuantity);
        }

        [HttpDelete("pizzas/{pizzaId}")]
        public ActionResult DeletePizzaFromCart(int pizzaId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, pizzaId);

            _cartSessionService.SetCart(cart);
            var cartToReturn = _cartSessionService.GetCart();

            return Ok(cartToReturn);
        }
    }
}