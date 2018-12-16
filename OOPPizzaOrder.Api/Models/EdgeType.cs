using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Models
{
    public class EdgeType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal ExcessCost { get; set; }
    }
}
