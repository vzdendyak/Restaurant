using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DAL.Data.Models
{
    [Table("Dishes")]
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int PortionWeight { get; set; }
        public double CookMinutes { get; set; }
        public string Description { get; set; }
        public string PreviewPath { get; set; }

        // nav prop
        public virtual ICollection<DishIngredient> DishIngredients { get; set; }

        public virtual ICollection<DishOrders> DishOrders { get; set; }
    }
}