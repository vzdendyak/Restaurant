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

        //Task DeleteIngredientFromDish(int dishId, int ingredientId);
        Task CreateAsync(OrderDto order);

        Task UpdateAsync(OrderDto order);

        Task DeleteAsync(int id);

        Task AddDishOrderToOrder(DishOrdersDto dishOrders);

        Task RemoveDishOrderFromOrder(int dishOrderId);
    }
}