using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL.BusinessLogic.Interfaces;
using Restaurant.BLL.Data.DTOs;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBl _orderBl;

        public OrderController(IOrderBl orderBl)
        {
            _orderBl = orderBl;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _orderBl.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var order = await _orderBl.GetAsync(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrderDto order)
        {
            await _orderBl.CreateAsync(order);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] OrderDto order)
        {
            await _orderBl.UpdateAsync(order);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _orderBl.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("dishOrders")]
        public async Task<IActionResult> AddDishToOrderAsync([FromBody] DishOrdersDto dishOrders)
        {
            await _orderBl.AddDishToOrderAsync(dishOrders);
            return Ok();
        }

        [HttpDelete("dishOrders/{dishOrdersId}")]
        public async Task<IActionResult> RemoveDishOrderFromOrder(int dishOrdersId)
        {
            await _orderBl.RemoveDishOrderFromOrder(dishOrdersId);
            return Ok();
        }

        [HttpGet("dishOrders/{ordersId}")]
        public async Task<IActionResult> GetAllDishesForOrder(int ordersId)
        {
            var dishOrders = await _orderBl.GetAllDishesForOrder(ordersId);
            return Ok(dishOrders);
        }

        [HttpGet("table/{number}")]
        public async Task<IActionResult> GetByTableNumber(int number)
        {
            var orders = await _orderBl.GetByTableNumber(number);
            return Ok(orders);
        }
    }
}