using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOPPizzaOrder.Api.Dtos;
using OOPPizzaOrder.Api.Repository.Abstract;

namespace OOPPizzaOrder.Api.Controllers
{
    [Route("api/pizzaorder")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaTypeRepository _pizzaTypeRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IToppingRepository _toppingRepository;

        public PizzaController (IPizzaTypeRepository pizzaTypeRepository,ISizeRepository sizeRepository,IToppingRepository toppingRepository)
        {
            _pizzaTypeRepository = pizzaTypeRepository;
            _sizeRepository = sizeRepository;
            _toppingRepository = toppingRepository;
        }

        [HttpGet("pizzatypes")]
        public ActionResult GetPizzaTypes()
        {
            var pizzaTypes = _pizzaTypeRepository.GetAllPizzas();

            return Ok(pizzaTypes);
        }

        
        [HttpGet("sizes")]
         public IActionResult GetSizes()
        {
            var sizes = _sizeRepository.GetAllPizzaSizes();

            return Ok(sizes);
        }

        [HttpGet("toppings")]
        public ActionResult GetToppings()
        {
            var toppings = _toppingRepository.GetAllToppings();

            return Ok(toppings);
        }

     



    }
}