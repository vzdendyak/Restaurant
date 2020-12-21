using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Models;
using Restaurant.Features.Commands.DishCRUD;
using Restaurant.Features.Commands.DishIngredientCRUD;
using Restaurant.Features.Queries.DishCRUD;
using System.IO;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DishController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var getQuery = new GetAllDishes.Query();
            var res = await _mediator.Send(getQuery);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Dish dish)
        {
            var createCommand = new CreateDish.Command(dish);
            var res = await _mediator.Send(createCommand);
            return Ok(res);
        }

        [HttpPost("ingredient")]
        public async Task<IActionResult> AddIngredientAsync([FromBody] DishIngredient dishIngredient)
        {
            var createCommand = new AddIngredientToDish.Command(dishIngredient.DishId, dishIngredient.IngredientId);
            var res = await _mediator.Send(createCommand);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteDish.Command(id);
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet("preview/{id}")]
        public async Task<IActionResult> GetIPreview(int Id)
        {
            var query = new GetDishPreview.Query(Id);
            var res = await _mediator.Send(query);

            return new FileStreamResult(new FileStream(res, FileMode.Open), "image/jpeg");
        }

        [HttpPost("preview"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadPreview()
        {
            var file = Request.Form.Files[0];
            var dishId = Request.Form["dish"];
            var command = new UploadDishPreview.Command(file, int.Parse(dishId.ToString()));
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}