using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.BusinessLogic.Interfaces;
using Restaurant.BLL.Data.DTOs;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientBl _ingredientBl;
        private readonly IDishBl _dishBl;

        public IngredientController(IIngredientBl ingredientBl, IDishBl dishBl)
        {
            _ingredientBl = ingredientBl;
            _dishBl = dishBl;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var dishes = await _ingredientBl.GetAllAsync();
            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var dishes = await _ingredientBl.GetAsync(id);
            return Ok(dishes);
        }

        [HttpGet("{id}/dishes")]
        public async Task<IActionResult> GetDishesByIngredient(int id)
        {
            var dishes = await _dishBl.GetByIngredient(id);
            return Ok(dishes);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var dishes = await _ingredientBl.GetByName(name);
            return Ok(dishes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] IngredientDto ingredient)
        {
            await _ingredientBl.CreateAsync(ingredient);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] IngredientDto ingredient)
        {
            await _ingredientBl.UpdateAsync(ingredient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _ingredientBl.DeleteAsync(id);
            return Ok();
        }
    }
}