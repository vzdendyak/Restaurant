using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Data;
using Restaurant.DAL.Data.Models;
using Restaurant.DAL.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly AppDbContext _context;

        public IngredientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> Get(int id)
        {
            return await _context.Ingredients.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task Create(Ingredient ingredient)
        {
            await _context.Ingredients.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Ingredient ingredient)
        {
            _context.Entry<Ingredient>(ingredient).State = EntityState.Modified;
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Ingredients.FindAsync(id);
            if (result == null)
                return;

            _context.Ingredients.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetByName(string name)
        {
            return await _context.Ingredients.Where(ing => ing.Name.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetByDish(int dishId)
        {
            var ingredients = await _context.DishIngredients.Where(di => di.DishId == dishId).
                Select(d => d.Ingredient).ToListAsync();
            return ingredients;
        }
    }
}