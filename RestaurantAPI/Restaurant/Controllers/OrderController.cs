using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //private readonly IMediator _mediator;

        //public OrderController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync([FromBody] Order order)
        //{
        //    var createCommand = new CreateOrder.Command(order);
        //    var res = await _mediator.Send(createCommand);
        //    return Ok(res);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var command = new DeleteOrder.Command(id);
        //    var res = await _mediator.Send(command);
        //    return Ok(res);
        //}
    }
}