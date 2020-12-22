using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.BusinessLogic.Interfaces;
using Restaurant.BLL.Data.DTOs;
using System.IO;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishBl _dishBl;
        private readonly IIngredientBl _ingredientBl;

        public DishController(IDishBl dishBl, IIngredientBl ingredientBl)
        {
            _dishBl = dishBl;
            _ingredientBl = ingredientBl;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var dishes = await _dishBl.GetAllAsync();
            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var dishes = await _dishBl.GetAsync(id);
            return Ok(dishes);
        }

        [HttpPost("{dishId}/ingredients/{ingredientId}")]
        public async Task<IActionResult> AddIngredient(int dishId, int ingredientId)
        {
            await _dishBl.AddIngredientToDish(dishId, ingredientId);
            return Ok();
        }

        [HttpDelete("{dishId}/ingredients/{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient(int dishId, int ingredientId)
        {
            await _dishBl.DeleteIngredientFromDish(dishId, ingredientId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DishDto dish)
        {
            await _dishBl.CreateAsync(dish);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] DishDto dish)
        {
            await _dishBl.UpdateAsync(dish);
            return Ok();
        }

        //[HttpPost("ingredient")]
        //public async Task<IActionResult> AddIngredientAsync([FromBody] DishIngredient dishIngredient)
        //{
        //    var createCommand = new AddIngredientToDish.Command(dishIngredient.DishId, dishIngredient.IngredientId);
        //    var res = await _mediator.Send(createCommand);
        //    return Ok(res);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _dishBl.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}/ingredients")]
        public async Task<IActionResult> GetDishIngredientsAsync(int id)
        {
            var dishes = await _ingredientBl.GetByDish(id);
            return Ok(dishes);
        }

        //[HttpGet("preview/{id}")]
        //public async Task<IActionResult> GetIPreview(int Id)
        //{
        //    var query = new GetDishPreview.Query(Id);
        //    var res = await _mediator.Send(query);

        //    return new FileStreamResult(new FileStream(res, FileMode.Open), "image/jpeg");
        //}

        //[HttpPost("preview"), DisableRequestSizeLimit]
        //public async Task<IActionResult> UploadPreview()
        //{
        //    var file = Request.Form.Files[0];
        //    var dishId = Request.Form["dish"];
        //    var command = new UploadDishPreview.Command(file, int.Parse(dishId.ToString()));
        //    var res = await _mediator.Send(command);
        //    return Ok(res);
        //}
    }
}