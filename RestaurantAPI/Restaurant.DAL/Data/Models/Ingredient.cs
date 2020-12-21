using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.DAL.Data.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // nav prop

        public virtual ICollection<DishIngredient> DishIngredients { get; set; }
    }
}