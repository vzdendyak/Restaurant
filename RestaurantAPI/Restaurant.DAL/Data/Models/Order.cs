using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DAL.Data.Models
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public string OwnerName { get; set; }
        public int TotalPrice { get; set; }

        // nav prop
        public virtual ICollection<DishOrders> DishOrders { get; set; }
    }
}