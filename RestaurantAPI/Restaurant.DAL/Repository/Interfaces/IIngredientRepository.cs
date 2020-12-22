using Restaurant.DAL.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repository.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetAll();

        Task<Ingredient> Get(int id);

        Task<IEnumerable<Ingredient>> GetByName(string name);

        Task<IEnumerable<Ingredient>> GetByDish(int id);

        Task Create(Ingredient ingredient);

        Task Update(Ingredient ingredient);

        Task Delete(int id);
    }
}