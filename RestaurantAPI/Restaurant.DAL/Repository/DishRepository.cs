using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Data;
using Restaurant.DAL.Data.Models;
using Restaurant.DAL.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly AppDbContext _context;

        public DishRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAll()
        {
            return await _context.Dishes.ToListAsync();
        }

        public async Task<Dish> Get(int id)
        {
            return await _context.Dishes.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Dish dish)
        {
            await _context.Dishes.AddAsync(dish);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Dish dish)
        {
            _context.Entry<Dish>(dish).State = EntityState.Modified;
            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Dishes.FindAsync(id);
            if (result == null)
                return;

            _context.Dishes.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task AddIngredientToDish(int dishId, int ingredientId)
        {
            var relation = new DishIngredient { DishId = dishId, IngredientId = ingredientId };
            await _context.DishIngredients.AddAsync(relation);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveIngredientFromDish(int dishId, int ingredientId)
        {
            var relation = _context.DishIngredients.Where(di => di.DishId == dishId && di.IngredientId == ingredientId).ToList();
            _context.DishIngredients.RemoveRange(relation);
            await _context.SaveChangesAsync();
        }
    }
}