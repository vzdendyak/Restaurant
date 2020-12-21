using Restaurant.DAL.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repository.Interfaces
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetByName(string name);
    }
}