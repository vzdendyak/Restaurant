using Restaurant.BLL.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.BLL.BusinessLogic.Interfaces
{
    public interface IDishBl
    {
        Task<IEnumerable<DishDto>> GetAllAsync();

        Task<DishDto> GetAsync(int id);

        Task<IEnumerable<DishDto>> GetByIngredient(int ingredientId);

        Task AddIngredientToDish(int dishId, int ingredientId);

        Task DeleteIngredientFromDish(int dishId, int ingredientId);

        Task CreateAsync(DishDto dish);

        Task UpdateAsync(DishDto dish);

        Task DeleteAsync(int id);
    }
}