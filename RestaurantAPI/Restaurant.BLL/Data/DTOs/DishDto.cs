using System.Collections.Generic;

namespace Restaurant.BLL.Data.DTOs
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int PortionWeight { get; set; }
        public double CookMinutes { get; set; }
        public string Description { get; set; }
        public string PreviewPath { get; set; }
        public virtual ICollection<DishIngredientDto> DishIngredients { get; set; }
    }
}