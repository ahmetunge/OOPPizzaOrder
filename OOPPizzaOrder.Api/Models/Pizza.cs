
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPPizzaOrder.Api.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }

        public int EdgeTypeId { get; set; }
        public EdgeType EdgeType { get; set; }

        public List<string> PizzaToppings { get; set; }

        public int PizzaTypeId { get; set; }
        public PizzaType PizzaType { get; set; }
    }
}
