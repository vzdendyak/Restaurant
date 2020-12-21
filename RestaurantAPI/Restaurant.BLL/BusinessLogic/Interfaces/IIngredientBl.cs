using Restaurant.BLL.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.BLL.BusinessLogic.Interfaces
{
    public interface IIngredientBl
    {
        Task<IEnumerable<IngredientDto>> GetByName(string name);
    }
}