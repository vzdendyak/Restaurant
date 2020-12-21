using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DAL.Data.Models
{
    [Table("DishIngredients")]
    public class DishIngredient
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }

        // nav prop
        public Dish Dish { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}