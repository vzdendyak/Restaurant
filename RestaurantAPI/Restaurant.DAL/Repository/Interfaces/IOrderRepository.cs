using Restaurant.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();

        Task<Order> Get(int id);

        Task Create(Order order);

        Task Update(Order order);

        Task Delete(int id);

        Task<DishOrders> GetDishOrder(int dishOrderId);

        Task AddDishToOrderAsync(DishOrders dishOrders);

        Task RemoveDishOrderFromOrder(int dishOrderId);

        Task<IEnumerable<DishOrders>> GetAllDishesForOrder(int orderId);

        Task<IEnumerable<Order>> GetByTableNumber(int tableNumber);
    }
}