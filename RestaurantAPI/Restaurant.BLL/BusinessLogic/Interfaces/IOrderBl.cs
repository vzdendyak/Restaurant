using Restaurant.BLL.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.BusinessLogic.Interfaces
{
    public interface IOrderBl
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();

        Task<OrderDto> GetAsync(int id);

        //Task<IEnumerable<OrderDto>> GetByIngredient(int ingredientId);

        //Task AddIngredientToDish(int dishId, int ingredientId);

        //Task DeleteIngredientFromDish(int dishId, int ingredientId);
        Task CreateAsync(OrderDto order);

        Task UpdateAsync(OrderDto order);

        Task DeleteAsync(int id);
    }
}