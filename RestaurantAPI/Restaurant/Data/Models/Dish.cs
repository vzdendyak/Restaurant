using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data.Models
{
    [Table("Dishes")]
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string PreviewPath { get; set; }

        // nav prop
        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}