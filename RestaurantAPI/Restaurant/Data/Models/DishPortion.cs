using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data.Models
{
    [Table("DishPortions")]
    public class DishPortion
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int PortionNumber { get; set; }

        // nav prop
        public Order Order { get; set; }
    }
}