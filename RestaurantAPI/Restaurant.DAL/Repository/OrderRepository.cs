using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Data;
using Restaurant.DAL.Data.Models;
using Restaurant.DAL.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            _context.Entry<Order>(order).State = EntityState.Modified;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Orders.FindAsync(id);
            if (result == null)
                return;

            _context.Orders.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<DishOrders> GetDishOrder(int dishOrderId)
        {
            return await _context.DishPortions.Where(d => d.Id == dishOrderId).FirstOrDefaultAsync();
        }

        public async Task AddDishToOrderAsync(DishOrders dishOrders)
        {
            await _context.DishPortions.AddAsync(dishOrders);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveDishOrderFromOrder(int dishOrderId)
        {
            var result = await _context.DishPortions.FindAsync(dishOrderId);
            if (result == null)
                return;

            _context.DishPortions.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DishOrders>> GetAllDishesForOrder(int orderId)
        {
            return await _context.DishPortions.Where(dp => dp.OrderId == orderId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByTableNumber(int tableNumber)
        {
            return await _context.Orders.Where(ing => ing.TableNumber == tableNumber).ToListAsync();
        }
    }
}