using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Data.DTOs
{
    public class DishIngredientDto
    {
        public int DishId { get; set; }
        public int IngredientId { get; set; }

        // nav prop
        public DishDto Dish { get; set; }

        public IngredientDto Ingredient { get; set; }
    }
}