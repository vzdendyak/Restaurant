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

        Task CreateAsync(OrderDto order);

        Task UpdateAsync(OrderDto order);

        Task DeleteAsync(int id);

        Task AddDishToOrderAsync(DishOrdersDto dishOrders);

        Task RemoveDishOrderFromOrder(int dishOrderId);

        Task<IEnumerable<DishOrdersDto>> GetAllDishesForOrder(int orderId);
    }
}