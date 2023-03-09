using DDDWebapi.Application.Services.Orders;
using DDDWebapi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDWebapi.Api.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrderAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> AddOrder(Order order)
        {
            var addedOrder = await _orderService.AddOrderAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = addedOrder.Id }, addedOrder);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Order>> UpdateOrder(Guid id, Order order)
        {
            if ((id != order.Id))
            {
                return BadRequest();
            }

            var updatedOrder = await _orderService.UpdateOrderAsync(order);

            if (updatedOrder == null)
            {
                return NotFound();
            }

            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
