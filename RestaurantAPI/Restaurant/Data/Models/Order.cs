using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string OwnerName { get; set; }

        // nav prop
        public virtual ICollection<DishPortion> DishPortions { get; set; }
    }
}