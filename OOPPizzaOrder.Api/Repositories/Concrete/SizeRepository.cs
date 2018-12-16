using OOPPizzaOrder.Api.Models;
using OOPPizzaOrder.Api.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Repository.Concrete
{
    public class SizeRepository : ISizeRepository
    {
        public List<Size> GetAllPizzaSizes()
        {
           

            Size small = new Size
            {
                  Id=1,
                  Name="Small",
                  Multiplier=1
            };

            Size medium = new Size
            {
                Id = 2,
                Name ="Medium",
                Multiplier=1.25m
            };

            Size big = new Size
            {
                Id = 3,
                Name ="Big",
                Multiplier=1.75m
            };

            Size maxi = new Size
            {
                Id = 4,
                Name ="Maxi",
                Multiplier=2
            };

            List<Size> sizes = new List<Size>
            {
                small,
                medium,
                big,
                maxi
            };

            return sizes;
        }

        public decimal GetSizeMultiplier(int sizeId)
        {
            decimal multiplier = GetAllPizzaSizes()
               .Where(pt => pt.Id == sizeId)
               .Select(pt => pt.Multiplier)
               .SingleOrDefault();

            return multiplier;
        }
    }
}
