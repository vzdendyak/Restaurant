using Restaurant.DAL.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repository.Interfaces
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAll();

        Task<Dish> Get(int id);

        Task AddIngredientToDish(int dishId, int ingredientId);

        Task RemoveIngredientFromDish(int dishId, int ingredientId);

        Task<IEnumerable<Dish>> GetByIngredient(int ingredientId);

        Task Create(Dish dish);

        Task Update(Dish dish);

        Task Delete(int id);
    }
}