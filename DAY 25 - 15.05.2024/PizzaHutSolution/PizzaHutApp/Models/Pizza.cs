using System.ComponentModel.DataAnnotations;

namespace PizzaHutApp.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public int DiameterInches { get; set; }
        public bool IsVeg{ get; set; }
        public int Price { get; set; } = 0;
        public bool IsAvailable { get; set; } = true;
    }
}
