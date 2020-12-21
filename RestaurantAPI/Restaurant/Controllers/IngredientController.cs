using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Models;
using Restaurant.Features.Commands.IngredientCRUD;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Ingredient ingredient)
        {
            var createCommand = new CreateIngredient.Command(ingredient);
            var res = await _mediator.Send(createCommand);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var command = new DeleteIngredient.Command(id);
            var res = await _mediator.Send(command);
            return Ok(res);
        }
    }
}