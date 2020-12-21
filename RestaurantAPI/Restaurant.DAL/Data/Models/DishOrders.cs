using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DAL.Data.Models
{
    [Table("DishOrders")]
    public class DishOrders
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int PortionNumber { get; set; }

        // nav prop
        public Order Order { get; set; }

        public Dish Dish { get; set; }
    }
}