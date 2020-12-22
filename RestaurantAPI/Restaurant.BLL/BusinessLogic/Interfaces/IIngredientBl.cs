using Restaurant.BLL.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.BLL.BusinessLogic.Interfaces
{
    public interface IIngredientBl
    {
        Task<IEnumerable<IngredientDto>> GetAllAsync();

        Task<IngredientDto> GetAsync(int id);

        Task CreateAsync(IngredientDto dish);

        Task UpdateAsync(IngredientDto dish);

        Task DeleteAsync(int id);

        Task<IEnumerable<IngredientDto>> GetByDish(int id);

        Task<IEnumerable<IngredientDto>> GetByName(string name);
    }
}